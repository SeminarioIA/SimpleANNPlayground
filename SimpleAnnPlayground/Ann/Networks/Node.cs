// <copyright file="Node.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// Represents a node of a neural network graph.
    /// </summary>
    internal class Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="layer">The parent layer for this node.</param>
        /// <param name="neuron">The neuron associated to this node.</param>
        public Node(Layer layer, Neuron neuron)
        {
            Layer = layer;
            Neuron = neuron;
            Next = new List<Link>();
            Previous = new List<Link>();
        }

        /// <summary>
        /// Gets the parent layer for this node.
        /// </summary>
        public Layer Layer { get; }

        /// <summary>
        /// Gets the neuron associated to this node.
        /// </summary>
        public Neuron Neuron { get; }

        /// <summary>
        /// Gets the next list of links to nodes connected to this node.
        /// </summary>
        public List<Link> Next { get; }

        /// <summary>
        /// Gets the previous list of links to nodes connected to this node.
        /// </summary>
        public List<Link> Previous { get; }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is Node other && other.Neuron == Neuron;

        /// <inheritdoc/>
        public override int GetHashCode() => Neuron.GetHashCode();

        /// <summary>
        /// Expands the node from itself.
        /// </summary>
        /// <param name="nextLayer">The next layer to expand.</param>
        internal void Expand(Layer nextLayer)
        {
            foreach (var output in Neuron.Outputs)
            {
                // Iterate the connection in destination order.
                foreach (var connection in output.GetConnections().OrderBy(conn => conn.Destination.Owner.Location.Y))
                {
                    // Add the node.
                    if (connection.Destination.Owner is Neuron neuron)
                    {
                        // Check if the node already exists.
                        Node? node = nextLayer.Nodes.FirstOrDefault(n => n.Neuron == neuron);
                        if (node == null)
                        {
                            // Create a new node.
                            node = new Node(nextLayer, neuron);
                            nextLayer.Nodes.Add(node);
                            Layer.Graph.Nodes.Add(node);
                        }

                        // Add the link.
                        var link = new Link(connection, this, node);

                        // Register the link with the nodes.
                        Next.Add(link);
                        node.Previous.Add(link);
                    }
                }
            }
        }
    }
}
