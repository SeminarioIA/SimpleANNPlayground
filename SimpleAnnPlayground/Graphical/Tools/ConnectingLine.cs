// <copyright file="ConnectingLine.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;

namespace SimpleAnnPlayground.Graphical.Tools
{
    /// <summary>
    /// Helper class to connect two connectors.
    /// </summary>
    internal class ConnectingLine
    {
        private const float Width = 0.1f;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectingLine"/> class.
        /// </summary>
        /// <param name="source">The source object for the connection.</param>
        /// <param name="start">The start connector.</param>
        public ConnectingLine(CanvasObject source, Connector start)
        {
            Source = source;
            Start = start;
            StartPoint = Source.GetAbsolute(Start.Location);
            EndPoint = StartPoint;
            Type = Start.Type == Connector.Types.Input ? Connector.Types.Output : Connector.Types.Input;
        }

        /// <summary>
        /// Gets the destination connection type.
        /// </summary>
        public Connector.Types Type { get; }

        /// <summary>
        /// Gets the source object of the connection.
        /// </summary>
        public CanvasObject Source { get; }

        /// <summary>
        /// Gets the start connector.
        /// </summary>
        public Connector Start { get; }

        /// <summary>
        /// Gets the start point for the connecting line.
        /// </summary>
        public PointF StartPoint { get; }

        /// <summary>
        /// Gets the source object of the connection.
        /// </summary>
        public CanvasObject? Destination { get; private set; }

        /// <summary>
        /// Gets the start connector.
        /// </summary>
        public Connector? End { get; private set; }

        /// <summary>
        /// Gets the end point for the connecting line.
        /// </summary>
        public PointF EndPoint { get; private set; }

        /// <summary>
        /// Updates the mouse location.
        /// </summary>
        /// <param name="location">The current mouse location.</param>
        /// <param name="destination">The current destination object.</param>
        public void Update(PointF location, CanvasObject? destination)
        {
            EndPoint = location;
            Destination = destination;
            End = destination?.ActiveConnector;
        }

        /// <summary>
        /// Ends the connection and returns a new connection object if was successful.
        /// </summary>
        /// <returns>The connection object.</returns>
        public Connection? Finish()
        {
            return Destination != null && End != null
                ? End.Type == Connector.Types.Input
                    ? new Connection(Destination, End, Source, Start)
                    : new Connection(Source, Start, Destination, End)
                : null;
        }

        /// <summary>
        /// Paints the connection line in the given <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">To paint the line.</param>
        internal void Paint(Graphics graphics)
        {
            Color color = Start.Type == Connector.Types.Input ? Connector.InputColor : Connector.OutputColor;
            using (Pen pen = new Pen(color, Width))
            {
                graphics.DrawLine(pen, StartPoint, EndPoint);
            }
        }
    }
}
