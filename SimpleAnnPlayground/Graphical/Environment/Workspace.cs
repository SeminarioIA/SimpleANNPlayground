// <copyright file="Workspace.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

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

            // PictureBox events.
            PictureBox.Paint += PictureBox_Paint;
            PictureBox.Resize += PictureBox_Resize;

            HScrollBar.Minimum = WorkSheet.Bounds.Left;
            HScrollBar.Maximum = WorkSheet.Bounds.Right;
            VScrollBar.Minimum = WorkSheet.Bounds.Top;
            VScrollBar.Maximum = WorkSheet.Bounds.Bottom;

            // Scrollbars events.
            HScrollBar.ValueChanged += HScrollBar_ValueChanged;
            VScrollBar.ValueChanged += VScrollBar_ValueChanged;

            CenterSheetView();
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
        public HScrollBar? HScrollBar { get; }

        /// <summary>
        /// Gets the vertical scroll bar control of this workspace.
        /// </summary>
        public VScrollBar? VScrollBar { get; }

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
        /// Forces to paint the workspace.
        /// </summary>
        public void Refresh() => PictureBox.Invalidate();

        /// <summary>
        /// Centers the sheet in the viewing area.
        /// </summary>
        public void CenterSheetView()
        {
            Transform.Reset();
            Transform.Translate(PictureBox.Width / 2, PictureBox.Height / 2);
            PictureBox.Invalidate();
        }

        private void PictureBox_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.Transform = Transform;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the work sheet.
            WorkSheet.Paint(e.Graphics);

            // Draw the shadow canvas.
            Shadow.Paint(e.Graphics);

            // Draw the main canvas.
            Canvas.Paint(e.Graphics);

            // Draw mouse tool controls.
            MouseTool.Paint(e.Graphics);
        }

        private void PictureBox_Resize(object? sender, EventArgs e)
        {
            Transform.Reset();
            Transform.Translate(PictureBox.Width / 2, PictureBox.Height / 2);
            PictureBox.Invalidate();
        }

        private void HScrollBar_ValueChanged(object? sender, EventArgs e)
        {
            SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(HScrollBar));
            Transform.Reset();
            Transform.Translate(PictureBox.Width / 2f - HScrollBar?.Value ?? 0, PictureBox.Height / 2f - VScrollBar?.Value ?? 0);
            Refresh();
        }

        private void VScrollBar_ValueChanged(object? sender, EventArgs e)
        {
            SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(VScrollBar));
            Transform.Reset();
            Transform.Translate(PictureBox.Width / 2f - HScrollBar?.Value ?? 0, PictureBox.Height / 2f - VScrollBar?.Value ?? 0);
            Refresh();
        }
    }
}
