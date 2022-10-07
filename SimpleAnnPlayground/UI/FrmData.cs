// <copyright file="FrmData.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Networks;
using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.UI;
using SimpleAnnPlayground.Utils;
using SimpleAnnPlayground.Utils.DataView;

namespace SimpleAnnPlayground.Screens
{
    /// <summary>
    /// Form to load the model data.
    /// </summary>
    internal partial class FrmData : Form
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
            { nameof(BtnShuffle), new() { "Shuffle", "Revolver" } },

            // Context menus.
        };

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
            Workspace.DataTableSelectRegister += Workspace_DataTableSelectRegister;
            _table = new DataGridViewEditor(DgData);
            _typeRow = new DataGridViewRow();
            PbData.ValueChanged += PbData_ValueChanged;
            _table.CellValueChanged += Table_CellValueChanged;
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        public Workspace Workspace { get; }

        /// <summary>
        /// Gets the selected register.
        /// </summary>
        public DataRegister? Selected { get; private set; }

        /// <summary>
        /// Gets the current mode.
        /// </summary>
        public NetworkMode Mode { get; private set; }

        /// <summary>
        /// Enables or disables the training mode in the window.
        /// </summary>
        public void TrainingMode()
        {
            if (Mode != NetworkMode.Edition) EditingMode();
            BtnShuffle.Enabled = false;
            PbData.Enabled = false;
            BtnImport.Enabled = false;

            DgData.SuspendLayout();
            for (int index = Workspace.DataTable.TrainingCount + 1; index < DgData.RowCount; index++)
            {
                DgData.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
            }

            DgData.ResumeLayout();
            Mode = NetworkMode.Training;
        }

        /// <summary>
        /// Enables or disables the testing mode in the window.
        /// </summary>
        public void TestingMode()
        {
            if (Mode != NetworkMode.Edition) EditingMode();
            BtnShuffle.Enabled = false;
            PbData.Enabled = false;
            BtnImport.Enabled = false;

            DgData.SuspendLayout();
            for (int index = 1; index <= Workspace.DataTable.TrainingCount; index++)
            {
                DgData.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
            }

            int columnIndex = DgData.Columns.Add("cnResults", "Results");
            DgData.Columns[columnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgData.ResumeLayout();
            Mode = NetworkMode.Testing;
        }

        /// <summary>
        /// Enables the editing mode in the window.
        /// </summary>
        public void EditingMode()
        {
            BtnShuffle.Enabled = true;
            PbData.Enabled = true;
            BtnImport.Enabled = true;

            DgData.SuspendLayout();
            if (DgData.Columns.Contains("cnResults")) DgData.Columns.Remove("cnResults");

            foreach (DataGridViewRow row in DgData.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }

            if (Selected is not null && Selected.Tag is DataGridViewRow selectedRow)
            {
                selectedRow.DefaultCellStyle.BackColor = Color.White;
                Selected = null;
            }

            DgData.ResumeLayout();
            Mode = NetworkMode.Edition;
        }

        /// <summary>
        /// Registers a test result.
        /// </summary>
        /// <param name="result">The test result.</param>
        /// <param name="value">The value of the result.</param>
        /// <param name="wrong">Indicates if the result must be marked as wrong.</param>
        internal void RegisterResult(decimal result, decimal value, bool wrong)
        {
            if (Selected is not null && Selected.Tag is DataGridViewRow row)
            {
                var cell = row.Cells[DgData.ColumnCount - 1];
                cell.Value = result;
                if (wrong) cell.Style.BackColor = Color.LightSalmon;
                cell.ToolTipText = value.ToString("F3");
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void Workspace_DataTableChanged(object? sender, EventArgs e)
        {
            if (Workspace.DataTable.Registers is null) throw new InvalidOperationException();
            DgData.Rows.Clear();
            DgData.Columns.Clear();
            _typeRow.Cells.Clear();
            PbData.Value = Workspace.DataTable.Training;
            PbData_ValueChanged(PbData, e);

            if (Workspace.DataTable.HasData())
            {
                DgData.SuspendLayout();

                foreach (DataLabel label in Workspace.DataTable.Labels)
                {
                    int columnIndex = DgData.Columns.Add(label.Text, label.Text);
                    DgData.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                    DgData.Columns[columnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
                    row.Tag = register;
                    register.Tag = row;
                }

                DgData.ResumeLayout();
            }

            UpdateInfo();
        }

        private void Workspace_DataTableSelectRegister(object? sender, EventArgs e)
        {
            if (Selected is not null && Selected.Tag is DataGridViewRow oldRow) oldRow.DefaultCellStyle.BackColor = Color.White;
            if (sender is DataRegister register && register.Tag is DataGridViewRow row)
            {
                Selected = register;
                row.DefaultCellStyle.BackColor = Color.Yellow;
                int rowsHeight = DgData.Height / row.Height - 2;
                if (row.Index < DgData.FirstDisplayedScrollingRowIndex)
                {
                    DgData.FirstDisplayedScrollingRowIndex = row.Index;
                }
                else if (row.Index >= DgData.FirstDisplayedScrollingRowIndex + rowsHeight - 1)
                {
                    DgData.FirstDisplayedScrollingRowIndex = row.Index - rowsHeight + rowsHeight / 2;
                }
            }
            else
            {
                Selected = null;
            }
        }

        private void PbData_ValueChanged(object? sender, EventArgs e)
        {
            LbTraining.Text = $"Training - {PbData.Value} %";
            LbTest.Text = $"{100 - PbData.Value} % - Test";
            Workspace.DataTable.Training = PbData.Value;
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
            if (e.Cell.RowIndex == 0)
            {
                var label = Workspace.DataTable.Labels[e.Cell.ColumnIndex];
                var dataType = Enum.Parse<DataType>(e.Cell.Value?.ToString() ?? throw new InvalidOperationException());
                if (dataType != label.DataType)
                {
                    if (label.DataType == DataType.Input)
                    {
                        Workspace.Canvas.Objects
                            .Where(obj => obj is Input input && input.DataLabel == label)
                            .ToList()
                            .ConvertAll(obj => (Input)obj)
                            .ForEach(input => input.DataLabel = null);
                    }
                    else if (label.DataType == DataType.Output)
                    {
                        Workspace.Canvas.Objects
                            .Where(obj => obj is Output output && output.DataLabel == label)
                            .ToList()
                            .ConvertAll(obj => (Output)obj)
                            .ForEach(output => output.DataLabel = null);
                    }

                    label.DataType = dataType;
                    Workspace.Refresh();
                }
            }
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
            // Getting application language from user settings.
            var formLanguage = Languages.GetApplicationLanguage();

            // Applying form language.
            Languages.ChangeFormLanguage(this, FormWords, formLanguage);
        }

        private void BtnShuffle_Click(object sender, EventArgs e)
        {
            _table.Viewer.Rows.Remove(_typeRow);
            _table.Shuffle();
            _table.Viewer.Rows.Insert(0, _typeRow);

            Workspace.DataTable.Registers.Clear();
            foreach (DataGridViewRow row in _table.Viewer.Rows)
            {
                if (row.Tag is DataRegister register) Workspace.DataTable.Registers.Add(register);
            }
        }
    }
}
