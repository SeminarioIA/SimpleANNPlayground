// <copyright file="Link.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// Represents the joint between two nodes.
    /// </summary>
    internal class Link
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Link"/> class.
        /// </summary>
        /// <param name="connection">The <see cref="Connection"/> associated to this <see cref="Link"/>.</param>
        /// <param name="previous">The previous node.</param>
        /// <param name="next">The next node.</param>
        public Link(Connection connection, Node previous, Node next)
        {
            Connection = connection;
            Previous = previous;
            Next = next;
        }

        /// <summary>
        /// Gets the <see cref="Connection"/> associated to this <see cref="Link"/>.
        /// </summary>
        public Connection Connection { get; }

        /// <summary>
        /// Gets the previous <see cref="Node"/> of this <see cref="Link"/>.
        /// </summary>
        public Node Previous { get; }

        /// <summary>
        /// Gets the previous <see cref="Node"/> of this <see cref="Link"/>.
        /// </summary>
        public Node Next { get; }
    }
}
