namespace SimpleAnnPlayground
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                _frmElementDesigner.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnOpen = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnInputNeurone = new System.Windows.Forms.ToolStripButton();
            this.BtnInternalNeurone = new System.Windows.Forms.ToolStripButton();
            this.BtnOutputNeurone = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PicWorkspace = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuEditOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuToolsLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuElementDesigner = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicWorkspace)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnOpen,
            this.BtnSave,
            this.toolStripSeparator1,
            this.BtnInputNeurone,
            this.BtnInternalNeurone,
            this.BtnOutputNeurone});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(777, 56);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNew
            // 
            this.BtnNew.Image = global::SimpleAnnPlayground.Properties.Resources.new_32;
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(38, 53);
            this.BtnNew.Text = "New";
            this.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnOpen
            // 
            this.BtnOpen.Image = global::SimpleAnnPlayground.Properties.Resources.open_32;
            this.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(44, 53);
            this.BtnOpen.Text = "Open";
            this.BtnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnSave
            // 
            this.BtnSave.Image = global::SimpleAnnPlayground.Properties.Resources.save_32;
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(39, 53);
            this.BtnSave.Text = "Save";
            this.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // BtnInputNeurone
            // 
            this.BtnInputNeurone.Image = global::SimpleAnnPlayground.Properties.Resources.Input_Icono_32;
            this.BtnInputNeurone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnInputNeurone.Name = "BtnInputNeurone";
            this.BtnInputNeurone.Size = new System.Drawing.Size(41, 53);
            this.BtnInputNeurone.Text = "Input";
            this.BtnInputNeurone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnInputNeurone.Click += new System.EventHandler(this.BtnInputNeurone_Click);
            // 
            // BtnInternalNeurone
            // 
            this.BtnInternalNeurone.Image = global::SimpleAnnPlayground.Properties.Resources.Interna_Icono_32;
            this.BtnInternalNeurone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnInternalNeurone.Name = "BtnInternalNeurone";
            this.BtnInternalNeurone.Size = new System.Drawing.Size(55, 53);
            this.BtnInternalNeurone.Text = "Internal";
            this.BtnInternalNeurone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnInternalNeurone.Click += new System.EventHandler(this.BtnInternalNeurone_Click);
            // 
            // BtnOutputNeurone
            // 
            this.BtnOutputNeurone.Image = global::SimpleAnnPlayground.Properties.Resources.Output_Icono_32;
            this.BtnOutputNeurone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOutputNeurone.Name = "BtnOutputNeurone";
            this.BtnOutputNeurone.Size = new System.Drawing.Size(52, 53);
            this.BtnOutputNeurone.Text = "Output";
            this.BtnOutputNeurone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnOutputNeurone.Click += new System.EventHandler(this.BtnOutputNeurone_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 451);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(777, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PicWorkspace
            // 
            this.PicWorkspace.BackColor = System.Drawing.Color.White;
            this.PicWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicWorkspace.Location = new System.Drawing.Point(0, 80);
            this.PicWorkspace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PicWorkspace.Name = "PicWorkspace";
            this.PicWorkspace.Size = new System.Drawing.Size(777, 371);
            this.PicWorkspace.TabIndex = 2;
            this.PicWorkspace.TabStop = false;
            this.PicWorkspace.Paint += new System.Windows.Forms.PaintEventHandler(this.PicWorkspace_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFile,
            this.MnuEdit,
            this.MnuTools,
            this.MnuHelp,
            this.MnuDebug});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(777, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnuFile
            // 
            this.MnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFileNew,
            this.MnuFileOpen,
            this.toolStripMenuItem1,
            this.MnuFileSave,
            this.MnuFileSaveAs,
            this.toolStripMenuItem2,
            this.MnuFileExit});
            this.MnuFile.Name = "MnuFile";
            this.MnuFile.Size = new System.Drawing.Size(37, 20);
            this.MnuFile.Text = "File";
            // 
            // MnuFileNew
            // 
            this.MnuFileNew.Name = "MnuFileNew";
            this.MnuFileNew.Size = new System.Drawing.Size(114, 22);
            this.MnuFileNew.Text = "New";
            // 
            // MnuFileOpen
            // 
            this.MnuFileOpen.Name = "MnuFileOpen";
            this.MnuFileOpen.Size = new System.Drawing.Size(114, 22);
            this.MnuFileOpen.Text = "Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 6);
            // 
            // MnuFileSave
            // 
            this.MnuFileSave.Name = "MnuFileSave";
            this.MnuFileSave.Size = new System.Drawing.Size(114, 22);
            this.MnuFileSave.Text = "Save";
            // 
            // MnuFileSaveAs
            // 
            this.MnuFileSaveAs.Name = "MnuFileSaveAs";
            this.MnuFileSaveAs.Size = new System.Drawing.Size(114, 22);
            this.MnuFileSaveAs.Text = "Save As";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(111, 6);
            // 
            // MnuFileExit
            // 
            this.MnuFileExit.Name = "MnuFileExit";
            this.MnuFileExit.Size = new System.Drawing.Size(114, 22);
            this.MnuFileExit.Text = "Exit";
            // 
            // MnuEdit
            // 
            this.MnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuEditUndo,
            this.MnuEditRedo,
            this.toolStripMenuItem3,
            this.MnuEditDelete,
            this.MnuEditCopy,
            this.MnuEditCut,
            this.MnuEditPaste,
            this.toolStripMenuItem4,
            this.MnuEditOptions});
            this.MnuEdit.Name = "MnuEdit";
            this.MnuEdit.Size = new System.Drawing.Size(39, 20);
            this.MnuEdit.Text = "Edit";
            // 
            // MnuEditUndo
            // 
            this.MnuEditUndo.Name = "MnuEditUndo";
            this.MnuEditUndo.Size = new System.Drawing.Size(116, 22);
            this.MnuEditUndo.Text = "Undo";
            // 
            // MnuEditRedo
            // 
            this.MnuEditRedo.Name = "MnuEditRedo";
            this.MnuEditRedo.Size = new System.Drawing.Size(116, 22);
            this.MnuEditRedo.Text = "Redo";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(113, 6);
            // 
            // MnuEditDelete
            // 
            this.MnuEditDelete.Name = "MnuEditDelete";
            this.MnuEditDelete.Size = new System.Drawing.Size(116, 22);
            this.MnuEditDelete.Text = "Delete";
            // 
            // MnuEditCopy
            // 
            this.MnuEditCopy.Name = "MnuEditCopy";
            this.MnuEditCopy.Size = new System.Drawing.Size(116, 22);
            this.MnuEditCopy.Text = "Copy";
            // 
            // MnuEditCut
            // 
            this.MnuEditCut.Name = "MnuEditCut";
            this.MnuEditCut.Size = new System.Drawing.Size(116, 22);
            this.MnuEditCut.Text = "Cut";
            // 
            // MnuEditPaste
            // 
            this.MnuEditPaste.Name = "MnuEditPaste";
            this.MnuEditPaste.Size = new System.Drawing.Size(116, 22);
            this.MnuEditPaste.Text = "Paste";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(113, 6);
            // 
            // MnuEditOptions
            // 
            this.MnuEditOptions.Name = "MnuEditOptions";
            this.MnuEditOptions.Size = new System.Drawing.Size(116, 22);
            this.MnuEditOptions.Text = "Options";
            // 
            // MnuTools
            // 
            this.MnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuToolsLanguage});
            this.MnuTools.Name = "MnuTools";
            this.MnuTools.Size = new System.Drawing.Size(46, 20);
            this.MnuTools.Text = "Tools";
            // 
            // MnuToolsLanguage
            // 
            this.MnuToolsLanguage.Name = "MnuToolsLanguage";
            this.MnuToolsLanguage.Size = new System.Drawing.Size(126, 22);
            this.MnuToolsLanguage.Text = "Language";
            // 
            // MnuHelp
            // 
            this.MnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuHelpAbout});
            this.MnuHelp.Name = "MnuHelp";
            this.MnuHelp.Size = new System.Drawing.Size(44, 20);
            this.MnuHelp.Text = "Help";
            // 
            // MnuHelpAbout
            // 
            this.MnuHelpAbout.Name = "MnuHelpAbout";
            this.MnuHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.MnuHelpAbout.Text = "About";
            // 
            // MnuDebug
            // 
            this.MnuDebug.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MnuDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuElementDesigner});
            this.MnuDebug.Name = "MnuDebug";
            this.MnuDebug.Size = new System.Drawing.Size(54, 20);
            this.MnuDebug.Text = "Debug";
            this.MnuDebug.Visible = false;
            // 
            // MnuElementDesigner
            // 
            this.MnuElementDesigner.Name = "MnuElementDesigner";
            this.MnuElementDesigner.Size = new System.Drawing.Size(165, 22);
            this.MnuElementDesigner.Text = "Element designer";
            this.MnuElementDesigner.Click += new System.EventHandler(this.MnuElementDesigner_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 473);
            this.Controls.Add(this.PicWorkspace);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "Red Neuronal Artificial Interactiva";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicWorkspace)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton BtnNew;
        private ToolStripButton BtnOpen;
        private ToolStripButton BtnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton BtnInputNeurone;
        private ToolStripButton BtnInternalNeurone;
        private ToolStripButton BtnOutputNeurone;
        private StatusStrip statusStrip1;
        private PictureBox PicWorkspace;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MnuFile;
        private ToolStripMenuItem MnuFileNew;
        private ToolStripMenuItem MnuFileOpen;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem MnuFileSave;
        private ToolStripMenuItem MnuFileSaveAs;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem MnuFileExit;
        private ToolStripMenuItem MnuEdit;
        private ToolStripMenuItem MnuEditUndo;
        private ToolStripMenuItem MnuEditRedo;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem MnuEditDelete;
        private ToolStripMenuItem MnuEditCopy;
        private ToolStripMenuItem MnuEditCut;
        private ToolStripMenuItem MnuEditPaste;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem MnuEditOptions;
        private ToolStripMenuItem MnuHelp;
        private ToolStripMenuItem MnuHelpAbout;
        private ToolStripMenuItem MnuTools;
        private ToolStripMenuItem MnuToolsLanguage;
        private ToolStripMenuItem MnuDebug;
        private ToolStripMenuItem MnuElementDesigner;
    }
}