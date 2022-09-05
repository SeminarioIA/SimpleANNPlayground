﻿// <copyright file="Neuron.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Ann.Activation;
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
        /// Gets or sets the neuron bias value.
        /// </summary>
        public decimal? Bias { get; set; }

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
                string text = Z is not null ? $"b={Bias}\nZ={Math.Round(Z.Value, 3)}" : $"b={Bias}";
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
                    graphics.DrawString($"a={Math.Round(A.Value, 3)}", font, brush, location, format);
                }
            }

            if (Error is not null)
            {
                using (var font = new Font("Arial", 8))
                using (var brush = new SolidBrush(Color.Red))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
                {
                    var location = new PointF(Location.X, Location.Y + Component.Y + font.Size + 2);
                    graphics.DrawString($"e={Math.Round(Error.Value, 3)}", font, brush, location, format);
                }
            }

            if (Correction is not null)
            {
                using (var font = new Font("Arial", 8))
                using (var brush = new SolidBrush(Color.Blue))
                using (var format = new StringFormat(StringFormatFlags.NoWrap) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
                {
                    var location = new PointF(Location.X, Location.Y + Component.Y + font.Size * 2 + 4);
                    graphics.DrawString($"c={Math.Round(Correction.Value, 3)}", font, brush, location, format);
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
