// <copyright file="FrmObjectsViewer.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Environment;

namespace SimpleAnnPlayground.Debugging
{
    /// <summary>
    /// The form to explore objects properties.
    /// </summary>
    public partial class FrmObjectsViewer : Form
    {
        private readonly Workspace _workspace;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmObjectsViewer"/> class.
        /// </summary>
        /// <param name="workspace">The workspace.</param>
        internal FrmObjectsViewer(Workspace workspace)
        {
            InitializeComponent();
            _workspace = workspace;
        }

        /// <summary>
        /// Selects an object to show its properties.
        /// </summary>
        /// <param name="selection">The object to select.</param>
        public void SelectObject(object? selection)
        {
            PgdView.SelectedObject = selection;
            LbType.Text = selection?.GetType().ToString() ?? string.Empty;
        }

        private void FrmObjectsViewer_Load(object sender, EventArgs e)
        {
        }

        private void FrmObjectsViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            _ = Owner.Focus();
        }

        private void PgdView_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _workspace.Refresh();
        }
    }
}
