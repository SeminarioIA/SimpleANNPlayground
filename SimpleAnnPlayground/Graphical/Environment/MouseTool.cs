// <copyright file="MouseTool.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

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
            Workspace.PictureBox.Click += PictureBox_Click;
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
        public MouseState State => Inserting != null ? MouseState.Inserting
            : Moving != null ? MouseState.Moving
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
        public CanvasObject? Moving { get; private set; }

        /// <summary>
        /// Configures the mouse tool to insert an object.
        /// </summary>
        /// <param name="obj">The object to insert.</param>
        public void InsertObject(CanvasObject obj)
        {
            Inserting = obj;
        }

        /// <summary>
        /// Cancells the current operation.
        /// </summary>
        public void CancelOperation()
        {
            switch (State)
            {
                case MouseState.Inserting:
                {
                    Inserting = null;
                    break;
                }

                case MouseState.Moving:
                    break;
                case MouseState.Connecting:
                    break;
            }
        }

        /// <summary>
        /// Paints the mouse operations in the given <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">The graphics to perform the paint operation.</param>
        internal void Paint(Graphics graphics)
        {
            if (Configuration.CrossVisible && Location is PointF point)
            {
                if (Inserting is CanvasObject inserting)
                {
                    inserting.Location = Point.Truncate(point);
                    inserting.Draw(graphics);
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

            switch (State)
            {
                case MouseState.Idle:
                    break;
                case MouseState.Selecting:
                    break;
                case MouseState.Inserting:
                    break;
                case MouseState.Moving:
                {
                    if (Moving != null) Moving.Location = Point.Truncate((PointF)Location);
                    break;
                }

                case MouseState.Connecting:
                    break;
                default:
                    break;
            }

            MouseMove?.Invoke(this, new EventArgs());
            Workspace.Paint();
        }

        private void PictureBox_MouseLeave(object? sender, EventArgs e)
        {
            ControlLocation = null;
            Location = null;
            MouseMove?.Invoke(this, new EventArgs());
            Workspace.Paint();
        }

        private void PictureBox_Click(object? sender, EventArgs e)
        {
            switch (State)
            {
                case MouseState.Idle:
                    break;
                case MouseState.Inserting:
                {
                    if (Inserting != null)
                    {
                        Workspace.Canvas.AddObject(Inserting);
                        Workspace.Shadow.AddObject(Inserting);
                        Inserting.SetStateFlag(Component.State.Selected);
                        ObjectAdded?.Invoke(this, new ObjectAddedEventArgs(Inserting, Workspace));
                        Inserting = null;
                    }

                    break;
                }

                case MouseState.Moving:
                    break;
                case MouseState.Connecting:
                    break;
                default:
                    break;
            }
        }

        private void PictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (Location == null) return;
            switch (State)
            {
                case MouseState.Idle:
                {
                    if (Workspace.Canvas.IsObject(Location.Value) is CanvasObject obj)
                    {
                        Moving = obj;
                        Moving.SetStateFlag(Component.State.Selected);
                    }

                    break;
                }

                case MouseState.Inserting:
                    break;
                case MouseState.Moving:
                    break;
                case MouseState.Connecting:
                    break;
                default:
                    break;
            }
        }

        private void PictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (Location == null) return;
            switch (State)
            {
                case MouseState.Idle:
                    break;
                case MouseState.Selecting:
                    break;
                case MouseState.Inserting:
                    break;
                case MouseState.Moving:
                {
                    if (Moving != null)
                    {
                        Workspace.Shadow.MoveObject(Moving);
                        Moving = null;
                    }

                    break;
                }

                case MouseState.Connecting:
                    break;
                default:
                    break;
            }
        }
    }
}
