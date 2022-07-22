// <copyright file="OutputTerminal.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Visualization;

namespace SimpleAnnPlayground.Graphical.Terminals
{
    /// <summary>
    /// Represents a terminal that accepts only output connections.
    /// </summary>
    internal class OutputTerminal : Terminal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputTerminal"/> class.
        /// </summary>
        /// <param name="owner">The owning <see cref="CanvasObject"/>.</param>
        /// <param name="connector">The base connector of type <see cref="Connector.Types.Output"/>.</param>
        /// <exception cref="ArgumentException">If the <paramref name="connector"/> type is different from <see cref="Connector.Types.Output"/>.</exception>
        public OutputTerminal(CanvasObject owner, Connector connector)
            : base(owner, connector)
        {
            if (connector.Type != Connector.Types.Output) throw new ArgumentException($"The {nameof(Connector.Type)} must be {Connector.Types.Output}.", nameof(connector));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputTerminal"/> class.
        /// </summary>
        /// <param name="other">The object to copy.</param>
        public OutputTerminal(OutputTerminal other)
            : base(other)
        {
        }

        /// <inheritdoc/>
        public override void Paint(Graphics graphics)
        {
        }
    }
}
