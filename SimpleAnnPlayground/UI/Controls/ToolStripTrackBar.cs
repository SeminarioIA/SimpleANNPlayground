// <copyright file="ToolStripTrackBar.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.UI.Controls
{
    /// <summary>
    /// A custom track bar control based on the progress bar.
    /// </summary>
    public partial class ToolStripTrackBar : ToolStripProgressBar
    {
        private static readonly Brush _brush = Brushes.ForestGreen;
        private Point? _trackPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripTrackBar"/> class.
        /// </summary>
        public ToolStripTrackBar()
        {
            InitializeComponent();

            // do this to allow the Paint event to be fired and more ...
            if (typeof(Control) is not Type controlType) return;
            var setStyleMethod = controlType.GetMethod("SetStyle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (setStyleMethod == null) return;
            object[] style = new object[] { ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true };
            _ = setStyleMethod.Invoke(ProgressBar, style);
        }

        /// <summary>
        /// Occurs when the value in changed by the user.
        /// </summary>
        public event EventHandler? ValueChanged;

        /// <inheritdoc/>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null || !Enabled) return;
            Rectangle rectangle = e.ClipRectangle;
            rectangle.Width = (int)(rectangle.Width * ((double)Value / Maximum)) - 4;
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rectangle.Height = Height - 4;
            e.Graphics.FillRectangle(_brush, 2, 2, rectangle.Width, rectangle.Height);
        }

        /// <inheritdoc/>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e != null) _trackPoint = e.Location;
            UpdateValue();
            base.OnMouseDown(e);
        }

        /// <inheritdoc/>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _trackPoint = null;
            base.OnMouseDown(e);
        }

        /// <inheritdoc/>
        protected override void OnMouseMove(MouseEventArgs mea)
        {
            if (mea != null && _trackPoint != null)
            {
                _trackPoint = mea.Location;
                UpdateValue();
            }

            base.OnMouseMove(mea);
        }

        /// <summary>
        /// Raises the <see cref="ValueChanged"/> event.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        private void UpdateValue()
        {
            if (_trackPoint == null) return;
            int x = Math.Min(Math.Max(0, _trackPoint.Value.X), Width);
            Value = (Maximum - Minimum) * x / Bounds.Width;
            OnValueChanged(new EventArgs());
        }
    }
}
