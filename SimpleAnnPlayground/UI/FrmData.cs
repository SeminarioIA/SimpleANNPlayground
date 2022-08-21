﻿// <copyright file="FrmData.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.UI;
using SimpleAnnPlayground.Utils;

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
        public FrmData()
        {
            InitializeComponent();

            _table = new DataGridViewEditor(DgData);
            _typeRow = new DataGridViewRow();
            PbData.ValueChanged += PbData_ValueChanged;
            _table.CellValueChanged += Table_CellValueChanged;
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        public DataTable? DataTable { get; private set; }

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

            using (var frmImportData = new FrmImportData(fileName))
            {
                if (frmImportData.GetData() is DataTable data)
                {
                    LoadData(data);
                }
            }
        }

        private void LoadData(DataTable table)
        {
            DataTable = table;
            DgData.Rows.Clear();
            DgData.Columns.Clear();
            foreach (DataLabel label in DataTable.Labels)
            {
                _ = DgData.Columns.Add(label.Text, label.Text);

                // Add the type row.
                var typeCell = new DataGridViewComboBoxCell();
                _ = _typeRow.Cells.Add(typeCell);
                typeCell.Items.AddRange(Enum.GetNames<DataType>());
                typeCell.Value = label == DataTable.Labels.Last() ? DataType.Output.ToString() : DataType.Input.ToString();
            }

            _typeRow.HeaderCell.Value = "Type:";
            _typeRow.Frozen = true;
            _ = DgData.Rows.Add(_typeRow);
            DgData.RowHeadersWidth = 100;

            foreach (DataRegister register in table.Registers)
            {
                int rowIndex = DgData.Rows.Add(register.GetStrings());
                var row = DgData.Rows[rowIndex];
                row.ReadOnly = true;
                row.HeaderCell.Value = register.Id;
            }

            UpdateInfo();
        }

        private void Table_CellValueChanged(object? sender, EventArgs e)
        {
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
        }

        private void FrmData_Load(object sender, EventArgs e)
        {
        }
    }
}
