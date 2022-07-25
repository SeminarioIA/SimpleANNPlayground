// <copyright file="ShadowCanvas.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
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
        /// Restores a previusly added and removed object.
        /// </summary>
        /// <param name="obj">The object to restore.</param>
        public void RestoreShadowObject(CanvasObject obj)
        {
            if (!obj.State.HasFlag(Component.State.Shadow)) throw new ArgumentException("Object is not shadow", nameof(obj));
            base.AddObject(obj);
        }

        /// <inheritdoc/>
        public override void AddConnection(Connection connection)
        {
            var shadow = new Connection(connection, this);
            shadow.IsShadow = true;
            base.AddConnection(shadow);
        }

        /// <summary>
        /// Restores a previusly added and removed connection.
        /// </summary>
        /// <param name="connection">The connection to restore.</param>
        public void RestoreShadowConnection(Connection connection)
        {
            if (!connection.IsShadow) throw new ArgumentException("Connection is not shadow", nameof(connection));
            base.AddConnection(connection);
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

        /// <summary>
        /// Swaps an object by another.
        /// </summary>
        /// <param name="toRemove">The shadow object to remove.</param>
        /// <param name="toAdd">The shadow object to add.</param>
        internal void SwapObjects(CanvasObject? toRemove, CanvasObject? toAdd)
        {
            if (toRemove != null) _ = Objects.Remove(toRemove);
            if (toAdd != null) Objects.Add(toAdd);
        }
    }
}
