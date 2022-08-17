// <copyright file="WorkSheet.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Visualization;

namespace SimpleAnnPlayground.Graphical.Environment
{
    /// <summary>
    /// Represents the sheet in the workspace area.
    /// </summary>
    internal class WorkSheet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkSheet"/> class.
        /// </summary>
        /// <param name="size">The sheet size.</param>
        [JsonConstructor]
        public WorkSheet(Size size)
        {
            Cross = new Cross(Color.DarkGray, PointF.Empty, 10);
            Size = size;
        }

        /// <summary>
        /// Gets the center cross.
        /// </summary>
        [JsonIgnore]
        public Cross Cross { get; }

        /// <summary>
        /// Gets the sheet size.
        /// </summary>
        public Size Size { get; private set; }

        /// <summary>
        /// Gets the rectangle that represents the working area.
        /// </summary>
        [JsonIgnore]
        public Rectangle Bounds => new(-Size.Width / 2, -Size.Height / 2, Size.Width, Size.Height);

        /// <summary>
        /// Determines if an object is inside the sheet area.
        /// </summary>
        /// <param name="obj">The object to test.</param>
        /// <returns>True if is inside, otherwise false.</returns>
        public bool IsInside(CanvasObject obj)
        {
            return Bounds.Contains(Rectangle.Round(obj.SelectionArea));
        }

        /// <summary>
        /// Paints the sheet in the given <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        internal void Paint(Graphics graphics)
        {
            // Draw sheet shadow.
            var shadowRect = Bounds;
            shadowRect.Offset(2, 2);
            using (var brush = new SolidBrush(Color.DimGray))
            {
                graphics.FillRectangle(brush, shadowRect);
            }

            // Draw sheet background
            using (var brush = new SolidBrush(Color.White))
            {
                graphics.FillRectangle(brush, Bounds);
            }

            // Draw sheet border
            using (var pen = new Pen(Color.Black))
            {
                graphics.DrawRectangle(pen, Bounds);
            }

            // Draw center cross.
            Cross.Paint(graphics);
        }
    }
}
