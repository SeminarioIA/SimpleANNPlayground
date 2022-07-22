// <copyright file="Internal.cs" company="SeminarioIA">
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
    internal class Internal : CanvasObject, IConnectableInputs, IConnectableOutputs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Internal"/> class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Internal(int x, int y)
            : base(Component.InternalNeuron, x, y)
        {
            Inputs = new Collection<Connection>();
            Outputs = new Collection<Connection>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Internal"/> class.
        /// </summary>
        /// <param name="other">Other object to copy.</param>
        public Internal(Internal other)
            : base(other)
        {
            Inputs = other.Inputs;
            Outputs = other.Outputs;
        }

        /// <summary>
        /// Gets the input connections of this object.
        /// </summary>
        public Collection<Connection> Inputs { get; private set; }

        /// <summary>
        /// Gets the output connections of this object.
        /// </summary>
        public Collection<Connection> Outputs { get; private set; }
    }
}
