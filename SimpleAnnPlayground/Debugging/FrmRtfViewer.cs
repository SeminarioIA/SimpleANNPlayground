// <copyright file="FrmRtfViewer.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Utils.FileManagment;

namespace SimpleAnnPlayground.Debugging
{
    /// <summary>
    /// Form to debug the Rich Text format.
    /// </summary>
    public partial class FrmRtfViewer : Form
    {
        private readonly TextFileManager _fileManager;

        private bool _lock;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmRtfViewer"/> class.
        /// </summary>
        public FrmRtfViewer()
        {
            InitializeComponent();

            _fileManager = new TextFileManager();
            _fileManager.AddFileFormat(".rtf", "Rich Text Format");
        }

        private void FrmRtbViewer_Load(object sender, EventArgs e)
        {
            TbViewer.Text = RtbText.Rtf;
            _fileManager.New(RtbText.Rtf);
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

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TbViewer.Text = string.Empty;
            _fileManager.New(RtbText.Rtf);
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (_fileManager.Open() && _fileManager.FileContent is not null)
            {
                TbViewer.Text = (string)_fileManager.FileContent;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _ = _fileManager.Save(TbViewer.Text);
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            _ = _fileManager.SaveAs(TbViewer.Text);
        }

        private void BtnSendText_Click(object sender, EventArgs e)
        {
            if (Owner is FrmMain frmMain) frmMain.Details = TbViewer.Text;
        }

        private void BtnGetText_Click(object sender, EventArgs e)
        {
            if (Owner is FrmMain frmMain) TbViewer.Text = frmMain.Details;
        }
    }
}
