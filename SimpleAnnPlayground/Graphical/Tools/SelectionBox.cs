// <copyright file="SelectionBox.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Utils;
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

        /// <summary>
        /// Determines if the selection box intersects with the given <see cref="Connection"/>.
        /// </summary>
        /// <param name="connection">The connection to test.</param>
        /// <returns>True if the selection intersects the connection, otherwise false.</returns>
        internal bool IntersectsWith(Connection connection)
        {
            return Vectors.AreSegmentsIntersecting(connection.Source.Location, connection.Destination.Location, new PointF(_box.Left, _box.Top), new PointF(_box.Left, _box.Bottom))
                || Vectors.AreSegmentsIntersecting(connection.Source.Location, connection.Destination.Location, new PointF(_box.Left, _box.Top), new PointF(_box.Right, _box.Top))
                || Vectors.AreSegmentsIntersecting(connection.Source.Location, connection.Destination.Location, new PointF(_box.Right, _box.Top), new PointF(_box.Right, _box.Bottom))
                || Vectors.AreSegmentsIntersecting(connection.Source.Location, connection.Destination.Location, new PointF(_box.Left, _box.Bottom), new PointF(_box.Right, _box.Bottom));
        }
    }
}
