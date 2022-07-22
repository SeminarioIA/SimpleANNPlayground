// <copyright file="Input.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical;
using SimpleAnnPlayground.Graphical.Interfaces;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents an internal neurone in a neural network.
    /// </summary>
    internal class Input : CanvasObject, IConnectableOutputs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Input(int x, int y)
            : base(Component.InputNeuron, x, y)
        {
            Outputs = new Collection<Connection>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        /// <param name="other">Other object to copy.</param>
        public Input(Input other)
            : base(other)
        {
            Outputs = other.Outputs;
        }

        /// <summary>
        /// Gets the output connections of this object.
        /// </summary>
        public Collection<Connection> Outputs { get; private set; }
    }
}
