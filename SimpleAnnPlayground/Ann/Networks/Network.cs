// <copyright file="Network.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Environment;
using static SimpleAnnPlayground.Graphical.Component;

namespace SimpleAnnPlayground.Ann.Networks
{
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
        }

        /// <summary>
        /// Gets the workspace containing the elements to build the network.
        /// </summary>
        public Workspace Workspace { get; }

        /// <summary>
        /// Gets the network graph.
        /// </summary>
        public Graph? Graph { get; private set; }

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

        private bool BuildGraph()
        {
            Graph = new Graph(this);

            // Get the input layer
            Workspace.Canvas.Objects
                .Where(obj => obj is Input)
                .OrderBy(obj => obj.Location.Y)
                .Select(obj => obj as Input)
                .ToList()
                .ForEach(Graph.AddInput);

            // Expand the graph
            Graph.Expand();

            return Graph.Nodes.Count == Workspace.Canvas.Objects.Count;
        }

        private void CleanObjects()
        {
            Workspace.Messages.Clear();
            foreach (var obj in Workspace.Canvas.Objects)
            {
                obj.ClearStateFlag(State.ComponentStatusMask);
                obj.Messages.Clear();
            }
        }
    }
}
