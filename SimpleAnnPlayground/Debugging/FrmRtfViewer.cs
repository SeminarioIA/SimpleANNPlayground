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
        private bool _lock;

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
            if (_lock) return;
            _lock = true;
            TbViewer.Text = RtbText.Rtf;
            _lock = false;
        }

        private void TbViewer_TextChanged(object sender, EventArgs e)
        {
            if (_lock) return;
            _lock = true;
#pragma warning disable CA1031 // Do not catch general exception types
            try
            {
                RtbText.Rtf = TbViewer.Text;
                TbViewer.BackColor = Color.White;
            }
            catch
            {
                TbViewer.BackColor = Color.LightSalmon;
            }
#pragma warning restore CA1031 // Do not catch general exception types
            _lock = false;
        }
    }
}
