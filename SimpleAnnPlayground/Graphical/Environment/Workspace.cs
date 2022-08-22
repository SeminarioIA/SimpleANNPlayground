// <copyright file="Workspace.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Actions;
using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Graphical.Environment.EventsArgs;
using SimpleAnnPlayground.Graphical.Visualization;
using SimpleAnnPlayground.Storage;
using System.Collections.ObjectModel;
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
            DataTable = new DataTable();

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
        /// Occurs when the mouse had selected a new object.
        /// </summary>
        public event EventHandler<SelectionChangedEventArgs>? SelectionChanged;

        /// <summary>
        /// Occurs when the data table is cleared or changes.
        /// </summary>
        public event EventHandler? DataTableChanged;

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
        /// Gets the workspace data table.
        /// </summary>
        public DataTable DataTable { get; private set; }

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
        /// Gets a value indicating whether the workspace is in read only mode.
        /// </summary>
        public bool ReadOnly { get; private set; }

        /// <summary>
        /// Forces to paint the workspace.
        /// </summary>
        public void Refresh() => PictureBox.Invalidate();

        /// <summary>
        /// Set the workspace as read only.
        /// </summary>
        public void SetReadOnly()
        {
            ReadOnly = true;
            if (Canvas.GetSelectedObjects().Any()) Canvas.UnselectAll();
        }

        /// <summary>
        /// Sets the workspace as editable.
        /// </summary>
        public void SetEditable()
        {
            ReadOnly = false;
        }

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

        /// <summary>
        /// Generates a document to save the workspace information into a file.
        /// </summary>
        /// <returns>The generated document.</returns>
        public Document GenerateDocument()
        {
            var dataLinks = new Collection<DataLink>();
            foreach (var obj in Canvas.Objects)
            {
                switch (obj)
                {
                    case Input input:
                        if (input.DataLabel != null) dataLinks.Add(new DataLink(input.Id, input.DataLabel.Text));
                        break;
                    case Output output:
                        if (output.DataLabel != null) dataLinks.Add(new DataLink(output.Id, output.DataLabel.Text));
                        break;
                }
            }

            return new(WorkSheet, Canvas, DataTable, dataLinks);
        }

        /// <summary>
        /// Loads an existing document into the workspace.
        /// </summary>
        /// <param name="document">The document to load.</param>
        public void LoadDocument(Document document)
        {
            MouseTool.CancelOperation();
            WorkSheet = document.WorkSheet;
            Canvas = document.Canvas;
            Shadow = new ShadowCanvas(Canvas);
            DataTable = document.DataTable;
            DataTableChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Cleans the workspace.
        /// </summary>
        internal void Clean()
        {
            Canvas.Objects.Clear();
            Canvas.Connections.Clear();
            Shadow.Objects.Clear();
            Shadow.Connections.Clear();
            DataTable.Clear();
            Actions.Clear();
            Refresh();
            DataTableChanged?.Invoke(this, EventArgs.Empty);
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
