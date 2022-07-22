// <copyright file="Canvas.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Represents a canvas to draw graphical objects.
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
        protected List<CanvasObject> Objects { get; private set; }

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
        /// Adds an object to the canvas.
        /// </summary>
        /// <param name="obj">The object to be added.</param>
        public virtual void AddObject(CanvasObject obj) => Objects.Add(obj);

        /// <summary>
        /// Determines if a location touches a <see cref="CanvasObject"/>.
        /// </summary>
        /// <param name="location">The location to test.</param>
        /// <returns>The object in the location, otherwise null.</returns>
        public CanvasObject? IsObject(PointF location)
        {
            foreach (var obj in Objects)
            {
                if (obj.HasPoint(Point.Truncate(location)))
                {
                    return obj;
                }
            }

            return null;
        }

        /// <summary>
        /// Draws all the canvas objects over a graphics.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        internal void Draw(Graphics graphics)
        {
            foreach (CanvasObject obj in Objects)
            {
                obj.Draw(graphics);
            }
        }

        private static int ShadowValue(byte value)
        {
            int diff = byte.MaxValue - value;
            int inc = 93 * diff / 100;
            return inc + value;
        }
    }
}
