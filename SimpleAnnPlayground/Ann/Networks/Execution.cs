﻿// <copyright file="Execution.cs" company="SeminarioIA">
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
        /// Fordward pass phase.
        /// </summary>
        FordwardPass,

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
                        node.Neuron.Input = null;
                    }

                    Phase = ExecPhase.GetData;
                    break;
                case ExecPhase.GetData:
                    foreach (var node in _layer.Current.Nodes)
                    {
                        if (node.Neuron is Input input)
                        {
                            input.ClearStateFlag(Component.State.ExecutionStep);
                            input.Input = Data.GetValue(input.DataLabel ?? throw new InvalidOperationException());
                        }
                    }

                    // Next phase
                    Phase = ExecPhase.FordwardPass;
                    _node.Current.Neuron.SetStateFlag(Component.State.ExecutionStep);
                    _link.Current.Connection.Executing = true;
                    break;
                case ExecPhase.FordwardPass:
                    if (StepCxFordward()) Phase = ExecPhase.FetchData;
                    break;
                case ExecPhase.BackPropagation:
                    break;
                default:
                    break;
            }

            Network.Workspace.Refresh();
        }

        private bool StepCxFordward()
        {
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
                        if (!StepIntoNd())
                        {
                            if (_layer.Current.IsOutput) return true;
                            throw new InvalidOperationException("Layer does not have any node.");
                        }
                    }
                }
            }

            return false;
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