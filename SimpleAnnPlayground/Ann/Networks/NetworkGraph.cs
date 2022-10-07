// <copyright file="NetworkGraph.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// Represents a neural network graph.
    /// </summary>
    internal class NetworkGraph : Graph
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkGraph"/> class.
        /// </summary>
        /// <param name="network">The network that owns the graph.</param>
        public NetworkGraph(Network network)
        {
            Network = network;
            Layers.Add(new Layer(this));
        }

        /// <summary>
        /// Gets the <see cref="Network"/> that owns this <see cref="Graph"/>.
        /// </summary>
        public Network Network { get; }

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
