// <copyright file="ConnectingLine.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Terminals;
using SimpleAnnPlayground.Graphical.Visualization;

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
        /// <param name="workspace">The workspace where the connection is performed.</param>
        /// <param name="startTerminal">The terminal object for the connection.</param>
        public ConnectingLine(Workspace workspace, Terminal startTerminal)
        {
            Workspace = workspace;
            Start = startTerminal;
            _endPoint = Start.Location;
            Type = Start is InputTerminal ? Connector.Types.Output : Connector.Types.Input;
        }

        /// <summary>
        /// Gets the destination connection type.
        /// </summary>
        public Connector.Types Type { get; }

        /// <summary>
        /// Gets the workspace where the connection is performed.
        /// </summary>
        public Workspace Workspace { get; }

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
                return null;
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

        /// <summary>
        /// Determines the active terminal for the connection.
        /// </summary>
        /// <param name="obj">The object being connected.</param>
        /// <param name="location">The location relative to the object.</param>
        /// <returns>The active terminal for the connection.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        internal Terminal? GetActiveTerminal(CanvasObject obj, PointF location)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (obj is Neuron neuron && Start.Owner is Neuron start)
            {
                if (Type == Connector.Types.Input)
                {
                    // Verify the layers are consecutive.
                    if (start.Layer != null && neuron.Layer != null && neuron.Layer > 0 && neuron.Layer != start.Layer + 1) return null;

                    // TODO: Look for the nearest terminal.
                    foreach (var terminal in neuron.Inputs)
                    {
                        // Verify if the terminals are already connected.
                        if (!Workspace.Canvas.Connections.Any(conn => conn.IsConnecting(Start, terminal))) return terminal;
                    }
                }
                else if (Type == Connector.Types.Output)
                {
                    // Verify the layers are consecutive.
                    if (start.Layer != null && neuron.Layer != null && start.Layer > 0 && neuron.Layer != start.Layer - 1) return null;

                    // TODO: Look for the nearest terminal.
                    foreach (var terminal in neuron.Outputs)
                    {
                        if (!Workspace.Canvas.Connections.Any(conn => conn.IsConnecting(Start, terminal))) return terminal;
                    }
                }
            }

            return null;
        }
    }
}
