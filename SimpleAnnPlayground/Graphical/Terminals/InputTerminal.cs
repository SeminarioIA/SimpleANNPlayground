// <copyright file="InputTerminal.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Visualization;

namespace SimpleAnnPlayground.Graphical.Terminals
{
    /// <summary>
    /// Represents a terminal that accepts only input connections.
    /// </summary>
    internal class InputTerminal : Terminal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputTerminal"/> class.
        /// </summary>
        /// <param name="owner">The owning <see cref="CanvasObject"/>.</param>
        /// <param name="connector">The base connector of type <see cref="Connector.Types.Input"/>.</param>
        /// <exception cref="ArgumentException">If the <paramref name="connector"/> type is different from <see cref="Connector.Types.Input"/>.</exception>
        public InputTerminal(CanvasObject owner, Connector connector)
            : base(owner, connector)
        {
            if (connector.Type != Connector.Types.Input) throw new ArgumentException($"The {nameof(Connector.Type)} must be {Connector.Types.Input}.", nameof(connector));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputTerminal"/> class.
        /// </summary>
        /// <param name="other">The other instance to copy.</param>
        public InputTerminal(InputTerminal other)
            : base(other)
        {
        }

        /// <inheritdoc/>
        public override void Paint(Graphics graphics)
        {
        }
    }
}
