// <copyright file="DataGridViewNumericUpDownEditingControl.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Runtime.InteropServices;

namespace SimpleAnnPlayground.UI.Controls
{
    /// <summary>
    /// NumericUpDown control definition.
    /// </summary>
    public class DataGridViewNumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewNumericUpDownEditingControl"/> class.
        /// </summary>
        public DataGridViewNumericUpDownEditingControl()
        {
            // The editing control must not be part of the tabbing loop
            TabStop = false;
        }

        /// <summary>
        /// Gets or sets the DataGridView that uses this editing control.
        /// </summary>
        public virtual DataGridView? EditingControlDataGridView { get; set; }

        /// <summary>
        /// Gets or sets the current formatted value of the editing control.
        /// </summary>
#pragma warning disable CA1721 // Property names should not match get methods
        public virtual object EditingControlFormattedValue
#pragma warning restore CA1721 // Property names should not match get methods
        {
            get => GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            set => Text = (string)value;
        }

        /// <summary>
        /// Gets or sets the row in which the editing control resides.
        /// </summary>
        public virtual int EditingControlRowIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value of the editing control has changed or not.
        /// </summary>
        public virtual bool EditingControlValueChanged { get; set; }

        /// <summary>
        /// Gets which cursor must be used for the editing panel,
        /// i.e. the parent of the editing control.
        /// </summary>
        public virtual Cursor EditingPanelCursor => Cursors.Default;

        /// <summary>
        /// Gets a value indicating whether the editing control needs to be repositioned
        /// when its value changes.
        /// </summary>
        public virtual bool RepositionEditingControlOnValueChange => false;

        /// <summary>
        /// Method called by the grid before the editing control is shown so it can adapt to the
        /// provided cell style.
        /// </summary>
        /// <param name="dataGridViewCellStyle">The cell style.</param>
        public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            if (dataGridViewCellStyle is null) throw new ArgumentNullException(nameof(dataGridViewCellStyle));
            Font = dataGridViewCellStyle.Font;
            if (dataGridViewCellStyle.BackColor.A < 255)
            {
                // The NumericUpDown control does not support transparent back colors
                Color opaqueBackColor = Color.FromArgb(255, dataGridViewCellStyle.BackColor);
                BackColor = opaqueBackColor;
                if (EditingControlDataGridView is not null) EditingControlDataGridView.EditingPanel.BackColor = opaqueBackColor;
            }
            else
            {
                BackColor = dataGridViewCellStyle.BackColor;
            }

