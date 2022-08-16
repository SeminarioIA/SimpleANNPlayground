// <copyright file="Space.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Drawing.Drawing2D;

namespace SimpleAnnPlayground.Utils.Graphics
{
    /// <summary>
    /// Utility class to make spacial operations.
    /// </summary>
    internal static class Space
    {
        /// <summary>
        /// Scales a point with the given transform.
        /// </summary>
        /// <param name="point">The point to transform.</param>
        /// <param name="transform">The space transform.</param>
        /// <returns>The point to scale.</returns>
        public static PointF ScalePoint(PointF point, Matrix transform)
        {
            Matrix m = transform.Clone();
            m.Invert();
            var pts = new PointF[] { point };
            m.TransformPoints(pts);
            return pts[0];
        }

        /// <summary>
        /// Unscales a point from the given transform.
        /// </summary>
        /// <param name="point">The point to transform.</param>
        /// <param name="transform">The space transform.</param>
        /// <returns>The point to unscale.</returns>
        public static PointF UnscalePoint(PointF point, Matrix transform)
        {
            var pts = new PointF[] { point };
            transform.TransformPoints(pts);
            return pts[0];
        }

        /// <summary>
        /// Orders two points according to their X coordinate.
        /// </summary>
        /// <param name="point1">The first point to compare.</param>
        /// <param name="point2">The second point to compare.</param>
        /// <returns>The pair of points ordered.</returns>
        public static (PointF, PointF) OrderPointsInX(PointF point1, PointF point2)
        {
            return point1.X <= point2.X ? (point1, point2) : (point2, point1);
        }

        /// <summary>
        /// Determines if a value is between two limits.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="minor">The minor limit.</param>
        /// <param name="major">The major limit.</param>
        /// <returns>True if the value is between the limits, otherwise false.</returns>
        public static bool InRange(float value, float minor, float major)
        {
            return minor <= value && value <= major;
        }

        /// <summary>
        /// Determines if a point is between the range of a line segment.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <param name="x1">The X coordinate of the line segment start point.</param>
        /// <param name="y1">The Y coordinate of the line segment start point.</param>
        /// <param name="x2">The X coordinate of the line segment end point.</param>
        /// <param name="y2">The Y coordinate of the line segment end point.</param>
        /// <returns>True if the point is in range, otherwise false.</returns>
        public static bool InRange(PointF point, float x1, float y1, float x2, float y2)
        {
            return Math.Min(x1, x2) < point.X && point.X < Math.Max(x1, x2)
                && Math.Min(y1, y2) < point.Y && point.Y < Math.Max(y1, y2);
        }

        /// <summary>
        /// Determines if a point is between the range of a line segment.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <param name="lineStart">The start point of the line segment.</param>
        /// <param name="lineEnd">The end point of the line segment.</param>
        /// <returns>True if the point is in range, otherwise false.</returns>
        public static bool InRange(PointF point, PointF lineStart, PointF lineEnd)
        {
            return Math.Min(lineStart.X, lineEnd.X) < point.X && point.X < Math.Max(lineStart.X, lineEnd.X)
                && Math.Min(lineStart.Y, lineEnd.Y) < point.Y && point.Y < Math.Max(lineStart.Y, lineEnd.Y);
        }

        /// <summary>
        /// Determines if a line segment has a close angle to the X axis.
        /// </summary>
        /// <param name="lineStart">The line segment start.</param>
        /// <param name="lineEnd">The line segment end.</param>
        /// <returns>True if there is close angle, otherwise false.</returns>
        public static bool IsCloseXAngle(PointF lineStart, PointF lineEnd)
        {
            return Math.Abs(lineStart.X - lineEnd.X) >= Math.Abs(lineStart.Y - lineEnd.Y);
        }

        /// <summary>
        /// Gets the intersection X coordinate between a point and a line segment.
        /// </summary>
        /// <param name="point">The point to analyze.</param>
        /// <param name="lineStart">The line segment start.</param>
        /// <param name="lineEnd">The line segment end.</param>
        /// <returns>The X coordinate that intersects the line segment.</returns>
        public static float GetXIntersection(PointF point, PointF lineStart, PointF lineEnd)
        {
            return (point.Y - lineStart.Y) * ((lineEnd.X - lineStart.X) / (lineEnd.Y - lineStart.Y)) + lineStart.X;
        }

        /// <summary>
        /// Gets the intersection Y coordinate between a point and a line segment.
        /// </summary>
        /// <param name="point">The point to analyze.</param>
        /// <param name="lineStart">The line segment start.</param>
        /// <param name="lineEnd">The line segment end.</param>
        /// <returns>The Y coordinate that intersects the line segment.</returns>
        public static float GetYIntersection(PointF point, PointF lineStart, PointF lineEnd)
        {
            return (point.X - lineStart.X) * ((lineEnd.Y - lineStart.Y) / (lineEnd.X - lineStart.X)) + lineStart.Y;
        }
    }
}
