// <copyright file="ShadowCanvas.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Graphical
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
            if (copy is CanvasObject canvasObject)
            {
                base.AddObject(canvasObject);
                canvasObject.SetStateFlag(Component.State.Shadow);
            }
        }

        /// <summary>
        /// Executes a move operation over an object.
        /// </summary>
        /// <param name="obj">The moving object.</param>
        internal void MoveObject(CanvasObject obj)
        {
            var shadow = Objects.First(shadow => shadow.Equals(obj));
            shadow.Location = obj.Location;
        }
    }
}
