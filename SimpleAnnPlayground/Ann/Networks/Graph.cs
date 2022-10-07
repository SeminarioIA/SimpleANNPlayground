// <copyright file="Graph.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// Represents a neural network graph.
    /// </summary>
    internal abstract class Graph
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Graph"/> class.
        /// </summary>
        public Graph()
        {
            Nodes = new List<Node>();
            Links = new List<Link>();
            Layers = new List<Layer>();
        }

        /// <summary>
        /// Gets the list of all the nodes in this graph.
        /// </summary>
        public List<Node> Nodes { get; }

        /// <summary>
        /// Gets the list of all the links in this graph.
        /// </summary>
        public List<Link> Links { get; }

        /// <summary>
        /// Gets the list of all the layers in this graph.
        /// </summary>
        public List<Layer> Layers { get; }

        /// <summary>
        /// Gets the input layer.
        /// </summary>
        public Layer InputLayer => Layers.First();
    }
}
