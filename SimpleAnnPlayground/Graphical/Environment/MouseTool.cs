// <copyright file="MouseTool.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Tools;
using SimpleAnnPlayground.Utils;

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
            obj.SetStateFlag(Component.State.Selected);
            Moving = new MovingBag(startPoint, Workspace.Canvas.GetSelectedObjects());
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
        /// <param name="obj">The source object to connect.</param>
        /// <param name="start">The selected connector.</param>
        public void StartConnection(CanvasObject obj, Connector start)
        {
            Workspace.Canvas.UnselectAll();
            obj.ClearStateFlag(Component.State.Hover);
            Connecting = new ConnectingLine(obj, start);
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
                Workspace.Canvas.AddObject(Inserting);
                Workspace.Shadow.AddObject(Inserting);
                Inserting.SetStateFlag(Component.State.Selected);
                ObjectAdded?.Invoke(this, new ObjectAddedEventArgs(Inserting, Workspace));
                Inserting = null;
            }
            else if (Moving != null)
            {
                Workspace.Shadow.MoveObjects(Moving.Selection);
                Moving = null;
            }
            else if (Selecting != null)
            {
                Selecting = null;
            }
            else if (Connecting != null)
            {
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
                    Inserting.Draw(graphics);
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

        private void PictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            ControlLocation = e.Location;
            Location = Space.ScalePoint((PointF)ControlLocation, Workspace.Transform);

            if (State == MouseState.Idle)
            {
                Workspace.Canvas.UpdateMousePosition(Location.Value);
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
                Connecting.UpdateEndPoint(Location.Value);
                Workspace.Canvas.UpdateConnectingPosition(Location.Value, Connecting);
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
            if (Location != null && State == MouseState.Idle)
            {
                if (Workspace.Canvas.IsObject(Location.Value) is CanvasObject obj)
                {
                    if (obj.ActiveConnector != null)
                    {
                        StartConnection(obj, obj.ActiveConnector);
                    }
                    else
                    {
                        MoveObjects(obj, Location.Value);
                    }
                }
                else
                {
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
