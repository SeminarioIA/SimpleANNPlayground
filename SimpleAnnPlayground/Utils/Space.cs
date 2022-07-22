// <copyright file="Space.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Drawing.Drawing2D;

namespace SimpleAnnPlayground.Utils
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
    }
}
