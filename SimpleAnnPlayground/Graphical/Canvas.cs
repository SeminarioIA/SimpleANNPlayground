// <copyright file="Canvas.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Represents a canvas to graw graphical objects.
    /// </summary>
    internal class Canvas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Canvas"/> class.
        /// </summary>
        public Canvas()
        {
            Objects = new List<CanvasObject>();
        }

        /// <summary>
        /// Gets the list of objects on this canvas.
        /// </summary>
        public List<CanvasObject> Objects { get; private set; }

        /// <summary>
        /// Draws all the canvas objects over a graphics.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        public void Draw(Graphics graphics)
        {
            foreach (CanvasObject obj in Objects)
            {
                obj.Draw(graphics);
            }
        }
    }
}
