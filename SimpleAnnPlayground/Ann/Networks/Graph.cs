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
            Layers = new List<Layer>
            {
                new Layer(this),
            };
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
        /// Gets the list of all the layers in this graph.
        /// </summary>
        public List<Layer> Layers { get; }

        /// <summary>
        /// Gets the input layer.
        /// </summary>
        public Layer InputLayer => Layers.First();

        /// <summary>
        /// Adds a neuron as an input to the graph.
        /// </summary>
        /// <param name="inputNeuron">The input neuron.</param>
        internal void AddInput(Input inputNeuron)
        {
            var node = new Node(InputLayer, inputNeuron);
            InputLayer.Nodes.Add(node);
            Nodes.Add(node);
        }

        /// <summary>
        /// Expands the graph from the input nodes.
        /// </summary>
        internal void Expand()
        {
            if (!InputLayer.Nodes.Any()) return;
            InputLayer.Expand();
        }
    }
}
