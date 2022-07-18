// <copyright file="Triangle.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace SimpleAnnPlayground.Graphical.Elements
{
    /// <summary>
    /// Represents an element to be drawn as a line.
    /// </summary>
    public class Triangle : Element
    {
        /// <summary>
        /// The default value for the <seealso cref="OffsetX1"/> property.
        /// </summary>
        public const int DefaultOffsetX1 = 0;

        /// <summary>
        /// The default value for the <seealso cref="OffsetY1"/> property.
        /// </summary>
        public const int DefaultOffsetY1 = 40;

        /// <summary>
        /// The default value for the <seealso cref="OffsetX1"/> property.
        /// </summary>
        public const int DefaultOffsetX2 = 30;

        /// <summary>
        /// The default value for the <seealso cref="OffsetY1"/> property.
        /// </summary>
        public const int DefaultOffsetY2 = 20;

        /// <summary>
        /// The default value for the <seealso cref="BackColor"/> property.
        /// </summary>
        public static readonly Color? DefaultBackColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="color">The element color.</param>
        /// <param name="x">The X coordinate of the ellipse.</param>
        /// <param name="y">The Y coordinate of the ellipse.</param>
        public Triangle(Color color, float x, float y)
            : base(color, x, y)
        {
            OffsetX1 = DefaultOffsetX1;
            OffsetY1 = DefaultOffsetY1;
            OffsetX2 = DefaultOffsetX2;
            OffsetY2 = DefaultOffsetY2;
            BackColor = DefaultBackColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="color">The element color.</param>
        /// <param name="x">The X coordinate of the line.</param>
        /// <param name="y">The Y coordinate of the line.</param>
        /// <param name="offsetX1">The <seealso cref="OffsetX1"/> for the triangle.</param>
        /// <param name="offsetY1">The <seealso cref="OffsetY1"/> for the triangle.</param>
        /// <param name="offsetX2">The <seealso cref="OffsetX2"/> for the triangle.</param>
        /// <param name="offsetY2">The <seealso cref="OffsetY2"/> for the triangle.</param>
        /// /// <param name="backColor">The triangle back color, null otherwise.</param>
        public Triangle(Color color, float x, float y, float offsetX1, float offsetY1, float offsetX2, float offsetY2, Color? backColor = null)
            : base(color, x, y)
        {
            OffsetX1 = offsetX1;
            OffsetY1 = offsetY1;
            OffsetX2 = offsetX2;
            OffsetY2 = offsetY2;
            BackColor = backColor;
        }

        /// <summary>
        /// Gets or sets the offset Y1 to draw a triangle side.
        /// </summary>
        [Category("Offset1")]
        [Description("The offset Y1 to draw a triangle side.")]
        public float OffsetX1 { get; set; }

        /// <summary>
        /// Gets or sets the offset Y1 to draw a triangle side.
        /// </summary>
        [Category("Offset1")]
        [Description("The offset Y1 to draw a triangle side.")]
        public float OffsetY1 { get; set; }

        /// <summary>
        /// Gets or sets the offset X2 to draw a triangle side.
        /// </summary>
        [Category("Offset2")]
        [Description("The offset X2 to draw a triangle side.")]
        public float OffsetX2 { get; set; }

        /// <summary>
        /// Gets or sets the offset Y2 to draw a triangle side.
        /// </summary>
        [Category("Offset2")]
        [Description("The offset Y2 to draw a triangle side.")]
        public float OffsetY2 { get; set; }

        /// <summary>
        /// Gets or sets the element back color.
        /// </summary>
        [Category("Appearance")]
        [Description("The back color of this element.")]
        public Color? BackColor { get; set; }

        /// <inheritdoc/>
        internal override void Paint(Graphics graphics)
        {
            PointF[] triangle = new PointF[]
            {
                new PointF(X, Y),
                new PointF(X + OffsetX1, Y + OffsetY1),
                new PointF(X + OffsetX2, Y + OffsetY2),
            };

            using (Pen pen = new Pen(Color))
            {
                if (BackColor != null)
                {
                    using (Brush brush = new SolidBrush(BackColor.Value))
                    {
                        graphics.FillPolygon(brush, triangle);
                    }
                }

                graphics.DrawPolygon(pen, triangle);
            }
        }
    }
}
