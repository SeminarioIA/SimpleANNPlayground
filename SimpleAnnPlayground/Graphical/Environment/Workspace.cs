// <copyright file="Workspace.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Actions;
using SimpleAnnPlayground.Graphical.Environment.EventsArgs;
using SimpleAnnPlayground.Graphical.Visualization;
using System.Drawing.Drawing2D;

namespace SimpleAnnPlayground.Graphical.Environment
{
    /// <summary>
    /// Graphical workspace helper class.
    /// </summary>
    internal class Workspace
    {
        /// <summary>
        /// The zoom scale of this workspace.
        /// </summary>
        private readonly int[] _zoomScale = new int[] { 50, 80, 100, 150, 200, 300, 500 };

        /// <summary>
        /// The selected zoom index from the zoom scale.
        /// </summary>
        private int _zoomIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Workspace"/> class.
        /// </summary>
        /// <param name="pictureBox">The PictureBox for this workspace.</param>
        /// <param name="hScrollBar">The horizontal scroll bar control.</param>
        /// <param name="vScrollBar">The vertical scroll bar control.</param>
        public Workspace(PictureBox pictureBox, HScrollBar hScrollBar, VScrollBar vScrollBar)
        {
            PictureBox = pictureBox;
            HScrollBar = hScrollBar;
            VScrollBar = vScrollBar;
            WorkSheet = new WorkSheet(new Size(PictureBox.Width - 50, pictureBox.Height - 50));
            MouseTool = new MouseTool(this);
            Transform = new Matrix();
            Canvas = new Canvas();
            Shadow = new ShadowCanvas();
            Actions = new ActionsManager(this);

            // PictureBox events.
            PictureBox.Paint += PictureBox_Paint;
            PictureBox.Resize += PictureBox_Resize;

            HScrollBar.Minimum = WorkSheet.Bounds.Left;
            HScrollBar.Maximum = WorkSheet.Bounds.Right;
            VScrollBar.Minimum = WorkSheet.Bounds.Top;
            VScrollBar.Maximum = WorkSheet.Bounds.Bottom;

            // Scrollbars events.
            HScrollBar.ValueChanged += ScrollBar_ValueChanged;
            VScrollBar.ValueChanged += ScrollBar_ValueChanged;

            RestoreZoom();
        }

        /// <summary>
        /// Ocurs when the mouse had selected a new object.
        /// </summary>
        public event EventHandler<SelectionChangedEventArgs>? SelectionChanged;

        /// <summary>
        /// Gets the <seealso cref="PictureBox"/> object linked to this workspace.
        /// </summary>
        public PictureBox PictureBox { get; }

        /// <summary>
        /// Gets the horizontal scroll bar control of this workspace.
        /// </summary>
        public HScrollBar HScrollBar { get; }

        /// <summary>
        /// Gets the vertical scroll bar control of this workspace.
        /// </summary>
        public VScrollBar VScrollBar { get; }

        /// <summary>
        /// Gets the workspace sheet.
        /// </summary>
        public WorkSheet WorkSheet { get; private set; }

        /// <summary>
        /// Gets the active <seealso cref="MouseTool"/> object.
        /// </summary>
        public MouseTool MouseTool { get; private set; }

        /// <summary>
        /// Gets the transform of this <see cref="Workspace"/>.
        /// </summary>
        public Matrix Transform { get; private set; }

        /// <summary>
        /// Gets the main canvas where the objects are drawn.
        /// </summary>
        public Canvas Canvas { get; private set; }

        /// <summary>
        /// Gets the shadow canvas where the original objects are saved.
        /// </summary>
        public ShadowCanvas Shadow { get; private set; }

        /// <summary>
        /// Gets the <see cref="ActionsManager"/> of this workspace.
        /// </summary>
        public ActionsManager Actions { get; }

        /// <summary>
        /// Gets the current zoom value.
        /// </summary>
        public int Zoom => _zoomScale[_zoomIndex];

        /// <summary>
        /// Gets the current transform scale.
        /// </summary>
        public float Scale => Zoom / 100f;

        /// <summary>
        /// Forces to paint the workspace.
        /// </summary>
        public void Refresh() => PictureBox.Invalidate();

        /// <summary>
        /// Centers the sheet in the viewing area.
        /// </summary>
        public void CenterSheetView()
        {
            HScrollBar.Value = 0;
            VScrollBar.Value = 0;
        }

        /// <summary>
        /// Executes a zoom in operation in the workspace.
        /// </summary>
        public void ZoomIn()
        {
            if (_zoomIndex < _zoomScale.Length - 1) _zoomIndex++;
            UpdateTransform();
        }

        /// <summary>
        /// Executes a zoom out operation in the workspace.
        /// </summary>
        public void ZoomOut()
        {
            if (_zoomIndex > 0) _zoomIndex--;
            UpdateTransform();
        }

        /// <summary>
        /// Restores the zoom to the default value.
        /// </summary>
        public void RestoreZoom()
        {
            _zoomIndex = _zoomScale.ToList().IndexOf(100);
            UpdateTransform();
        }

        private void UpdateTransform()
        {
            Transform.Reset();
            Transform.Translate(PictureBox.Width / 2f, PictureBox.Height / 2f);
            Transform.Scale(Scale, Scale);
            Transform.Translate(-HScrollBar.Value, -VScrollBar.Value);
            Refresh();
        }

        private void PictureBox_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.Transform = Transform;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the work sheet.
            WorkSheet.Paint(e.Graphics);

            // Draw the shadow canvas.
            /* Shadow.Paint(e.Graphics); */

            // Draw the main canvas.
            Canvas.Paint(e.Graphics);

            // Draw mouse tool controls.
            MouseTool.Paint(e.Graphics);
        }

        private void PictureBox_Resize(object? sender, EventArgs e)
        {
            UpdateTransform();
        }

        private void ScrollBar_ValueChanged(object? sender, EventArgs e)
        {
            SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(sender));
            UpdateTransform();
        }
    }
}
