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
        /// The network obtains the correction value for the output.
        /// </summary>
        OutputCorrection,

        /// <summary>
        /// The network calcs the new bias for the neurons.
        /// </summary>
        BiasCorrection,

        /// <summary>
        /// The network calcs the new weights for the neuron connections.
        /// </summary>
        WeightsCorrection,

        /// <summary>
        /// The network propagates the error to the internal neurons.
        /// </summary>
        ErrorPropagation,

        /// <summary>
        /// The network calcs the correction value from the accumulated error.
        /// </summary>
        CorrectionValue,

        /// <summary>
        /// The network updates the weights to the new calculated values.
        /// </summary>
        ApplyNewWeights,

        /// <summary>
        /// The network has completed an epoch.
        /// </summary>
        EpochDone,

        /// <summary>
        /// The network registers a new test result.
        /// </summary>
        RegisterResult,
    }

    /// <summary>
    /// Enumerates the types of executions steps.
    /// </summary>
    internal enum StepType
    {
        /// <summary>
        /// Represents a Connection step.
        /// </summary>
        Connection,

        /// <summary>
        /// Represents a Neuron step.
        /// </summary>
        Neuron,

        /// <summary>
        /// Represents a Layer step.
        /// </summary>
        Layer,

        /// <summary>
        /// Represents a data register step.
        /// </summary>
        DataRegister,

        /// <summary>
        /// Represents a batch of data step.
        /// </summary>
        DataBatch,

        /// <summary>
        /// Represents the full data step.
        /// </summary>
        Epoch,
    }

    /// <summary>
    /// Handles the network model execution.
    /// </summary>
    internal class Execution
    {
        private IEnumerator<DataRegister>? _register;
        private IEnumerator<Layer>? _layer;
        private IEnumerator<Node>? _node;
        private IEnumerator<Link>? _link;

        /// <summary>
        /// Initializes a new instance of the <see cref="Execution"/> class.
        /// </summary>
        /// <param name="network">The network to execute.</param>
        public Execution(Network network)
        {
            Network = network;
            Phase = ExecPhase.FetchData;
        }

        /// <summary>
        /// Ocurrs when a general metrics is updated.
        /// </summary>
        public event EventHandler<MetricsUpdatedEventArgs>? MetricsUpdated;

        /// <summary>
        /// Ocurs when a training epoch has been completed.
        /// </summary>
        public event EventHandler? EpochDone;

        /// <summary>
        /// Ocurs when the network obtains a new test result.
        /// </summary>
        public event EventHandler<GotTestResultEventArgs>? GotTestResult;

        /// <summary>
        /// Ocurs when all the test registers have been passed for the network.
        /// </summary>
        public event EventHandler? TestDone;

        /// <summary>
        /// Gets the network to execute.
        /// </summary>
        public Network Network { get; }

        /// <summary>
        /// Gets the data to process in the network.
        /// </summary>
        public DataTable Data => Network.Workspace.DataTable;

        /// <summary>
        /// Gets the current execution phase.
        /// </summary>
        public ExecPhase Phase { get; private set; }

        /// <summary>
        /// Gets or sets the execution selected <see cref="SubGraph"/> to show the details.
        /// </summary>
        public SubGraph? SubGraph { get; set; }

        /// <summary>
        /// Gets the current epoch number.
        /// </summary>
        public int Epoch { get; private set; }

        /// <summary>
        /// Gets the current batch number.
        /// </summary>
        public int Batch { get; private set; }

        /// <summary>
        /// Gets the current register number.
        /// </summary>
        public int Register { get; private set; }

        /// <summary>
        /// Prepares the network for execution.
        /// </summary>
        public void Start()
        {
            if (Network.Graph is null) throw new InvalidOperationException("Invalid Graph value.");
            if (!Network.Workspace.ReadOnly) throw new InvalidOperationException("The workspace should be readonly.");
            if (!Network.BuildResult) throw new InvalidOperationException("The network should built without errors.");

            // Select the first register.
            _register = Network.Mode switch
            {
                NetworkMode.Training => Data.GetTrainingEnumerator(),
                NetworkMode.Testing => Data.GetTestingEnumerator(),
                _ => throw new InvalidOperationException()
            };

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

            // First phase is to get the data from the table.
            Phase = ExecPhase.GetData;

            if (Network.Mode == NetworkMode.Training)
            {
                // Init all the bias values
                foreach (var node in Network.Graph.Nodes)
                {
                    if (node.Neuron is not Input) node.Neuron.Bias = node.Neuron.InitBias;
                }

                // Init the connections with the initialization weights.
                foreach (var link in Network.Graph.Links)
                {
                    link.Connection.Weight = link.Connection.InitWeight;
                    link.Connection.WeightCorrection = null;
                }
            }

            // Select the register in the table.
            Network.Workspace.SelectRegister(_register.Current);
            if (_register.Current.Tag is DataGridViewRow row)
            {
                Register = row.Index - 1;
                Batch = 0;
                Epoch = 0;
                OnMetricsUpdated();
            }

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
                node.Neuron.BiasCorrection = null;
                node.Neuron.A = null;
                node.Neuron.Error = null;
                node.Neuron.Correction = null;
                if (node.Neuron is Output output)
                {
                    output.Y = null;
                    output.MSE = null;
                }
            }

            // Clear the weights.
            foreach (var link in Network.Graph.Links)
            {
                link.Connection.Weight = null;
                link.Connection.WeightCorrection = null;
            }

            SubGraph = null;
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

            if (SubGraph is not null)
            {
                SubGraph.Node.Neuron.PaintOutput(graphics, SubGraph);
            }
        }

        /// <summary>
        /// Executes the full data set in the network.
        /// </summary>
        public void Run()
        {
            StepType stepType;
            do
            {
                stepType = OneStep();
            }
            while (stepType is not StepType.Epoch);

            Network.Workspace.Refresh();
        }

        /// <summary>
        /// Executes one connection step in the network.
        /// </summary>
        public void StepIntoCx()
        {
            _ = OneStep();

            Network.Workspace.Refresh();
        }

        /// <summary>
        /// Executes one Neuron step in the network.
        /// </summary>
        public void StepIntoNeuron()
        {
            StepType stepType;
            do
            {
                stepType = OneStep();
            }
            while (stepType is < StepType.Neuron);

            Network.Workspace.Refresh();
        }

        /// <summary>
        /// Executes one Layer step in the network.
        /// </summary>
        public void StepIntoLayer()
        {
            StepType stepType;
            do
            {
                stepType = OneStep();
            }
            while (stepType is < StepType.Layer);

            Network.Workspace.Refresh();
        }

        /// <summary>
        /// Executes one Layer step in the network.
        /// </summary>
        public void StepIntoData()
        {
            StepType stepType;
            do
            {
                stepType = OneStep();
            }
            while (stepType is < StepType.DataRegister);

            Network.Workspace.Refresh();
        }

        /// <summary>
        /// Executes one Batch step in the network.
        /// </summary>
        public void StepIntoBatch()
        {
            StepType stepType;
            do
            {
                stepType = OneStep();
            }
            while (stepType is < StepType.DataBatch);

            Network.Workspace.Refresh();
        }

        /// <summary>
        /// Executes one Batch step in the network.
        /// </summary>
        public void StepIntoEpoch()
        {
            StepType stepType;
            do
            {
                stepType = OneStep();
            }
            while (stepType is < StepType.Epoch);

            Network.Workspace.Refresh();
        }

        private StepType OneStep()
        {
            if (Network.Graph is null || _node is null || _layer is null || _register is null) throw new InvalidOperationException();
            StepType stepType = StepType.Connection;

            switch (Phase)
            {
                case ExecPhase.FetchData:
                {
                    // Get the layers in forward order.
                    _layer = Network.Graph.Layers.GetEnumerator();
                    if (_layer.MoveNext()) _node = _layer.Current.Nodes.GetEnumerator();
                    if (_node.MoveNext()) _link = _node.Current.Next.GetEnumerator();
                    if (!_link?.MoveNext() ?? false) throw new InvalidOperationException("The node does not have links.");

                    // Clear all the network nodes.
                    foreach (var node in Network.Graph.Nodes)
                    {
                        node.Neuron.Z = null;
                        node.Neuron.A = null;
                        node.Neuron.Error = null;
                    }

                    // Select all the nodes in the input layer.
                    foreach (var node in _layer.Current.Nodes)
                    {
                        node.Neuron.SetStateFlag(Component.State.Execution);
                    }

                    if (!_register.MoveNext())
                    {
                        stepType = StepType.Epoch;
                        if (Network.Mode == NetworkMode.Training) OnEpochDone();
                        else OnTestDone();
                        Phase = ExecPhase.EpochDone;
                        Epoch++;
                        Batch = 0;
                        OnMetricsUpdated();
                        return stepType;
                    }
                    else if ((Register + 1) % Network.BatchSize == 0)
                    {
                        stepType = StepType.DataBatch;
                        Batch++;
                        OnMetricsUpdated();
                    }

                    // Select the current register in the table.
                    Network.Workspace.SelectRegister(_register.Current);
                    if (_register.Current.Tag is DataGridViewRow row)
                    {
                        Register = row.Index - 1;
                        OnMetricsUpdated();
                    }

                    Phase = ExecPhase.GetData;
                    break;
                }

                case ExecPhase.GetData:
                {
                    // Clear the outputs from the neurons in the last layer.
                    foreach (var node in Network.Graph.Layers.Last().Nodes)
                    {
                        if (node.Neuron is Output output)
                        {
                            output.Y = null;
                        }
                    }

                    // Clear the execution mark for the nodes in the first layer.
                    foreach (var node in _layer.Current.Nodes)
                    {
                        if (node.Neuron is Input input)
                        {
                            input.ClearStateFlag(Component.State.Execution);
                            input.A = Data.GetValue(input.DataLabel ?? throw new InvalidOperationException());
                        }
                    }

                    // Next phase.
                    Phase = ExecPhase.ConnectionsWeights;
                    stepType = StepType.DataRegister;

                    // Get the next layer.
                    if (!_layer.MoveNext()) throw new InvalidOperationException("Expected an internal layer.");

                    // Initialize the layer.
                    InitializeLayer();
                    break;
                }

                case ExecPhase.ConnectionsWeights:
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
                    }
                    else
                    {
                        // If no connections then execute the activation function.
                        Phase = ExecPhase.Activation;
                    }

                    break;
                }

                case ExecPhase.Activation:
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

                        // Next phase.
                        Phase = ExecPhase.ConnectionsWeights;
                        stepType = StepType.Neuron;
                    }
                    else
                    {
                        // Move to the next layer.
                        if (_layer.MoveNext())
                        {
                            // Initialize the layer.
                            InitializeLayer();

                            // Next phase.
                            Phase = ExecPhase.ConnectionsWeights;
                            stepType = StepType.Layer;
                        }
                        else
                        {
                            // Prepare for backpropagation.
                            _layer = Network.Graph.Layers.AsEnumerable().Reverse().GetEnumerator() ?? throw new InvalidOperationException();

                            // Get the next layer.
                            if (!_layer.MoveNext()) throw new InvalidOperationException("Expected an internal layer.");

                            // Set the execution mark for the nodes in the last layer.
                            foreach (var node in _layer.Current.Nodes)
                            {
                                node.Neuron.SetStateFlag(Component.State.Execution);
                            }

                            // Move to the next execution phase.
                            Phase = ExecPhase.GetOutputData;
                            stepType = StepType.Layer;
                        }
                    }

                    break;
                }

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

                    // Set the neuron error to 0.
                    _node.Current.Neuron.Error = 0m;

                    // Move to the next phase.
                    Phase = Network.Mode switch
                    {
                        NetworkMode.Training => ExecPhase.OutputNeuronError,
                        NetworkMode.Testing => ExecPhase.RegisterResult,
                        _ => throw new InvalidOperationException()
                    };

                    stepType = StepType.Layer;
                    break;
                }

                case ExecPhase.OutputNeuronError:
                {
                    if (_node.Current.Neuron is not Output output || output.Activation is null || output.A is null || output.Y is null) throw new InvalidOperationException();

                    // Get the last layer output neurons
                    int n = _layer.Current.Nodes.Count;

                    // Calc the output neuron error.
                    output.MSE = 1m / n * (decimal)Math.Pow((double)(output.Y.Value - output.A.Value), 2.0);

                    // From the chain rule.
                    decimal part1 = output.A.Value - output.Y.Value;
                    decimal part2 = output.Activation.Derivative(output.A.Value);

                    // Set the neuron cost.
                    output.Error = part1 * part2;

                    // Move to the next phase.
                    Phase = ExecPhase.OutputCorrection;

                    break;
                }

                case ExecPhase.OutputCorrection:
                {
                    // Set the correction value to the error.
                    if (_node.Current.Neuron.Correction is null)
                    {
                        _node.Current.Neuron.Correction = _node.Current.Neuron.Error;
                    }
                    else
                    {
                        _node.Current.Neuron.Correction += _node.Current.Neuron.Error;
                    }

                    // Remove the node execution mark.
                    _node.Current.Neuron.ClearStateFlag(Component.State.Execution);

                    // Move to the next node.
                    if (_node.MoveNext())
                    {
                        // Set the neuron error to 0.
                        _node.Current.Neuron.Error = 0m;

                        // Move to the next phase.
                        Phase = ExecPhase.OutputNeuronError;
                    }
                    else
                    {
                        // Get the total error.
                        decimal totalMse = 0m;
                        foreach (Node node in _layer.Current.Nodes)
                        {
                            if (node.Neuron is Output output1)
                            {
                                totalMse += output1.MSE ?? throw new InvalidOperationException();
                            }
                        }

                        // Update the error.
                        OnMetricsUpdated(totalMse);

                        // Check if this is the last batch register.
                        if ((Register + 1) % Network.BatchSize == 0)
                        {
                            // Move to the first node again.
                            _node.Reset();
                            if (!_node.MoveNext()) throw new InvalidOperationException("Expected node in layer.");

                            // Move to the next phase.
                            Phase = ExecPhase.BiasCorrection;
                        }
                        else
                        {
                            // Move to the next phase.
                            Phase = ExecPhase.FetchData;
                            stepType = OneStep();
                        }
                    }

                    // Set the node execution mark.
                    _node.Current.Neuron.SetStateFlag(Component.State.Execution);

                    break;
                }

                case ExecPhase.BiasCorrection:
                {
                    // The chain rule for bias.
                    decimal part12;
                    if (_node.Current.Neuron is Output output)
                    {
                        if (output.Correction is null) throw new InvalidOperationException();
                        part12 = output.Correction.Value / Network.BatchSize;
                    }
                    else if (_node.Current.Neuron is Internal @internal)
                    {
                        if (@internal.Error is null || @internal.Correction is null) throw new InvalidOperationException();
                        part12 = @internal.Error.Value * @internal.Correction.Value;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }

                    // Calc the new bias value.
                    _node.Current.Neuron.BiasCorrection = _node.Current.Neuron.Bias - Network.LearningRate * part12;

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

                    // The chain rule for weights.
                    decimal part12, part3;
                    if (_node.Current.Neuron is Output output)
                    {
                        if (output.Correction is null) throw new InvalidOperationException();
                        part12 = output.Correction.Value / Network.BatchSize;
                    }
                    else if (_node.Current.Neuron is Internal @internal)
                    {
                        if (@internal.Error is null || @internal.Correction is null) throw new InvalidOperationException();
                        part12 = @internal.Error.Value * @internal.Correction.Value;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }

                    part3 = _link.Current.Previous.Neuron.A ?? throw new InvalidOperationException();
                    decimal chain = part12 * part3;

                    // Calc the new connection weight.
                    _link.Current.Connection.WeightCorrection = _link.Current.Connection.Weight - Network.LearningRate * chain;

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

                            // Repeat error calc phase.
                            if (_node.Current.Neuron is Output)
                            {
                                // Move to the next phase.
                                Phase = ExecPhase.BiasCorrection;
                                stepType = StepType.Neuron;
                            }
                            else if (_node.Current.Neuron is Internal @internal)
                            {
                                // Set the neuron error to 0.
                                @internal.Error = 0m;

                                // Get the previous links enumerator.
                                _link = _node.Current.Next.GetEnumerator();
                                if (!_link.MoveNext()) throw new InvalidOperationException("Expected a link in the node.");

                                // Set the link execution mark.
                                _link.Current.Connection.Executing = true;

                                // Move to the next phase.
                                Phase = ExecPhase.ErrorPropagation;
                                stepType = StepType.Neuron;
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
                                    // Select all the connections.
                                    foreach (var link in Network.Graph.Links)
                                    {
                                        link.Connection.Executing = true;
                                    }

                                    // Move to the next phase.
                                    Phase = ExecPhase.ApplyNewWeights;
                                    stepType = StepType.Layer;
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
                                    stepType = StepType.Layer;
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
                        // Move to the next phase.
                        Phase = ExecPhase.CorrectionValue;
                    }

                    break;
                }

                case ExecPhase.CorrectionValue:
                {
                    if (_node.Current.Neuron.Activation is null || _node.Current.Neuron.A is null) throw new InvalidOperationException();
                    _node.Current.Neuron.Correction = _node.Current.Neuron.Activation.Derivative(_node.Current.Neuron.A.Value);

                    // Move to the next phase.
                    Phase = ExecPhase.BiasCorrection;
                    break;
                }

                case ExecPhase.ApplyNewWeights:
                {
                    // Apply new weights and unselect all the connections.
                    foreach (var link in Network.Graph.Links)
                    {
                        link.Connection.Weight = link.Connection.WeightCorrection;
                        link.Connection.WeightCorrection = null;
                        link.Connection.Executing = false;
                    }

                    // Apply new bias and remove MSE text.
                    foreach (Layer layer in Network.Graph.Layers.Skip(1))
                    {
                        foreach (Node node in layer.Nodes)
                        {
                            if (node.Neuron is Output output) output.MSE = null;
                            node.Neuron.Bias = node.Neuron.BiasCorrection;
                            node.Neuron.BiasCorrection = null;
                        }
                    }

                    // Remove Total MSE label.
                    OnMetricsUpdated();

                    // Move to the next phase.
                    Phase = ExecPhase.FetchData;
                    stepType = OneStep();
                    break;
                }

                case ExecPhase.RegisterResult:
                {
                    if (_node.Current.Neuron is Output output && output.Y is not null && output.A is not null)
                    {
                        OnGotTestResult(output.Y.Value, output.A.Value);
                        Phase = ExecPhase.FetchData;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }

                    break;
                }

                case ExecPhase.EpochDone:
                {
                    _register.Reset();
                    if (_register.MoveNext())
                    {
                        Network.Workspace.SelectRegister(_register.Current);
                        if (_register.Current.Tag is DataGridViewRow row)
                        {
                            Register = row.Index - 1;
                            OnMetricsUpdated();
                        }

                        Phase = ExecPhase.GetData;
                        _ = OneStep();
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }

                    break;
                }

                default:
                    throw new NotImplementedException();
            }

            return stepType;
        }

        private void InitializeNode()
        {
            if (_node is null) throw new InvalidOperationException();

            // Set the execution mark for the node.
            _node.Current.Neuron.SetStateFlag(Component.State.Execution);

            // Initialize the Z with the bias value
            _node.Current.Neuron.Z = _node.Current.Neuron.Bias;

            // Get the first node link.
            _link = _node.Current.Previous.GetEnumerator();
            if (!_link.MoveNext()) throw new InvalidOperationException("Unexpected node without incomming links.");

            // Set the execution mark for the link.
            _link.Current.Connection.Executing = true;
        }

        private void InitializeLayer()
        {
            if (_layer is null) throw new InvalidOperationException();

            // Get the nodes enumerator for the layer.
            _node = _layer.Current.Nodes.GetEnumerator();

            // Get the first node from the enumerator.
            if (!_node.MoveNext()) throw new InvalidOperationException("Expected a node in the layer.");

            // Initialize the node.
            InitializeNode();
        }

        private void OnMetricsUpdated(decimal? error = null)
        {
            MetricsUpdatedEventArgs args = new MetricsUpdatedEventArgs(Batch, Epoch, error);
            MetricsUpdated?.Invoke(this, args);
        }

        private void OnEpochDone()
        {
            EpochDone?.Invoke(this, EventArgs.Empty);
        }

        private void OnGotTestResult(decimal label, decimal output)
        {
            GotTestResult?.Invoke(this, new GotTestResultEventArgs(label, output));
        }

        private void OnTestDone()
        {
            TestDone?.Invoke(this, EventArgs.Empty);
        }
    }
}
