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
        /// The network loads the selected data entry for the input layer.
        /// </summary>
        GetData,

        /// <summary>
        /// The neuron adds the previous neurons values multiplied by the connections weight.
        /// </summary>
        ConnectionsWeights,

        /// <summary>
        /// The neuron process its value with the activation function.
        /// </summary>
        Activation,

        /// <summary>
        /// The network loads the selected data entry for the output layer.
        /// </summary>
        GetOutputData,

        /// <summary>
        /// The network obtains the output layer neurons errors.
        /// </summary>
        OutputNeuronError,

        /// <summary>
        /// The network changes the weights for the neuron connections.
        /// </summary>
        WeightsCorrection,

        /// <summary>
        /// The network propagates the error to the internal neurons.
        /// </summary>
        ErrorPropagation,
    }

    /// <summary>
    /// Handles the network model execution.
    /// </summary>
    internal class Execution
    {
        private readonly IEnumerator<DataRegister> _register;
        private IEnumerator<Layer> _layer;
        private IEnumerator<Node> _node;
        private IEnumerator<Link>? _link;

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

            // Select the first register.
            _register = Data.Registers.GetEnumerator();
            if (!_register.MoveNext())
            {
                throw new InvalidOperationException("Input data does not contains registers.");
            }

            // Get the first layer.
            _layer = Network.Graph.Layers.GetEnumerator();
            if (_layer.MoveNext())
            {
                _node = _layer.Current.Nodes.GetEnumerator();
                if (!_node.MoveNext())
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

            // First phase is to get the data from the table.
            Phase = ExecPhase.GetData;

            // Init all the bias values
            foreach (var node in Network.Graph.Nodes)
            {
                if (node.Neuron is not Input) node.Neuron.Bias = 0;
            }

            // Init the connections with the initialization weights.
            foreach (var link in Network.Graph.Links)
            {
                link.Connection.Weight = link.Connection.InitWeight;
            }

            // Select the register in the table.
            Network.Workspace.SelectRegister(_register.Current);

            // Set execution mark for the nodes in the first layer.
            foreach (var node in _layer.Current.Nodes)
            {
                node.Neuron.SetStateFlag(Component.State.Execution);
            }
        }

        /// <summary>
        /// Restores the network state.
        /// </summary>
        public void Stop()
        {
            if (Network.Graph is null) throw new InvalidOperationException("Invalid Graph value.");

            // Clear connections execution marks.
            foreach (var link in Network.Graph.Links)
            {
                link.Connection.Executing = false;
            }

            // Clear nodes execution marks, Z, A, Y and bias values.
            foreach (var node in Network.Graph.Nodes)
            {
                node.Neuron.ClearStateFlag(Component.State.Execution);
                node.Neuron.Z = null;
                node.Neuron.Bias = null;
                node.Neuron.A = null;
                if (node.Neuron is Output output) output.Y = null;
            }

            // Clear the weights.
            foreach (var link in Network.Graph.Links)
            {
                link.Connection.Weight = null;
            }
        }

        /// <summary>
        /// Draws the execution elements.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        public void Paint(Graphics graphics)
        {
            if (_link?.Current is not null)
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
                {
                    // Get the layers in forward order.
                    _layer = Network.Graph?.Layers.GetEnumerator() ?? throw new InvalidOperationException();
                    if (_layer.MoveNext()) _node = _layer.Current.Nodes.GetEnumerator();
                    if (_node.MoveNext()) _link = _node.Current.Next.GetEnumerator();
                    if (!_link?.MoveNext() ?? false) throw new InvalidOperationException("The node does not have links.");
                    if (!_register.MoveNext()) throw new NotImplementedException("Pending to implement what to do at the end of the table.");
                    Network.Workspace.SelectRegister(_register.Current);
                    foreach (var node in _layer.Current.Nodes)
                    {
                        node.Neuron.SetStateFlag(Component.State.Execution);
                        node.Neuron.Z = null;
                        node.Neuron.A = null;
                    }

                    Phase = ExecPhase.GetData;
                    break;
                }

                case ExecPhase.GetData:
                    // Clear the execution mark for the nodes in the first layer.
                    foreach (var node in _layer.Current.Nodes)
                    {
                        if (node.Neuron is Input input)
                        {
                            input.ClearStateFlag(Component.State.Execution);
                            input.A = Data.GetValue(input.DataLabel ?? throw new InvalidOperationException());
                        }
                    }

                    // Next phase
                    Phase = ExecPhase.ConnectionsWeights;

                    // Get the next layer.
                    if (!_layer.MoveNext()) throw new InvalidOperationException("Expected an internal layer.");

                    // Initialize the layer.
                    InitializeLayer();
                    break;
                case ExecPhase.ConnectionsWeights:
                    Phase = StepCxWeights();
                    break;
                case ExecPhase.Activation:
                    Phase = StepCxActivations();
                    break;
                case ExecPhase.GetOutputData:
                {
                    // Clear the execution mark for the nodes in the last layer and add the output value.
                    foreach (var node in _layer.Current.Nodes)
                    {
                        if (node.Neuron is Output output)
                        {
                            output.ClearStateFlag(Component.State.Execution);
                            output.Y = Data.GetValue(output.DataLabel ?? throw new InvalidOperationException());
                        }
                    }

                    // Get the layer enumerator for the nodes.
                    _node = _layer.Current.Nodes.GetEnumerator();

                    // Get the first node from the enumerator.
                    if (!_node.MoveNext()) throw new InvalidOperationException("Expected a node in the layer.");

                    // Set the execution mark for the node.
                    _node.Current.Neuron.SetStateFlag(Component.State.Execution);

                    // Move to the next phase.
                    Phase = ExecPhase.OutputNeuronError;
                    break;
                }

                case ExecPhase.OutputNeuronError:
                {
                    if (_node.Current.Neuron is not Output output || output.Activation is null || output.A is null || output.Y is null) throw new InvalidOperationException();

                    // Calc the output neuron error.
                    output.Error = output.Activation.Derivative(output.A.Value) * (output.Y.Value - output.A.Value);

                    // Get the node links.
                    _link = _node.Current.Previous.GetEnumerator();
                    if (!_link.MoveNext()) throw new InvalidOperationException("Expected connection in node.");

                    // Set the connection execution mark.
                    _link.Current.Connection.Executing = true;

                    // Move to the next phase.
                    Phase = ExecPhase.WeightsCorrection;
                    break;
                }

                case ExecPhase.WeightsCorrection:
                {
                    if (_link is null || _node.Current.Neuron is Input) throw new InvalidOperationException();

                    // Calc the new connection weight.
                    _link.Current.Connection.WeightCorrection = _link.Current.Connection.Weight + Network.LearningRate * _node.Current.Neuron.A * _node.Current.Neuron.Error;

                    // Remove the link execution mark.
                    _link.Current.Connection.Executing = false;

                    // Move to the next link.
                    if (_link.MoveNext())
                    {
                        // Set the link execution mark.
                        _link.Current.Connection.Executing = true;
                    }
                    else
                    {
                        // Remove the node execution mark.
                        _node.Current.Neuron.ClearStateFlag(Component.State.Execution);

                        // Move to the next node.
                        if (_node.MoveNext())
                        {
                            // Set the node execution mark.
                            _node.Current.Neuron.SetStateFlag(Component.State.Execution);

                            // Set the neuron error to 0.
                            _node.Current.Neuron.Error = 0m;

                            // Repeat error calc phase.
                            if (_node.Current.Neuron is Output)
                            {
                                // Move to the next phase.
                                Phase = ExecPhase.OutputNeuronError;
                            }
                            else if (_node.Current.Neuron is Internal)
                            {
                                // Get the previous links enumerator.
                                _link = _node.Current.Next.GetEnumerator();
                                if (!_link.MoveNext()) throw new InvalidOperationException("Expected a link in the node.");

                                // Set the link execution mark.
                                _link.Current.Connection.Executing = true;

                                // Move to the next phase.
                                Phase = ExecPhase.ErrorPropagation;
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            // Move to the next layer.
                            if (_layer.MoveNext())
                            {
                                // Get the first layer node.
                                _node = _layer.Current.Nodes.GetEnumerator();
                                if (!_node.MoveNext()) throw new InvalidOperationException("Expected node in layer.");

                                if (_node.Current.Neuron is Input)
                                {
                                    Phase = ExecPhase.FetchData;
                                    StepIntoCx();
                                }
                                else
                                {
                                    // Set the node execution mark.
                                    _node.Current.Neuron.SetStateFlag(Component.State.Execution);

                                    // Set the neuron error to 0.
                                    _node.Current.Neuron.Error = 0m;

                                    // Get the node links enumerator.
                                    _link = _node.Current.Next.GetEnumerator();
                                    if (!_link.MoveNext()) throw new InvalidOperationException("Expected link in neuron.");

                                    // Set the link execution mark.
                                    _link.Current.Connection.Executing = true;

                                    // Move to the next phase.
                                    Phase = ExecPhase.ErrorPropagation;
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("We shouldn't be here.");
                            }
                        }
                    }

                    break;
                }

                case ExecPhase.ErrorPropagation:
                {
                    if (_link is null) throw new InvalidOperationException();

                    // Add to the error the output neuron error.
                    _node.Current.Neuron.AddError(_link.Current.Next.Neuron.Error, _link.Current.Connection.Weight);

                    // Clear the execution mark for the link.
                    _link.Current.Connection.Executing = false;

                    // Move to the next link.
                    if (_link.MoveNext())
                    {
                        // Set the execution mark for the link.
                        _link.Current.Connection.Executing = true;
                    }
                    else
                    {
                        // Get the previous links enumerator.
                        _link = _node.Current.Previous.GetEnumerator();
                        if (!_link.MoveNext()) throw new InvalidOperationException("Expected a link in the node.");

                        // Set the link execution mark.
                        _link.Current.Connection.Executing = true;

                        // Move to the next phase.
                        Phase = ExecPhase.WeightsCorrection;
                    }

                    break;
                }

                default:
                    break;
            }

            Network.Workspace.Refresh();
        }

        private ExecPhase StepCxWeights()
        {
            if (_link is null) throw new InvalidOperationException("Unexpected null link enumerator.");

            // Add to Z the previous A value multiplied by the link weight.
            _node.Current.Neuron.AddValue(_link.Current.Previous.Neuron.A, _link.Current.Connection.Weight);

            // Clear connection execution mark.
            _link.Current.Connection.Executing = false;

            // Move to the next connection.
            if (_link.MoveNext())
            {
                // Set execution mark for the next connection.
                _link.Current.Connection.Executing = true;
                return Phase;
            }
            else
            {
                // If no connections then execute the activation function.
                return ExecPhase.Activation;
            }
        }

        private ExecPhase StepCxActivations()
        {
            if (_node.Current.Neuron.Z is null) throw new InvalidOperationException("Invalid neuron Z value.");
            if (_node.Current.Neuron.Activation is null) throw new InvalidOperationException("Invalid or missing Activation function.");

            // Calc the neuron output.
            _node.Current.Neuron.A = _node.Current.Neuron.Activation.Execute(_node.Current.Neuron.Z.Value);

            // Remove the neuron execution mark.
            _node.Current.Neuron.ClearStateFlag(Component.State.Execution);

            // Move to the next neuron in the layer.
            if (_node.MoveNext())
            {
                // Initialize the node.
                InitializeNode();

                return ExecPhase.ConnectionsWeights;
            }
            else
            {
                // Move to the next layer.
                if (_layer.MoveNext())
                {
                    // Initialize the layer.
                    InitializeLayer();
                    return ExecPhase.ConnectionsWeights;
                }
                else
                {
                    // Prepare for backpropagation.
                    _layer = Network.Graph?.Layers.AsEnumerable().Reverse().GetEnumerator() ?? throw new InvalidOperationException();

                    // Get the next layer.
                    if (!_layer.MoveNext()) throw new InvalidOperationException("Expected an internal layer.");

                    // Set the execution mark for the nodes in the last layer.
                    foreach (var node in _layer.Current.Nodes)
                    {
                        if (node.Neuron is Output output) output.SetStateFlag(Component.State.Execution);
                    }

                    // Move to the next execution phase.
                    return ExecPhase.GetOutputData;
                }
            }
        }

        private void InitializeNode()
        {
            // Set the execution mark for the node.
            _node.Current.Neuron.SetStateFlag(Component.State.Execution);

            // Initialize the node Z value.
            _node.Current.Neuron.Z = 0;

            // Get the first node link.
            _link = _node.Current.Previous.GetEnumerator();
            if (!_link.MoveNext()) throw new InvalidOperationException("Unexpected node without incomming links.");

            // Set the execution mark for the link.
            _link.Current.Connection.Executing = true;
        }

        private void InitializeLayer()
        {
            // Get the nodes enumerator for the layer.
            _node = _layer.Current.Nodes.GetEnumerator();

            // Get the first node from the enumerator.
            if (!_node.MoveNext()) throw new InvalidOperationException("Expected a node in the layer.");

            // Initialize the node.
            InitializeNode();
        }
    }
}
