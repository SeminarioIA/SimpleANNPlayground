// <copyright file="DataGridViewEditor.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Utils
{
    /// <summary>
    /// Configures a <see cref="EditableViewer"/> to be editable.
    /// </summary>
    public class DataGridViewEditor
    {
        /// <summary>
        /// Indicates if the viewer is changing.
        /// </summary>
        private bool _changing;

        /// <summary>
        /// Stores the last mouse click location.
        /// </summary>
        private Point _cellPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewEditor"/> class.
        /// </summary>
        /// <param name="dataGridView">The <see cref="EditableViewer"/> control to be asociated to this object.</param>
        public DataGridViewEditor(DataGridView dataGridView)
        {
            EditableViewer = dataGridView;
            EditableViewer.MultiSelect = false;
            EditableViewer.EditingControlShowing += EditableViewer_EditingControlShowing;
            EditableViewer.CellMouseDown += EditableViewer_CellMouseDown;
            EditableViewer.SelectionChanged += EditableViewer_SelectionChanged;
            EditableViewer.CellValueChanged += EditableViewer_CellValueChanged;
            EditableViewer.CurrentCellDirtyStateChanged += EditableViewer_CurrentCellDirtyStateChanged;
            EditableViewer.CellEndEdit += EditableViewer_CellEndEdit;
            EditableViewer.DataError += EditableViewer_DataError;
        }

        /// <summary>
        /// Ocurrs when a <see cref="DataGridViewRow"/> had been edited.
        /// </summary>
        public event EventHandler<EventArgs>? RowUpdated;

        /// <summary>
        /// Ocurrs when a <see cref="DataGridViewRow"/> had been edited.
        /// </summary>
        public event EventHandler<EventArgs>? CellEndEdit;

        /// <summary>
        /// Gets the <see cref="EditableViewer"/> linked to this instance of <see cref="DataGridViewEditor"/>.
        /// </summary>
        public DataGridView EditableViewer { get; private set; }

        private static void EditableViewer_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void EditableViewer_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView viewer)
            {
                var cell = viewer.Rows[e.RowIndex].Cells[e.ColumnIndex];
                CellEndEdit?.Invoke(cell, EventArgs.Empty);
            }
        }

        private void EditableViewer_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (sender is DataGridView viewer && viewer.IsCurrentCellDirty)
            {
                _ = viewer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void EditableViewer_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (!_changing && e.RowIndex >= 0 && sender is DataGridView viewer)
            {
                _changing = true;
                RowUpdated?.Invoke(viewer.Rows[e.RowIndex], EventArgs.Empty);
                _changing = false;
            }
        }

        private void EditableViewer_SelectionChanged(object? sender, EventArgs e)
        {
            if (sender is DataGridView viewer && viewer.RowCount > 1 && viewer.SelectedCells.Count > 0 &&
                viewer.SelectedCells[0].RowIndex == viewer.RowCount - 1)
            {
                int columnIndex = viewer.SelectedCells[0].ColumnIndex == 1 ? 2 : viewer.SelectedCells[0].ColumnIndex;
                viewer.Rows[viewer.SelectedCells[0].RowIndex - 1].Cells[columnIndex].Selected = true;
            }
        }

        private void EditableViewer_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e) => _cellPoint = e.Location;

        private void EditableViewer_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox comboBox)
            {
                // Fix the black background on the drop down menu
                e.CellStyle.BackColor = Color.White;

                comboBox.Enter -= ComboBox_Enter;
                comboBox.Enter += ComboBox_Enter;
            }
            else if (e.Control is NumericUpDown numeric)
            {
                numeric.Enter -= Numeric_Enter;
                numeric.Enter += Numeric_Enter;
            }
            else if (e.Control is TextBox textBox)
            {
                // Fix the black background on the drop down menu
                e.CellStyle.BackColor = Color.White;
            }
        }

        private void Numeric_Enter(object? sender, EventArgs e)
        {
            if (sender is NumericUpDown numeric)
            {
                if (numeric.Controls[0] is Control buttons && buttons.Bounds.Contains(_cellPoint))
                {
                    if (_cellPoint.Y < buttons.Height / 2) numeric.UpButton();
                    else numeric.DownButton();
                }

                numeric.Enter -= Numeric_Enter;
            }
        }

        private void ComboBox_Enter(object? sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                comboBox.DroppedDown = true;
                comboBox.Enter -= ComboBox_Enter;
            }
        }
    }
}
