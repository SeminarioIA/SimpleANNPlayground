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
            bool result = true;
            result &= CheckUnconnected();
            if (result) result &= CheckForInputs();
            if (result) result &= CheckForOutputs();
            if (result) result &= CheckForDataLinks();
            if (result) result &= BuildGraph();
            Workspace.Refresh();
            return result;
        }

        /// <summary>
        /// Cleans all the objects messages.
        /// </summary>
        public void Clean()
        {
            foreach (var obj in Workspace.Canvas.Objects)
            {
                obj.ClearStateFlag(State.ComponentStatusMask);
            }

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
                    result = false;
                }
            }

            return result;
        }

        private bool CheckForInputs()
        {
            return Workspace.Canvas.Objects.Any(obj => obj is Input);
        }

        private bool CheckForOutputs()
        {
            return Workspace.Canvas.Objects.Any(obj => obj is Output);
        }

        private bool CheckForDataLinks()
        {
            bool result = true;

            foreach (var obj in Workspace.Canvas.Objects)
            {
                switch (obj)
                {
                    case Input input:
                    {
                        if (input.DataLabel == null)
                        {
                            obj.SetStateFlag(State.ComponentError);
                            result = false;
                        }

                        break;
                    }

                    case Output output:
                    {
                        if (output.DataLabel == null)
                        {
                            obj.SetStateFlag(State.ComponentError);
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
    }
}
