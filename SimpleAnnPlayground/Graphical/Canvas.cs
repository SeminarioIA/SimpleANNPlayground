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
        /// Converts a color object into another color with less bright.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <param name="shadow">Indicates if the operation will be performed.</param>
        /// <returns>The resulting shadow color.</returns>
        public static Color GetShadowColor(Color color, bool shadow)
        {
            return shadow ? Color.FromArgb(ShadowValue(color.R), ShadowValue(color.G), ShadowValue(color.B)) : color;
        }

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

        private static int ShadowValue(byte value)
        {
            int diff = byte.MaxValue - value;
            int inc = 9 * diff / 10;
            return inc + value;
        }
    }
}
