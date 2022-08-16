// <copyright file="Terminal.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Visualization;

namespace SimpleAnnPlayground.Graphical.Terminals
{
    /// <summary>
    /// Represents a neuron terminal for connecting with other neurons.
    /// </summary>
    internal abstract class Terminal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Terminal"/> class.
        /// </summary>
        /// <param name="other">The other instance to copy.</param>
        public Terminal(Terminal other)
        {
            Owner = other.Owner;
            Connector = other.Connector;
            Index = other.Index;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terminal"/> class.
        /// </summary>
        /// <param name="owner">The owning <see cref="CanvasObject"/>.</param>
        /// <param name="connector">The base connector.</param>
        /// <param name="index">The terminal index.</param>
        protected Terminal(CanvasObject owner, Connector connector, int index)
        {
            Owner = owner;
            Connector = connector;
            Index = index;
        }

        /// <summary>
        /// Gets the owner object of this terminal.
        /// </summary>
        [JsonIgnore]
        public CanvasObject Owner { get; }

        /// <summary>
        /// Gets the index of this <see cref="Terminal"/>.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// Gets the base connector for this terminal.
        /// </summary>
        [JsonIgnore]
        public Connector Connector { get; }

        /// <summary>
        /// Gets the location if this terminal.
        /// </summary>
        [JsonIgnore]
        public PointF Location => Owner.GetAbsolute(Connector.Location);

        /// <summary>
        /// Gets a value indicating whether if the terminal is connected.
        /// </summary>
        public bool IsConnected => Owner.Canvas.Connections.Any(conn => conn.HasTerminal(this));

        /// <summary>
        /// Gets any connection linked to this terminal.
        /// </summary>
        public Connection? AnyConnection => Owner.Canvas.Connections.FirstOrDefault(conn => conn.HasTerminal(this));

        /// <summary>
        /// Creates a copy from a given <see cref="Terminal"/>.
        /// </summary>
        /// <param name="other">The object to copy.</param>
        /// <returns>A new copy of <paramref name="other"/>.</returns>
        public static Terminal Copy(Terminal other)
        {
            return Activator.CreateInstance(other.GetType(), other) as Terminal ?? throw new NotImplementedException();
        }

        /// <summary>
        /// Determines all the connections realated to this terminal.
        /// </summary>
        /// <returns>A list of all the connections.</returns>
        public List<Connection> GetConnections()
        {
            var connections = new List<Connection>();
            foreach (var conn in Owner.Canvas.Connections)
            {
                if (conn.Source == this || conn.Destination == this) connections.Add(conn);
            }

            return connections;
        }
    }
}
