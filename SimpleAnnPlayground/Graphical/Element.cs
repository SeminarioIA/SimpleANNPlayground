// <copyright file="Element.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Represents a draw element for a drawable object.
    /// </summary>
    public abstract class Element
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
        /// Paints the element in a graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        internal abstract void Paint(Graphics graphics);

        /// <summary>
        /// Serializes the element information into a string.
        /// </summary>
        /// <returns>The string containing the serialized object.</returns>
        internal string Serialize()
        {
            var data = new List<string>();
            var type = GetType();
            data.Add(type.Name);
            foreach (var property in type.GetProperties())
            {
                string name = property.Name;
                object? value = property.GetValue(this, null);
                if (value is Color color)
                {
                    data.Add($"{name}: {color.Name}");
                }
                else
                {
                    data.Add($"{name}: {value}");
                }
            }

            return string.Join(", ", data);
        }
    }
}
