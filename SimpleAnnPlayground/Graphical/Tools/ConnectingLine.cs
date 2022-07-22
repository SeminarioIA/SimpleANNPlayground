// <copyright file="ConnectingLine.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Terminals;

namespace SimpleAnnPlayground.Graphical.Tools
{
    /// <summary>
    /// Helper class to connect two connectors.
    /// </summary>
    internal class ConnectingLine
    {
        private const float Width = 0.1f;

        /// <summary>
        /// Gets the end point for the connecting line.
        /// </summary>
        private PointF _endPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectingLine"/> class.
        /// </summary>
        /// <param name="startTerminal">The terminal object for the connection.</param>
        public ConnectingLine(Terminal startTerminal)
        {
            Start = startTerminal;
            _endPoint = Start.Location;
            Type = Start is InputTerminal ? Connector.Types.Output : Connector.Types.Input;
        }

        /// <summary>
        /// Gets the destination connection type.
        /// </summary>
        public Connector.Types Type { get; }

        /// <summary>
        /// Gets the start terminal.
        /// </summary>
        public Terminal Start { get; }

        /// <summary>
        /// Gets the end terminal.
        /// </summary>
        public Terminal? End { get; private set; }

        /// <summary>
        /// Updates the mouse location.
        /// </summary>
        /// <param name="location">The current mouse location.</param>
        /// <param name="end">The current end terminal.</param>
        public void Update(PointF location, Terminal? end)
        {
            _endPoint = location;
            End = end;
        }

        /// <summary>
        /// Ends the connection and returns a new connection object if was successful.
        /// </summary>
        /// <returns>The connection object.</returns>
        public Connection? Finish()
        {
            if (Start is OutputTerminal start && End is InputTerminal end)
            {
                return new Connection(start, end);
            }
            else if (End is OutputTerminal start2 && Start is InputTerminal end2)
            {
                return new Connection(start2, end2);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Paints the connection line in the given <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">To paint the line.</param>
        internal void Paint(Graphics graphics)
        {
            Color color = Start is InputTerminal ? Connector.InputColor : Connector.OutputColor;
            using (Pen pen = new Pen(color, Width))
            {
                graphics.DrawLine(pen, Start.Location, _endPoint);
            }
        }
    }
}
