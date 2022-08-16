// <copyright file="ConnectionAction.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Utils.Graphics;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Actions
{
    /// <summary>
    /// Represents the actions performed in the draw with <see cref="Connection"/>.
    /// </summary>
    internal class ConnectionAction : RecordableAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionAction"/> class.
        /// </summary>
        /// <param name="workspace">The reference to the current workspace.</param>
        /// <param name="connections">The list of refence connections.</param>
        public ConnectionAction(Workspace workspace, Collection<Connection> connections)
            : base(workspace, ActionType.Connected)
        {
            foreach (var connection in connections)
            {
                Workspace.Canvas.AddConnection(connection);
                Workspace.Shadow.AddConnection(connection);
            }

            Snapshot = Workspace.Shadow.GetConnectionsWithReference(connections);
        }

        /// <summary>
        /// Gets the collection of pairs (object, shadow) of the modified connections with their shadows.
        /// </summary>
        public Collection<(Connection, Connection)> Snapshot { get; private set; }

        /// <inheritdoc/>
        public override void Undo()
        {
            foreach (var (connection, shadow) in Snapshot)
            {
                Workspace.Canvas.RemoveConnection(connection);
                Workspace.Shadow.RemoveConnection(shadow);
            }
        }

        /// <inheritdoc/>
        public override void Redo()
        {
            foreach (var (connection, shadow) in Snapshot)
            {
                Workspace.Canvas.AddConnection(connection);
                Workspace.Shadow.RestoreShadowConnection(shadow);
            }
        }

        /// <inheritdoc/>
        public override void PaintBefore(Graphics graphics)
        {
            foreach (var (_, shadow) in Snapshot)
            {
                shadow.Paint(graphics);
            }
        }

        /// <inheritdoc/>
        public override void PaintAfter(Graphics graphics)
        {
            foreach (var (connection, _) in Snapshot)
            {
                connection.Paint(graphics);
            }
        }

        /// <inheritdoc/>
        protected override RectangleF CalcBounds()
        {
            var topLeft = PointF.Empty;
            var bottomRight = PointF.Empty;

            foreach (var (connection, shadow) in Snapshot)
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
