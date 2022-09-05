namespace SimpleAnnPlayground.Debugging
{
    partial class FrmRtfViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                _fileManager.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScMain = new System.Windows.Forms.SplitContainer();
            this.RtbText = new System.Windows.Forms.RichTextBox();
            this.TbViewer = new System.Windows.Forms.TextBox();
            this.TsTools = new System.Windows.Forms.ToolStrip();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnOpen = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.BtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnSendText = new System.Windows.Forms.ToolStripButton();
            this.BtnGetText = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
            this.ScMain.Panel1.SuspendLayout();
            this.ScMain.Panel2.SuspendLayout();
            this.ScMain.SuspendLayout();
            this.TsTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScMain
            // 
            this.ScMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ScMain.Location = new System.Drawing.Point(0, 25);
            this.ScMain.Name = "ScMain";
            this.ScMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ScMain.Panel1
            // 
            this.ScMain.Panel1.Controls.Add(this.RtbText);
            // 
            // ScMain.Panel2
            // 
            this.ScMain.Panel2.Controls.Add(this.TbViewer);
            this.ScMain.Size = new System.Drawing.Size(602, 481);
            this.ScMain.SplitterDistance = 180;
            this.ScMain.TabIndex = 0;
            // 
            // RtbText
            // 
            this.RtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbText.Location = new System.Drawing.Point(0, 0);
            this.RtbText.Name = "RtbText";
            this.RtbText.Size = new System.Drawing.Size(602, 180);
            this.RtbText.TabIndex = 0;
            this.RtbText.Text = "";
            this.RtbText.WordWrap = false;
            this.RtbText.TextChanged += new System.EventHandler(this.RtbText_TextChanged);
            // 
            // TbViewer
            // 
            this.TbViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbViewer.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbViewer.Location = new System.Drawing.Point(0, 0);
            this.TbViewer.Multiline = true;
            this.TbViewer.Name = "TbViewer";
            this.TbViewer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbViewer.Size = new System.Drawing.Size(602, 297);
            this.TbViewer.TabIndex = 0;
            this.TbViewer.TextChanged += new System.EventHandler(this.TbViewer_TextChanged);
            // 
            // TsTools
            // 
            this.TsTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnOpen,
            this.BtnSave,
            this.BtnSaveAs,
            this.toolStripSeparator1,
            this.BtnSendText,
            this.BtnGetText});
            this.TsTools.Location = new System.Drawing.Point(0, 0);
            this.TsTools.Name = "TsTools";
            this.TsTools.Size = new System.Drawing.Size(602, 25);
            this.TsTools.TabIndex = 1;
            this.TsTools.Text = "toolStrip1";
            // 
            // BtnNew
            // 
            this.BtnNew.Image = global::SimpleAnnPlayground.Properties.Resources.d_new;
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(51, 22);
            this.BtnNew.Text = "New";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Image = global::SimpleAnnPlayground.Properties.Resources.d_open;
            this.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(56, 22);
            this.BtnOpen.Text = "Open";
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = global::SimpleAnnPlayground.Properties.Resources.d_save;
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(51, 22);
            this.BtnSave.Text = "Save";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnSaveAs
            // 
            this.BtnSaveAs.Image = global::SimpleAnnPlayground.Properties.Resources.d_save_as;
            this.BtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSaveAs.Name = "BtnSaveAs";
            this.BtnSaveAs.Size = new System.Drawing.Size(65, 22);
            this.BtnSaveAs.Text = "Save as";
            this.BtnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnSendText
            // 
            this.BtnSendText.Image = global::SimpleAnnPlayground.Properties.Resources.d_up;
            this.BtnSendText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSendText.Name = "BtnSendText";
            this.BtnSendText.Size = new System.Drawing.Size(76, 22);
            this.BtnSendText.Text = "Send text";
            this.BtnSendText.Click += new System.EventHandler(this.BtnSendText_Click);
            // 
            // BtnGetText
            // 
            this.BtnGetText.Image = global::SimpleAnnPlayground.Properties.Resources.d_down;
            this.BtnGetText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGetText.Name = "BtnGetText";
            this.BtnGetText.Size = new System.Drawing.Size(68, 22);
            this.BtnGetText.Text = "Get text";
            this.BtnGetText.Click += new System.EventHandler(this.BtnGetText_Click);
            // 
            // FrmRtfViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 506);
            this.Controls.Add(this.ScMain);
            this.Controls.Add(this.TsTools);
            this.Name = "FrmRtfViewer";
            this.Text = "RTF Viewer";
            this.Load += new System.EventHandler(this.FrmRtbViewer_Load);
            this.ScMain.Panel1.ResumeLayout(false);
            this.ScMain.Panel2.ResumeLayout(false);
            this.ScMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
            this.ScMain.ResumeLayout(false);
            this.TsTools.ResumeLayout(false);
            this.TsTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer ScMain;
        private RichTextBox RtbText;
        private TextBox TbViewer;
        private ToolStrip TsTools;
        private ToolStripButton BtnNew;
        private ToolStripButton BtnOpen;
        private ToolStripButton BtnSave;
        private ToolStripButton BtnSaveAs;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton BtnSendText;
        private ToolStripButton BtnGetText;
    }
}