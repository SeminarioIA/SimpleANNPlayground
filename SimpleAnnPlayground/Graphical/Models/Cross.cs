// <copyright file="Cross.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Graphical.Models
{
    /// <summary>
    /// Represents an cross object to draw.
    /// </summary>
    internal class Cross
    {
        /// <summary>
        /// The default cross line width.
        /// </summary>
        public const float CrossWidth = 0.1f;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cross"/> class.
        /// </summary>
        /// <param name="color">The cross color.</param>
        /// <param name="location">Location of the cross.</param>
        /// <param name="size">Size of the cross.</param>
        public Cross(Color color, PointF location, float size)
        {
            Color = color;
            Location = location;
            Size = size;
        }

        /// <summary>
        /// Gets or sets the color to paint the cross.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Gets the cross location.
        /// </summary>
        public PointF Location { get; private set; }

        /// <summary>
        /// Gets the cross size.
        /// </summary>
        public float Size { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether if the <see cref="Cross"/> is visible.
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Paints the object in a <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">The object to perform the paint operation.</param>
        internal void Paint(Graphics graphics)
        {
            if (!Visible) return;

            using (var pen = new Pen(Color, CrossWidth))
            {
                graphics.DrawLine(pen, Location.X - Size, Location.Y, Location.X + Size, Location.Y);
                graphics.DrawLine(pen, Location.X, Location.Y - Size, Location.X, Location.Y + Size);
            }
        }
    }
}
