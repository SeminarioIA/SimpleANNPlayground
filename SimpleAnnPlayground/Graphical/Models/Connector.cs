// <copyright file="Connector.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Utils.Serialization.Yml;
using System.ComponentModel;

namespace SimpleAnnPlayground.Graphical.Models
{
    /// <summary>
    /// Represents a connector to join elements.
    /// </summary>
    public class Connector : ITextSerializable
    {
        /// <summary>
        /// Indicates the color for an Input connector.
        /// </summary>
        public static readonly Color InputColor = Color.Blue;

        /// <summary>
        /// Indicates the color for an Output connector.
        /// </summary>
        public static readonly Color OutputColor = Color.Red;

        /// <summary>
        /// Indicates the color for a connected connector.
        /// </summary>
        public static readonly Color ConnectedColor = Color.Black;

        /// <summary>
        /// Indicates the color for the shadow of the connector.
        /// </summary>
        public static readonly Color InputShadowColor = Color.LightBlue;

        /// <summary>
        /// Indicates the color for the shadow of the connector.
        /// </summary>
        public static readonly Color OutputShadowColor = Color.LightCoral;

        /// <summary>
        /// Indicates the radio for the connector element.
        /// </summary>
        private static readonly SizeF _shape = new(5, 5);

        /// <summary>
        /// Initializes a new instance of the <see cref="Connector"/> class.
        /// </summary>
        public Connector()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Connector"/> class.
        /// </summary>
        /// <param name="type">The type of connector.</param>
        public Connector(Types type)
        {
            Type = type;
        }

        /// <summary>
        /// The type of connector.
        /// </summary>
        public enum Types
        {
            /// <summary>
            /// An input connector.
            /// </summary>
            Input,

            /// <summary>
            /// An output connector.
            /// </summary>
            Output,
        }

        /// <summary>
        /// The draw mode for the connector.
        /// </summary>
        public enum DrawMode
        {
            /// <summary>
            /// The connector is drawn as a shadow.
            /// </summary>
            Shadow,

            /// <summary>
            /// The connecto is drawn as hover.
            /// </summary>
            Hover,

            /// <summary>
            /// The connector is drawn as connected.
            /// </summary>
            Connected,
        }

        /// <summary>
        /// Gets or sets the type of connector.
        /// </summary>
        [Description("The connector type.")]
        public Types Type { get; set; }

        /// <summary>
        /// Gets or sets the X coordinate of this connector.
        /// </summary>
        [Category("Location")]
        [Description("The X coordinate of this connector.")]
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of this connector.
        /// </summary>
        [Category("Location")]
        [Description("The Y coordinate of this connector.")]
        public float Y { get; set; }

        /// <summary>
        /// Gets the location point of this connector.
        /// </summary>
        public PointF Location => new (X, Y);

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
        public override string ToString() => Type.ToString();

        /// <summary>
        /// Paints the connector in a graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        /// <param name="drawMode">Indicates how the connector is drawn as a shadow.</param>
        internal void Paint(Graphics graphics, DrawMode drawMode)
        {
            Color color = drawMode switch
            {
                DrawMode.Shadow => Type == Types.Input ? InputShadowColor : OutputShadowColor,
                DrawMode.Hover => Type == Types.Input ? InputColor : OutputColor,
                DrawMode.Connected => ConnectedColor,
                _ => throw new NotImplementedException()
            };

            using (Brush brush = new SolidBrush(color))
            {
                float x = X - _shape.Width / 2f;
                float y = Y - _shape.Height / 2f;
                graphics.FillEllipse(brush, x, y, _shape.Width, _shape.Height);
            }
        }

        /// <summary>
        /// Determines if a point is part if this connector.
        /// </summary>
        /// <param name="point">The passed point.</param>
        /// <returns>True if the point is part of the connector.</returns>
        internal bool HasPoint(PointF point)
        {
            float extra = 5;
            var rect = new RectangleF(new PointF(X - _shape.Width / 2f, Y - _shape.Height / 2f), _shape);
            rect.Inflate(extra, extra);
            return rect.Contains(point);
        }
    }
}
