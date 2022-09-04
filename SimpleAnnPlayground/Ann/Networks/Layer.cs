// <copyright file="Layer.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// Represents a layer in the network.
    /// </summary>
    internal class Layer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Layer"/> class.
        /// </summary>
        /// <param name="graph">The parent graph for this layer.</param>
        public Layer(Graph graph)
        {
            Graph = graph;
            Nodes = new Collection<Node>();
        }

        /// <summary>
        /// Gets the parent graph for this node.
        /// </summary>
        public Graph Graph { get; }

        /// <summary>
        /// Gets the collection of nodes of this <see cref="Layer"/>.
        /// </summary>
        public Collection<Node> Nodes { get; }

        /// <summary>
        /// Gets the next Layer.
        /// </summary>
        public Layer? Next { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the layer is an output layer.
        /// </summary>
        public bool IsOutput => Nodes.First().Neuron is Output;

        /// <summary>
        /// Expands the layer nodes to find the next layer.
        /// </summary>
        internal void Expand()
        {
            var nextLayer = new Layer(Graph);
            Next = nextLayer;
            Graph.Layers.Add(nextLayer);
            foreach (var node in Nodes)
            {
                node.Expand(nextLayer);
            }

            // Expand the next layer.
            if (!nextLayer.IsOutput) nextLayer.Expand();
        }
    }
}
