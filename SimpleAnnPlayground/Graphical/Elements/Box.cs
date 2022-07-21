// <copyright file="Box.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace SimpleAnnPlayground.Graphical.Elements
{
    /// <summary>
    /// Represents an element to be drawn as a rectangle.
    /// </summary>
    public class Box : Element
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
        /// The default value for the <seealso cref="BackColor"/> property.
        /// </summary>
        public static readonly Color? DefaultBackColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Box"/> class.
        /// </summary>
        /// <param name="color">The element color.</param>
        /// <param name="x">The X coordinate of the ellipse.</param>
        /// <param name="y">The Y coordinate of the ellipse.</param>
        public Box(Color color, float x, float y)
            : base(color, x, y)
        {
            BackColor = DefaultBackColor;
            Width = DefaultWidth;
            Height = DefaultHeight;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Box"/> class.
        /// </summary>
        /// <param name="color">The element color.</param>
        /// <param name="x">The X coordinate of the rectangle.</param>
        /// <param name="y">The Y coordinate of the rectangle.</param>
        /// <param name="width">The rectangle width.</param>
        /// <param name="height">The rectangle height.</param>
        /// <param name="backColor">The rectangle back color, null otherwise.</param>
        public Box(Color color, float x, float y, float width, float height, Color? backColor = null)
            : base(color, x, y)
        {
            BackColor = backColor;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or sets the element back color.
        /// </summary>
        [Category("Appearance")]
        [Description("The back color of this element.")]
        public Color? BackColor { get; set; }

        /// <summary>
        /// Gets or sets the ellipse width.
        /// </summary>
        [Category("Size")]
        [Description("The width of this element.")]
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets the ellipse height.
        /// </summary>
        [Category("Size")]
        [Description("The height of this element.")]
        public float Height { get; set; }

        /// <inheritdoc/>
        internal override void Paint(Graphics graphics, bool shadowDraw)
        {
            if (!shadowDraw && BackColor != null)
            {
                using (Brush brush = new SolidBrush(BackColor.Value))
                {
                    graphics.FillRectangle(brush, X, Y, Width, Height);
                }
            }

            using (Pen pen = new Pen(Canvas.GetShadowColor(Color, shadowDraw)))
            {
                graphics.DrawRectangle(pen, X, Y, Width, Height);
            }
        }
    }
}
