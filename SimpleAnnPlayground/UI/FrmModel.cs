// <copyright file="FrmModel.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Networks;

namespace SimpleAnnPlayground.UI
{
    /// <summary>
    /// Window to adjust the model parameters.
    /// </summary>
    internal partial class FrmModel : Form
    {
        private readonly Network _network;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmModel"/> class.
        /// </summary>
        /// <param name="network">The network to set the parameters.</param>
        public FrmModel(Network network)
        {
            InitializeComponent();

            _network = network;
        }

        private void FrmModel_Load(object sender, EventArgs e)
        {
            TkRate.Value = Network.LearningRates.ToList().IndexOf(_network.LearningRate);
            TbRate.ReadOnly = TkRate.Value != -1;
            TbRate.Text = _network.LearningRate.ToString();
        }

        private void TkRate_ValueChanged(object sender, EventArgs e)
        {
            if (TkRate.Value == -1)
            {
                TbRate.ReadOnly = false;
                TbRate.Text = _network.LearningRate.ToString();
            }
            else
            {
                TbRate.ReadOnly = true;
                TbRate.Text = Network.LearningRates[TkRate.Value].ToString();
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            _network.LearningRate = decimal.Parse(TbRate.Text);
        }

        private void TbRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is(< '0' or > '9') and not('\x8' or '.'))
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
            else if (e.KeyChar is '.' && TbRate.Text.Contains('.', StringComparison.Ordinal))
            {
                e.KeyChar = '\0';
            }
        }
    }
}
