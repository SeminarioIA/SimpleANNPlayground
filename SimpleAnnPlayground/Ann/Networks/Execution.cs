// <copyright file="Execution.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Graphical;

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// Represents the execution phases of a neural network.
    /// </summary>
    public enum ExecPhase
    {
        /// <summary>
        /// The network selects a data entry.
        /// </summary>
        FetchData,

        /// <summary>
        /// The network loads the selected data entry.
        /// </summary>
        GetData,

        /// <summary>
        /// The neuron adds the previous neurons values multiplied by the connections weight.
        /// </summary>
        ConnectionsWeights,

        /// <summary>
        /// The neuron process its value with the activation function.
        /// </summary>
        Activations,

        /// <summary>
        /// Backpropagation phase.
        /// </summary>
        BackPropagation,
    }

    /// <summary>
    /// Handles the network model execution.
    /// </summary>
    internal class Execution
    {
        private readonly IEnumerator<DataRegister> _register;
        private readonly IEnumerator<Layer> _layer;
        private IEnumerator<Node> _node;
        private IEnumerator<Link> _link;

        /// <summary>
        /// Initializes a new instance of the <see cref="Execution"/> class.
        /// </summary>
        /// <param name="network">The network to execute.</param>
        public Execution(Network network)
        {
            Network = network;
            Data = Network.Workspace.DataTable;
            Phase = ExecPhase.FetchData;
            if (!Network.Workspace.ReadOnly) throw new InvalidOperationException("The workspace should be readonly.");
            if (!Network.BuildResult || Network.Graph == null) throw new InvalidOperationException("The network should built without errors.");

            _register = Data.Registers.GetEnumerator();
            if (!_register.MoveNext())
            {
                throw new InvalidOperationException("Input data does not contains registers.");
            }

            foreach (var link in Network.Graph.Links)
            {
                link.Connection.Weight = 1;
            }

            _layer = Network.Graph.Layers.GetEnumerator();
            if (_layer.MoveNext())
            {
                _node = _layer.Current.Nodes.GetEnumerator();
                if (_node.MoveNext())
                {
                    _link = _node.Current.Next.GetEnumerator();
                    if (!_link.MoveNext())
                    {
                        throw new InvalidOperationException("The node does not have links.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("The input layer does not have nodes.");
                }
            }
            else
            {
                throw new InvalidOperationException("The network does not have layers.");
            }
        }

        /// <summary>
        /// Gets the network to execute.
        /// </summary>
        public Network Network { get; }

        /// <summary>
        /// Gets the data to process in the network.
        /// </summary>
        public DataTable Data { get; }

        /// <summary>
        /// Gets the current execution phase.
        /// </summary>
        public ExecPhase Phase { get; private set; }

        /// <summary>
        /// Prepares the network for execution.
        /// </summary>
        public void Start()
        {
            if (Network.Graph is null) throw new InvalidOperationException("Invalid Graph value.");
            foreach (var node in Network.Graph.Nodes)
            {
                if (node.Neuron is not Input) node.Neuron.Bias = 0;
            }

            Phase = ExecPhase.GetData;
            Network.Workspace.SelectRegister(_register.Current);
            foreach (var node in _layer.Current.Nodes)
            {
                node.Neuron.SetStateFlag(Component.State.ExecutionStep);
            }
        }

        /// <summary>
        /// Restores the network state.
        /// </summary>
        public void Stop()
        {
            _link.Current.Connection.Executing = false;
            _node.Current.Neuron.ClearStateFlag(Component.State.ExecutionStep);
        }

        /// <summary>
        /// Draws the execution elements.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        public void Paint(Graphics graphics)
        {
            if (_link.Current != null)
            {
                _link.Current.Connection.Paint(graphics);
            }
        }

        /// <summary>
        /// Executes one connection step in the network.
        /// </summary>
        public void StepIntoCx()
        {
            switch (Phase)
            {
                case ExecPhase.FetchData:
                    _node.Current.Neuron.ClearStateFlag(Component.State.ExecutionStep);
                    _layer.Reset();
                    if (_layer.MoveNext()) _node = _layer.Current.Nodes.GetEnumerator();
                    if (_node.MoveNext()) _link = _node.Current.Next.GetEnumerator();
                    if (!_link.MoveNext()) throw new InvalidOperationException("The node does not have links.");
                    if (!_register.MoveNext()) throw new NotImplementedException("Pending to implement what to do at the end of the table.");
                    Network.Workspace.SelectRegister(_register.Current);
                    foreach (var node in _layer.Current.Nodes)
                    {
                        node.Neuron.SetStateFlag(Component.State.ExecutionStep);
                        node.Neuron.Z = null;
                        node.Neuron.A = null;
                    }

                    Phase = ExecPhase.GetData;
                    break;
                case ExecPhase.GetData:
                    foreach (var node in _layer.Current.Nodes)
                    {
                        if (node.Neuron is Input input)
                        {
                            input.ClearStateFlag(Component.State.ExecutionStep);
                            /* input.Z = Data.GetValue(input.DataLabel ?? throw new InvalidOperationException()); */
                            input.A = Data.GetValue(input.DataLabel ?? throw new InvalidOperationException());
                        }
                    }

                    // Next phase
                    Phase = ExecPhase.ConnectionsWeights;
                    if (_layer.Current.Next is not null)
                    {
                        foreach (var node in _layer.Current.Next.Nodes)
                        {
                            node.Neuron.Z = 0;
                        }
                    }

                    _node.Current.Neuron.SetStateFlag(Component.State.ExecutionStep);
                    _link.Current.Connection.Executing = true;
                    break;
                case ExecPhase.ConnectionsWeights:
                    Phase = StepCxWeights();
                    break;
                case ExecPhase.Activations:
                    Phase = StepCxActivations();
                    break;
                case ExecPhase.BackPropagation:
                    break;
                default:
                    break;
            }

            Network.Workspace.Refresh();
        }

        private ExecPhase StepCxWeights()
        {
            _link.Current.Next.Neuron.AddValue(_node.Current.Neuron.A, _link.Current.Connection.Weight);
            _link.Current.Connection.Executing = false;

            if (_link.MoveNext())
            {
                _link.Current.Connection.Executing = true;
            }
            else
            {
                _node.Current.Neuron.ClearStateFlag(Component.State.ExecutionStep);
                if (!StepIntoNd())
                {
                    if (_layer.MoveNext())
                    {
                        _node = _layer.Current.Nodes.GetEnumerator();
                        if (_node.MoveNext())
                        {
                            _node.Current.Neuron.SetStateFlag(Component.State.ExecutionStep);
                            return ExecPhase.Activations;
                        }
                        else
                        {
                            throw new InvalidOperationException("Layer does not have any node.");
                        }
                    }
                }
            }

            return Phase;
        }

        private ExecPhase StepCxActivations()
        {
            if (_node.Current.Neuron.Z is null) throw new InvalidOperationException("Invalid neuron Z value.");
            if (_node.Current.Neuron.Activation is null) throw new InvalidOperationException("Invalid or missing Activation function.");
            _node.Current.Neuron.A = _node.Current.Neuron.Activation.Execute(_node.Current.Neuron.Z.Value);
            _node.Current.Neuron.ClearStateFlag(Component.State.ExecutionStep);

            if (_node.MoveNext())
            {
                _node.Current.Neuron.SetStateFlag(Component.State.ExecutionStep);
            }
            else
            {
                _node.Reset();
                if (StepIntoNd())
                {
                    foreach (var node in _layer.Current.Nodes)
                    {
                        node.Neuron.Z = null;
                    }

                    if (_layer.Current.Next is not null)
                    {
                        foreach (var node in _layer.Current.Next.Nodes)
                        {
                            node.Neuron.Z = 0;
                        }
                    }

                    return ExecPhase.ConnectionsWeights;
                }
                else
                {
                    if (_layer.Current.IsOutput)
                    {
                        foreach (var node in _layer.Current.Nodes)
                        {
                            node.Neuron.Z = null;
                        }

                        return ExecPhase.FetchData;
                    }

                    throw new InvalidOperationException("Layer does not have any node.");
                }
            }

            return Phase;
        }

        private bool StepIntoNd()
        {
            if (_node.MoveNext())
            {
                _node.Current.Neuron.SetStateFlag(Component.State.ExecutionStep);
                _link = _node.Current.Next.GetEnumerator();
                if (_link.MoveNext())
                {
                    _link.Current.Connection.Executing = true;
                    return true;
                }
                else if (!_layer.Current.IsOutput)
                {
                    throw new InvalidOperationException("Node does not have any link.");
                }
            }

            return false;
        }
    }
}
