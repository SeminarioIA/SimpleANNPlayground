// <copyright file="Element.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Utils.Serialization;
using System.ComponentModel;

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Represents a draw element for a drawable object.
    /// </summary>
    public abstract partial class Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="color">The element color.</param>
        /// <param name="x">The X coordinate of the element.</param>
        /// <param name="y">The Y coordinate of the element.</param>
        protected Element(Color color, float x, float y)
        {
            Color = color;
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the element color.
        /// </summary>
        [Category("Appearance")]
        [Description("The border color of this element.")]
        public Color Color { get; set; }

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

        /// <inheritdoc/>
        public override string ToString() => GetType().Name;

        /// <summary>
        /// Deserializes an Element of the given <paramref name="type"/> from a <paramref name="text"/> string.
        /// </summary>
        /// <param name="type">The type of the new element.</param>
        /// <param name="text">The text string containing the element data.</param>
        /// <returns>The new element created from the text.</returns>
        internal static Element Deserialize(Types type, string text)
        {
            var elementType = ElementsTypes[(int)type];
            var element = Activator.CreateInstance(elementType, Color.Black, 0f, 0f) as Element;
            if (element != null)
            {
                var properties = TextSerializer.Deserialize(text);
                PropertiesHelper.SetProperties(element, properties);
            }

            return element ?? throw new NotImplementedException();
        }

        /// <summary>
        /// Serializes the element information into a string.
        /// </summary>
        /// <returns>The string containing the serialized object.</returns>
        internal string Serialize()
        {
            var properties = PropertiesHelper.GetProperties(this);
            return TextSerializer.Serialize(properties);
        }

        /// <summary>
        /// Paints the element in a graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        /// <param name="shadowDraw">Indicates if the connector is drawn as a shadow.</param>
        internal abstract void Paint(Graphics graphics, bool shadowDraw = false);
    }
}
