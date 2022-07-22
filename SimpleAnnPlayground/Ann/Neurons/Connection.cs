// <copyright file="Connection.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Terminals;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents the connection between two components.
    /// </summary>
    internal class Connection
    {
        private const float Width = 0.1f;
        private readonly Color _color = Color.Black;

        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="source">The input terminal in the source component.</param>
        /// <param name="destination">The output terminal in the destination component.</param>
        public Connection(OutputTerminal source, InputTerminal destination)
        {
            Source = source;
            Destination = destination;
        }

        /// <summary>
        /// Gets the source object.
        /// </summary>
        public OutputTerminal Source { get; private set; }

        /// <summary>
        /// Gets the destination object.
        /// </summary>
        public InputTerminal Destination { get; private set; }

        /// <summary>
        /// Paints the connection in a <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        internal void Paint(Graphics graphics)
        {
            using (Pen pen = new Pen(_color, Width))
            {
                graphics.DrawLine(pen, Source.Location, Destination.Location);
            }
        }
    }
}
