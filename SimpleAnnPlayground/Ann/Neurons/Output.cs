// <copyright file="Output.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Graphical;
using SimpleAnnPlayground.Graphical.Visualization;
using System.Text.Json.Serialization;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents an internal neurone in a neural network.
    /// </summary>
    internal class Output : Neuron
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Output"/> class.
        /// </summary>
        /// <param name="canvas">The containing canvas.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Output(Canvas canvas, int x, int y)
            : base(canvas, Component.OutputNeuron, x, y)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Output"/> class.
        /// </summary>
        /// <param name="other">Other object to copy.</param>
        /// <param name="mode">The creation mode.</param>
        public Output(Output other, CreationMode mode)
            : base(other, mode)
        {
        }

        /// <inheritdoc/>
        internal override int? UpwardLayer => -1;

        /// <inheritdoc/>
        internal override int? DownwardLayer => (Inputs.FirstOrDefault(input => input.IsConnected)?.AnyConnection?.Source.Owner as Neuron)?.DownwardLayer + 1;

        /// <summary>
        /// Gets or sets the linked data label.
        /// </summary>
        [JsonInclude]
        internal DataLabel? DataLabel { get; set; }

        /// <inheritdoc/>
        public override void Paint(Graphics graphics)
        {
            base.Paint(graphics);
            if (DataLabel != null)
            {
                using (var font = new Font("Arial", 8))
                using (var brush = new SolidBrush(Color.Black))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
                {
                    var location = new PointF(Location.X + Component.X, Location.Y);
                    graphics.DrawString(DataLabel.Text, font, brush, location, format);
                }
            }
        }
    }
}