            ForeColor = dataGridViewCellStyle.ForeColor;
            TextAlign = DataGridViewNumericUpDownCell.TranslateAlignment(dataGridViewCellStyle.Alignment);
        }

        /// <summary>
        /// Method called by the grid on keystrokes to determine if the editing control is
        /// interested in the key or not.
        /// </summary>
        /// <param name="keyData">The key data.</param>
        /// <param name="dataGridViewWantsInputKey">Process input key.</param>
        /// <returns>True if the input key was processed.</returns>
        public virtual bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Right:
                {
                    if (Controls[1] is TextBox textBox)
                    {
                        // If the end of the selection is at the end of the string,
                        // let the DataGridView treat the key message
                        if ((RightToLeft == RightToLeft.No && !(textBox.SelectionLength == 0 && textBox.SelectionStart == textBox.Text.Length)) ||
                            (RightToLeft == RightToLeft.Yes && !(textBox.SelectionLength == 0 && textBox.SelectionStart == 0)))
                        {
                            return true;
                        }
                    }

                    break;
                }

                case Keys.Left:
                {
                    if (Controls[1] is TextBox textBox)
                    {
                        // If the end of the selection is at the begining of the string
                        // or if the entire text is selected and we did not start editing,
                        // send this character to the dataGridView, else process the key message
                        if ((RightToLeft == RightToLeft.No && !(textBox.SelectionLength == 0 && textBox.SelectionStart == 0)) ||
                            (RightToLeft == RightToLeft.Yes && !(textBox.SelectionLength == 0 && textBox.SelectionStart == textBox.Text.Length)))
                        {
                            return true;
                        }
                    }

                    break;
                }

                case Keys.Down:
                    // If the current value hasn't reached its minimum yet, handle the key. Otherwise let
                    // the grid handle it.
                    if (Value > Minimum) return true;
                    break;

                case Keys.Up:
                    // If the current value hasn't reached its maximum yet, handle the key. Otherwise let
                    // the grid handle it.
                    if (Value < Maximum) return true;
                    break;

                case Keys.Home:
                case Keys.End:
                {
                    // Let the grid handle the key if the entire text is selected.
                    if (Controls[1] is TextBox textBox)
                    {
                        if (textBox.SelectionLength != textBox.Text.Length)
                        {
                            return true;
                        }
                    }

                    break;
                }

                case Keys.Delete:
                {
                    // Let the grid handle the key if the carret is at the end of the text.
                    if (Controls[1] is TextBox textBox)
                    {
                        if (textBox.SelectionLength > 0 ||
                            textBox.SelectionStart < textBox.Text.Length)
                        {
                            return true;
                        }
                    }

                    break;
                }
            }

            return !dataGridViewWantsInputKey;
        }

        /// <summary>
        /// Returns the current value of the editing control.
        /// </summary>
        /// <param name="context">The control context.</param>
        /// <returns>The associated object.</returns>
        public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            /*bool userEdit = UserEdit;
            try
            {
                // Prevent the Value from being set to Maximum or Minimum when the cell is being painted.
                UserEdit = (context & DataGridViewDataErrorContexts.Display) == 0;
                return Value.ToString((ThousandsSeparator ? "N" : "F") + DecimalPlaces.ToString());
            }
            finally
            {
                UserEdit = userEdit;
            }*/
            return Value.ToString();
        }

        /// <summary>
        /// Called by the grid to give the editing control a chance to prepare itself for
        /// the editing session.
        /// </summary>
        /// <param name="selectAll">Select all the text.</param>
        public virtual void PrepareEditingControlForEdit(bool selectAll)
        {
            if (Controls[1] is TextBox textBox)
            {
                if (selectAll)
                {
                    textBox.SelectAll();
                }
                else
                {
                    // Do not select all the text, but
                    // position the caret at the end of the text
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
        }

        /*
        /// <summary>
        /// Listen to the KeyPress notification to know when the value changed, and
        /// notify the grid of the change.
        /// </summary>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            // The value changes when a digit, the decimal separator, the group separator or
            // the negative sign is pressed.
            bool notifyValueChange = false;
            if (char.IsDigit(e.KeyChar))
            {
                notifyValueChange = true;
            }
            else
            {
                System.Globalization.NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
                string decimalSeparatorStr = numberFormatInfo.NumberDecimalSeparator;
                string groupSeparatorStr = numberFormatInfo.NumberGroupSeparator;
                string negativeSignStr = numberFormatInfo.NegativeSign;
                if (!string.IsNullOrEmpty(decimalSeparatorStr) && decimalSeparatorStr.Length == 1)
                {
                    notifyValueChange = decimalSeparatorStr[0] == e.KeyChar;
                }
                if (!notifyValueChange && !string.IsNullOrEmpty(groupSeparatorStr) && groupSeparatorStr.Length == 1)
                {
                    notifyValueChange = groupSeparatorStr[0] == e.KeyChar;
                }
                if (!notifyValueChange && !string.IsNullOrEmpty(negativeSignStr) && negativeSignStr.Length == 1)
                {
                    notifyValueChange = negativeSignStr[0] == e.KeyChar;
                }
            }

            if (notifyValueChange)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
            }
        }*/

        /// <inheritdoc/>
        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);

            // if (Focused)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
            }
        }

        /// <inheritdoc/>
        protected override bool ProcessKeyEventArgs(ref Message m)
        {
            if (Controls[1] is TextBox textBox)
            {
                _ = SendMessage(textBox.Handle, m.Msg, m.WParam, m.LParam);
                return true;
            }
            else
            {
                return base.ProcessKeyEventArgs(ref m);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Small utility function that updates the local dirty state and
        /// notifies the grid of the value change.
        /// </summary>
        private void NotifyDataGridViewOfValueChange()
        {
            if (!EditingControlValueChanged)
            {
                EditingControlValueChanged = true;
                EditingControlDataGridView?.NotifyCurrentCellDirty(true);
            }
        }
    }
}
