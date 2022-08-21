// <copyright file="FrmData.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.UI;
using SimpleAnnPlayground.Utils.DataView;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SimpleAnnPlayground.Screens
{
    /// <summary>
    /// Form to load the model data.
    /// </summary>
    internal partial class FrmData : Form
    {
        private const int ControlRows = 1;
        private readonly DataGridViewEditor _table;
        private readonly DataGridViewRow _typeRow;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmData"/> class.
        /// </summary>
        /// <param name="workspace">The workspace containing the data.</param>
        public FrmData(Workspace workspace)
        {
            InitializeComponent();

            Workspace = workspace;
            Workspace.DataTableChanged += Workspace_DataTableChanged;
            _table = new DataGridViewEditor(DgData);
            _typeRow = new DataGridViewRow();
            PbData.ValueChanged += PbData_ValueChanged;
            _table.CellValueChanged += Table_CellValueChanged;
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        public Workspace Workspace { get; }

        private void Workspace_DataTableChanged(object? sender, EventArgs e)
        {
            DgData.Rows.Clear();
            DgData.Columns.Clear();
            _typeRow.Cells.Clear();

            if (Workspace.DataTable.HasData())
            {
                foreach (DataLabel label in Workspace.DataTable.Labels)
                {
                    _ = DgData.Columns.Add(label.Text, label.Text);

                    // Add the type row.
                    var typeCell = new DataGridViewComboBoxCell();
                    _ = _typeRow.Cells.Add(typeCell);
                    typeCell.Items.AddRange(Enum.GetNames<DataType>());
                    typeCell.Value = label.DataType.ToString();
                }

                _typeRow.HeaderCell.Value = "Type:";
                _typeRow.Frozen = true;
                _ = DgData.Rows.Add(_typeRow);
                DgData.RowHeadersWidth = 100;

                foreach (DataRegister register in Workspace.DataTable.Registers)
                {
                    int rowIndex = DgData.Rows.Add(register.GetStrings());
                    var row = DgData.Rows[rowIndex];
                    row.ReadOnly = true;
                    row.HeaderCell.Value = register.Id.ToString();
                }
            }

            UpdateInfo();
        }

        private void PbData_ValueChanged(object? sender, EventArgs e)
        {
            LbTraining.Text = $"Training - {PbData.Value} %";
            LbTest.Text = $"{100 - PbData.Value} % - Test";
        }

        private void FrmData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            _ = Owner.Focus();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            string fileName;
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Comma separated values (*.csv)|*.csv";
                if (ofd.ShowDialog() != DialogResult.OK) return;
                fileName = ofd.FileName;
            }

            using (var frmImportData = new FrmImportData(fileName, Workspace.DataTable))
            {
                if (frmImportData.GetData())
                {
                    Workspace_DataTableChanged(null, EventArgs.Empty);
                }
            }
        }

        private void Table_CellValueChanged(object? sender, CellValueChangedEventArgs e)
        {
            if (e.Cell.RowIndex == 0) Workspace.DataTable.Labels[e.Cell.ColumnIndex].DataType = Enum.Parse<DataType>(e.Cell.Value?.ToString() ?? string.Empty);
        }

        private void UpdateInfo()
        {
            int inputs = 0, outputs = 0;
            foreach (DataGridViewComboBoxCell cell in _typeRow.Cells)
            {
                if (cell.Value.ToString() == DataType.Input.ToString()) inputs++;
                if (cell.Value.ToString() == DataType.Output.ToString()) outputs++;
            }

            LbColumns.Text = $"Columns: {DgData.ColumnCount}";
            LbRegisters.Text = $"Registers: {DgData.RowCount - ControlRows}";
            LbInputs.Text = $"Inputs: {inputs}";
            LbOutputs.Text = $"Outputs: {outputs}";

            BtnShuffle.Enabled = Workspace.DataTable.HasData();
            PbData.Enabled = Workspace.DataTable.HasData();
        }

        private void FrmData_Load(object sender, EventArgs e)
        {
        }

        private void BtnShuffle_Click(object sender, EventArgs e)
        {
            _table.Viewer.Rows.Remove(_typeRow);
            _table.Shuffle();
            _table.Viewer.Rows.Insert(0, _typeRow);
        }
    }
}
