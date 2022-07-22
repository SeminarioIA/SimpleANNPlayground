// <copyright file="Line.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Visualization;
using System.ComponentModel;

namespace SimpleAnnPlayground.Graphical.Elements
{
    /// <summary>
    /// Represents an element to be drawn as a line.
    /// </summary>
    public class Line : Element
    {
        /// <summary>
        /// The default value for the <seealso cref="X2"/> property.
        /// </summary>
        public const int DefaultX2 = 50;

        /// <summary>
        /// The default value for the <seealso cref="Y2"/> property.
        /// </summary>
        public const int DefaultY2 = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="color">The element color.</param>
        /// <param name="x">The X coordinate of the ellipse.</param>
        /// <param name="y">The Y coordinate of the ellipse.</param>
        public Line(Color color, float x, float y)
            : base(color, x, y)
        {
            X2 = DefaultX2;
            Y2 = DefaultY2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="color">The element color.</param>
        /// <param name="x">The X coordinate of the line.</param>
        /// <param name="y">The Y coordinate of the line.</param>
        /// <param name="x2">The X2 coordinate of the line.</param>
        /// <param name="y2">The Y2 coordinate of the line.</param>
        public Line(Color color, float x, float y, float x2, float y2)
            : base(color, x, y)
        {
            X2 = x2;
            Y2 = y2;
        }

        /// <summary>
        /// Gets or sets the X2 coordinate of this element.
        /// </summary>
        [Category("Point2")]
        [Description("The X2 coordinate of the line.")]
        public float X2 { get; set; }

        /// <summary>
        /// Gets or sets the Y2 coordinate of this element.
        /// </summary>
        [Category("Point2")]
        [Description("The Y2 coordinate of the line.")]
        public float Y2 { get; set; }

        /// <inheritdoc/>
        internal override void Paint(Graphics graphics, bool shadowDraw)
        {
            using (Pen pen = new Pen(Canvas.GetShadowColor(Color, shadowDraw)))
            {
                graphics.DrawLine(pen, X, Y, X2, Y2);
            }
        }
    }
}
