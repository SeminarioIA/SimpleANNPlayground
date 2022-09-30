// <copyright file="FrmDetails.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Networks;
using SimpleAnnPlayground.Help;
using System.Globalization;

namespace SimpleAnnPlayground.UI
{
    /// <summary>
    /// The form to show the details about the math operations.
    /// </summary>
    public partial class FrmDetails : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmDetails"/> class.
        /// </summary>
        public FrmDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the windows info.
        /// </summary>
        /// <param name="phase">Execution phase.</param>
        internal void SetInfo(ExecPhase phase)
        {
            RtbInfo.Rtf = HelpSources.ResourceManager.GetString(phase.ToString(), CultureInfo.InvariantCulture);
        }

        private void FrmDetails_Load(object sender, EventArgs e)
        {
        }

        private void FrmDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            _ = Owner.Focus();
        }
    }
}
