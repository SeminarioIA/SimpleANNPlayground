// <copyright file="Selector.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Utils.Serialization;
using System.ComponentModel;

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Represents an element to be drawn as a rectangle.
    /// </summary>
    public class Selector : ITextSerializable
    {
        /// <summary>
        /// The default value for the <seealso cref="Width"/> property.
        /// </summary>
        public const int DefaultWidth = 50;

        /// <summary>
        /// The default value for the <seealso cref="Width"/> property.
        /// </summary>
        public const int DefaultHeight = 30;

        /// <summary>
        /// The color used to signal the component when is simulated.
        /// </summary>
        public static readonly Color StepColor = Color.Yellow;

        /// <summary>
        /// The color used to signal the component when was simulated.
        /// </summary>
        public static readonly Color PassedColor = Color.FromArgb(230, 230, 230);

        /// <summary>
        /// The color used to signal the component when has a simulation error.
        /// </summary>
        public static readonly Color ErrorColor = Color.Salmon;

        /// <summary>
        /// The color used to signal the component when is selected.
        /// </summary>
        public static readonly Color SelectionColor = Color.Blue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Selector"/> class.
        /// </summary>
        /// <param name="x">The X coordinate of the ellipse.</param>
        /// <param name="y">The Y coordinate of the ellipse.</param>
        public Selector(float x, float y)
        {
            X = x;
            Y = y;
            Width = DefaultWidth;
            Height = DefaultHeight;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Selector"/> class.
        /// </summary>
        /// <param name="x">The X coordinate of the rectangle.</param>
        /// <param name="y">The Y coordinate of the rectangle.</param>
        /// <param name="width">The rectangle width.</param>
        /// <param name="height">The rectangle height.</param>
        public Selector(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or sets the X coordinate of this selector.
        /// </summary>
        [Category("Location")]
        [Description("The X coordinate of this element.")]
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of this selector.
        /// </summary>
        [Category("Location")]
        [Description("The Y coordinate of this element.")]
        public float Y { get; set; }

        /// <summary>
        /// Gets or sets the selector width.
        /// </summary>
        [Category("Size")]
        [Description("The width of this element.")]
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets the selector height.
        /// </summary>
        [Category("Size")]
        [Description("The height of this element.")]
        public float Height { get; set; }

        /// <summary>
        /// Gets the selector rectangle for this object.
        /// </summary>
        public RectangleF Rectangle => new (X, Y, Width, Height);

        /// <inheritdoc/>
        public override string ToString() => GetType().Name;

        /// <summary>
        /// Deserializes the Selector from a <paramref name="text"/> string.
        /// </summary>
        /// <param name="text">The text string containing the element data.</param>
        public void Deserialize(string text)
        {
            if (text != null)
            {
                var properties = TextSerializer.Deserialize(text);
                PropertiesHelper.SetProperties(this, properties);
            }
        }

        /// <summary>
        /// Serializes the element information into a string.
        /// </summary>
        /// <returns>The string containing the serialized object.</returns>
        public string Serialize()
        {
            var properties = PropertiesHelper.GetProperties(this);
            return TextSerializer.Serialize(properties);
        }

        /// <summary>
        /// Paints the selector box in a graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        /// <param name="selected">Indicated if the object is selected.</param>
        /// <param name="state">Indicates the state of the selector.</param>
        internal void Paint(Graphics graphics, bool selected, Component.State state = Component.State.None)
        {
            switch (state)
            {
                case Component.State.SimulationStep:
                {
                    using (Brush brush = new SolidBrush(StepColor))
                    {
                        graphics.FillRectangle(brush, X, Y, Width, Height);
                    }

                    break;
                }

                case Component.State.SimulationPass:
                {
                    using (Brush brush = new SolidBrush(PassedColor))
                    {
                        graphics.FillRectangle(brush, X, Y, Width, Height);
                    }

                    break;
                }

                case Component.State.SimulationError:
                {
                    using (Brush brush = new SolidBrush(ErrorColor))
                    {
                        graphics.FillRectangle(brush, X, Y, Width, Height);
                    }

                    break;
                }
            }

            if (selected)
            {
                using (Pen pen = new Pen(SelectionColor, 0.1f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                {
                    graphics.DrawRectangle(pen, X, Y, Width, Height);
                }
            }
        }
    }
}
