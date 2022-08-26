// <copyright file="Neuron.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
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
        /// <param name="canvas">The containing canvas.</param>
        /// <param name="component">The graphical component linked to this object.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Neuron(Canvas canvas, Component component, int x, int y)
            : base(canvas, component, x, y)
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
        [JsonIgnore]
        public int? Layer => DownwardLayer ?? UpwardLayer;

        /// <summary>
        /// Gets the neuron current layer.
        /// </summary>
        internal abstract int? UpwardLayer { get; }

        /// <summary>
        /// Gets the neuron current layer.
        /// </summary>
        internal abstract int? DownwardLayer { get; }

        /// <summary>
        /// Gets or sets the neuron output value.
        /// </summary>
        internal decimal? Input { get; set; }

        /// <inheritdoc/>
        public override void Paint(Graphics graphics)
        {
            base.Paint(graphics);

            if (Layer is not null and > 0)
            {
                using (var font = new Font("Arial", 8))
                using (var brush = new SolidBrush(Color.Black))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    var location = new PointF(Location.X, Location.Y);
                    graphics.DrawString(Layer.ToString(), font, brush, location, format);
                }
            }

            if (Input is not null)
            {
                using (var font = new Font("Arial", 8))
                using (var brush = new SolidBrush(Color.Black))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far })
                {
                    var location = new PointF(Location.X, Location.Y - Component.Y);
                    graphics.DrawString(Input.ToString(), font, brush, location, format);
                }
            }
        }
    }
}
