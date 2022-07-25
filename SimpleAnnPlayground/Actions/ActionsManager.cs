// <copyright file="ActionsManager.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Visualization;
using System.Collections.ObjectModel;
using static SimpleAnnPlayground.Actions.RecordableAction;

namespace SimpleAnnPlayground.Actions
{
    /// <summary>
    /// Manages the reversable actions performed in a document.
    /// </summary>
    internal class ActionsManager
    {
        /// <summary>
        /// The list of performed actions.
        /// </summary>
        private readonly Stack<RecordableAction> _actions;

        /// <summary>
        /// The list of actions reverted.
        /// </summary>
        private readonly Stack<RecordableAction> _reverted;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionsManager"/> class.
        /// </summary>
        /// <param name="workspace">The workspace owning this <see cref="ActionsManager"/>.</param>
        public ActionsManager(Workspace workspace)
        {
            Workspace = workspace;
            _actions = new Stack<RecordableAction>();
            _reverted = new Stack<RecordableAction>();
        }

        /// <summary>
        /// Ocurs when there is a performed action.
        /// </summary>
        public event EventHandler? ActionPerformed;

        /// <summary>
        /// Gets the <see cref="Workspace"/> linked to this <see cref="ActionsManager"/>.
        /// </summary>
        public Workspace Workspace { get; private set; }

        /// <summary>
        /// Gets a value indicating whether there are actions to undo.
        /// </summary>
        public bool CanUndo => _actions.Any();

        /// <summary>
        /// Gets a value indicating whether there are actions to redo.
        /// </summary>
        public bool CanRedo => _reverted.Any();

        /// <summary>
        /// Reverts the latest performed action.
        /// </summary>
        public void Undo()
        {
            if (_actions.TryPop(out RecordableAction? action))
            {
                action.Undo();
                _reverted.Push(action);
                Workspace.Refresh();
            }
        }

        /// <summary>
        /// Performs the latest reverted action.
        /// </summary>
        public void Redo()
        {
            if (_reverted.TryPop(out RecordableAction? action))
            {
                action.Redo();
                _actions.Push(action);
                Workspace.Refresh();
            }
        }

        /// <summary>
        /// Adds a new <see cref="ObjectsAction"/> to the collection of actions.
        /// </summary>
        /// <param name="type">The type of action to add.</param>
        /// <param name="objects">The list of refence objects.</param>
        public void AddObjectsAction(ActionType type, Collection<CanvasObject> objects)
        {
            // Create a new action from the given objects and type.
            AddAction(new ObjectsAction(Workspace, type, objects));
        }

        /// <summary>
        /// Adds a new <see cref="ConnectionsActions"/> to the collection of actions.
        /// </summary>
        /// <param name="type">The type of action to add.</param>
        /// <param name="connections">The list of refence connections.</param>
        public void AddConnectionsAction(ActionType type, Collection<Connection> connections)
        {
            AddAction(new ConnectionsActions(Workspace, type, connections));
        }

        private void AddAction(RecordableAction action)
        {
            // Clear redo actions.
            _reverted.Clear();

            // Add the action to the collection of actions.
            _actions.Push(action);

            // Invoke ActionPerformed event.
            ActionPerformed?.Invoke(this, new EventArgs());
        }
    }
}
