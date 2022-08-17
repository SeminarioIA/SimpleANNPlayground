// <copyright file="FrmImportData.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Utils;

namespace SimpleAnnPlayground.UI
{
    /// <summary>
    /// Import window to select the data to import.
    /// </summary>
    public partial class FrmImportData : Form
    {
        private const int ControlRows = 1;
        private readonly string _fileName;
        private readonly DataGridViewEditor _table;
        private readonly DataGridViewRow _checkRow;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmImportData"/> class.
        /// </summary>
        /// <param name="fileName">The file path to load the data from.</param>
        public FrmImportData(string fileName)
        {
            InitializeComponent();

            _fileName = fileName;
            _table = new DataGridViewEditor(DgImport);
            _checkRow = new DataGridViewRow();
            TkSelect.ValueChanged += TkSelect_ValueChanged;
            TkSelect.MouseUp += TkSelect_MouseUp;
        }

        /// <summary>
        /// Shows the window and returns the imported data.
        /// </summary>
        /// <returns>The imported data.</returns>
        internal DataTable? GetData()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                var columns = new List<string>();
                foreach (DataGridViewCheckBoxCell cell in _checkRow.Cells)
                {
                    if ((bool)cell.Value) columns.Add(cell.OwningColumn.HeaderText);
                }

                var data = new DataTable(columns);
                foreach (var row in DgImport.GetRowRange(ControlRows, GetSelectedRowsCount()))
                {
                    var register = new DataRegister(row.HeaderCell.Value?.ToString() ?? string.Empty);
                    data.Registers.Add(register);
                    foreach (string column in columns)
                    {
                        register.Fields.Add(new DataValue(row.Cells[column].Value.ToString() ?? string.Empty));
                    }
                }

                return data;
            }

            return null;
        }

        private void FrmImportData_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(_fileName);
            string[] headers = lines.First().Split(',');

            foreach (string header in headers.Skip(1))
            {
                // Add the column header.
                int columnIndex = DgImport.Columns.Add(header, header);
                var column = DgImport.Columns[columnIndex];
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Add the check row.
                var checkCell = new DataGridViewCheckBoxCell();
                _ = _checkRow.Cells.Add(checkCell);
                checkCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                checkCell.Value = true;
            }

            _checkRow.HeaderCell.Value = "Include:";
            _checkRow.Frozen = true;
            _checkRow.DefaultCellStyle.BackColor = SystemColors.Control;
            _ = DgImport.Rows.Add(_checkRow);

            DgImport.RowHeadersWidth = 100;

            foreach (string line in lines.Skip(1))
            {
                string[] data = line.Split(',');
                int rowIndex = DgImport.Rows.Add(data.Skip(1).ToArray());
                var row = DgImport.Rows[rowIndex];
                row.ReadOnly = true;
                row.HeaderCell.Value = data[0];
            }

            _table.CellValueChanged += Table_CellValueChanged;
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            int columns = 0;
            foreach (DataGridViewCheckBoxCell cell in _checkRow.Cells)
            {
                if ((bool)cell.Value) columns++;
            }

            int total = DgImport.RowCount - ControlRows;
            int registers = TkSelect.Value * total / 100;

            LbColumns.Text = $"Columns: {columns}";
            LbRegisters.Text = $"Registers: {registers}";
            LbSelect.Text = $"Import: {TkSelect.Value} %";
        }

        private void Table_CellValueChanged(object? sender, EventArgs e)
        {
            if (sender is DataGridViewCheckBoxCell cell)
            {
                switch (cell.RowIndex)
                {
                    case 0: // Checkbox
                        DgImport.Columns[cell.ColumnIndex].DefaultCellStyle.BackColor = (bool)cell.Value ? Color.Empty : SystemColors.ControlDark;
                        DgImport.Columns[cell.ColumnIndex].DefaultCellStyle.ForeColor = (bool)cell.Value ? Color.Empty : SystemColors.ControlDarkDark;
                        break;
                }
            }

            UpdateInfo();
        }

        private void TkSelect_ValueChanged(object? sender, EventArgs e)
        {
            UpdateInfo();
        }

        private int GetRowsCount() => DgImport.RowCount - ControlRows;

        private int GetSelectedRowsCount() => TkSelect.Value * GetRowsCount() / 100;

        private int GetDiscardRowsCount() => GetRowsCount() - GetSelectedRowsCount();

        private void TkSelect_MouseUp(object? sender, MouseEventArgs e)
        {
            foreach (var row in DgImport.GetRowRange(ControlRows, GetSelectedRowsCount()))
            {
                row.DefaultCellStyle.BackColor = Color.Empty;
                row.DefaultCellStyle.ForeColor = Color.Empty;
            }

            foreach (var row in DgImport.GetRowRange(GetSelectedRowsCount() + ControlRows, GetDiscardRowsCount()))
            {
                row.DefaultCellStyle.BackColor = SystemColors.ControlDark;
                row.DefaultCellStyle.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void DgImport_DataError(object? sender, DataGridViewDataErrorEventArgs e) => throw new NotImplementedException();

        private void BtnImport_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
