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
#if DEBUG
                _frmElementDesigner.Dispose();
                _frmObjectsViewer.Dispose();
                _frmActionsViewer.Dispose();
#endif
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
            this.TspEdition = new System.Windows.Forms.ToolStrip();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnOpen = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnInputNeurone = new System.Windows.Forms.ToolStripButton();
            this.BtnInternalNeurone = new System.Windows.Forms.ToolStripButton();
            this.BtnOutputNeurone = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnCheck = new System.Windows.Forms.ToolStripButton();
            this.BtnTraining = new System.Windows.Forms.ToolStripButton();
            this.BtnTest = new System.Windows.Forms.ToolStripButton();
            this.SspStatus = new System.Windows.Forms.StatusStrip();
            this.LblMousePosition = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.MnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuViewCenterScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuToolsLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebugElementDesigner = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebugObjectViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebugActionsViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.VsbMain = new System.Windows.Forms.VScrollBar();
            this.ScBotom = new System.Windows.Forms.SplitContainer();
            this.HsbMain = new System.Windows.Forms.HScrollBar();
            this.LbZoom = new System.Windows.Forms.Label();
            this.LbZoomOut = new System.Windows.Forms.Label();
            this.LbZoomIn = new System.Windows.Forms.Label();
            this.TspExecution = new System.Windows.Forms.ToolStrip();
            this.BtnStop = new System.Windows.Forms.ToolStripButton();
            this.BtnRun = new System.Windows.Forms.ToolStripButton();
            this.BtnCxStep = new System.Windows.Forms.ToolStripButton();
            this.BtnNeuronStep = new System.Windows.Forms.ToolStripButton();
            this.BtnLayerStep = new System.Windows.Forms.ToolStripButton();
            this.TspEdition.SuspendLayout();
            this.SspStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicWorkspace)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScBotom)).BeginInit();
            this.ScBotom.Panel1.SuspendLayout();
            this.ScBotom.Panel2.SuspendLayout();
            this.ScBotom.SuspendLayout();
            this.TspExecution.SuspendLayout();
            this.SuspendLayout();
            // 
            // TspEdition
            // 
            this.TspEdition.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TspEdition.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TspEdition.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TspEdition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnOpen,
            this.BtnSave,
            this.toolStripSeparator1,
            this.BtnInputNeurone,
            this.BtnInternalNeurone,
            this.BtnOutputNeurone,
            this.toolStripSeparator2,
            this.BtnCheck,
            this.BtnTraining,
            this.BtnTest});
            this.TspEdition.Location = new System.Drawing.Point(0, 24);
            this.TspEdition.Name = "TspEdition";
            this.TspEdition.Size = new System.Drawing.Size(777, 56);
            this.TspEdition.TabIndex = 0;
            this.TspEdition.Text = "toolStrip1";
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
            this.BtnInputNeurone.Click += new System.EventHandler(this.BtnInsertNeurone_Click);
            // 
            // BtnInternalNeurone
            // 
            this.BtnInternalNeurone.Image = global::SimpleAnnPlayground.Properties.Resources.Interna_Icono_32;
            this.BtnInternalNeurone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnInternalNeurone.Name = "BtnInternalNeurone";
            this.BtnInternalNeurone.Size = new System.Drawing.Size(55, 53);
            this.BtnInternalNeurone.Text = "Internal";
            this.BtnInternalNeurone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnInternalNeurone.Click += new System.EventHandler(this.BtnInsertNeurone_Click);
            // 
            // BtnOutputNeurone
            // 
            this.BtnOutputNeurone.Image = global::SimpleAnnPlayground.Properties.Resources.Output_Icono_32;
            this.BtnOutputNeurone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOutputNeurone.Name = "BtnOutputNeurone";
            this.BtnOutputNeurone.Size = new System.Drawing.Size(52, 53);
            this.BtnOutputNeurone.Text = "Output";
            this.BtnOutputNeurone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnOutputNeurone.Click += new System.EventHandler(this.BtnInsertNeurone_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 56);
            // 
            // BtnCheck
            // 
            this.BtnCheck.Image = global::SimpleAnnPlayground.Properties.Resources.check_32;
            this.BtnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCheck.Name = "BtnCheck";
            this.BtnCheck.Size = new System.Drawing.Size(46, 53);
            this.BtnCheck.Text = "Check";
            this.BtnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnTraining
            // 
            this.BtnTraining.Image = global::SimpleAnnPlayground.Properties.Resources.training_32;
            this.BtnTraining.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnTraining.Name = "BtnTraining";
            this.BtnTraining.Size = new System.Drawing.Size(58, 53);
            this.BtnTraining.Text = "Training";
            this.BtnTraining.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnTest
            // 
            this.BtnTest.Image = global::SimpleAnnPlayground.Properties.Resources.testing_32;
            this.BtnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(53, 53);
            this.BtnTest.Text = "Testing";
            this.BtnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SspStatus
            // 
            this.SspStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblMousePosition});
            this.SspStatus.Location = new System.Drawing.Point(0, 449);
            this.SspStatus.Name = "SspStatus";
            this.SspStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.SspStatus.Size = new System.Drawing.Size(777, 24);
            this.SspStatus.TabIndex = 1;
            this.SspStatus.Text = "statusStrip1";
            // 
            // LblMousePosition
            // 
            this.LblMousePosition.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LblMousePosition.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LblMousePosition.Name = "LblMousePosition";
            this.LblMousePosition.Size = new System.Drawing.Size(53, 19);
            this.LblMousePosition.Text = "X: -, Y: -";
            // 
            // PicWorkspace
            // 
            this.PicWorkspace.BackColor = System.Drawing.Color.DarkGray;
            this.PicWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicWorkspace.Location = new System.Drawing.Point(0, 80);
            this.PicWorkspace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PicWorkspace.Name = "PicWorkspace";
            this.PicWorkspace.Size = new System.Drawing.Size(760, 352);
            this.PicWorkspace.TabIndex = 2;
            this.PicWorkspace.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFile,
            this.MnuEdit,
            this.MnuView,
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
            this.MnuEditUndo.Enabled = false;
            this.MnuEditUndo.Name = "MnuEditUndo";
            this.MnuEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.MnuEditUndo.Size = new System.Drawing.Size(180, 22);
            this.MnuEditUndo.Text = "Undo";
            this.MnuEditUndo.Click += new System.EventHandler(this.MnuEditUndo_Click);
            // 
            // MnuEditRedo
            // 
            this.MnuEditRedo.Enabled = false;
            this.MnuEditRedo.Name = "MnuEditRedo";
            this.MnuEditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.MnuEditRedo.Size = new System.Drawing.Size(180, 22);
            this.MnuEditRedo.Text = "Redo";
            this.MnuEditRedo.Click += new System.EventHandler(this.MnuEditRedo_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // MnuEditDelete
            // 
            this.MnuEditDelete.Enabled = false;
            this.MnuEditDelete.Name = "MnuEditDelete";
            this.MnuEditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.MnuEditDelete.Size = new System.Drawing.Size(180, 22);
            this.MnuEditDelete.Text = "Delete";
            this.MnuEditDelete.Click += new System.EventHandler(this.MnuEditDelete_Click);
            // 
            // MnuEditCopy
            // 
            this.MnuEditCopy.Enabled = false;
            this.MnuEditCopy.Name = "MnuEditCopy";
            this.MnuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MnuEditCopy.Size = new System.Drawing.Size(180, 22);
            this.MnuEditCopy.Text = "Copy";
            this.MnuEditCopy.Click += new System.EventHandler(this.MnuEditCopy_Click);
            // 
            // MnuEditCut
            // 
            this.MnuEditCut.Enabled = false;
            this.MnuEditCut.Name = "MnuEditCut";
            this.MnuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.MnuEditCut.Size = new System.Drawing.Size(180, 22);
            this.MnuEditCut.Text = "Cut";
            // 
            // MnuEditPaste
            // 
            this.MnuEditPaste.Enabled = false;
            this.MnuEditPaste.Name = "MnuEditPaste";
            this.MnuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.MnuEditPaste.Size = new System.Drawing.Size(180, 22);
            this.MnuEditPaste.Text = "Paste";
            this.MnuEditPaste.Click += new System.EventHandler(this.MnuEditPaste_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
            // 
            // MnuEditOptions
            // 
            this.MnuEditOptions.Name = "MnuEditOptions";
            this.MnuEditOptions.Size = new System.Drawing.Size(180, 22);
            this.MnuEditOptions.Text = "Options";
            // 
            // MnuView
            // 
            this.MnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuViewCenterScreen});
            this.MnuView.Name = "MnuView";
            this.MnuView.Size = new System.Drawing.Size(44, 20);
            this.MnuView.Text = "View";
            // 
            // MnuViewCenterScreen
            // 
            this.MnuViewCenterScreen.Name = "MnuViewCenterScreen";
            this.MnuViewCenterScreen.Size = new System.Drawing.Size(146, 22);
            this.MnuViewCenterScreen.Text = "Center screen";
            this.MnuViewCenterScreen.Click += new System.EventHandler(this.MnuViewCenterScreen_Click);
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
            this.MnuDebugElementDesigner,
            this.MnuDebugObjectViewer,
            this.MnuDebugActionsViewer});
            this.MnuDebug.Name = "MnuDebug";
            this.MnuDebug.Size = new System.Drawing.Size(54, 20);
            this.MnuDebug.Text = "Debug";
            this.MnuDebug.Visible = false;
            // 
            // MnuDebugElementDesigner
            // 
            this.MnuDebugElementDesigner.Name = "MnuDebugElementDesigner";
            this.MnuDebugElementDesigner.Size = new System.Drawing.Size(165, 22);
            this.MnuDebugElementDesigner.Text = "Element designer";
            this.MnuDebugElementDesigner.Click += new System.EventHandler(this.MnuDebugElementDesigner_Click);
            // 
            // MnuDebugObjectViewer
            // 
            this.MnuDebugObjectViewer.Name = "MnuDebugObjectViewer";
            this.MnuDebugObjectViewer.Size = new System.Drawing.Size(165, 22);
            this.MnuDebugObjectViewer.Text = "Objects viewer";
            this.MnuDebugObjectViewer.Click += new System.EventHandler(this.MnuDebugObjectsViewer_Click);
            // 
            // MnuDebugActionsViewer
            // 
            this.MnuDebugActionsViewer.Name = "MnuDebugActionsViewer";
            this.MnuDebugActionsViewer.Size = new System.Drawing.Size(165, 22);
            this.MnuDebugActionsViewer.Text = "Actions viewer";
            this.MnuDebugActionsViewer.Click += new System.EventHandler(this.MnuDebugActionsViewer_Click);
            // 
            // VsbMain
            // 
            this.VsbMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.VsbMain.Location = new System.Drawing.Point(760, 80);
            this.VsbMain.Name = "VsbMain";
            this.VsbMain.Size = new System.Drawing.Size(17, 369);
            this.VsbMain.TabIndex = 4;
            // 
            // ScBotom
            // 
            this.ScBotom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ScBotom.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ScBotom.Location = new System.Drawing.Point(0, 432);
            this.ScBotom.Name = "ScBotom";
            // 
            // ScBotom.Panel1
            // 
            this.ScBotom.Panel1.Controls.Add(this.HsbMain);
            // 
            // ScBotom.Panel2
            // 
            this.ScBotom.Panel2.Controls.Add(this.LbZoom);
            this.ScBotom.Panel2.Controls.Add(this.LbZoomOut);
            this.ScBotom.Panel2.Controls.Add(this.LbZoomIn);
            this.ScBotom.Size = new System.Drawing.Size(760, 17);
            this.ScBotom.SplitterDistance = 636;
            this.ScBotom.TabIndex = 5;
            // 
            // HsbMain
            // 
            this.HsbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HsbMain.Location = new System.Drawing.Point(0, 0);
            this.HsbMain.Name = "HsbMain";
            this.HsbMain.Size = new System.Drawing.Size(636, 17);
            this.HsbMain.TabIndex = 0;
            // 
            // LbZoom
            // 
            this.LbZoom.BackColor = System.Drawing.Color.White;
            this.LbZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbZoom.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LbZoom.Location = new System.Drawing.Point(17, 0);
            this.LbZoom.Name = "LbZoom";
            this.LbZoom.Size = new System.Drawing.Size(86, 17);
            this.LbZoom.TabIndex = 2;
            this.LbZoom.Text = "100 %";
            this.LbZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LbZoom.Click += new System.EventHandler(this.LbZoom_Click);
            // 
            // LbZoomOut
            // 
            this.LbZoomOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.LbZoomOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LbZoomOut.Location = new System.Drawing.Point(0, 0);
            this.LbZoomOut.Name = "LbZoomOut";
            this.LbZoomOut.Size = new System.Drawing.Size(17, 17);
            this.LbZoomOut.TabIndex = 0;
            this.LbZoomOut.Text = "-";
            this.LbZoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LbZoomOut.Click += new System.EventHandler(this.LbZoomOut_Click);
            this.LbZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbZoom_MouseDown);
            this.LbZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LbZoom_MouseUp);
            // 
            // LbZoomIn
            // 
            this.LbZoomIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.LbZoomIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LbZoomIn.Location = new System.Drawing.Point(103, 0);
            this.LbZoomIn.Name = "LbZoomIn";
            this.LbZoomIn.Size = new System.Drawing.Size(17, 17);
            this.LbZoomIn.TabIndex = 1;
            this.LbZoomIn.Text = "+";
            this.LbZoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LbZoomIn.Click += new System.EventHandler(this.LbZoomIn_Click);
            this.LbZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbZoom_MouseDown);
            this.LbZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LbZoom_MouseUp);
            // 
            // TspExecution
            // 
            this.TspExecution.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TspExecution.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TspExecution.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TspExecution.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnStop,
            this.BtnRun,
            this.BtnCxStep,
            this.BtnNeuronStep,
            this.BtnLayerStep});
            this.TspExecution.Location = new System.Drawing.Point(0, 80);
            this.TspExecution.Name = "TspExecution";
            this.TspExecution.Size = new System.Drawing.Size(760, 56);
            this.TspExecution.TabIndex = 6;
            this.TspExecution.Text = "toolStrip2";
            this.TspExecution.Visible = false;
            // 
            // BtnStop
            // 
            this.BtnStop.Image = global::SimpleAnnPlayground.Properties.Resources.stop_32;
            this.BtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(39, 53);
            this.BtnStop.Text = "Stop";
            this.BtnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnRun
            // 
            this.BtnRun.Image = global::SimpleAnnPlayground.Properties.Resources.start_32;
            this.BtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(36, 53);
            this.BtnRun.Text = "Run";
            this.BtnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnCxStep
            // 
            this.BtnCxStep.Image = global::SimpleAnnPlayground.Properties.Resources.right_step_32;
            this.BtnCxStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCxStep.Name = "BtnCxStep";
            this.BtnCxStep.Size = new System.Drawing.Size(57, 53);
            this.BtnCxStep.Text = "Cx-Step";
            this.BtnCxStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnNeuronStep
            // 
            this.BtnNeuronStep.Image = global::SimpleAnnPlayground.Properties.Resources.right_step_32;
            this.BtnNeuronStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNeuronStep.Name = "BtnNeuronStep";
            this.BtnNeuronStep.Size = new System.Drawing.Size(53, 53);
            this.BtnNeuronStep.Text = "N-Step";
            this.BtnNeuronStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnLayerStep
            // 
            this.BtnLayerStep.Image = global::SimpleAnnPlayground.Properties.Resources.right_32;
            this.BtnLayerStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLayerStep.Name = "BtnLayerStep";
            this.BtnLayerStep.Size = new System.Drawing.Size(49, 53);
            this.BtnLayerStep.Text = "L-Step";
            this.BtnLayerStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 473);
            this.Controls.Add(this.TspExecution);
            this.Controls.Add(this.PicWorkspace);
            this.Controls.Add(this.ScBotom);
            this.Controls.Add(this.VsbMain);
            this.Controls.Add(this.SspStatus);
            this.Controls.Add(this.TspEdition);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "Red Neuronal Artificial Interactiva";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.TspEdition.ResumeLayout(false);
            this.TspEdition.PerformLayout();
            this.SspStatus.ResumeLayout(false);
            this.SspStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicWorkspace)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ScBotom.Panel1.ResumeLayout(false);
            this.ScBotom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScBotom)).EndInit();
            this.ScBotom.ResumeLayout(false);
            this.TspExecution.ResumeLayout(false);
            this.TspExecution.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private ToolStrip TspEdition;
        private ToolStripButton BtnNew;
        private ToolStripButton BtnOpen;
        private ToolStripButton BtnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton BtnInputNeurone;
        private ToolStripButton BtnInternalNeurone;
        private ToolStripButton BtnOutputNeurone;
        private StatusStrip SspStatus;
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
        private ToolStripMenuItem MnuDebugElementDesigner;
        private ToolStripStatusLabel LblMousePosition;
        private ToolStripMenuItem MnuDebugObjectViewer;
        private VScrollBar VsbMain;
        private SplitContainer ScBotom;
        private HScrollBar HsbMain;
        private Label LbZoomIn;
        private Label LbZoomOut;
        private Label LbZoom;
        private ToolStripMenuItem MnuView;
        private ToolStripMenuItem MnuViewCenterScreen;
        private ToolStripMenuItem MnuDebugActionsViewer;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton BtnCheck;
        private ToolStripButton BtnTest;
        private ToolStrip TspExecution;
        private ToolStripButton BtnRun;
        private ToolStripButton BtnStop;
        private ToolStripButton BtnCxStep;
        private ToolStripButton BtnNeuronStep;
        private ToolStripButton BtnLayerStep;
        private ToolStripButton BtnTraining;
    }
}