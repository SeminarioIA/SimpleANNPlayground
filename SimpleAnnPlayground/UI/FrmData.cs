// <copyright file="FrmData.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Screens
{
    /// <summary>
    /// Form to load the model data.
    /// </summary>
    public partial class FrmData : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmData"/> class.
        /// </summary>
        public FrmData()
        {
            InitializeComponent();

            PbData.ValueChanged += PbData_ValueChanged;
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
    }
}
