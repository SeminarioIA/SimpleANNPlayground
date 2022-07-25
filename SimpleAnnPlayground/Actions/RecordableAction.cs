// <copyright file="RecordableAction.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Visualization;

namespace SimpleAnnPlayground.Actions
{
    /// <summary>
    /// Represents an action in the document.
    /// </summary>
    internal abstract class RecordableAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecordableAction"/> class.
        /// </summary>
        /// <param name="workspace">The reference to the current workspace.</param>
        /// <param name="actionType">The type of action.</param>
        protected RecordableAction(Workspace workspace, ActionType actionType)
        {
            Workspace = workspace;
            Type = actionType;
        }

        /// <summary>
        /// List of actions allowed by the application.
        /// </summary>
        public enum ActionType
        {
            /// <summary>
            /// A new <see cref="CanvasObject"/> was inserting.
            /// </summary>
            Inserted,

            /// <summary>
            /// A group of selected objects was moved.
            /// </summary>
            Moved,

            /// <summary>
            /// A connection between two neurons was performed.
            /// </summary>
            Connected,

            /// <summary>
            /// A disconnection of two neurons was performed.
            /// </summary>
            Disconnected,
        }

        /// <summary>
        /// Gets the type of this action.
        /// </summary>
        public ActionType Type { get; }

        /// <summary>
        /// Gets the workspace.
        /// </summary>
        public Workspace Workspace { get; }

        /// <summary>
        /// Undoes the action.
        /// </summary>
        public abstract void Undo();

        /// <summary>
        /// Performs the action.
        /// </summary>
        public abstract void Redo();
    }
}
