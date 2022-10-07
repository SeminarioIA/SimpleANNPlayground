// <copyright file="MouseTool.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Environment.EventsArgs;
using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Terminals;
using SimpleAnnPlayground.Graphical.Tools;
using SimpleAnnPlayground.Graphical.Visualization;
using SimpleAnnPlayground.Utils.Graphics;
using System.Collections.ObjectModel;
using static SimpleAnnPlayground.Actions.RecordableAction;

namespace SimpleAnnPlayground.Graphical.Environment
{
    /// <summary>
    /// Mouse tool to work in a workspace.
    /// </summary>
    internal class MouseTool
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MouseTool"/> class.
        /// </summary>
        /// <param name="workspace">The workspace owning this <see cref="MouseTool"/>.</param>
        internal MouseTool(Workspace workspace)
        {
            Configuration = new MouseConfiguration() { CrossVisible = true };

            Workspace = workspace;
            Workspace.PictureBox.MouseMove += PictureBox_MouseMove;
            Workspace.PictureBox.MouseLeave += PictureBox_MouseLeave;
            Workspace.PictureBox.MouseDown += PictureBox_MouseDown;
            Workspace.PictureBox.MouseUp += PictureBox_MouseUp;
        }

        /// <summary>
        /// Ocurs when the mouse moves in the workspace area.
        /// </summary>
        public event EventHandler? MouseMove;

        /// <summary>
        /// Ocurs when an object is added to a workspace.
        /// </summary>
        public event EventHandler<ObjectAddedEventArgs>? ObjectAdded;

        /// <summary>
        /// Ocurs when the mouse had selected a new object.
        /// </summary>
        public event EventHandler<SelectionChangedEventArgs>? SelectionChanged;

        /// <summary>
        /// The current state of the <see cref="MouseTool"/>.
        /// </summary>
        public enum MouseState
        {
            /// <summary>
            /// Mouse is idle.
            /// </summary>
            Idle,

            /// <summary>
            /// Mouse is selecting objects in the workspace.
            /// </summary>
            Selecting,

            /// <summary>
            /// Mouse is inserting a new <see cref="Component"/>.
            /// </summary>
            Inserting,

            /// <summary>
            /// Mouse is moving a <see cref="Component"/>.
            /// </summary>
            Moving,

            /// <summary>
            /// Mouse connecting two <see cref="Connector"/> objects.
            /// </summary>
            Connecting,
        }

        /// <summary>
        /// Gets the current mouse state.
        /// </summary>
        public MouseState State => Selecting != null ? MouseState.Selecting
            : Inserting != null ? MouseState.Inserting
            : Moving != null ? MouseState.Moving
            : Connecting != null ? MouseState.Connecting
            : MouseState.Idle;

        /// <summary>
        /// Gets the mouse tool configurations.
        /// </summary>
        public MouseConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets the <see cref="Workspace"/> linked to this mouse tool.
        /// </summary>
        public Workspace Workspace { get; private set; }

        /// <summary>
        /// Gets the mouse location relative to the <see cref="PictureBox"/>.
        /// </summary>
        public Point? ControlLocation { get; private set; }

        /// <summary>
        /// Gets the mouse location relative to the workspace.
        /// </summary>
        public PointF? Location { get; private set; }

        /// <summary>
        /// Gets the object being inserted into the workspace.
        /// </summary>
        public CanvasObject? Inserting { get; private set; }

        /// <summary>
        /// Gets the object being moved in the workspace.
        /// </summary>
        public MovingBag? Moving { get; private set; }

        /// <summary>
        /// Gets the selection rectangle in the workspace.
        /// </summary>
        public SelectionBox? Selecting { get; private set; }

        /// <summary>
        /// Gets the line when connecting two objects.
        /// </summary>
        public ConnectingLine? Connecting { get; private set; }

        /// <summary>
        /// Configures the mouse tool to insert an object.
        /// </summary>
        /// <param name="obj">The object to insert.</param>
        public void InsertObject(CanvasObject obj)
        {
            Workspace.Canvas.UnselectAll();
            Inserting = obj;
            Workspace.PictureBox.Cursor = Cursors.Cross;
            Workspace.Refresh();
        }

