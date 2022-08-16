// <copyright file="Input.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical;
using SimpleAnnPlayground.Graphical.Visualization;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents an internal neurone in a neural network.
    /// </summary>
    internal class Input : Neuron
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        /// <param name="canvas">The containing canvas.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Input(Canvas canvas, int x, int y)
            : base(canvas, Component.InputNeuron, x, y)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        /// <param name="other">Other object to copy.</param>
        /// <param name="mode">The creation mode.</param>
        public Input(Input other, CreationMode mode)
            : base(other, mode)
        {
        }

        /// <inheritdoc/>
        internal override int? UpwardLayer => 1;

        /// <inheritdoc/>
        internal override int? DownwardLayer => 1;
    }
}
