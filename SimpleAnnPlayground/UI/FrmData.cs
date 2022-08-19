// <copyright file="FrmData.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Graphical.Elements;
using SimpleAnnPlayground.UI;
using SimpleAnnPlayground.Utils;
using System.Diagnostics;
using System.Security.Cryptography;

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
            _typeRow.Cells.Clear();

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

        private void BtnShuffle_Click(object sender, EventArgs e)
        {
            DataGridView temporalDgData = DgData;
            int randomNumber;
            foreach (DataGridViewRow temporalRow in temporalDgData.Rows)
            {
                if(temporalRow.Index > 0)
                {
                    randomNumber = RandomNumberGenerator.GetInt32(1, 1000);

                    // Generates a random number between 1 to 1000, if that number is even, changes the current position with the next position. Last position avoided.
                    if ((randomNumber % 2 == 0) && (temporalRow.Index + 1 < temporalDgData.Rows.Count))
                    {
                        /* Uncomment to test the shuffle if the random generated number is even and it's within the first ten positions 
                        if (temporalRow.Index < 10)
                        {
                            Debug.WriteLine("Generated number: " + randomNumber + ", it's going to modify the position: " + temporalRow.Index);
                        }
                        */
                        object previousHeader = temporalDgData.Rows[temporalRow.Index + 1].HeaderCell.Value;
                        foreach (DataGridViewTextBoxCell temporalCell in temporalRow.Cells)
                        {
                            object previousValue = temporalDgData.Rows[temporalRow.Index + 1].Cells[temporalCell.ColumnIndex].Value;

                            temporalDgData.Rows[temporalRow.Index + 1].Cells[temporalCell.ColumnIndex].Value = temporalCell.Value;
                            temporalDgData.Rows[temporalRow.Index].Cells[temporalCell.ColumnIndex].Value = previousValue;
                        }

                        temporalDgData.Rows[temporalRow.Index + 1].HeaderCell.Value = temporalDgData.Rows[temporalRow.Index].HeaderCell.Value;
                        temporalDgData.Rows[temporalRow.Index].HeaderCell.Value = previousHeader;
                    }
                }
            }

            DgData = temporalDgData;
            UpdateInfo();
        }
    }
}
