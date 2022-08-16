// <copyright file="Connection.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Terminals;
using SimpleAnnPlayground.Graphical.Visualization;
using SimpleAnnPlayground.Utils.Graphics;
using SimpleAnnPlayground.Utils.Serialization.Json;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents the connection between two components.
    /// </summary>
    [JsonConverter(typeof(ConnectionConverter))]
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
        /// <param name="referenceObjects">Reference shadow canvas.</param>
        /// <param name="mode">The creation mode.</param>
        public Connection(Connection other, Collection<CanvasObject> referenceObjects, CreationMode mode)
            : base(other, mode)
        {
            // Get the shadow source terminal.
            CanvasObject shadowSourceOwner = referenceObjects.First(obj => obj.Equals(other.Source.Owner));
            Source = shadowSourceOwner.Outputs[other.Source.Index] ?? throw new ArgumentException("Invalid connection source", nameof(other));
            Source.Connection = this;

            // Get the shadow destination terminal.
            CanvasObject shadowDestinationOwner = referenceObjects.First(obj => obj.Equals(other.Destination.Owner));
            Destination = shadowDestinationOwner.Inputs[other.Destination.Index] ?? throw new ArgumentException("Invalid connection destination", nameof(other));
            Destination.Connection = this;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="source">The input terminal in the source component.</param>
        /// <param name="destination">The output terminal in the destination component.</param>
        public Connection(OutputTerminal source, InputTerminal destination)
        {
            Source = source;
            Source.Connection = this;
            Destination = destination;
            Destination.Connection = this;
        }

        /// <summary>
        /// Gets the source object.
        /// </summary>
        [JsonConverter(typeof(TerminalConverter))]
        public OutputTerminal Source { get; private set; }

        /// <summary>
        /// Gets the destination object.
        /// </summary>
        [JsonConverter(typeof(TerminalConverter))]
        public InputTerminal Destination { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this connection is shadow.
        /// </summary>
        [JsonIgnore]
        public bool IsShadow { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this connection is selected.
        /// </summary>
        [JsonIgnore]
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

            // Draw source connectors.
            graphics.TranslateTransform(Source.Owner.Location.X - Source.Owner.Component.Center.X, Source.Owner.Location.Y - Source.Owner.Component.Center.Y);
            Source.Connector.Paint(graphics, Connector.DrawMode.Connected);
            graphics.TranslateTransform(Source.Owner.Component.Center.X - Source.Owner.Location.X, Source.Owner.Component.Center.Y - Source.Owner.Location.Y);

            // Draw destination connectors.
            graphics.TranslateTransform(Destination.Owner.Location.X - Destination.Owner.Component.Center.X, Destination.Owner.Location.Y - Destination.Owner.Component.Center.Y);
            Destination.Connector.Paint(graphics, Connector.DrawMode.Connected);
            graphics.TranslateTransform(Destination.Owner.Component.Center.X - Destination.Owner.Location.X, Destination.Owner.Component.Center.Y - Destination.Owner.Location.Y);
        }
    }
}
