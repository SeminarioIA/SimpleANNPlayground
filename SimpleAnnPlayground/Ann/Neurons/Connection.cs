// <copyright file="Connection.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Terminals;
using SimpleAnnPlayground.Graphical.Visualization;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents the connection between two components.
    /// </summary>
    internal class Connection : DrawableObject
    {
        private const float Width = 0.1f;
        private readonly Color _color = Color.Black;

        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="other">Other instance to copy.</param>
        /// <param name="shadowCanvas">Reference shadow canvas.</param>
        public Connection(Connection other, ShadowCanvas shadowCanvas)
            : base(other)
        {
            // Get the shadow source terminal.
            CanvasObject shadowSourceOwner = shadowCanvas.GetObjectFromReference(other.Source.Owner) ?? throw new ArgumentException("Invalid connection source", nameof(other));
            int sourceTerminalIndex = other.Source.Owner.Outputs.IndexOf(other.Source);
            Source = shadowSourceOwner.Outputs[sourceTerminalIndex] ?? throw new ArgumentException("Invalid connection source", nameof(other));

            // Get the shadow destination terminal.
            CanvasObject shadowDestinationOwner = shadowCanvas.GetObjectFromReference(other.Destination.Owner) ?? throw new ArgumentException("Invalid connection destination", nameof(other));
            int destinationTerminalIndex = other.Destination.Owner.Inputs.IndexOf(other.Destination);
            Destination = shadowDestinationOwner.Inputs[destinationTerminalIndex] ?? throw new ArgumentException("Invalid connection destination", nameof(other));
        }

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
        /// Gets or sets a value indicating whether this connection is shadow.
        /// </summary>
        public bool IsShadow { get; set; }

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
