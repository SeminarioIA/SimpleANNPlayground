// <copyright file="FrmSetValue.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.UI
{
    /// <summary>
    /// Window to set a numeric value.
    /// </summary>
    public partial class FrmSetValue : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmSetValue"/> class.
        /// </summary>
        /// <param name="title">The window title.</param>
        public FrmSetValue(string title)
        {
            InitializeComponent();

            // Set the window title.
            Text = title;
        }

        /// <summary>
        /// Show the window to adjust a value.
        /// </summary>
        /// <param name="value">The default value.</param>
        /// <returns>The adjusted value.</returns>
        public decimal? AdjustValue(decimal value)
        {
            TbValue.Text = value.ToString();

            if (ShowDialog() == DialogResult.OK)
            {
                return decimal.Parse(TbValue.Text);
            }

            return null;
        }

        private void TbValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is(< '0' or > '9') and not('\x8' or '.'))
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
            else if (e.KeyChar is '.' && TbValue.Text.Contains('.', StringComparison.Ordinal))
            {
                e.KeyChar = '\0';
            }
        }
    }
}
