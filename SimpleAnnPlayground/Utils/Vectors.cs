// <copyright file="Vectors.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Utils
{
    /// <summary>
    /// Utility static class to work with vectors.
    /// </summary>
    internal static class Vectors
    {
        /// <summary>
        /// Calculates the cross product of vector p1 and p2.<br/>
        /// - If p1 is clockwise from p2 wrt origin then it returns +ve value.<br/>
        /// - If p2 is anti-clockwise from p2 wrt origin then it returns -ve value.<br/>
        /// - If p1 p2 and origin are collinear then it returs 0.
        /// </summary>
        /// <param name="p1">The point 1.</param>
        /// <param name="p2">The point 2.</param>
        /// <returns>The cross product between the points vectors.</returns>
        public static float CrossProduct(PointF p1, PointF p2)
        {
            return p1.X * p2.Y - p2.X * p1.Y;
        }

        /// <summary>
        /// Calculates the cross product of vector p1p3 and p1p2.
        /// </summary>
        /// <param name="p1">The point 1.</param>
        /// <param name="p2">The point 2.</param>
        /// <param name="p3">The point 3.</param>
        /// <returns>The cross product of vector p1p3 and p1p2.</returns>
        public static float PointsDirection(PointF p1, PointF p2, PointF p3)
        {
            return CrossProduct(p3.Substract(p1), p2.Substract(p1));
        }

        /// <summary>
        /// Determines if two line segments are intersecting.
        /// </summary>
        /// <param name="p1">Start point of the first segment.</param>
        /// <param name="p2">End point of the first segment.</param>
        /// <param name="p3">Start point of the second segment.</param>
        /// <param name="p4">End point of the secont segment.</param>
        /// <returns>True if the line segments intersect, otherwise false.</returns>
        public static bool AreSegmentsIntersecting(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            float d1 = PointsDirection(p3, p4, p1);
            float d2 = PointsDirection(p3, p4, p2);
            float d3 = PointsDirection(p1, p2, p3);
            float d4 = PointsDirection(p1, p2, p4);

            if (((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0))
                && ((d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0)))
            {
                return true;
            }
            else if (d1 == 0 && Space.InRange(p1, p3, p4))
            {
                return true;
            }
            else if (d2 == 0 && Space.InRange(p2, p3, p4))
            {
                return true;
            }
            else if (d3 == 0 && Space.InRange(p3, p1, p2))
            {
                return true;
            }
            else if (d4 == 0 && Space.InRange(p4, p1, p2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
