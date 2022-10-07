// <copyright file="DataGridViewNumericUpDownCell.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SimpleAnnPlayground.UI.Controls
{
    /// <summary>
    /// NumericUpDown cell definition.
    /// </summary>
    public class DataGridViewNumericUpDownCell : DataGridViewTextBoxCell
    {
        /// <summary>
        /// Default value of the decimalPlaces property.
        /// </summary>
        internal const int DefaultDecimalPlaces = 0;

        /// <summary>
        /// Default value of the Increment property.
        /// </summary>
        internal const decimal DefaultIncrement = decimal.One;

        /// <summary>
        /// Default value of the Maximum property.
        /// </summary>
        internal const decimal DefaultMaximum = 10000000.0M;

        /// <summary>
        /// Default value of the Minimum property.
        /// </summary>
        internal const decimal DefaultMinimum = decimal.Zero;

        /// <summary>
        /// Default value of the ThousandsSeparator property.
        /// </summary>
        internal const bool DefaultThousandsSeparator = false;

        private const DataGridViewContentAlignment AnyCenter = DataGridViewContentAlignment.TopCenter |
                                                                 DataGridViewContentAlignment.MiddleCenter |
                                                                 DataGridViewContentAlignment.BottomCenter;

        // Used in TranslateAlignment function
        private const DataGridViewContentAlignment AnyRight = DataGridViewContentAlignment.TopRight |
                                                                        DataGridViewContentAlignment.MiddleRight |
                                                                        DataGridViewContentAlignment.BottomRight;

        private const int DefaultRenderingBitmapHeight = 22;

        // Default dimensions of the static rendering bitmap used for the painting of the non-edited cells
        private const int DefaultRenderingBitmapWidth = 100;

        // Type of this cell's editing control
        private static readonly Type DefaultEditType = typeof(DataGridViewNumericUpDownEditingControl);

        // Type of this cell's value. The formatted value type is string, the same as the base class DataGridViewTextBoxCell
        private static readonly Type DefaultValueType = typeof(decimal);

        // The bitmap used to paint the non-edited cells via a call to NumericUpDown.DrawToBitmap
        [ThreadStatic]
        private static Bitmap? renderingBitmap;

        private int _decimalPlaces; // Caches the value of the decimalPlaces property
        private decimal _increment; // Caches the value of the Increment property
        private decimal _maximum; // Caches the value of the Maximum property
        private decimal _minimum; // Caches the value of the Minimum property

        // The NumericUpDown control used to paint the non-edited cells via a call to NumericUpDown.DrawToBitmap
        [ThreadStatic]
        private NumericUpDown _paintingNumericUpDown;
        private bool _thousandsSeparator; // Caches the value of the ThousandsSeparator property

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewNumericUpDownCell"/> class.
        /// </summary>
        public DataGridViewNumericUpDownCell()
        {
            // Create a thread specific bitmap used for the painting of the non-edited cells
            if (renderingBitmap == null)
            {
                renderingBitmap = new Bitmap(DefaultRenderingBitmapWidth, DefaultRenderingBitmapHeight);
            }

            // Create a thread specific NumericUpDown control used for the painting of the non-edited cells
            if (_paintingNumericUpDown == null)
            {
                _paintingNumericUpDown = new NumericUpDown();

                // Some properties only need to be set once for the lifetime of the control:
                _paintingNumericUpDown.BorderStyle = BorderStyle.None;
                _paintingNumericUpDown.Maximum = decimal.MaxValue / 10;
                _paintingNumericUpDown.Minimum = decimal.MinValue / 10;

                _paintingNumericUpDown.ValueChanged += PaintingNumericUpDown_ValueChanged;
            }

            // Set the default values of the properties:
            _decimalPlaces = DefaultDecimalPlaces;
            _increment = DefaultIncrement;
            _minimum = DefaultMinimum;
            _maximum = DefaultMaximum;
            _thousandsSeparator = DefaultThousandsSeparator;
        }

        /// <summary>
        /// Gets or sets the allowed decimal places.
        /// </summary>
        [DefaultValue(DefaultDecimalPlaces)]
        public int DecimalPlaces
        {
            get => _decimalPlaces;
            set
            {
                if (value is < 0 or > 99)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The decimalPlaces property cannot be smaller than 0 or larger than 99.");
                }

                if (_decimalPlaces != value)
                {
                    SetDecimalPlaces(RowIndex, value);
                    OnCommonChange();  // Assure that the cell or column gets repainted and autosized if needed
                }
            }
        }

        /// <summary>
        /// Gets define the type of the cell's editing control.
        /// </summary>
        public override Type EditType => DefaultEditType; // the type is DataGridViewNumericUpDownEditingControl

        /// <summary>
        /// Gets or sets the Increment property replicates the one from the NumericUpDown control.
        /// </summary>
        public decimal Increment
        {
            get => _increment;

            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The Increment property cannot be smaller than 0.");
                }

                SetIncrement(RowIndex, value);

                // No call to OnCommonChange is needed since the increment value does not affect the rendering of the cell.
            }
        }

        /// <summary>
        /// Gets or sets the Maximum property replicates the one from the NumericUpDown control.
        /// </summary>
        public decimal Maximum
        {
            get => _maximum;
            set
            {
                if (_maximum != value)
                {
                    SetMaximum(RowIndex, value);
                    OnCommonChange();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Minimum.
        /// </summary>
        public decimal Minimum
        {
            get => _minimum;
            set
            {
                if (_minimum != value)
                {
                    SetMinimum(RowIndex, value);
                    OnCommonChange();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the value contains thousands separator.
        /// </summary>
        [DefaultValue(DefaultThousandsSeparator)]
        public bool ThousandsSeparator
        {
            get => _thousandsSeparator;
            set
            {
                if (_thousandsSeparator != value)
                {
                    SetThousandsSeparator(RowIndex, value);
                    OnCommonChange();
                }
            }
        }

        /// <summary>
        /// Gets the type of the cell's Value property.
        /// </summary>
        public override Type ValueType
        {
            get
            {
                Type valueType = base.ValueType;
                if (valueType != null)
                {
                    return valueType;
                }

                return DefaultValueType;
            }
        }

        /// <summary>
        /// Gets returns the current DataGridView EditingControl as a DataGridViewNumericUpDownEditingControl control.
        /// </summary>
        private DataGridViewNumericUpDownEditingControl? EditingNumericUpDown => DataGridView?.EditingControl as DataGridViewNumericUpDownEditingControl;

        /// <inheritdoc/>
        public override object? Clone()
        {
            DataGridViewNumericUpDownCell? dataGridViewCell = base.Clone() as DataGridViewNumericUpDownCell;
            if (dataGridViewCell is not null)
            {
                dataGridViewCell._decimalPlaces = _decimalPlaces;
                dataGridViewCell.Increment = Increment;
                dataGridViewCell.Maximum = Maximum;
                dataGridViewCell.Minimum = Minimum;
                dataGridViewCell.ThousandsSeparator = ThousandsSeparator;
            }

            return dataGridViewCell;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override void DetachEditingControl()
        {
            if (DataGridView == null || DataGridView.EditingControl == null)
            {
                throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
            }

            if (DataGridView.EditingControl is NumericUpDown numericUpDown)
            {
                // Editing controls get recycled. Indeed, when a DataGridViewNumericUpDownCell cell gets edited
                // after another DataGridViewNumericUpDownCell cell, the same editing control gets reused for
                // performance reasons (to avoid an unnecessary control destruction and creation).
                // Here the undo buffer of the TextBox inside the NumericUpDown control gets cleared to avoid
                // interferences between the editing sessions.
                if (numericUpDown.Controls[1] is TextBox textBox)
                {
                    textBox.ClearUndo();
                }
            }

            base.DetachEditingControl();
        }

        /// <inheritdoc/>
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            if (DataGridView?.EditingControl is NumericUpDown numericUpDown)
            {
                numericUpDown.BorderStyle = BorderStyle.None;
                numericUpDown.DecimalPlaces = _decimalPlaces;
                numericUpDown.Increment = Increment;
                numericUpDown.Maximum = Maximum;
                numericUpDown.Minimum = Minimum;
                numericUpDown.ThousandsSeparator = ThousandsSeparator;
                numericUpDown.ReadOnly = true;
                numericUpDown.Text = initialFormattedValue is not string initialFormattedValueStr ? string.Empty : initialFormattedValueStr;
            }
        }

        /// <inheritdoc/>
        public override bool KeyEntersEditMode(KeyEventArgs e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));
            NumberFormatInfo numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            Keys negativeSignKey = Keys.None;
            string negativeSignStr = numberFormatInfo.NegativeSign;
            if (!string.IsNullOrEmpty(negativeSignStr) && negativeSignStr.Length == 1)
            {
                negativeSignKey = (Keys)VkKeyScan(negativeSignStr[0]);
            }

            if ((char.IsDigit((char)e.KeyCode) ||
                 (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                 negativeSignKey == e.KeyCode ||
                 e.KeyCode == Keys.Subtract) &&
                !e.Shift && !e.Alt && !e.Control)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public override void PositionEditingControl(
            bool setLocation,
            bool setSize,
            Rectangle cellBounds,
            Rectangle cellClip,
            DataGridViewCellStyle cellStyle,
            bool singleVerticalBorderAdded,
            bool singleHorizontalBorderAdded,
            bool isFirstDisplayedColumn,
            bool isFirstDisplayedRow)
        {
            Rectangle editingControlBounds = PositionEditingPanel(
                cellBounds,
                cellClip,
                cellStyle,
                singleVerticalBorderAdded,
                singleHorizontalBorderAdded,
                isFirstDisplayedColumn,
                isFirstDisplayedRow);
            if (cellStyle is null) throw new ArgumentNullException(nameof(cellStyle));
            editingControlBounds = GetAdjustedEditingControlBounds(editingControlBounds, cellStyle);
            if (DataGridView is not null)
            {
                DataGridView.EditingControl.Location = new Point(editingControlBounds.X, editingControlBounds.Y);
                DataGridView.EditingControl.Size = new Size(editingControlBounds.Width, editingControlBounds.Height);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "DataGridViewNumericUpDownCell { ColumnIndex=" + ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
        }

        /// <summary>
        /// Little utility function used by both the cell and column types to translate a DataGridViewContentAlignment value into
        /// a HorizontalAlignment value.
        /// </summary>
        /// <param name="align">The content alignment.</param>
        /// <returns>The horizontal alignment.</returns>
        internal static HorizontalAlignment TranslateAlignment(DataGridViewContentAlignment align)
        {
            return (align & AnyRight) != 0
                ? HorizontalAlignment.Right
                : (align & AnyCenter) != 0 ? HorizontalAlignment.Center : HorizontalAlignment.Left;
        }

        /// <summary>
        /// Utility function that sets a new value for the decimalPlaces property of the cell. This function is used by
        /// the cell and column decimalPlaces property. The column uses this method instead of the decimalPlaces
        /// property for performance reasons. This way the column can invalidate the entire column at once instead of
        /// invalidating each cell of the column individually. A row index needs to be provided as a parameter because
        /// this cell may be shared among multiple rows.
        /// </summary>
        /// <param name="rowIndex">The row index.</param>
        /// <param name="value">The value.</param>
        internal void SetDecimalPlaces(int rowIndex, int value)
        {
            Debug.Assert(value is >= 0 and <= 99, "The value is out of range.");
            _decimalPlaces = value;
            if (OwnsEditingNumericUpDown(rowIndex) && EditingNumericUpDown is not null)
            {
                EditingNumericUpDown.DecimalPlaces = value;
            }
        }

        /// <summary>
        /// Utility function that sets a new value for the Increment property of the cell. This function is used by
        /// the cell and column Increment property. A row index needs to be provided as a parameter because
        /// this cell may be shared among multiple rows.
        /// </summary>
        /// <param name="rowIndex">The row index.</param>
        /// <param name="value">The value.</param>
        internal void SetIncrement(int rowIndex, decimal value)
        {
            Debug.Assert(value >= 0m, "The value should be bigger or equal to 0.");
            _increment = value;
            if (OwnsEditingNumericUpDown(rowIndex) && EditingNumericUpDown is not null)
            {
                EditingNumericUpDown.Increment = value;
            }
        }

        /// <summary>
        /// Utility function that sets a new value for the Maximum property of the cell. This function is used by
        /// the cell and column Maximum property. The column uses this method instead of the Maximum
        /// property for performance reasons. This way the column can invalidate the entire column at once instead of
        /// invalidating each cell of the column individually. A row index needs to be provided as a parameter because
        /// this cell may be shared among multiple rows.
        /// </summary>
        /// <param name="rowIndex">The row index.</param>
        /// <param name="value">The value.</param>
        internal void SetMaximum(int rowIndex, decimal value)
        {
            _maximum = value;
            if (_minimum > _maximum)
            {
                _minimum = _maximum;
            }

            object cellValue = GetValue(rowIndex);
            if (cellValue != null)
            {
                decimal currentValue = Convert.ToDecimal(cellValue);
                decimal constrainedValue = Constrain(currentValue);
                if (constrainedValue != currentValue)
                {
                    _ = SetValue(rowIndex, constrainedValue);
                }
            }

            Debug.Assert(_maximum == value, "The maximum should be equal to value.");
            if (OwnsEditingNumericUpDown(rowIndex) && EditingNumericUpDown is not null)
            {
                EditingNumericUpDown.Maximum = value;
            }
        }

        /// <summary>
        /// Utility function that sets a new value for the Minimum property of the cell. This function is used by
        /// the cell and column Minimum property. The column uses this method instead of the Minimum
        /// property for performance reasons. This way the column can invalidate the entire column at once instead of
        /// invalidating each cell of the column individually. A row index needs to be provided as a parameter because
        /// this cell may be shared among multiple rows.
        /// </summary>
        /// <param name="rowIndex">The row index.</param>
        /// <param name="value">The value.</param>
        internal void SetMinimum(int rowIndex, decimal value)
        {
            _minimum = value;
            if (_minimum > _maximum)
            {
                _maximum = value;
            }

            object cellValue = GetValue(rowIndex);
            if (cellValue != null)
            {
                decimal currentValue = System.Convert.ToDecimal(cellValue);
                decimal constrainedValue = Constrain(currentValue);
                if (constrainedValue != currentValue)
                {
                    _ = SetValue(rowIndex, constrainedValue);
                }
            }

            Debug.Assert(_minimum == value, "The minimum should be equal to value.");
            if (OwnsEditingNumericUpDown(rowIndex) && EditingNumericUpDown is not null)
            {
                EditingNumericUpDown.Minimum = value;
            }
        }

        /// <summary>
        /// Utility function that sets a new value for the ThousandsSeparator property of the cell. This function is used by
        /// the cell and column ThousandsSeparator property. The column uses this method instead of the ThousandsSeparator
        /// property for performance reasons. This way the column can invalidate the entire column at once instead of
        /// invalidating each cell of the column individually. A row index needs to be provided as a parameter because
        /// this cell may be shared among multiple rows.
        /// </summary>
        /// <param name="rowIndex">The row index.</param>
        /// <param name="value">The value.</param>
        internal void SetThousandsSeparator(int rowIndex, bool value)
        {
            _thousandsSeparator = value;
            if (OwnsEditingNumericUpDown(rowIndex) && EditingNumericUpDown is not null)
            {
                EditingNumericUpDown.ThousandsSeparator = value;
            }
        }

        /// <inheritdoc/>
        protected override Rectangle GetErrorIconBounds(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex)
        {
            const int ButtonsWidth = 16;
            Rectangle errorIconBounds = base.GetErrorIconBounds(graphics, cellStyle, rowIndex);

            errorIconBounds.X = DataGridView?.RightToLeft == RightToLeft.Yes ? errorIconBounds.Left + ButtonsWidth : errorIconBounds.Left - ButtonsWidth;

            return errorIconBounds;
        }

        /// <inheritdoc/>
        protected override object GetFormattedValue(
            object value,
            int rowIndex,
            ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            // By default, the base implementation converts the decimal 1234.5 into the string "1234.5"
            object formattedValue = base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            string? formattedNumber = formattedValue as string;
            if (!string.IsNullOrEmpty(formattedNumber) && value != null)
            {
                decimal unformatteddecimal = System.Convert.ToDecimal(value);
                decimal formatteddecimal = System.Convert.ToDecimal(formattedNumber);
                if (unformatteddecimal == formatteddecimal)
                {
                    // The base implementation of GetFormattedValue (which triggers the CellFormatting event) did nothing else than
                    // the typical 1234.5 to "1234.5" conversion. But depending on the values of ThousandsSeparator and decimalPlaces,
                    // this may not be the actual string displayed. The real formatted value may be "1,234.500"
                    return formatteddecimal.ToString((ThousandsSeparator ? "N" : "F") + _decimalPlaces.ToString());
                }
            }

            return formattedValue;
        }

        /// <inheritdoc/>
        protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
        {
            if (DataGridView == null)
            {
                return new Size(-1, -1);
            }

            Size preferredSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            if (constraintSize.Width == 0)
            {
                const int ButtonsWidth = 16; // Account for the width of the up/down buttons.
                const int ButtonMargin = 8;  // Account for some blank pixels between the text and buttons.
                preferredSize.Width += ButtonsWidth + ButtonMargin;
            }

            return preferredSize;
        }

        /// <inheritdoc/>
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (DataGridView == null || cellStyle == null)
            {
                return;
            }

            /*if (paintingNumericUpDown.IsDisposed)
            {
                paintingNumericUpDown =new NumericUpDown();
            }*/

            // First paint the borders and background of the cell.
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~(DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.ContentForeground));

            Point ptCurrentCell = DataGridView.CurrentCellAddress;
            bool cellCurrent = ptCurrentCell.X == ColumnIndex && ptCurrentCell.Y == rowIndex;
            bool cellEdited = cellCurrent && DataGridView.EditingControl != null;

            // If the cell is in editing mode, there is nothing else to paint
            if (!cellEdited)
            {
                if (PartPainted(paintParts, DataGridViewPaintParts.ContentForeground))
                {
                    // Paint a NumericUpDown control
                    // Take the borders into account
                    Rectangle borderWidths = BorderWidths(advancedBorderStyle);
                    Rectangle valBounds = cellBounds;
                    valBounds.Offset(borderWidths.X, borderWidths.Y);
                    valBounds.Width -= borderWidths.Right;
                    valBounds.Height -= borderWidths.Bottom;

                    // Also take the padding into account
                    if (cellStyle.Padding != Padding.Empty)
                    {
                        if (DataGridView.RightToLeft == RightToLeft.Yes)
                        {
                            valBounds.Offset(cellStyle.Padding.Right, cellStyle.Padding.Top);
                        }
                        else
                        {
                            valBounds.Offset(cellStyle.Padding.Left, cellStyle.Padding.Top);
                        }

                        valBounds.Width -= cellStyle.Padding.Horizontal;
                        valBounds.Height -= cellStyle.Padding.Vertical;
                    }

                    // Determine the NumericUpDown control location
                    valBounds = GetAdjustedEditingControlBounds(valBounds, cellStyle);

                    bool cellSelected = (cellState & DataGridViewElementStates.Selected) != 0;

                    if ((renderingBitmap is not null) &&
                        (renderingBitmap.Width < valBounds.Width ||
                        renderingBitmap.Height < valBounds.Height))
                    {
                        // The static bitmap is too small, a bigger one needs to be allocated.
                        renderingBitmap.Dispose();
                        renderingBitmap = new Bitmap(valBounds.Width, valBounds.Height);
                    }

                    // Make sure the NumericUpDown control is parented to a visible control
                    if (_paintingNumericUpDown.Parent == null || !_paintingNumericUpDown.Parent.Visible)
                    {
                        _paintingNumericUpDown.Parent = DataGridView;
                    }

                    // Set all the relevant properties
                    _paintingNumericUpDown.TextAlign = TranslateAlignment(cellStyle.Alignment);
                    _paintingNumericUpDown.DecimalPlaces = _decimalPlaces;
                    _paintingNumericUpDown.ThousandsSeparator = ThousandsSeparator;
                    _paintingNumericUpDown.Font = cellStyle.Font;
                    _paintingNumericUpDown.Width = valBounds.Width;
                    _paintingNumericUpDown.Height = valBounds.Height;
                    _paintingNumericUpDown.RightToLeft = DataGridView.RightToLeft;
                    _paintingNumericUpDown.Location = new Point(0, -_paintingNumericUpDown.Height - 100);
                    _paintingNumericUpDown.Text = formattedValue as string;

                    Color backColor = PartPainted(paintParts, DataGridViewPaintParts.SelectionBackground) && cellSelected
                        ? cellStyle.SelectionBackColor
                        : cellStyle.BackColor;

                    if (PartPainted(paintParts, DataGridViewPaintParts.Background))
                    {
                        if (backColor.A < 255)
                        {
                            // The NumericUpDown control does not support transparent back colors
                            backColor = Color.FromArgb(255, backColor);
                        }

                        _paintingNumericUpDown.BackColor = backColor;
                    }

                    // Finally paint the NumericUpDown control
                    Rectangle srcRect = new Rectangle(0, 0, valBounds.Width, valBounds.Height);
                    if (renderingBitmap is not null && srcRect.Width > 0 && srcRect.Height > 0)
                    {
                        _paintingNumericUpDown.DrawToBitmap(renderingBitmap, srcRect);
                        graphics?.DrawImage(renderingBitmap, new Rectangle(valBounds.Location, valBounds.Size), srcRect, GraphicsUnit.Pixel);
                    }
                }

                if (PartPainted(paintParts, DataGridViewPaintParts.ErrorIcon))
                {
                    // Paint the potential error icon on top of the NumericUpDown control
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, DataGridViewPaintParts.ErrorIcon);
                }
            }
        }

        /// <summary>
        /// Little utility function called by the Paint function to see if a particular part needs to be painted.
        /// </summary>
        private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
        {
            return (paintParts & paintPart) != 0;
        }

        /// <summary>
        /// Adjusts the location and size of the editing control given the alignment characteristics of the cell.
        /// </summary>
        private static Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
        {
            // Add a 1 pixel padding on the left and right of the editing control
            editingControlBounds.X += 1;
            editingControlBounds.Width = Math.Max(0, editingControlBounds.Width - 2);

            // Adjust the vertical location of the editing control:
            int preferredHeight = cellStyle.Font.Height + 3;
            if (preferredHeight < editingControlBounds.Height)
            {
                switch (cellStyle.Alignment)
                {
                    case DataGridViewContentAlignment.MiddleLeft:
                    case DataGridViewContentAlignment.MiddleCenter:
                    case DataGridViewContentAlignment.MiddleRight:
                        editingControlBounds.Y += (editingControlBounds.Height - preferredHeight) / 2;
                        break;
                    case DataGridViewContentAlignment.BottomLeft:
                    case DataGridViewContentAlignment.BottomCenter:
                    case DataGridViewContentAlignment.BottomRight:
                        editingControlBounds.Y += editingControlBounds.Height - preferredHeight;
                        break;
                }
            }

            return editingControlBounds;
        }

        // Used in KeyEntersEditMode function
        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern short VkKeyScan(char key);

        private void PaintingNumericUpDown_ValueChanged(object? sender, EventArgs e)
        {
            Value = _paintingNumericUpDown.Value;
        }

        /// <summary>
        /// Returns the provided value constrained to be within the min and max.
        /// </summary>
        private decimal Constrain(decimal value)
        {
            Debug.Assert(_minimum <= _maximum, "The maximum should be bigger than the minimum.");
            if (value < _minimum)
            {
                value = _minimum;
            }

            if (value > _maximum)
            {
                value = _maximum;
            }

            return value;
        }

        /// <summary>
        /// Called when a cell characteristic that affects its rendering and/or preferred size has changed.
        /// This implementation only takes care of repainting the cells. The DataGridView's autosizing methods
        /// also need to be called in cases where some grid elements autosize.
        /// </summary>
        private void OnCommonChange()
        {
            if (DataGridView != null && !DataGridView.IsDisposed && !DataGridView.Disposing)
            {
                if (RowIndex == -1)
                {
                    // Invalidate and autosize column
                    DataGridView.InvalidateColumn(ColumnIndex);

                    // TODO: Add code to autosize the cell's column, the rows, the column headers
                    // and the row headers depending on their autosize settings.
                    // The DataGridView control does not expose a public method that takes care of.
                }
                else
                {
                    // The DataGridView control exposes a public method called UpdateCellValue
                    // that invalidates the cell so that it gets repainted and also triggers all
                    // the necessary autosizing: the cell's column and/or row, the column headers
                    // and the row headers are autosized depending on their autosize settings.
                    DataGridView.UpdateCellValue(ColumnIndex, RowIndex);
                }
            }
        }

        /// <summary>
        /// Determines whether this cell, at the given row index, shows the grid's editing control or not.
        /// The row index needs to be provided as a parameter because this cell may be shared among multiple rows.
        /// </summary>
        private bool OwnsEditingNumericUpDown(int rowIndex)
        {
            if (rowIndex == -1 || DataGridView == null) return false;
            return DataGridView.EditingControl is DataGridViewNumericUpDownEditingControl numericUpDownEditingControl && rowIndex == ((IDataGridViewEditingControl)numericUpDownEditingControl).EditingControlRowIndex;
        }
    }
}
