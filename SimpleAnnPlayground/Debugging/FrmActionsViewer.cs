// <copyright file="FrmActionsViewer.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Actions;
using SimpleAnnPlayground.Utils;
using System.Drawing.Drawing2D;

namespace SimpleAnnPlayground.Debugging
{
    /// <summary>
    /// Debug window to visualize the document actions.
    /// </summary>
    internal partial class FrmActionsViewer : Form
    {
        private readonly ActionsManager _actionsManager;
        private RecordableAction? _action;
        private Matrix _transform;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmActionsViewer"/> class.
        /// </summary>
        /// <param name="actionsManager">The <see cref="ActionsManager"/> reference.</param>
        public FrmActionsViewer(ActionsManager actionsManager)
        {
            InitializeComponent();
            _actionsManager = actionsManager;
            _transform = new Matrix();
        }

        /// <summary>
        /// Updated the list of actions from the <see cref="ActionsManager"/>.
        /// </summary>
        internal void RefreshActions()
        {
            LstUndo.Items.Clear();
            foreach (var action in _actionsManager.UndoStack.Reverse())
            {
                _ = LstUndo.Items.Add(action);
            }

            LstRedo.Items.Clear();
            foreach (var action in _actionsManager.RedoStack)
            {
                _ = LstRedo.Items.Add(action);
            }

            LstUndo.SelectedIndex = LstUndo.Items.Count - 1;
        }

        private void FrmActionsViewer_Load(object sender, EventArgs e)
        {
            LstUndo.Select();
        }

        private void FrmActionsViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            _ = Owner.Focus();
        }

        private void Pic_MouseMove(object sender, MouseEventArgs e)
        {
            PointF location = Space.ScalePoint((PointF)e.Location, _transform);
            LbPos.Text = $"X: {location.X}, Y: {location.Y}";
        }

        private void Pic_MouseLeave(object sender, EventArgs e)
        {
            LbPos.Text = "X: -, Y: -";
        }

        private void PicBefore_Paint(object sender, PaintEventArgs e)
        {
            if (_action != null)
            {
                e.Graphics.Transform = _transform;
                _action.PaintBefore(e.Graphics);
            }
        }

        private void PicAfter_Paint(object sender, PaintEventArgs e)
        {
            if (_action != null)
            {
                e.Graphics.Transform = _transform;
                _action.PaintAfter(e.Graphics);
            }
        }

        private void LstUndo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LstRedo.SelectedItem = null;
            _action = LstUndo.SelectedItem as RecordableAction;
            PgdAction.SelectedObject = _action;
            if (_action != null)
            {
                _action.AdjustTransformToBounds(ref _transform, PicBefore.Bounds);
            }

            PicBefore.Invalidate();
            PicAfter.Invalidate();
        }

        private void LstRedo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LstUndo.SelectedItem = null;
            _action = LstRedo.SelectedItem as RecordableAction;
            PgdAction.SelectedObject = _action;
            if (_action != null)
            {
                _action.AdjustTransformToBounds(ref _transform, PicBefore.Bounds);
            }

            PicBefore.Invalidate();
            PicAfter.Invalidate();
        }
    }
}
