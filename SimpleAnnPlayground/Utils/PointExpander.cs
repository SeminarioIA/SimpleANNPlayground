// <copyright file="PointExpander.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Utils
{
    /// <summary>
    /// Utility class to expand <see cref="Point"/> and <see cref="PointF"/> classes.
    /// </summary>
    internal static class PointExpander
    {
        /// <summary>
        /// Moves the point a given offset.
        /// </summary>
        /// <param name="point">The currect point.</param>
        /// <param name="offset">The offset to add to point.</param>
        /// <returns>The result of adding <paramref name="offset"/> to <paramref name="point"/>.</returns>
        public static PointF OffsetTo(this PointF point, PointF offset)
        {
            return new PointF(point.X + offset.X, point.Y + offset.Y);
        }

        /// <summary>
        /// Substracts a point from this point.
        /// </summary>
        /// <param name="point">The currect point.</param>
        /// <param name="other">The point to substract.</param>
        /// <returns>The result of sustracting <paramref name="other"/> to <paramref name="point"/>.</returns>
        public static PointF Substract(this PointF point, PointF other)
        {
            return new PointF(point.X - other.X, point.Y - other.Y);
        }

        /// <summary>
        /// Converts a <see cref="PointF"/> into a <see cref="SizeF"/>.
        /// </summary>
        /// <param name="point">The point to convert.</param>
        /// <returns>The converted size.</returns>
        public static SizeF ToSize(this PointF point)
        {
            return new SizeF(point.X, point.Y);
        }

        /// <summary>
        /// Gets a moved rectangle location with the given offset.
        /// </summary>
        /// <param name="rect">The rectangle to move.</param>
        /// <param name="offset">The offset to apply to the rectangle location.</param>
        /// <returns>A new moved rectangle.</returns>
        public static RectangleF OffsetTo(this RectangleF rect, PointF offset)
        {
            rect.Offset(offset);
            return rect;
        }
    }
}