        /// <summary>
        /// Configures the mouse tool to move an object.
        /// </summary>
        /// <param name="obj">The object to move.</param>
        /// <param name="startPoint">The movement start point.</param>
        public void MoveObjects(CanvasObject obj, PointF startPoint)
        {
            // Get the collection of selected objects.
            var selection = Workspace.Canvas.GetSelectedObjects();

            // Move the collection only if the mouse is over a selected object.
            if (!selection.Contains(obj))
            {
                // if not, then change the selection to the mouse object.
                selection = new Collection<CanvasObject>
                {
                    obj,
                };
            }

            // Unselect all the objects while moving.
            Workspace.Canvas.UnselectAll();

            // Create the moving bag to move the objects.
            Moving = new MovingBag(startPoint, selection);
            Workspace.PictureBox.Cursor = Cursors.SizeAll;
            Workspace.Refresh();
        }

        /// <summary>
        /// Starts selecting objects from the specified location.
        /// </summary>
        /// <param name="location">Point where the selection starts.</param>
        public void StartSelection(PointF location)
        {
            Workspace.Canvas.UnselectAll();
            Selecting = new SelectionBox(location);
            Workspace.PictureBox.Cursor = Cursors.Cross;
            Workspace.Refresh();
        }

        /// <summary>
        /// Starts connecting two objects.
        /// </summary>
        /// <param name="startTerminal">The selected connector.</param>
        public void StartConnection(Terminal startTerminal)
        {
            Workspace.Canvas.UnselectAll();
            Connecting = new ConnectingLine(Workspace, startTerminal);
            Workspace.PictureBox.Cursor = Cursors.Cross;
            Workspace.Refresh();
        }

        /// <summary>
        /// Finishes the current operation.
        /// </summary>
        public void FinishOperation()
        {
            if (State == MouseState.Idle) return;

            if (Inserting != null)
            {
                if (Workspace.PictureBox.Cursor != Cursors.No)
                {
                    // Add the object to the canvas.
                    Workspace.Canvas.AddObject(Inserting);

                    // Select the new inserted object.
                    Inserting.Selected = true;

                    // Grab the insertion action to be able to undo later.
                    Workspace.Actions.AddObjectsAction(ActionType.Inserted, Workspace.Canvas.GetSelectedObjects());

                    // Invoke SelectionChanged event.
                    OnSelectionChanged(Inserting);

                    // Invoke ObjectAdded event.
                    ObjectAdded?.Invoke(this, new ObjectAddedEventArgs(Inserting, Workspace));

                    // Finish the operation clearing Inserting.
                    Inserting = null;
                }
            }
            else if (Moving != null)
            {
                if (Moving.WasMoved)
                {
                    // Grab the moving action to be able to undo later.
                    Workspace.Actions.AddObjectsAction(ActionType.Moved, Moving.Selection);
                }

                // Select the moved objects.
                Workspace.Canvas.Select(Moving.Selection);

                // Invoke SelectionChanged event.
                OnSelectionChanged(Moving.Selection.FirstOrDefault());

                // Finish the operation clearing Moving.
                Moving = null;
            }
            else if (Selecting != null)
            {
                OnSelectionChanged(Workspace.Canvas.GetSelectedObjects().FirstOrDefault() as object
                    ?? Workspace.Canvas.GetSelectedConnections().FirstOrDefault());
                Selecting = null;
            }
            else if (Connecting != null)
            {
                if (Connecting.Finish() is Connection connection)
                {
                    // Add the connection action to be able to undo later.
                    Workspace.Actions.AddConnectionsAction(new Collection<Connection> { connection });
                }

                Connecting = null;
            }

            Workspace.PictureBox.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Cancells the current operation.
        /// </summary>
        public void CancelOperation()
        {
            if (State == MouseState.Idle) return;

            Inserting = null;
            Moving = null;
            Selecting = null;
            Connecting = null;

            Workspace.PictureBox.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Paints the mouse operations in the given <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">The graphics to perform the paint operation.</param>
        internal void Paint(Graphics graphics)
        {
            if (Configuration.CrossVisible && Location is PointF point)
            {
                if (Inserting != null)
                {
                    // Paint the object being inserted
                    Inserting.Location = Point.Truncate(point);
                    Inserting.Paint(graphics);
                }
                else if (Selecting != null)
                {
                    // Paint the selection rectangle.
                    Selecting.Paint(graphics);
                }
                else if (Connecting != null)
                {
                    // Paint the connecting line.
                    Connecting.Paint(graphics);
                }

                // Paint a mouse cross.
                if (Configuration.CrossVisible)
                {
                    var cross = new Cross(Color.Red, point, 10f);
                    cross.Paint(graphics);
                }
            }
        }

        /// <summary>
        /// Determines if the mouse tool is over an object.
        /// </summary>
        /// <returns>The <see cref="CanvasObject"/> , otherwise false.</returns>
        internal CanvasObject? GetObjectOver()
        {
            return Location != null && Workspace.Canvas.IsObject(Location.Value) is CanvasObject obj ? obj : null;
        }

        /// <summary>
        /// Determines if the mouse tool is over an object.
        /// </summary>
        /// <returns>The <see cref="CanvasObject"/> , otherwise false.</returns>
        internal Connection? GetConnectionOver()
        {
            return Location != null && Workspace.Canvas.IsConnection(Location.Value) is Connection conn ? conn : null;
        }

        /// <summary>
        /// Raises the <see cref="SelectionChanged"/> event.
        /// </summary>
        /// <param name="selectedObject">The object that was selected.</param>
        protected void OnSelectionChanged(object? selectedObject)
        {
            SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(selectedObject));

            if (Workspace.Network.Execution is not null)
            {
                Workspace.Network.Execution.SubGraph = selectedObject is Neuron neuron && neuron.Node is not null ? new Ann.Networks.SubGraph(neuron.Node, Workspace.DataTable) : null;
            }
        }

        private void PictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            ControlLocation = e.Location;
            Location = Space.ScalePoint((PointF)ControlLocation, Workspace.Transform);

            if (State == MouseState.Idle)
            {
                Workspace.Canvas.UpdateMousePosition(Location.Value);
                if (Workspace.Canvas.Objects.FirstOrDefault(obj => obj.State.HasFlag(Component.State.Hover)) is CanvasObject obj)
                {
                    if (Workspace.ToolTip.Tag != obj)
                    {
                        IWin32Window win = Workspace.PictureBox;
                        Workspace.ToolTip.Show(string.Join(System.Environment.NewLine, obj.Messages), win, e.Location);
                        Workspace.ToolTip.Tag = obj;
                    }
                }
                else
                {
                    Workspace.ToolTip.Hide(Workspace.PictureBox);
                    Workspace.ToolTip.Tag = null;
                }
            }
            else if (Inserting != null)
            {
                bool overOther = Workspace.Canvas.IntesectsObject(Inserting);
                bool insideSheet = Workspace.WorkSheet.IsInside(Inserting);
                Workspace.PictureBox.Cursor = overOther || !insideSheet ? Cursors.No : Cursors.Cross;
            }
            else if (Selecting != null)
            {
                Selecting.Extend(Location.Value);
                Workspace.Canvas.SelectArea(Selecting);
            }
            else if (Moving != null)
            {
                Moving.UpdateDestination(Location.Value);
            }
            else if (Connecting != null)
            {
                Workspace.Canvas.UpdateConnectingPosition(Location.Value, Connecting);
                Connecting.Update(Location.Value, Workspace.Canvas.GetActiveObject(Connecting.Start.Owner));
            }

            MouseMove?.Invoke(this, new EventArgs());
            Workspace.Refresh();
        }

