// <copyright file="Connector.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Graphical.Elements
{
    /// <summary>
    /// Represents an element to be drawn as a elements connector.
    /// </summary>
    public class Connector : Element
    {
        /// <summary>
        /// Indicates the radio for the connector element.
        /// </summary>
        private static readonly SizeF _shape = new (5, 5);

        /// <summary>
        /// Initializes a new instance of the <see cref="Connector"/> class.
        /// </summary>
        /// <param name="color">The element color.</param>
        /// <param name="x">The X coordinate of the element.</param>
        /// <param name="y">The Y coordinate of the element.</param>
        public Connector(Color color, float x, float y)
            : base(color, x, y)
        {
        }

        /// <inheritdoc/>
        internal override void Paint(Graphics graphics)
        {
            using (Brush brush = new SolidBrush(Color.Blue))
            {
                graphics.FillEllipse(brush, X, Y, _shape.Width, _shape.Height);
            }
        }
    }
}
