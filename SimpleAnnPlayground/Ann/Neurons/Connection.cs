// <copyright file="Connection.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents the connection between two components.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="source">The source component.</param>
        /// <param name="input">The input connector in the source component.</param>
        /// <param name="destination">The destination component.</param>
        /// <param name="output">The output connector in the destination component.</param>
        public Connection(Component source, Connector input, Component destination, Connector output)
        {
            Source = source;
            Input = input;
            Destination = destination;
            Output = output;
        }

        /// <summary>
        /// Gets the source component.
        /// </summary>
        public Component Source { get; private set; }

        /// <summary>
        /// Gets the input connector.
        /// </summary>
        public Connector Input { get; private set; }

        /// <summary>
        /// Gets the destination component.
        /// </summary>
        public Component Destination { get; private set; }

        /// <summary>
        /// Gets the output connector.
        /// </summary>
        public Connector Output { get; private set; }
    }
}
