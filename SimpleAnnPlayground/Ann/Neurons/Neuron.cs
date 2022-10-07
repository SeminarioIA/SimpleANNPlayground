// <copyright file="Neuron.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Ann.Activation;
using SimpleAnnPlayground.Ann.Networks;
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
        /// <param name="initBias">Initialization bias.</param>
        public Neuron(Canvas canvas, Component component, int x, int y, decimal initBias = 0m)
            : base(canvas, component, x, y)
        {
            InitBias = initBias;
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
        /// Gets or sets the neuron bias value.
        /// </summary>
        [JsonIgnore]
        public decimal? Bias { get; set; }

        /// <summary>
        /// Gets or sets the neuron bias value.
        /// </summary>
        public decimal InitBias { get; set; }

        /// <summary>
        /// Gets or sets the neuron bias value.
        /// </summary>
        [JsonIgnore]
        public decimal? BiasCorrection { get; set; }

        /// <summary>
        /// Gets or sets the neuron bias value.
        /// </summary>
        public decimal? Z { get; set; }

        /// <summary>
        /// Gets or sets the neuron bias value.
        /// </summary>
        public decimal? A { get; set; }

        /// <summary>
        /// Gets or sets the output error.
        /// </summary>
        public decimal? Error { get; set; }

        /// <summary>
        /// Gets or sets the correction value.
        /// </summary>
        public decimal? Correction { get; set; }

        /// <summary>
        /// Gets the neuron current layer.
        /// </summary>
        internal abstract int? UpwardLayer { get; }

        /// <summary>
        /// Gets the neuron current layer.
        /// </summary>
        internal abstract int? DownwardLayer { get; }

        /// <summary>
        /// Gets or sets the activation function for this neurone.
        /// </summary>
        internal ActivationFunction? Activation { get; set; }

        /// <summary>
        /// Gets or sets the graph node linked to this neuron.
        /// </summary>
        internal Node? Node { get; set; }

        /// <inheritdoc/>
        public override void Paint(Graphics graphics)
        {
            base.Paint(graphics);

            if (Layer is not null and > 0)
            {
                using (var font = new Font("Arial", 6))
                using (var brush = new SolidBrush(Color.Black))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    var location = new PointF(Location.X - 3f, Location.Y - 9f);
                    graphics.DrawString(Layer.ToString(), font, brush, location, format);
                }
            }

            if (Bias is not null)
            {
                string text = BiasCorrection is not null ? $"b={Bias:F4}\nb'={BiasCorrection:F4}" : Z is not null ? $"b={Bias:F4}\nZ={Z:F4}" : $"b={Bias:F4}";
                using (var font = new Font("Arial", 8))
                using (var brush = new SolidBrush(Color.Black))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far })
                {
                    var location = new PointF(Location.X, Location.Y - Component.Y);
                    graphics.DrawString(text, font, brush, location, format);
                }
            }

            if (A is not null)
            {
                using (var font = new Font("Arial", 8))
                using (var brush = new SolidBrush(Color.Black))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
                {
                    var location = new PointF(Location.X, Location.Y + Component.Y);
                    graphics.DrawString($"a={A:F4}", font, brush, location, format);
                }
            }

            if (Error is not null)
            {
                using (var font = new Font("Arial", 8))
                using (var brush = new SolidBrush(Color.Red))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
                {
                    var location = new PointF(Location.X, Location.Y + Component.Y + font.Size + 2);
                    graphics.DrawString($"e={Error:F4}", font, brush, location, format);
                }
            }

            if (Correction is not null)
            {
                using (var font = new Font("Arial", 8))
                using (var brush = new SolidBrush(Color.Blue))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
                {
                    int offset = (int)((Error is null ? 0 : font.Size + 2) + (A is null ? 0 : font.Size + 2));
                    var location = new PointF(Location.X, Location.Y + Component.Y + offset);
                    graphics.DrawString($"c={Correction:F4}", font, brush, location, format);
                }
            }

            if (Activation is not null)
            {
                graphics.TranslateTransform(Location.X, Location.Y);
                Activation.Paint(graphics);
                graphics.TranslateTransform(-Location.X, -Location.Y);
            }
        }

        /// <summary>
        /// Paints the neuron output detail.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        /// <param name="subGraph">The neuron graph.</param>
        public virtual void PaintOutput(Graphics graphics, SubGraph subGraph)
        {
            const int width = 50, height = 50;
            Rectangle rect = new Rectangle(Location.X - width / 2, Location.Y - height / 2, width, height);
            using (Brush brush = new SolidBrush(Color.White))
            using (Pen pen = new Pen(Color.Black, 0.01f))
            {
                graphics.FillRectangle(brush, rect);
                graphics.DrawRectangle(pen, rect);
            }

            subGraph.Paint(graphics, rect);
        }

        /// <summary>
        /// Adds a value to the neuron.
        /// </summary>
        /// <param name="previous">Previous output value.</param>
        /// <param name="weight">The connection weight.</param>
        public virtual void AddValue(decimal? previous, decimal? weight)
        {
            if (previous is null) throw new ArgumentNullException(nameof(previous));
            if (weight is null) throw new ArgumentNullException(nameof(weight));
            Z += previous * weight;
        }

        /// <summary>
        /// Adds a value to the neuron.
        /// </summary>
        /// <param name="previous">Previous error value.</param>
        /// <param name="weight">The connection weight.</param>
        public virtual void AddError(decimal? previous, decimal? weight)
        {
            if (previous is null) throw new ArgumentNullException(nameof(previous));
            if (weight is null) throw new ArgumentNullException(nameof(weight));
            Error += previous * weight;
        }

        /// <summary>
        /// Calculates the output value with the activation function.
        /// </summary>
        /// <returns>The output value.</returns>
        public virtual decimal GetOutput()
        {
            if (Activation is null || Z is null) throw new InvalidOperationException();
            return Activation.Execute(Z.Value);
        }
    }
}
