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
        /// <param name="graph">The parent graph for this node.</param>
        /// <param name="neuron">The neuron associated to this node.</param>
        public Node(Graph graph, Neuron neuron)
        {
            Graph = graph;
            Neuron = neuron;
            Next = new List<Node>();
            Previous = new List<Node>();
        }

        /// <summary>
        /// Gets the parent graph for this node.
        /// </summary>
        public Graph Graph { get; }

        /// <summary>
        /// Gets the neuron associated to this node.
        /// </summary>
        public Neuron Neuron { get; }

        /// <summary>
        /// Gets the next list of nodes connected to this node.
        /// </summary>
        public List<Node> Next { get; }

        /// <summary>
        /// Gets the previous list of nodes connected to this node.
        /// </summary>
        public List<Node> Previous { get; }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is Node other && other.Neuron == Neuron;

        /// <inheritdoc/>
        public override int GetHashCode() => Neuron.GetHashCode();

        /// <summary>
        /// Expands the node from itself.
        /// </summary>
        internal void Expand()
        {
            foreach (var output in Neuron.Outputs)
            {
                foreach (var connection in output.GetConnections().OrderBy(conn => conn.Source.Owner.Location.Y))
                {
                    if (connection.Destination.Owner is Neuron neuron)
                    {
                        // Check if the node already exists.
                        Node? node = Graph.Nodes.FirstOrDefault(n => n.Neuron == neuron);
                        if (node == null)
                        {
                            // Create a new node.
                            node = new Node(Graph, neuron);
                            Graph.Nodes.Add(node);

                            // Expand the node.
                            node.Expand();
                        }

                        // Register the nodes.
                        Next.Add(node);
                        node.Previous.Add(this);
                    }
                }
            }
        }
    }
}
