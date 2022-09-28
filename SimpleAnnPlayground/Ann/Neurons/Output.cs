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

        /// <summary>
        /// Gets or sets the expected output value during the training.
        /// </summary>
        public decimal? Y { get; set; }

        /// <summary>
        /// Gets or sets the expected output value during the training.
        /// </summary>
        public decimal? MSE { get; set; }

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
            if (DataLabel is not null)
            {
                string text = Y is not null ? $"{DataLabel.Text} ({Y})" : DataLabel.Text;
                using (var font = new Font("Arial", 8))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
                {
                    using (var brush = new SolidBrush(Color.Black))
                    {
                        var location = new PointF(Location.X + Component.X, Location.Y);
                        graphics.DrawString(text, font, brush, location, format);
                    }

                    if (MSE is not null)
                    {
                        float width = graphics.MeasureString(text, font).Width;
                        string mseText = $" MSE: {MSE:F4}";
                        using (var brush = new SolidBrush(Color.Red))
                        {
                            var location = new PointF(Location.X + Component.X + width, Location.Y);
                            graphics.DrawString(mseText, font, brush, location, format);
                        }
                    }
                }
            }
        }
    }
}
