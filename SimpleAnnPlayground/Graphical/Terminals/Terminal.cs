// <copyright file="Terminal.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

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
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terminal"/> class.
        /// </summary>
        /// <param name="owner">The owning <see cref="CanvasObject"/>.</param>
        /// <param name="connector">The base connector.</param>
        protected Terminal(CanvasObject owner, Connector connector)
        {
            Owner = owner;
            Connector = connector;
        }

        /// <summary>
        /// Enumerates the graphical states of a <see cref="Terminal"/>.
        /// </summary>
        [Flags]
        public enum GraphState
        {
            /// <summary>
            /// The default common state.
            /// </summary>
            None = 0,

            /// <summary>
            /// The <see cref="Terminal"/> is being hover by the mouse.
            /// </summary>
            Hover = 1,

            /// <summary>
            /// The <see cref="Terminal"/> is being selected.
            /// </summary>
            Selected = 2,

            /// <summary>
            /// The <see cref="Terminal"/> is has connections.
            /// </summary>
            Connected = 4,
        }

        /// <summary>
        /// Gets the <see cref="Terminal"/> graphical state.
        /// </summary>
        public GraphState State { get; private set; }

        /// <summary>
        /// Gets the owner object of this terminal.
        /// </summary>
        public CanvasObject Owner { get; }

        /// <summary>
        /// Gets the base connector for this terminal.
        /// </summary>
        public Connector Connector { get; }

        /// <summary>
        /// Gets the location if this terminal.
        /// </summary>
        public PointF Location => Owner.GetAbsolute(Connector.Location);

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
        /// Paints this terminal in a <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">The graphics to paint.</param>
        public abstract void Paint(Graphics graphics);
    }
}
