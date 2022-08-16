// <copyright file="Internal.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents an internal neurone in a neural network.
    /// </summary>
    internal class Internal : Neuron
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Internal"/> class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Internal(int x, int y)
            : base(Component.InternalNeuron, x, y)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Internal"/> class.
        /// </summary>
        /// <param name="other">Other object to copy.</param>
        /// <param name="mode">The creation mode.</param>
        public Internal(Internal other, CreationMode mode)
            : base(other, mode)
        {
        }

        /// <inheritdoc/>
        internal override int? UpwardLayer => (Outputs.FirstOrDefault(output => output.Connection != null)?.Connection?.Destination.Owner as Neuron)?.UpwardLayer - 1;

        /// <inheritdoc/>
        internal override int? DownwardLayer => (Inputs.FirstOrDefault(input => input.Connection != null)?.Connection?.Source.Owner as Neuron)?.DownwardLayer + 1;
    }
}
