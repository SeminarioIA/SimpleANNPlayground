// <copyright file="MovingBag.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Visualization;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Graphical.Tools
{
    /// <summary>
    /// Helper class to move multiple <see cref="CanvasObject"/>s a the <see cref="Workspace"/>.
    /// </summary>
    internal class MovingBag
    {
        /// <summary>
        /// A dictonary to store the objects initial points.
        /// </summary>
        private readonly Dictionary<CanvasObject, Point> _selection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovingBag"/> class.
        /// </summary>
        /// <param name="startPoint">The moving start point.</param>
        /// <param name="selection">The collection of selected objects.</param>
        public MovingBag(PointF startPoint, Collection<CanvasObject> selection)
        {
            StartPoint = startPoint;
            _selection = selection.ToDictionary(obj => obj, obj => obj.Location);
        }

        /// <summary>
        /// Gets the moving start point.
        /// </summary>
        public PointF StartPoint { get; }

        /// <summary>
        /// Gets the collection of selected objects.
        /// </summary>
        public Collection<CanvasObject> Selection => new (_selection.Keys.ToList());

        /// <summary>
        /// Updates the destination point for the objects in the bag.
        /// </summary>
        /// <param name="location">The mouse location.</param>
        public void UpdateDestination(PointF location)
        {
            foreach (var obj in _selection)
            {
                var offset = Point.Truncate(new PointF(location.X - StartPoint.X, location.Y - StartPoint.Y));
                Point dest = obj.Value;
                dest.Offset(offset);
                obj.Key.Location = dest;
            }
        }
    }
}
