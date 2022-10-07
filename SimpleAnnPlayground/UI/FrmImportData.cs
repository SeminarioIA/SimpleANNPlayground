// <copyright file="FrmImportData.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Data.Values;
using SimpleAnnPlayground.Screens;
using SimpleAnnPlayground.Utils;
using SimpleAnnPlayground.Utils.DataView;

namespace SimpleAnnPlayground.UI
{
    /// <summary>
    /// Import window to select the data to import.
    /// </summary>
    public partial class FrmImportData : Form
    {
        private const int ControlRows = 1;

        /// <summary>
        /// Contains the words for each control.
        /// </summary>
        private static readonly Dictionary<string, List<string>> FormWords = new()
        {
            // Window text.
            { nameof(FrmData), new() { "Project data", "Datos del projecto" } },

            // Buttons texts.
            { nameof(BtnImport), new() { "Import", "Importar" } },
            { nameof(BtnCancel), new() { "Cancel", "Cancelar" } },

            // Context menus.
        };

        private readonly string _fileName;
        private readonly DataGridViewEditor _table;
        private readonly DataGridViewRow _checkRow;
        private readonly DataTable _dataTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmImportData"/> class.
        /// </summary>
        /// <param name="fileName">The file path to load the data from.</param>
        /// <param name="dataTable">The data table to fill with the data.</param>
        internal FrmImportData(string fileName, DataTable dataTable)
        {
            InitializeComponent();

            _fileName = fileName;
            _dataTable = dataTable;
            _table = new DataGridViewEditor(DgImport);
            _checkRow = new DataGridViewRow();
            TkSelect.ValueChanged += TkSelect_ValueChanged;
            TkSelect.MouseUp += TkSelect_MouseUp;
        }

        /// <summary>
        /// Shows the window and returns the imported data.
        /// </summary>
        /// <returns>True if there was imported data, otherwise false.</returns>
        internal bool GetData()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                _dataTable.Clear();
                foreach (DataGridViewCheckBoxCell cell in _checkRow.Cells)
                {
                    var dataType = cell.ColumnIndex < DgImport.ColumnCount - 1 ? DataType.Input : DataType.Output;
                    if ((bool)cell.Value) _dataTable.Labels.Add(new DataLabel(_dataTable, cell.OwningColumn.HeaderText, dataType));
                }

                foreach (var row in DgImport.GetRowRange(ControlRows, GetSelectedRowsCount()))
                {
                    var register = new DataRegister(Convert.ToInt32(row.HeaderCell.Value?.ToString() ?? "0", 10));
                    _dataTable.Registers.Add(register);
                    foreach (DataLabel label in _dataTable.Labels)
                    {
                        register.Fields.Add(new Text(row.Cells[label.Text].Value.ToString() ?? string.Empty));
                    }
                }

                return true;
            }

            return false;
        }

        private void FrmImportData_Load(object sender, EventArgs e)
        {
            // Getting application language from user settings.
            var formLanguage = Languages.GetApplicationLanguage();

            // Applying form language.
            Languages.ChangeFormLanguage(this, FormWords, formLanguage);

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
