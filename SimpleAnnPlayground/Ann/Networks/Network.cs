// <copyright file="Network.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Environment;
using static SimpleAnnPlayground.Graphical.Component;

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// The available network modes.
    /// </summary>
    internal enum NetworkMode
    {
        /// <summary>
        /// The network is in edition mode.
        /// </summary>
        Edition,

        /// <summary>
        /// The network is in training mode.
        /// </summary>
        Training,

        /// <summary>
        /// The network is in testing mode.
        /// </summary>
        Testing,
    }

    /// <summary>
    /// Represents a neural network.
    /// </summary>
    internal class Network
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Network"/> class.
        /// </summary>
        /// <param name="workspace">The workspace containing the elements to build the network.</param>
        public Network(Workspace workspace)
        {
            Workspace = workspace;
            Execution = new Execution(this);
        }

        /// <summary>
        /// Gets the valid learning rates for the network.
        /// </summary>
        public static decimal[] LearningRates { get; } = new decimal[11] { 0.00001m, 0.0001m, 0.001m, 0.003m, 0.01m, 0.03m, 0.1m, 0.3m, 1m, 3m, 10m };

        /// <summary>
        /// Gets the workspace containing the elements to build the network.
        /// </summary>
        public Workspace Workspace { get; }

        /// <summary>
        /// Gets or sets the neural network learning rate.
        /// </summary>
        public decimal LearningRate { get; set; } = 0.03m;

        /// <summary>
        /// Gets or sets the model batch size for training.
        /// </summary>
        public int BatchSize { get; set; } = 1;

        /// <summary>
        /// Gets the network mode.
        /// </summary>
        public NetworkMode Mode { get; private set; }

        /// <summary>
        /// Gets the network graph.
        /// </summary>
        public NetworkGraph? Graph { get; private set; }

        /// <summary>
        /// Gets the execution helper.
        /// </summary>
        public Execution Execution { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the network build was successful.
        /// </summary>
        public bool BuildResult { get; private set; }

        /// <summary>
        /// Builds the neural network from the workspace objects.
        /// </summary>
        /// <returns>True if the build was successful, otherwise false.</returns>
        public bool Build()
        {
            CleanObjects();
            bool result = true;
            result &= CheckUnconnected();
            result &= CheckForInputs();
            result &= CheckForOutputs();
            result &= CheckForDataLinks();
            result &= CheckForActivations();
            if (result) result &= BuildGraph();
            Workspace.Refresh();
            return result;
        }

        /// <summary>
        /// Cleans all the objects messages.
        /// </summary>
        public void Clean()
        {
            CleanObjects();

            Graph = null;
            Workspace.Refresh();
        }

        /// <summary>
        /// Starts the network training.
        /// </summary>
        public void StartTraining()
        {
            Mode = NetworkMode.Training;
            Execution.Start();
        }

        /// <summary>
        /// Starts the network testing.
        /// </summary>
        public void StartTesting()
        {
            Mode = NetworkMode.Testing;
            Execution.Start();
        }

        /// <summary>
        /// Stops the network execution.
        /// </summary>
        public void Stop()
        {
            Execution.Stop();
            Mode = NetworkMode.Edition;
        }

        private bool CheckUnconnected()
        {
            bool result = true;

            foreach (var obj in Workspace.Canvas.Objects)
            {
                if (obj.Terminals.Any(terminal => !terminal.GetConnections().Any()))
                {
                    obj.SetStateFlag(State.ComponentError);
                    obj.Messages.Add("The component does not have connections.");
                    result = false;
                }
            }

            return result;
        }

        private bool CheckForInputs()
        {
            bool result = Workspace.Canvas.Objects.Any(obj => obj is Input);
            if (!result) Workspace.Messages.Add("The model does not have inputs.");
            return result;
        }

        private bool CheckForOutputs()
        {
            bool result = Workspace.Canvas.Objects.Any(obj => obj is Output);
            if (!result) Workspace.Messages.Add("The model does not have outputs.");
            return result;
        }

        private bool CheckForDataLinks()
        {
            bool result = true;
            if (!Workspace.DataTable.HasData())
            {
                Workspace.Messages.Add("The workspace does not have associated input data.");
            }

            foreach (var obj in Workspace.Canvas.Objects)
            {
                switch (obj)
                {
                    case Input input:
                    {
                        if (input.DataLabel == null)
                        {
                            obj.SetStateFlag(State.ComponentError);
                            obj.Messages.Add("The input does not have a data label.");
                            result = false;
                        }

                        break;
                    }

                    case Output output:
                    {
                        if (output.DataLabel == null)
                        {
                            obj.SetStateFlag(State.ComponentError);
                            obj.Messages.Add("The output does not have a data label.");
                            result = false;
                        }

                        break;
                    }

                    default:
                        break;
                }
            }

            return result;
        }

        private bool CheckForActivations()
        {
            bool result = true;
            foreach (var obj in Workspace.Canvas.Objects)
            {
                if (obj is Neuron neuron && neuron is not Input && neuron.Activation is null)
                {
                    obj.SetStateFlag(State.ComponentError);
                    obj.Messages.Add("The neuron does not have an activation function.");
                    result = false;
                }
            }

            return result;
        }

        private bool BuildGraph()
        {
            Graph = new NetworkGraph(this);

            // Get the input layer.
            Workspace.Canvas.Objects
                .Where(obj => obj is Input)
                .OrderBy(obj => obj.Location.Y)
                .ToList()
                .ConvertAll(obj => obj as Input ?? throw new InvalidOperationException())
                .ForEach(Graph.AddInput);

            // Expand the graph.
            Graph.Expand();

            // Verify all the neurons are included in the model.
            BuildResult = Graph.Nodes.Count == Workspace.Canvas.Objects.Count;

            return BuildResult;
        }

        private void CleanObjects()
        {
            Workspace.Messages.Clear();
            foreach (var obj in Workspace.Canvas.Objects)
            {
                if (obj is Neuron neuron) neuron.Node = null;
                obj.ClearStateFlag(State.ComponentStatusMask);
                obj.Messages.Clear();
            }
        }
    }
}
