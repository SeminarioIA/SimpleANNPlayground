// <copyright file="Connection.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Terminals;
using SimpleAnnPlayground.Graphical.Visualization;
using SimpleAnnPlayground.Utils;
using System.Drawing.Drawing2D;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents the connection between two components.
    /// </summary>
    internal class Connection : DrawableObject
    {
        private const float Width = 0.1f;
        private const float SelectionWidth = 2f;
        private readonly Color _color = Color.Black;
        private readonly Color _selectColor = Color.Blue;

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
        /// Gets or sets a value indicating whether this connection is selected.
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Determines if a point is near enough to the connection line.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <returns>True if the point is near, otherwise false.</returns>
        internal bool HasPoint(PointF point)
        {
            // Order the line segment points.
            (PointF start, PointF end) = Space.OrderPointsInX(Source.Location, Destination.Location);

            // Check if the line orientation.
            if (Space.InRange(end.X - start.X, -SelectionWidth, SelectionWidth))
            {
                // If the line is vertical.
                return Space.InRange(point, Math.Min(start.X, end.X) - SelectionWidth, start.Y, Math.Max(start.X, end.X) + SelectionWidth, end.Y);
            }
            else if (Space.InRange(end.Y - start.Y, -SelectionWidth, SelectionWidth))
            {
                // If the line is horizontal.
                return Space.InRange(point, start.X, Math.Min(start.Y, end.Y) - SelectionWidth, end.X, Math.Max(start.Y, end.Y) + SelectionWidth);
            }
            else if (!Space.InRange(point, start, end))
            {
                // If the line is not horizontal/vertical and the point is far.
                return false;
            }

            // Check what kind of angle the l
            if (Space.IsCloseXAngle(start, end))
            {
                float y = Space.GetYIntersection(point, start, end);
                return Space.InRange(point.Y, y - SelectionWidth, y + SelectionWidth);
            }
            else
            {
                float x = Space.GetXIntersection(point, start, end);
                return Space.InRange(point.X, x - SelectionWidth, x + SelectionWidth);
            }
        }

        /// <summary>
        /// Paints the connection in a <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        internal void Paint(Graphics graphics)
        {
            using (Pen pen = new Pen(IsSelected ? _selectColor : _color, Width))
            {
                graphics.DrawLine(pen, Source.Location, Destination.Location);
            }
        }
    }
}
