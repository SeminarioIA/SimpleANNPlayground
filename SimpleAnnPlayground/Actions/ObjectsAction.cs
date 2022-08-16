// <copyright file="ObjectsAction.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Visualization;
using SimpleAnnPlayground.Utils.Graphics;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Actions
{
    /// <summary>
    /// Represents the actions performed in the draw with <see cref="CanvasObject"/>.
    /// </summary>
    internal class ObjectsAction : RecordableAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectsAction"/> class.
        /// </summary>
        /// <param name="workspace">The reference to the current workspace.</param>
        /// <param name="type">The type of action performed.</param>
        /// <param name="objects">The list of refence objects.</param>
        public ObjectsAction(Workspace workspace, ActionType type, Collection<CanvasObject> objects)
            : base(workspace, type)
        {
            // Save the old objects state.
            Snapshot = new Collection<(CanvasObject, CanvasObject?)>();

            // Apply the changes in the shadow.
            foreach (var (obj, shadow) in Workspace.Shadow.GetObjectsWithReference(objects))
            {
                if (shadow != null) Workspace.Shadow.RemoveObject(shadow);
                Workspace.Shadow.AddObject(obj);
                var newShadow = Workspace.Shadow.GetObjectFromReference(obj) ?? throw new NotImplementedException();
                Snapshot.Add((newShadow, shadow));
            }
        }

        /// <summary>
        /// Gets the collection of pairs (object, shadow) of the modified objects with their shadows.
        /// </summary>
        public Collection<(CanvasObject, CanvasObject?)> Snapshot { get; private set; }

        /// <inheritdoc/>
        public override void Undo()
        {
            var snapshot = new Collection<(CanvasObject, CanvasObject?)>();
            foreach (var (after, before) in Snapshot)
            {
                var obj = Workspace.Canvas.GetObjectFromReference(after) ?? throw new NotImplementedException();
                if (before == null)
                {
                    Workspace.Canvas.RemoveObject(after);
                    snapshot.Add((after, obj));
                    Workspace.Shadow.RemoveObject(after);
                }
                else
                {
                    before.CopyTo(obj);
                    snapshot.Add((after, before));
                    Workspace.Shadow.SwapObjects(after, before);
                }
            }

            Snapshot = snapshot;
        }

        /// <inheritdoc/>
        public override void Redo()
        {
            var snapshot = new Collection<(CanvasObject, CanvasObject?)>();
            foreach (var (after, before) in Snapshot)
            {
                if (before == null) throw new NotImplementedException();
                var obj = Workspace.Canvas.GetObjectFromReference(after);
                if (obj == null)
                {
                    Workspace.Canvas.AddObject(before);
                    snapshot.Add((after, null));
                }
                else
                {
                    before.CopyTo(after);
                    snapshot.Add((after, before));
                    Workspace.Shadow.SwapObjects(obj, before);
                }
            }

            Snapshot = snapshot;
        }

        /// <inheritdoc/>
        public override void PaintBefore(Graphics graphics)
        {
            foreach (var (_, before) in Snapshot)
            {
                if (before != null) before.Component?.Paint(graphics, before.Location);
            }
        }

        /// <inheritdoc/>
        public override void PaintAfter(Graphics graphics)
        {
            foreach (var (after, _) in Snapshot)
            {
                after.Component?.Paint(graphics, after.Location);
            }
        }

        /// <inheritdoc/>
        protected override RectangleF CalcBounds()
        {
            var topLeft = PointF.Empty;
            var bottomRight = PointF.Empty;

            foreach (var (after, before) in Snapshot)
            {
                ExpandBounds(ref topLeft, ref bottomRight, after.Bounds);
                if (before != null) ExpandBounds(ref topLeft, ref bottomRight, before.Bounds);
            }

            return new RectangleF(topLeft, bottomRight.Substract(topLeft).ToSize());
        }
    }
}