        private void PictureBox_MouseLeave(object? sender, EventArgs e)
        {
            ControlLocation = null;
            Location = null;
            MouseMove?.Invoke(this, new EventArgs());
            Workspace.Refresh();
        }

        private void PictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (Location == null)
            {
                ControlLocation = e.Location;
                Location = Space.ScalePoint((PointF)ControlLocation, Workspace.Transform);
            }

            // Start an action from the mouse only id idle.
            if (State == MouseState.Idle)
            {
                // Check if the cursor is over an object.
                if (GetObjectOver() is CanvasObject obj)
                {
                    if (e.Button == MouseButtons.Left && !Workspace.ReadOnly)
                    {
                        // Check if the cursor is also over a connection terminal.
                        if (obj.ActiveTerminal != null)
                        {
                            // Start connecting terminals.
                            StartConnection(obj.ActiveTerminal);
                        }
                        else
                        {
                            // Move the selected objects.
                            MoveObjects(obj, Location.Value);
                        }
                    }
                    else if (e.Button == MouseButtons.Right || Workspace.ReadOnly)
                    {
                        // Select the object.
                        Workspace.Canvas.UnselectAll();
                        obj.Selected = true;
                        Workspace.Refresh();
                        OnSelectionChanged(obj);
                    }
                }
                else if (GetConnectionOver() is Connection connection)
                {
                    // Select the connection.
                    Workspace.Canvas.UnselectAll();
                    connection.Selected = true;
                    Workspace.Refresh();
                    OnSelectionChanged(connection);
                }
                else
                {
                    // If blank space then start a selection box.
                    StartSelection(Location.Value);
                }
            }
        }

        private void PictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            FinishOperation();
        }
    }
}
