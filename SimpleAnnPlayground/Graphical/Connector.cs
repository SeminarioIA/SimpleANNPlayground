// <copyright file="Connector.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Utils.Serialization;
using System.ComponentModel;

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Represents a connector to join elements.
    /// </summary>
    public class Connector : ITextSerializable
    {
        /// <summary>
        /// Indicates the radio for the connector element.
        /// </summary>
        private static readonly SizeF _shape = new (5, 5);

        /// <summary>
        /// Indicates the color for the connector.
        /// </summary>
        private static readonly Color Color = Color.Blue;

        /// <summary>
        /// Indicates the color for the shadow of the connector.
        /// </summary>
        private static readonly Color ShadowColor = Color.LightBlue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Connector"/> class.
        /// </summary>
        /// <param name="x">The X coordinate of the element.</param>
        /// <param name="y">The Y coordinate of the element.</param>
        public Connector(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the X coordinate of this element.
        /// </summary>
        [Category("Location")]
        [Description("The X coordinate of this element.")]
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of this element.
        /// </summary>
        [Category("Location")]
        [Description("The Y coordinate of this element.")]
        public float Y { get; set; }

        /// <summary>
        /// Deserializes an Connector from a <paramref name="text"/> string.
        /// </summary>
        /// <param name="text">The text string containing the element data.</param>
        public void Deserialize(string text)
        {
            if (text == null) return;
            var properties = TextSerializer.Deserialize(text);
            PropertiesHelper.SetProperties(this, properties);
        }

        /// <summary>
        /// Serializes the connector information into a string.
        /// </summary>
        /// <returns>The string containing the serialized object.</returns>
        public string Serialize()
        {
            var properties = PropertiesHelper.GetProperties(this);
            return TextSerializer.Serialize(properties);
        }

        /// <inheritdoc/>
        public override string ToString() => nameof(Connector);

        /// <summary>
        /// Paints the connector in a graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        /// <param name="shadowDraw">Indicates if the connector is drawn as a shadow.</param>
        internal void Paint(Graphics graphics, bool shadowDraw = false)
        {
            Color color = shadowDraw ? ShadowColor : Color;
            using (Brush brush = new SolidBrush(color))
            {
                float x = X - _shape.Width / 2f;
                float y = Y - _shape.Height / 2f;
                graphics.FillEllipse(brush, x, y, _shape.Width, _shape.Height);
            }
        }
    }
}
