// <copyright file="RemoveAction.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Visualization;
using SimpleAnnPlayground.Utils.Graphics;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Actions
{
    /// <summary>
    /// Represents a delete action.
    /// </summary>
    internal class RemoveAction : RecordableAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveAction"/> class.
        /// </summary>
        /// <param name="workspace">The reference to the current workspace.</param>
        /// <param name="actionType">The type of action.</param>
        /// <param name="objects">The list of refence objects.</param>
        /// <param name="connections">The list of refence connections.</param>
        public RemoveAction(Workspace workspace, ActionType actionType, Collection<CanvasObject> objects, Collection<Connection> connections)
            : base(workspace, actionType)
        {
            Objects = Workspace.Shadow.GetObjectsWithReference(objects);
            Connections = Workspace.Shadow.GetConnectionsWithReference(connections);

            // Apply the objects changes in the canvas and shadow.
            foreach (var (obj, shadow) in Objects)
            {
                Workspace.Canvas.RemoveObject(obj);
                if (shadow != null) Workspace.Shadow.RemoveObject(shadow);
            }

            // Apply the connections changes in the shadow.
            foreach (var (connection, shadow) in Connections)
            {
                Workspace.Canvas.RemoveConnection(connection);
                Workspace.Shadow.RemoveConnection(shadow);
            }
        }

        /// <summary>
        /// Gets the collection of pairs (object, shadow) of the modified objects with their shadows.
        /// </summary>
        public Collection<(CanvasObject, CanvasObject?)> Objects { get; private set; }

        /// <summary>
        /// Gets the collection of pairs (object, shadow) of the modified connections with their shadows.
        /// </summary>
        public Collection<(Connection, Connection)> Connections { get; private set; }

        /// <inheritdoc/>
        public override void Undo()
        {
            // Restore objects.
            foreach (var (obj, shadow) in Objects)
            {
                Workspace.Canvas.AddObject(obj);
                if (shadow != null) Workspace.Shadow.RestoreShadowObject(shadow);
            }

            // Restore connections.
            foreach (var (connection, shadow) in Connections)
            {
                Workspace.Canvas.AddConnection(connection);
                Workspace.Shadow.RestoreShadowConnection(shadow);
            }
        }

        /// <inheritdoc/>
        public override void Redo()
        {
            // Remove objects again.
            foreach (var (obj, shadow) in Objects)
            {
                Workspace.Canvas.RemoveObject(obj);
                if (shadow != null) Workspace.Shadow.RemoveObject(shadow);
            }

            // Remove connections again.
            foreach (var (connection, shadow) in Connections)
            {
                Workspace.Canvas.RemoveConnection(connection);
                Workspace.Shadow.RemoveConnection(shadow);
            }
        }

        /// <inheritdoc/>
        public override void PaintBefore(Graphics graphics)
        {
            foreach (var (_, shadow) in Objects)
            {
                if (shadow != null) shadow.Paint(graphics);
            }

            foreach (var (_, shadow) in Connections)
            {
                shadow.Paint(graphics);
            }
        }

        /// <inheritdoc/>
        public override void PaintAfter(Graphics graphics)
        {
            foreach (var (obj, _) in Objects)
            {
                obj.Paint(graphics);
            }

            foreach (var (connection, _) in Connections)
            {
                connection.Paint(graphics);
            }
        }

        /// <inheritdoc/>
        protected override RectangleF CalcBounds()
        {
            var topLeft = PointF.Empty;
            var bottomRight = PointF.Empty;

            foreach (var (obj, shadow) in Objects)
            {
                ExpandBounds(ref topLeft, ref bottomRight, obj.Bounds);
                if (shadow != null) ExpandBounds(ref topLeft, ref bottomRight, shadow.Bounds);
            }

            foreach (var (connection, shadow) in Connections)
            {
                ExpandBounds(ref topLeft, ref bottomRight, connection.Source.Location);
                ExpandBounds(ref topLeft, ref bottomRight, connection.Destination.Location);
                ExpandBounds(ref topLeft, ref bottomRight, shadow.Source.Location);
                ExpandBounds(ref topLeft, ref bottomRight, shadow.Destination.Location);
            }

            return new RectangleF(topLeft, bottomRight.Substract(topLeft).ToSize());
        }
    }
}
