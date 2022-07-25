// <copyright file="ObjectsAction.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Visualization;
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
            Snapshot = Workspace.Shadow.GetObjectsWithReference(objects);

            // Apply the changes in the shadow.
            foreach (var (obj, shadow) in Snapshot)
            {
                if (shadow != null) Workspace.Shadow.RemoveObject(shadow);
                Workspace.Shadow.AddObject(obj);
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
            foreach (var (obj, oldShadow) in Snapshot)
            {
                var shadow = Workspace.Shadow.GetObjectFromReference(obj);
                snapshot.Add((obj, shadow));
                if (shadow == null) Workspace.Canvas.AddObject(obj);
                else if (oldShadow == null) Workspace.Canvas.RemoveObject(obj);
                else oldShadow.CopyTo(obj);
                Workspace.Shadow.SwapObjects(shadow, oldShadow);
            }

            Snapshot = snapshot;
        }

        /// <inheritdoc/>
        public override void Redo()
        {
            var snapshot = new Collection<(CanvasObject, CanvasObject?)>();
            foreach (var (obj, oldShadow) in Snapshot)
            {
                var shadow = Workspace.Shadow.GetObjectFromReference(obj);
                snapshot.Add((obj, shadow));
                if (shadow == null) Workspace.Canvas.AddObject(obj);
                else if (oldShadow == null) Workspace.Canvas.RemoveObject(obj);
                else oldShadow.CopyTo(obj);
                Workspace.Shadow.SwapObjects(shadow, oldShadow);
            }

            Snapshot = snapshot;
        }
    }
}
