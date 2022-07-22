// <copyright file="ShadowCanvas.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Graphical.Visualization
{
    /// <summary>
    /// Represents a shadow of a <see cref="Canvas"/>.
    /// </summary>
    internal class ShadowCanvas : Canvas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadowCanvas"/> class.
        /// </summary>
        public ShadowCanvas()
        {
        }

        /// <inheritdoc/>
        public override void AddObject(CanvasObject obj)
        {
            object? copy = Activator.CreateInstance(obj.GetType(), obj);
            if (copy is CanvasObject shadow)
            {
                base.AddObject(shadow);
                shadow.State = Component.State.Shadow;
            }
        }

        /// <summary>
        /// Executes a move operation over an object.
        /// </summary>
        /// <param name="objects">The collection of objects to move.</param>
        internal void MoveObjects(Collection<CanvasObject> objects)
        {
            foreach (CanvasObject obj in objects)
            {
                var shadow = Objects.First(shadow => shadow.Equals(obj));
                shadow.Location = obj.Location;
            }
        }
    }
}
