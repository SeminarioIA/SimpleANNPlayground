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
    internal class Input : CanvasObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Input(int x, int y)
            : base(Component.InputNeuron, x, y)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        /// <param name="other">Other object to copy.</param>
        public Input(Input other)
            : base(other)
        {
        }
    }
}
