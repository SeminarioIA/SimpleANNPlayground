// <copyright file="FrmRtfViewer.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Debugging
{
    /// <summary>
    /// Form to debug the Rich Text format.
    /// </summary>
    public partial class FrmRtfViewer : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmRtfViewer"/> class.
        /// </summary>
        public FrmRtfViewer()
        {
            InitializeComponent();
        }

        private void FrmRtbViewer_Load(object sender, EventArgs e)
        {
            TbViewer.Text = RtbText.Rtf;
        }

        private void RtbText_TextChanged(object sender, EventArgs e)
        {
            TbViewer.Text = RtbText.Rtf;
        }

        private void TbViewer_TextChanged(object sender, EventArgs e)
        {
            RtbText.Rtf = TbViewer.Text;
        }
    }
}
