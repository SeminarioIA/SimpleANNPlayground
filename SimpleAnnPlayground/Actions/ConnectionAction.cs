// <copyright file="ConnectionAction.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Environment;
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
    }
}
