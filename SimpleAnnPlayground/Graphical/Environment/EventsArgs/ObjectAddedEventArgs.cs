// <copyright file="ObjectAddedEventArgs.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Visualization;

namespace SimpleAnnPlayground.Graphical.Environment.EventsArgs
{
    /// <summary>
    /// Event arguments for the <see cref="MouseTool.ObjectAdded"/> event.
    /// </summary>
    internal class ObjectAddedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAddedEventArgs"/> class.
        /// </summary>
        /// <param name="obj">The object being added.</param>
        /// <param name="workspace">The workspace where the object was added.</param>
        public ObjectAddedEventArgs(CanvasObject obj, Workspace workspace)
        {
            Object = obj;
            Workspace = workspace;
        }

        /// <summary>
        /// Gets the inserted object.
        /// </summary>
        public CanvasObject Object { get; private set; }

        /// <summary>
        /// Gets the workspace where the object was added.
        /// </summary>
        public Workspace Workspace { get; private set; }
    }
}
