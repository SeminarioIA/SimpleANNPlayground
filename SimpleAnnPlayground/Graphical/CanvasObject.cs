// <copyright file="CanvasObject.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Represents an object to be drawn on a <seealso cref="Canvas"/>.
    /// </summary>
    internal abstract class CanvasObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasObject"/> class.
        /// </summary>
        /// <param name="component">The graphical component linked to this object.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        protected CanvasObject(Component component, int x, int y)
        {
            Component = component;
            Location = new Point(x, y);
        }

        /// <summary>
        /// Gets the graphical component linked to this object.
        /// </summary>
        public Component Component { get; private set; }

        /// <summary>
        /// Gets or sets the object location in the draw.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Draws the object over a canvas.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        public void Draw(Graphics graphics)
        {
            Component?.Paint(graphics, Location);
        }
    }
}
