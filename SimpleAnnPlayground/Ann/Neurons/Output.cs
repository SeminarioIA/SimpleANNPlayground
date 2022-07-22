﻿// <copyright file="Output.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents an internal neurone in a neural network.
    /// </summary>
    internal class Output : CanvasObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Output"/> class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Output(int x, int y)
            : base(Component.OutputNeuron, x, y)
        {
            Inputs = new Collection<Connection>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Output"/> class.
        /// </summary>
        /// <param name="other">Other object to copy.</param>
        public Output(Output other)
            : base(other)
        {
            Inputs = other.Inputs;
        }

        /// <summary>
        /// Gets the input connections of this object.
        /// </summary>
        public Collection<Connection> Inputs { get; private set; }
    }
}
