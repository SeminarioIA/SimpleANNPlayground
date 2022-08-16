// <copyright file="Graph.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// Represents a neural network graph.
    /// </summary>
    internal class Graph
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Graph"/> class.
        /// </summary>
        /// <param name="network">The network that owns the graph.</param>
        public Graph(Network network)
        {
            Network = network;
            Nodes = new List<Node>();
            Inputs = new List<Node>();
        }

        /// <summary>
        /// Gets the <see cref="Network"/> that owns this <see cref="Graph"/>.
        /// </summary>
        public Network Network { get; }

        /// <summary>
        /// Gets the list of all the nodes in this graph.
        /// </summary>
        public List<Node> Nodes { get; }

        /// <summary>
        /// Gets the list of nodes for the input layer.
        /// </summary>
        public List<Node> Inputs { get; }

        /// <summary>
        /// Adds a neuron as an input to the graph.
        /// </summary>
        /// <param name="inputNeuron">The input neuron.</param>
        internal void AddInput(Input? inputNeuron)
        {
            if (inputNeuron == null) return;
            var node = new Node(this, inputNeuron);
            Inputs.Add(node);
            Nodes.Add(node);
        }

        /// <summary>
        /// Expands the graph from the input nodes.
        /// </summary>
        internal void Expand()
        {
            if (!Inputs.Any()) return;

            foreach (var node in Inputs)
            {
                node.Expand();
            }
        }
    }
}
