// <copyright file="DataGridViewNumericUpDownColumn.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace SimpleAnnPlayground.UI.Controls
{
    /// <summary>
    /// NumericUpDown column definition.
    /// </summary>
    public class DataGridViewNumericUpDownColumn : DataGridViewColumn
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewNumericUpDownColumn"/> class.
        /// </summary>
        public DataGridViewNumericUpDownColumn()
#pragma warning disable CA2000 // Dispose objects before losing scope
            : base(new DataGridViewNumericUpDownCell())
#pragma warning restore CA2000 // Dispose objects before losing scope
        {
        }

        /// <summary>
        /// Gets or sets the implicit cell that gets cloned when adding rows to the grid.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                if (value is null)
                {
                    throw new InvalidCastException("Value provided for CellTemplate must be of type DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell or derive from it.");
                }

                base.CellTemplate = value;
            }
        }

        /// <summary>
        /// Gets or sets the DecimalPlaces property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DataGridViewNumericUpDownCell.DefaultDecimalPlaces)]
        [Description("Indicates the number of decimal places to display.")]
        public int DecimalPlaces
        {
            get
            {
                if (NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }

                return NumericUpDownCellTemplate.DecimalPlaces;
            }

            set
            {
                if (NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }

                // Update the template cell so that subsequent cloned cells use the new value.
                NumericUpDownCellTemplate.DecimalPlaces = value;
                if (DataGridView != null)
                {
                    // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily.
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[Index] is DataGridViewNumericUpDownCell dataGridViewCell)
                        {
                            // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation
                            // of each cell. The whole column is invalidated later in a single operation for better performance.
                            dataGridViewCell.SetDecimalPlaces(rowIndex, value);
                        }
                    }

                    DataGridView.InvalidateColumn(Index);

                    // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
                }
            }
        }

        /// <summary>
        /// Gets or sets the Increment property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [Category("Data")]
        [Description("Indicates the amount to increment or decrement on each button click.")]
        public decimal Increment
        {
            get
            {
                if (NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }

                return NumericUpDownCellTemplate.Increment;
            }

            set
            {
                if (NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }

                NumericUpDownCellTemplate.Increment = value;
                if (DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[Index] is DataGridViewNumericUpDownCell dataGridViewCell)
                        {
                            dataGridViewCell.SetIncrement(rowIndex, value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the Maximum property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [Category("Data")]
        [Description("Indicates the maximum value for the numeric up-down cells.")]
        [RefreshProperties(RefreshProperties.All)]
        public decimal Maximum
        {
            get
            {
                if (NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }

                return NumericUpDownCellTemplate.Maximum;
            }

            set
            {
                if (NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }

                NumericUpDownCellTemplate.Maximum = value;
                if (DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[Index] is DataGridViewNumericUpDownCell dataGridViewCell)
                        {
                            dataGridViewCell.SetMaximum(rowIndex, value);
                        }
                    }

                    DataGridView.InvalidateColumn(Index);

                    // TODO: This column and/or grid rows may need to be autosized depending on their
                    //       autosize settings. Call the autosizing methods to autosize the column, rows,
                    //       column headers / row headers as needed.
                }
            }
        }

        /// <summary>
        /// Gets or sets the Minimum property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [Category("Data")]
        [Description("Indicates the minimum value for the numeric up-down cells.")]
        [RefreshProperties(RefreshProperties.All)]
        public decimal Minimum
        {
            get
            {
                if (NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }

                return NumericUpDownCellTemplate.Minimum;
            }

            set
            {
                if (NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }

                NumericUpDownCellTemplate.Minimum = value;
                if (DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[Index] is DataGridViewNumericUpDownCell dataGridViewCell)
                        {
                            dataGridViewCell.SetMinimum(rowIndex, value);
                        }
                    }

                    DataGridView.InvalidateColumn(Index);

                    // TODO: This column and/or grid rows may need to be autosized depending on their
                    //       autosize settings. Call the autosizing methods to autosize the column, rows,
                    //       column headers / row headers as needed.
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the ThousandsSeparator property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [Category("Data")]
        [DefaultValue(DataGridViewNumericUpDownCell.DefaultThousandsSeparator)]
        [Description("Indicates whether the thousands separator will be inserted between every three decimal digits.")]
        public bool ThousandsSeparator
        {
            get
            {
                if (NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }

                return NumericUpDownCellTemplate.ThousandsSeparator;
            }

            set
            {
                if (NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }

                NumericUpDownCellTemplate.ThousandsSeparator = value;
                if (DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[Index] is DataGridViewNumericUpDownCell dataGridViewCell)
                        {
                            dataGridViewCell.SetThousandsSeparator(rowIndex, value);
                        }
                    }

                    DataGridView.InvalidateColumn(Index);

                    // TODO: This column and/or grid rows may need to be autosized depending on their
                    //       autosize settings. Call the autosizing methods to autosize the column, rows,
                    //       column headers / row headers as needed.
                }
            }
        }

        /// <summary>
        /// Gets the template cell as a DataGridViewNumericUpDownCell.
        /// </summary>
        private DataGridViewNumericUpDownCell NumericUpDownCellTemplate => (DataGridViewNumericUpDownCell)CellTemplate;

        /// <summary>
        /// Returns a standard compact string representation of the column.
        /// </summary>
        /// <returns>A string representing the column.</returns>
        public override string ToString() => $"DataGridViewNumericUpDownColumn {{ Name={Name}, Index={Index} }}";

        /// <summary>
        /// Indicates whether the Increment property should be persisted.
        /// </summary>
        /// <returns>True if is persisted.</returns>
        private bool ShouldSerializeIncrement()
        {
            return !Increment.Equals(DataGridViewNumericUpDownCell.DefaultIncrement);
        }

        /// <summary>
        /// Indicates whether the Maximum property should be persisted.
        /// </summary>
        /// <returns>True if is persisted.</returns>
        private bool ShouldSerializeMaximum()
        {
            return !Maximum.Equals(DataGridViewNumericUpDownCell.DefaultMaximum);
        }

        /// <summary>
        /// Indicates whether the Maximum property should be persisted.
        /// </summary>
        /// <returns>True if is persisted.</returns>
        private bool ShouldSerializeMinimum()
        {
            return !Minimum.Equals(DataGridViewNumericUpDownCell.DefaultMinimum);
        }
    }
}
