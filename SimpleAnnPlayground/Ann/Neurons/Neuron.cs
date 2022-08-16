// <copyright file="Neuron.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical;
using SimpleAnnPlayground.Graphical.Visualization;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents a neuron in the draw.
    /// </summary>
    internal abstract class Neuron : CanvasObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Neuron"/> class.
        /// </summary>
        /// <param name="component">The graphical component linked to this object.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Neuron(Component component, int x, int y)
            : base(component, x, y)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Neuron"/> class.
        /// </summary>
        /// <param name="other">Other object to copy.</param>
        /// <param name="mode">The creation mode.</param>
        public Neuron(Neuron other, CreationMode mode)
            : base(other, mode)
        {
        }

        /// <summary>
        /// Gets the neuron current layer.
        /// </summary>
        public int? Layer => DownwardLayer ?? UpwardLayer;

        /// <summary>
        /// Gets the neuron current layer.
        /// </summary>
        internal abstract int? UpwardLayer { get; }

        /// <summary>
        /// Gets the neuron current layer.
        /// </summary>
        internal abstract int? DownwardLayer { get; }
    }
}
