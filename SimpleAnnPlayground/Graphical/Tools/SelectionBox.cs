// <copyright file="SelectionBox.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Drawing.Drawing2D;

namespace SimpleAnnPlayground.Graphical.Tools
{
    /// <summary>
    /// Represents a selection area.
    /// </summary>
    internal class SelectionBox
    {
        private const float _width = 0.1f;
        private readonly Color _color = Color.Blue;
        private readonly Color _fillColor = Color.FromArgb(20, 0, 0, 200);
        private RectangleF _box;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionBox"/> class.
        /// </summary>
        /// <param name="startPoint">The selection start point.</param>
        public SelectionBox(PointF startPoint)
        {
            StartPoint = startPoint;
            _box = new RectangleF(startPoint, SizeF.Empty);
        }

        /// <summary>
        /// Gets a value indicating whether if the selection is inclusive.
        /// </summary>
        public bool Inclusive { get; private set; }

        /// <summary>
        /// Gets the selection start point.
        /// </summary>
        public PointF StartPoint { get; private set; }

        /// <summary>
        /// Gets the selection box.
        /// </summary>
        public RectangleF Rectangle => _box;

        /// <summary>
        /// Paints the selection box in a graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        internal void Paint(Graphics graphics)
        {
            if (!Inclusive)
            {
                using (Brush brush = new SolidBrush(_fillColor))
                {
                    graphics.FillRectangle(brush, _box);
                }
            }

            using (var pen = new Pen(_color, _width) { DashStyle = Inclusive ? DashStyle.Solid : DashStyle.Dash })
            {
                graphics.DrawRectangle(pen, _box.X, _box.Y, _box.Width, _box.Height);
            }
        }

        /// <summary>
        /// Extends the selection to the given location.
        /// </summary>
        /// <param name="location">The location to extend the selection.</param>
        internal void Extend(PointF location)
        {
            Inclusive = StartPoint.X < location.X;
            _box.X = Math.Min(StartPoint.X, location.X);
            _box.Y = Math.Min(StartPoint.Y, location.Y);
            _box.Width = Math.Abs(location.X - StartPoint.X);
            _box.Height = Math.Abs(location.Y - StartPoint.Y);
        }
    }
}
