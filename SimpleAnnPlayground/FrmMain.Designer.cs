using SimpleAnnPlayground.Debugging;

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
                _frmRtfViewer.Dispose();
#endif
                _frmData.Dispose();
                _frmDetails.Dispose();
                _fileManager.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TspEdition = new System.Windows.Forms.ToolStrip();
            this.BtnNew = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnNewEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnNewTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnNewExample = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnOpen = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.TspEditionSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnInputNeurone = new System.Windows.Forms.ToolStripButton();
            this.BtnInternalNeurone = new System.Windows.Forms.ToolStripButton();
            this.BtnOutputNeurone = new System.Windows.Forms.ToolStripButton();
            this.TspEditionSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnCheck = new System.Windows.Forms.ToolStripButton();
            this.BtnClean = new System.Windows.Forms.ToolStripButton();
            this.TspEditionSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnData = new System.Windows.Forms.ToolStripButton();
            this.BtnTraining = new System.Windows.Forms.ToolStripButton();
            this.BtnTest = new System.Windows.Forms.ToolStripButton();
            this.SspStatus = new System.Windows.Forms.StatusStrip();
            this.LblMousePosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbSimulationPhase = new System.Windows.Forms.ToolStripStatusLabel();
            this.PicWorkspace = new System.Windows.Forms.PictureBox();
            this.CmsDraw = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuContextLinkTo = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuContextActivation = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuContextInitBias = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuContextInitWeight = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuContextSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuContextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuContextCut = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuContextPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuContextSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuContextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuContextCenterScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileNewEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileNewTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFileNewExample = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEditSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuEditDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuViewCenterScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuModel = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuModelCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuModelClean = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuModelData = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuModelTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuModelTesting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuModelParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExec = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExecCxStep = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExecNeuronStep = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExecLayerStep = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExecDataStep = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExecBatchStep = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuExecNewEpoch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuExecRun = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExecStop = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuToolsLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebugElementDesigner = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebugObjectViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebugActionsViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebugRtfViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.VsbMain = new System.Windows.Forms.VScrollBar();
            this.ScBotom = new System.Windows.Forms.SplitContainer();
            this.HsbMain = new System.Windows.Forms.HScrollBar();
            this.LbZoom = new System.Windows.Forms.Label();
            this.LbZoomOut = new System.Windows.Forms.Label();
            this.LbZoomIn = new System.Windows.Forms.Label();
            this.TspExecution = new System.Windows.Forms.ToolStrip();
            this.BtnExecData = new System.Windows.Forms.ToolStripButton();
            this.SepExec1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnStop = new System.Windows.Forms.ToolStripButton();
            this.BtnRun = new System.Windows.Forms.ToolStripButton();
            this.SepExec2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnCxStep = new System.Windows.Forms.ToolStripButton();
            this.BtnNeuronStep = new System.Windows.Forms.ToolStripButton();
            this.BtnLayerStep = new System.Windows.Forms.ToolStripButton();
            this.SepExec3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnDataStep = new System.Windows.Forms.ToolStripButton();
            this.LbData = new System.Windows.Forms.ToolStripLabel();
            this.SepExec4 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnBatchStep = new System.Windows.Forms.ToolStripButton();
            this.LbBatch = new System.Windows.Forms.ToolStripLabel();
            this.SepExec5 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnRunEpoch = new System.Windows.Forms.ToolStripButton();
            this.LbEpoch = new System.Windows.Forms.ToolStripLabel();
            this.SepExec6 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnExecTraining = new System.Windows.Forms.ToolStripButton();
            this.BtnExecTest = new System.Windows.Forms.ToolStripButton();
            this.LbTotalError = new System.Windows.Forms.ToolStripLabel();
            this.TtMessages = new System.Windows.Forms.ToolTip(this.components);
            this.TspEdition.SuspendLayout();
            this.SspStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicWorkspace)).BeginInit();
            this.CmsDraw.SuspendLayout();
            this.MenuStrip.SuspendLayout();
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
            this.TspEditionSep1,
            this.BtnInputNeurone,
            this.BtnInternalNeurone,
            this.BtnOutputNeurone,
            this.TspEditionSep2,
            this.BtnCheck,
            this.BtnClean,
            this.TspEditionSep3,
            this.BtnData,
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
            this.BtnNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNewEmpty,
            this.BtnNewTemplate,
            this.toolStripMenuItem4,
            this.BtnNewExample});
            this.BtnNew.Image = global::SimpleAnnPlayground.Properties.Resources.new_32;
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(47, 53);
            this.BtnNew.Text = "New";
            this.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnNewEmpty
            // 
            this.BtnNewEmpty.Image = global::SimpleAnnPlayground.Properties.Resources.new_32;
            this.BtnNewEmpty.Name = "BtnNewEmpty";
            this.BtnNewEmpty.Size = new System.Drawing.Size(196, 38);
            this.BtnNewEmpty.Text = "Empty";
            this.BtnNewEmpty.Click += new System.EventHandler(this.BtnNewEmpty_Click);
            // 
            // BtnNewTemplate
            // 
            this.BtnNewTemplate.Image = global::SimpleAnnPlayground.Properties.Resources.TemplateWindow;
            this.BtnNewTemplate.Name = "BtnNewTemplate";
            this.BtnNewTemplate.Size = new System.Drawing.Size(196, 38);
            this.BtnNewTemplate.Text = "From template";
            this.BtnNewTemplate.Click += new System.EventHandler(this.MnuFileNewTemplate_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(193, 6);
            // 
            // BtnNewExample
            // 
            this.BtnNewExample.Image = global::SimpleAnnPlayground.Properties.Resources.Examples_32;
            this.BtnNewExample.Name = "BtnNewExample";
            this.BtnNewExample.Size = new System.Drawing.Size(196, 38);
            this.BtnNewExample.Text = "Included example";
            // 
            // BtnOpen
            // 
            this.BtnOpen.Image = global::SimpleAnnPlayground.Properties.Resources.open_32;
            this.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(44, 53);
            this.BtnOpen.Text = "Open";
            this.BtnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnOpen.Click += new System.EventHandler(this.MnuFileOpen_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = global::SimpleAnnPlayground.Properties.Resources.save_32;
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(39, 53);
            this.BtnSave.Text = "Save";
            this.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSave.Click += new System.EventHandler(this.MnuFileSave_Click);
            // 
            // TspEditionSep1
            // 
            this.TspEditionSep1.Name = "TspEditionSep1";
            this.TspEditionSep1.Size = new System.Drawing.Size(6, 56);
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
            // TspEditionSep2
            // 
            this.TspEditionSep2.Name = "TspEditionSep2";
            this.TspEditionSep2.Size = new System.Drawing.Size(6, 56);
            // 
            // BtnCheck
            // 
            this.BtnCheck.Image = global::SimpleAnnPlayground.Properties.Resources.check_32;
            this.BtnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCheck.Name = "BtnCheck";
            this.BtnCheck.Size = new System.Drawing.Size(46, 53);
            this.BtnCheck.Text = "Check";
            this.BtnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // BtnClean
            // 
            this.BtnClean.Image = global::SimpleAnnPlayground.Properties.Resources.clear_32;
            this.BtnClean.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnClean.Name = "BtnClean";
            this.BtnClean.Size = new System.Drawing.Size(44, 53);
            this.BtnClean.Text = "Clean";
            this.BtnClean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnClean.Click += new System.EventHandler(this.BtnClean_Click);
            // 
            // TspEditionSep3
            // 
            this.TspEditionSep3.Name = "TspEditionSep3";
            this.TspEditionSep3.Size = new System.Drawing.Size(6, 56);
            // 
            // BtnData
            // 
            this.BtnData.Image = global::SimpleAnnPlayground.Properties.Resources.Data_32;
            this.BtnData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnData.Name = "BtnData";
            this.BtnData.Size = new System.Drawing.Size(39, 53);
            this.BtnData.Text = "Data";
            this.BtnData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnData.Click += new System.EventHandler(this.BtnData_Click);
            // 
            // BtnTraining
            // 
            this.BtnTraining.Enabled = false;
            this.BtnTraining.Image = global::SimpleAnnPlayground.Properties.Resources.training_32;
            this.BtnTraining.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnTraining.Name = "BtnTraining";
            this.BtnTraining.Size = new System.Drawing.Size(58, 53);
            this.BtnTraining.Text = "Training";
            this.BtnTraining.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnTraining.Click += new System.EventHandler(this.BtnTraining_Click);
            // 
            // BtnTest
            // 
            this.BtnTest.Enabled = false;
            this.BtnTest.Image = global::SimpleAnnPlayground.Properties.Resources.testing_32;
            this.BtnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(53, 53);
            this.BtnTest.Text = "Testing";
            this.BtnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // SspStatus
            // 
            this.SspStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblMousePosition,
            this.LbSimulationPhase});
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
            // LbSimulationPhase
            // 
            this.LbSimulationPhase.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LbSimulationPhase.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LbSimulationPhase.Name = "LbSimulationPhase";
            this.LbSimulationPhase.Size = new System.Drawing.Size(42, 19);
            this.LbSimulationPhase.Text = "Phase";
            this.LbSimulationPhase.Visible = false;
            // 
            // PicWorkspace
            // 
            this.PicWorkspace.BackColor = System.Drawing.Color.DarkGray;
            this.PicWorkspace.ContextMenuStrip = this.CmsDraw;
            this.PicWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicWorkspace.Location = new System.Drawing.Point(0, 136);
            this.PicWorkspace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PicWorkspace.Name = "PicWorkspace";
            this.PicWorkspace.Size = new System.Drawing.Size(760, 296);
            this.PicWorkspace.TabIndex = 2;
            this.PicWorkspace.TabStop = false;
            // 
            // CmsDraw
            // 
            this.CmsDraw.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuContextLinkTo,
            this.MnuContextActivation,
            this.MnuContextInitBias,
            this.MnuContextInitWeight,
            this.MnuContextSep1,
            this.MnuContextCopy,
            this.MnuContextCut,
            this.MnuContextPaste,
            this.MnuContextSep2,
            this.MnuContextDelete,
            this.MnuContextCenterScreen});
            this.CmsDraw.Name = "CmsDraw";
            this.CmsDraw.Size = new System.Drawing.Size(147, 170);
            this.CmsDraw.Opening += new System.ComponentModel.CancelEventHandler(this.CmsDraw_Opening);
            // 
            // MnuContextLinkTo
            // 
            this.MnuContextLinkTo.Name = "MnuContextLinkTo";
            this.MnuContextLinkTo.Size = new System.Drawing.Size(146, 22);
            this.MnuContextLinkTo.Text = "Link to";
            // 
            // MnuContextActivation
            // 
            this.MnuContextActivation.Name = "MnuContextActivation";
            this.MnuContextActivation.Size = new System.Drawing.Size(146, 22);
            this.MnuContextActivation.Text = "Activation";
            // 
            // MnuContextInitBias
            // 
            this.MnuContextInitBias.Name = "MnuContextInitBias";
            this.MnuContextInitBias.Size = new System.Drawing.Size(180, 22);
            this.MnuContextInitBias.Text = "Initial bias";
            this.MnuContextInitBias.Click += new System.EventHandler(this.MnuContextInitBias_Click);
            // 
            // MnuContextInitWeight
            // 
            this.MnuContextInitWeight.Name = "MnuContextInitWeight";
            this.MnuContextInitWeight.Size = new System.Drawing.Size(180, 22);
            this.MnuContextInitWeight.Text = "Initial weight";
            this.MnuContextInitWeight.Click += new System.EventHandler(this.MnuContextInitWeight_Click);
            // 
            // MnuContextSep1
            // 
            this.MnuContextSep1.Name = "MnuContextSep1";
            this.MnuContextSep1.Size = new System.Drawing.Size(143, 6);
            // 
            // MnuContextCopy
            // 
            this.MnuContextCopy.Name = "MnuContextCopy";
            this.MnuContextCopy.ShortcutKeyDisplayString = "Ctrl+C";
            this.MnuContextCopy.Size = new System.Drawing.Size(146, 22);
            this.MnuContextCopy.Text = "Copy";
            this.MnuContextCopy.Click += new System.EventHandler(this.MnuEditCopy_Click);
            // 
            // MnuContextCut
            // 
            this.MnuContextCut.Name = "MnuContextCut";
            this.MnuContextCut.ShortcutKeyDisplayString = "Ctrl+X";
            this.MnuContextCut.Size = new System.Drawing.Size(146, 22);
            this.MnuContextCut.Text = "Cut";
            this.MnuContextCut.Click += new System.EventHandler(this.MnuEditCut_Click);
            // 
            // MnuContextPaste
            // 
            this.MnuContextPaste.Name = "MnuContextPaste";
            this.MnuContextPaste.ShortcutKeyDisplayString = "Ctrl+V";
            this.MnuContextPaste.Size = new System.Drawing.Size(146, 22);
            this.MnuContextPaste.Text = "Paste";
            this.MnuContextPaste.Click += new System.EventHandler(this.MnuEditPaste_Click);
            // 
            // MnuContextSep2
            // 
            this.MnuContextSep2.Name = "MnuContextSep2";
            this.MnuContextSep2.Size = new System.Drawing.Size(143, 6);
            // 
            // MnuContextDelete
            // 
            this.MnuContextDelete.Name = "MnuContextDelete";
            this.MnuContextDelete.ShortcutKeyDisplayString = "Del";
            this.MnuContextDelete.Size = new System.Drawing.Size(146, 22);
            this.MnuContextDelete.Text = "Delete";
            this.MnuContextDelete.Click += new System.EventHandler(this.MnuEditDelete_Click);
            // 
            // MnuContextCenterScreen
            // 
            this.MnuContextCenterScreen.Name = "MnuContextCenterScreen";
            this.MnuContextCenterScreen.Size = new System.Drawing.Size(146, 22);
            this.MnuContextCenterScreen.Text = "Center screen";
            this.MnuContextCenterScreen.Click += new System.EventHandler(this.MnuViewCenterScreen_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFile,
            this.MnuEdit,
            this.MnuView,
            this.MnuModel,
            this.MnuExec,
            this.MnuTools,
            this.MnuHelp,
            this.MnuDebug});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(777, 24);
            this.MenuStrip.TabIndex = 3;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // MnuFile
            // 
            this.MnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFileNew,
            this.MnuFileOpen,
            this.MnuFileSep1,
            this.MnuFileSave,
            this.MnuFileSaveAs,
            this.MnuFileSep2,
            this.MnuFileExit});
            this.MnuFile.Name = "MnuFile";
            this.MnuFile.Size = new System.Drawing.Size(37, 20);
            this.MnuFile.Text = "File";
            // 
            // MnuFileNew
            // 
            this.MnuFileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFileNewEmpty,
            this.MnuFileNewTemplate,
            this.toolStripMenuItem3,
            this.MnuFileNewExample});
            this.MnuFileNew.Name = "MnuFileNew";
            this.MnuFileNew.Size = new System.Drawing.Size(146, 22);
            this.MnuFileNew.Text = "New";
            // 
            // MnuFileNewEmpty
            // 
            this.MnuFileNewEmpty.Name = "MnuFileNewEmpty";
            this.MnuFileNewEmpty.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MnuFileNewEmpty.Size = new System.Drawing.Size(168, 22);
            this.MnuFileNewEmpty.Text = "Empty";
            this.MnuFileNewEmpty.Click += new System.EventHandler(this.MnuFileNew_Click);
            // 
            // MnuFileNewTemplate
            // 
            this.MnuFileNewTemplate.Name = "MnuFileNewTemplate";
            this.MnuFileNewTemplate.Size = new System.Drawing.Size(168, 22);
            this.MnuFileNewTemplate.Text = "From template";
            this.MnuFileNewTemplate.Click += new System.EventHandler(this.MnuFileNewTemplate_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(165, 6);
            // 
            // MnuFileNewExample
            // 
            this.MnuFileNewExample.Name = "MnuFileNewExample";
            this.MnuFileNewExample.Size = new System.Drawing.Size(168, 22);
            this.MnuFileNewExample.Text = "Included example";
            // 
            // MnuFileOpen
            // 
            this.MnuFileOpen.Name = "MnuFileOpen";
            this.MnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MnuFileOpen.Size = new System.Drawing.Size(146, 22);
            this.MnuFileOpen.Text = "Open";
            this.MnuFileOpen.Click += new System.EventHandler(this.MnuFileOpen_Click);
            // 
            // MnuFileSep1
            // 
            this.MnuFileSep1.Name = "MnuFileSep1";
            this.MnuFileSep1.Size = new System.Drawing.Size(143, 6);
            // 
            // MnuFileSave
            // 
            this.MnuFileSave.Name = "MnuFileSave";
            this.MnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MnuFileSave.Size = new System.Drawing.Size(146, 22);
            this.MnuFileSave.Text = "Save";
            this.MnuFileSave.Click += new System.EventHandler(this.MnuFileSave_Click);
            // 
            // MnuFileSaveAs
            // 
            this.MnuFileSaveAs.Name = "MnuFileSaveAs";
            this.MnuFileSaveAs.Size = new System.Drawing.Size(146, 22);
            this.MnuFileSaveAs.Text = "Save As";
            this.MnuFileSaveAs.Click += new System.EventHandler(this.MnuFileSaveAs_Click);
            // 
            // MnuFileSep2
            // 
            this.MnuFileSep2.Name = "MnuFileSep2";
            this.MnuFileSep2.Size = new System.Drawing.Size(143, 6);
            // 
            // MnuFileExit
            // 
            this.MnuFileExit.Name = "MnuFileExit";
            this.MnuFileExit.Size = new System.Drawing.Size(146, 22);
            this.MnuFileExit.Text = "Exit";
            // 
            // MnuEdit
            // 
            this.MnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuEditUndo,
            this.MnuEditRedo,
            this.MnuEditSep1,
            this.MnuEditDelete,
            this.MnuEditCopy,
            this.MnuEditCut,
            this.MnuEditPaste,
            this.MnuEditSep2,
            this.MnuEditDocument});
            this.MnuEdit.Name = "MnuEdit";
            this.MnuEdit.Size = new System.Drawing.Size(39, 20);
            this.MnuEdit.Text = "Edit";
            // 
            // MnuEditUndo
            // 
            this.MnuEditUndo.Enabled = false;
            this.MnuEditUndo.Name = "MnuEditUndo";
            this.MnuEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.MnuEditUndo.Size = new System.Drawing.Size(173, 22);
            this.MnuEditUndo.Text = "Undo";
            this.MnuEditUndo.Click += new System.EventHandler(this.MnuEditUndo_Click);
            // 
            // MnuEditRedo
            // 
            this.MnuEditRedo.Enabled = false;
            this.MnuEditRedo.Name = "MnuEditRedo";
            this.MnuEditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.MnuEditRedo.Size = new System.Drawing.Size(173, 22);
            this.MnuEditRedo.Text = "Redo";
            this.MnuEditRedo.Click += new System.EventHandler(this.MnuEditRedo_Click);
            // 
            // MnuEditSep1
            // 
            this.MnuEditSep1.Name = "MnuEditSep1";
            this.MnuEditSep1.Size = new System.Drawing.Size(170, 6);
            // 
            // MnuEditDelete
            // 
            this.MnuEditDelete.Enabled = false;
            this.MnuEditDelete.Name = "MnuEditDelete";
            this.MnuEditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.MnuEditDelete.Size = new System.Drawing.Size(173, 22);
            this.MnuEditDelete.Text = "Delete";
            this.MnuEditDelete.Click += new System.EventHandler(this.MnuEditDelete_Click);
            // 
            // MnuEditCopy
            // 
            this.MnuEditCopy.Enabled = false;
            this.MnuEditCopy.Name = "MnuEditCopy";
            this.MnuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MnuEditCopy.Size = new System.Drawing.Size(173, 22);
            this.MnuEditCopy.Text = "Copy";
            this.MnuEditCopy.Click += new System.EventHandler(this.MnuEditCopy_Click);
            // 
            // MnuEditCut
            // 
            this.MnuEditCut.Enabled = false;
            this.MnuEditCut.Name = "MnuEditCut";
            this.MnuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.MnuEditCut.Size = new System.Drawing.Size(173, 22);
            this.MnuEditCut.Text = "Cut";
            this.MnuEditCut.Click += new System.EventHandler(this.MnuEditCut_Click);
            // 
            // MnuEditPaste
            // 
            this.MnuEditPaste.Enabled = false;
            this.MnuEditPaste.Name = "MnuEditPaste";
            this.MnuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.MnuEditPaste.Size = new System.Drawing.Size(173, 22);
            this.MnuEditPaste.Text = "Paste";
            this.MnuEditPaste.Click += new System.EventHandler(this.MnuEditPaste_Click);
            // 
            // MnuEditSep2
            // 
            this.MnuEditSep2.Name = "MnuEditSep2";
            this.MnuEditSep2.Size = new System.Drawing.Size(170, 6);
            // 
            // MnuEditDocument
            // 
            this.MnuEditDocument.Name = "MnuEditDocument";
            this.MnuEditDocument.Size = new System.Drawing.Size(173, 22);
            this.MnuEditDocument.Text = "Document options";
            this.MnuEditDocument.Click += new System.EventHandler(this.MnuEditDocument_Click);
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
            // MnuModel
            // 
            this.MnuModel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuModelCheck,
            this.MnuModelClean,
            this.toolStripMenuItem2,
            this.MnuModelData,
            this.MnuModelTraining,
            this.MnuModelTesting,
            this.toolStripMenuItem5,
            this.MnuModelParameters});
            this.MnuModel.Name = "MnuModel";
            this.MnuModel.Size = new System.Drawing.Size(53, 20);
            this.MnuModel.Text = "Model";
            // 
            // MnuModelCheck
            // 
            this.MnuModelCheck.Name = "MnuModelCheck";
            this.MnuModelCheck.Size = new System.Drawing.Size(158, 22);
            this.MnuModelCheck.Text = "Check";
            this.MnuModelCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // MnuModelClean
            // 
            this.MnuModelClean.Name = "MnuModelClean";
            this.MnuModelClean.Size = new System.Drawing.Size(158, 22);
            this.MnuModelClean.Text = "Clean messages";
            this.MnuModelClean.Click += new System.EventHandler(this.BtnClean_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 6);
            // 
            // MnuModelData
            // 
            this.MnuModelData.Name = "MnuModelData";
            this.MnuModelData.Size = new System.Drawing.Size(158, 22);
            this.MnuModelData.Text = "Data";
            this.MnuModelData.Click += new System.EventHandler(this.BtnData_Click);
            // 
            // MnuModelTraining
            // 
            this.MnuModelTraining.Name = "MnuModelTraining";
            this.MnuModelTraining.Size = new System.Drawing.Size(158, 22);
            this.MnuModelTraining.Text = "Training";
            this.MnuModelTraining.Click += new System.EventHandler(this.BtnTraining_Click);
            // 
            // MnuModelTesting
            // 
            this.MnuModelTesting.Name = "MnuModelTesting";
            this.MnuModelTesting.Size = new System.Drawing.Size(158, 22);
            this.MnuModelTesting.Text = "Testing";
            this.MnuModelTesting.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(155, 6);
            // 
            // MnuModelParameters
            // 
            this.MnuModelParameters.Name = "MnuModelParameters";
            this.MnuModelParameters.Size = new System.Drawing.Size(158, 22);
            this.MnuModelParameters.Text = "Parameters";
            this.MnuModelParameters.Click += new System.EventHandler(this.MnuModelParameters_Click);
            // 
            // MnuExec
            // 
            this.MnuExec.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuExecCxStep,
            this.MnuExecNeuronStep,
            this.MnuExecLayerStep,
            this.MnuExecDataStep,
            this.MnuExecBatchStep,
            this.toolStripMenuItem1,
            this.MnuExecNewEpoch,
            this.toolStripMenuItem6,
            this.MnuExecRun,
            this.MnuExecStop});
            this.MnuExec.Name = "MnuExec";
            this.MnuExec.Size = new System.Drawing.Size(71, 20);
            this.MnuExec.Text = "Execution";
            this.MnuExec.Visible = false;
            // 
            // MnuExecCxStep
            // 
            this.MnuExecCxStep.Name = "MnuExecCxStep";
            this.MnuExecCxStep.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MnuExecCxStep.Size = new System.Drawing.Size(181, 22);
            this.MnuExecCxStep.Text = "Connection Step";
            this.MnuExecCxStep.Click += new System.EventHandler(this.BtnCxStep_Click);
            // 
            // MnuExecNeuronStep
            // 
            this.MnuExecNeuronStep.Name = "MnuExecNeuronStep";
            this.MnuExecNeuronStep.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.MnuExecNeuronStep.Size = new System.Drawing.Size(181, 22);
            this.MnuExecNeuronStep.Text = "Neuron Step";
            this.MnuExecNeuronStep.Click += new System.EventHandler(this.BtnNeuronStep_Click);
            // 
            // MnuExecLayerStep
            // 
            this.MnuExecLayerStep.Name = "MnuExecLayerStep";
            this.MnuExecLayerStep.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.MnuExecLayerStep.Size = new System.Drawing.Size(181, 22);
            this.MnuExecLayerStep.Text = "Layer Step";
            this.MnuExecLayerStep.Click += new System.EventHandler(this.BtnLayerStep_Click);
            // 
            // MnuExecDataStep
            // 
            this.MnuExecDataStep.Name = "MnuExecDataStep";
            this.MnuExecDataStep.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.MnuExecDataStep.Size = new System.Drawing.Size(181, 22);
            this.MnuExecDataStep.Text = "Data Step";
            this.MnuExecDataStep.Click += new System.EventHandler(this.BtnDataStep_Click);
            // 
            // MnuExecBatchStep
            // 
            this.MnuExecBatchStep.Name = "MnuExecBatchStep";
            this.MnuExecBatchStep.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.MnuExecBatchStep.Size = new System.Drawing.Size(181, 22);
            this.MnuExecBatchStep.Text = "Batch Step";
            this.MnuExecBatchStep.Click += new System.EventHandler(this.BtnBatchStep_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // MnuExecNewEpoch
            // 
            this.MnuExecNewEpoch.Enabled = false;
            this.MnuExecNewEpoch.Name = "MnuExecNewEpoch";
            this.MnuExecNewEpoch.Size = new System.Drawing.Size(181, 22);
            this.MnuExecNewEpoch.Text = "New Epoch";
            this.MnuExecNewEpoch.Click += new System.EventHandler(this.BtnRunEpoch_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(178, 6);
            // 
            // MnuExecRun
            // 
            this.MnuExecRun.Name = "MnuExecRun";
            this.MnuExecRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.MnuExecRun.Size = new System.Drawing.Size(181, 22);
            this.MnuExecRun.Text = "Run";
            this.MnuExecRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // MnuExecStop
            // 
            this.MnuExecStop.Name = "MnuExecStop";
            this.MnuExecStop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.MnuExecStop.Size = new System.Drawing.Size(181, 22);
            this.MnuExecStop.Text = "Stop";
            this.MnuExecStop.Click += new System.EventHandler(this.BtnStop_Click);
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
            this.MnuDebugActionsViewer,
            this.MnuDebugRtfViewer});
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
            // MnuDebugRtfViewer
            // 
            this.MnuDebugRtfViewer.Name = "MnuDebugRtfViewer";
            this.MnuDebugRtfViewer.Size = new System.Drawing.Size(165, 22);
            this.MnuDebugRtfViewer.Text = "Rtf viewer";
            this.MnuDebugRtfViewer.Click += new System.EventHandler(this.MnuDebugRtfViewer_Click);
            // 
            // VsbMain
            // 
            this.VsbMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.VsbMain.Location = new System.Drawing.Point(760, 136);
            this.VsbMain.Name = "VsbMain";
            this.VsbMain.Size = new System.Drawing.Size(17, 313);
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
            this.BtnExecData,
            this.SepExec1,
            this.BtnStop,
            this.BtnRun,
            this.SepExec2,
            this.BtnCxStep,
            this.BtnNeuronStep,
            this.BtnLayerStep,
            this.SepExec3,
            this.BtnDataStep,
            this.LbData,
            this.SepExec4,
            this.BtnBatchStep,
            this.LbBatch,
            this.SepExec5,
            this.BtnRunEpoch,
            this.LbEpoch,
            this.SepExec6,
            this.BtnExecTraining,
            this.BtnExecTest,
            this.LbTotalError});
            this.TspExecution.Location = new System.Drawing.Point(0, 80);
            this.TspExecution.Name = "TspExecution";
            this.TspExecution.Size = new System.Drawing.Size(777, 56);
            this.TspExecution.TabIndex = 6;
            this.TspExecution.Text = "toolStrip2";
            // 
            // BtnExecData
            // 
            this.BtnExecData.Image = global::SimpleAnnPlayground.Properties.Resources.Data_32;
            this.BtnExecData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExecData.Name = "BtnExecData";
            this.BtnExecData.Size = new System.Drawing.Size(39, 53);
            this.BtnExecData.Text = "Data";
            this.BtnExecData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnExecData.Click += new System.EventHandler(this.BtnData_Click);
            // 
            // SepExec1
            // 
            this.SepExec1.Name = "SepExec1";
            this.SepExec1.Size = new System.Drawing.Size(6, 56);
            // 
            // BtnStop
            // 
            this.BtnStop.Image = global::SimpleAnnPlayground.Properties.Resources.stop_32;
            this.BtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(39, 53);
            this.BtnStop.Text = "Stop";
            this.BtnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnRun
            // 
            this.BtnRun.Image = global::SimpleAnnPlayground.Properties.Resources.start_32;
            this.BtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(36, 53);
            this.BtnRun.Text = "Run";
            this.BtnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // SepExec2
            // 
            this.SepExec2.Name = "SepExec2";
            this.SepExec2.Size = new System.Drawing.Size(6, 56);
            // 
            // BtnCxStep
            // 
            this.BtnCxStep.Image = global::SimpleAnnPlayground.Properties.Resources.right_step_32;
            this.BtnCxStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCxStep.Name = "BtnCxStep";
            this.BtnCxStep.Size = new System.Drawing.Size(57, 53);
            this.BtnCxStep.Text = "Cx-Step";
            this.BtnCxStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnCxStep.ToolTipText = "Connection Step";
            this.BtnCxStep.Click += new System.EventHandler(this.BtnCxStep_Click);
            // 
            // BtnNeuronStep
            // 
            this.BtnNeuronStep.Image = global::SimpleAnnPlayground.Properties.Resources.right_step_32;
            this.BtnNeuronStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNeuronStep.Name = "BtnNeuronStep";
            this.BtnNeuronStep.Size = new System.Drawing.Size(53, 53);
            this.BtnNeuronStep.Text = "N-Step";
            this.BtnNeuronStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnNeuronStep.ToolTipText = "Neuron Step";
            this.BtnNeuronStep.Click += new System.EventHandler(this.BtnNeuronStep_Click);
            // 
            // BtnLayerStep
            // 
            this.BtnLayerStep.Image = global::SimpleAnnPlayground.Properties.Resources.right_32;
            this.BtnLayerStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLayerStep.Name = "BtnLayerStep";
            this.BtnLayerStep.Size = new System.Drawing.Size(49, 53);
            this.BtnLayerStep.Text = "L-Step";
            this.BtnLayerStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnLayerStep.ToolTipText = "Layer Step";
            this.BtnLayerStep.Click += new System.EventHandler(this.BtnLayerStep_Click);
            // 
            // SepExec3
            // 
            this.SepExec3.Name = "SepExec3";
            this.SepExec3.Size = new System.Drawing.Size(6, 56);
            // 
            // BtnDataStep
            // 
            this.BtnDataStep.Image = global::SimpleAnnPlayground.Properties.Resources.right_32;
            this.BtnDataStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDataStep.Name = "BtnDataStep";
            this.BtnDataStep.Size = new System.Drawing.Size(52, 53);
            this.BtnDataStep.Text = "D-Step";
            this.BtnDataStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnDataStep.ToolTipText = "Data Register Step";
            this.BtnDataStep.Click += new System.EventHandler(this.BtnDataStep_Click);
            // 
            // LbData
            // 
            this.LbData.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LbData.ForeColor = System.Drawing.Color.Blue;
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(37, 53);
            this.LbData.Text = "Data\n0";
            // 
            // SepExec4
            // 
            this.SepExec4.Name = "SepExec4";
            this.SepExec4.Size = new System.Drawing.Size(6, 56);
            // 
            // BtnBatchStep
            // 
            this.BtnBatchStep.Image = global::SimpleAnnPlayground.Properties.Resources.run_32;
            this.BtnBatchStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnBatchStep.Name = "BtnBatchStep";
            this.BtnBatchStep.Size = new System.Drawing.Size(69, 53);
            this.BtnBatchStep.Text = "Run Batch";
            this.BtnBatchStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBatchStep.ToolTipText = "Batch Step";
            this.BtnBatchStep.Click += new System.EventHandler(this.BtnBatchStep_Click);
            // 
            // LbBatch
            // 
            this.LbBatch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LbBatch.ForeColor = System.Drawing.Color.Blue;
            this.LbBatch.Name = "LbBatch";
            this.LbBatch.Size = new System.Drawing.Size(42, 53);
            this.LbBatch.Text = "Batch\n0";
            // 
            // SepExec5
            // 
            this.SepExec5.Name = "SepExec5";
            this.SepExec5.Size = new System.Drawing.Size(6, 56);
            // 
            // BtnRunEpoch
            // 
            this.BtnRunEpoch.Image = global::SimpleAnnPlayground.Properties.Resources.run_32;
            this.BtnRunEpoch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRunEpoch.Name = "BtnRunEpoch";
            this.BtnRunEpoch.Size = new System.Drawing.Size(74, 53);
            this.BtnRunEpoch.Text = "Run Epoch";
            this.BtnRunEpoch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnRunEpoch.ToolTipText = "Run Epoch";
            this.BtnRunEpoch.Click += new System.EventHandler(this.BtnRunEpoch_Click);
            // 
            // LbEpoch
            // 
            this.LbEpoch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LbEpoch.ForeColor = System.Drawing.Color.Blue;
            this.LbEpoch.Name = "LbEpoch";
            this.LbEpoch.Size = new System.Drawing.Size(45, 53);
            this.LbEpoch.Text = "Epoch\n0";
            // 
            // SepExec6
            // 
            this.SepExec6.Name = "SepExec6";
            this.SepExec6.Size = new System.Drawing.Size(6, 56);
            // 
            // BtnExecTraining
            // 
            this.BtnExecTraining.Image = global::SimpleAnnPlayground.Properties.Resources.training_32;
            this.BtnExecTraining.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExecTraining.Name = "BtnExecTraining";
            this.BtnExecTraining.Size = new System.Drawing.Size(58, 53);
            this.BtnExecTraining.Text = "Training";
            this.BtnExecTraining.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnExecTraining.Click += new System.EventHandler(this.BtnExecTraining_Click);
            // 
            // BtnExecTest
            // 
            this.BtnExecTest.Enabled = false;
            this.BtnExecTest.Image = global::SimpleAnnPlayground.Properties.Resources.testing_32;
            this.BtnExecTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExecTest.Name = "BtnExecTest";
            this.BtnExecTest.Size = new System.Drawing.Size(53, 53);
            this.BtnExecTest.Text = "Testing";
            this.BtnExecTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnExecTest.Click += new System.EventHandler(this.BtnExecTest_Click);
            // 
            // LbTotalError
            // 
            this.LbTotalError.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LbTotalError.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LbTotalError.ForeColor = System.Drawing.Color.Red;
            this.LbTotalError.Name = "LbTotalError";
            this.LbTotalError.Size = new System.Drawing.Size(107, 17);
            this.LbTotalError.Text = "Total Error: 0.25";
            this.LbTotalError.Visible = false;
            // 
            // TtMessages
            // 
            this.TtMessages.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 473);
            this.Controls.Add(this.PicWorkspace);
            this.Controls.Add(this.ScBotom);
            this.Controls.Add(this.VsbMain);
            this.Controls.Add(this.SspStatus);
            this.Controls.Add(this.TspExecution);
            this.Controls.Add(this.TspEdition);
            this.Controls.Add(this.MenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
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
            this.CmsDraw.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
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
        private ToolStripButton BtnOpen;
        private ToolStripButton BtnSave;
        private ToolStripSeparator TspEditionSep1;
        private ToolStripButton BtnInputNeurone;
        private ToolStripButton BtnInternalNeurone;
        private ToolStripButton BtnOutputNeurone;
        private StatusStrip SspStatus;
        private PictureBox PicWorkspace;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem MnuFile;
        private ToolStripMenuItem MnuFileNew;
        private ToolStripMenuItem MnuFileOpen;
        private ToolStripSeparator MnuFileSep1;
        private ToolStripMenuItem MnuFileSave;
        private ToolStripMenuItem MnuFileSaveAs;
        private ToolStripSeparator MnuFileSep2;
        private ToolStripMenuItem MnuFileExit;
        private ToolStripMenuItem MnuEdit;
        private ToolStripMenuItem MnuEditUndo;
        private ToolStripMenuItem MnuEditRedo;
        private ToolStripSeparator MnuEditSep1;
        private ToolStripMenuItem MnuEditDelete;
        private ToolStripMenuItem MnuEditCopy;
        private ToolStripMenuItem MnuEditCut;
        private ToolStripMenuItem MnuEditPaste;
        private ToolStripSeparator MnuEditSep2;
        private ToolStripMenuItem MnuEditDocument;
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
        private ToolStripSeparator TspEditionSep2;
        private ToolStripButton BtnCheck;
        private ToolStripButton BtnTest;
        private ToolStrip TspExecution;
        private ToolStripButton BtnRun;
        private ToolStripButton BtnStop;
        private ToolStripButton BtnCxStep;
        private ToolStripButton BtnNeuronStep;
        private ToolStripButton BtnLayerStep;
        private ToolStripButton BtnTraining;
        private ToolStripButton BtnData;
        private ToolStripButton BtnClean;
        private ToolStripSeparator TspEditionSep3;
        private ContextMenuStrip CmsDraw;
        private ToolStripMenuItem MnuContextLinkTo;
        private ToolStripSeparator MnuContextSep1;
        private ToolStripMenuItem MnuContextCopy;
        private ToolStripMenuItem MnuContextCut;
        private ToolStripMenuItem MnuContextPaste;
        private ToolStripSeparator MnuContextSep2;
        private ToolStripMenuItem MnuContextDelete;
        private ToolStripMenuItem MnuContextCenterScreen;
        private ToolTip TtMessages;
        private ToolStripMenuItem MnuContextActivation;
        private ToolStripMenuItem MnuModel;
        private ToolStripMenuItem MnuModelCheck;
        private ToolStripMenuItem MnuModelClean;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem MnuModelData;
        private ToolStripMenuItem MnuModelTraining;
        private ToolStripMenuItem MnuModelTesting;
        private ToolStripMenuItem MnuExec;
        private ToolStripMenuItem MnuExecCxStep;
        private ToolStripMenuItem MnuExecNeuronStep;
        private ToolStripMenuItem MnuExecLayerStep;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem MnuExecRun;
        private ToolStripMenuItem MnuExecStop;
        private ToolStripStatusLabel LbSimulationPhase;
        private ToolStripButton BtnExecData;
        private ToolStripSeparator SepExec1;
        private ToolStripSeparator SepExec2;
        private ToolStripButton BtnDataStep;
        private ToolStripButton BtnBatchStep;
        private ToolStripMenuItem MnuDebugRtfViewer;
        private ToolStripMenuItem MnuFileNewEmpty;
        private ToolStripMenuItem MnuFileNewTemplate;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem MnuFileNewExample;
        private ToolStripDropDownButton BtnNew;
        private ToolStripMenuItem BtnNewEmpty;
        private ToolStripMenuItem BtnNewTemplate;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem BtnNewExample;
        private ToolStripMenuItem MnuExecDataStep;
        private ToolStripMenuItem MnuExecBatchStep;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem MnuModelParameters;
        private ToolStripMenuItem MnuExecNewEpoch;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripSeparator SepExec3;
        private ToolStripButton BtnRunEpoch;
        private ToolStripButton BtnExecTest;
        private ToolStripLabel LbTotalError;
        private ToolStripLabel LbEpoch;
        private ToolStripSeparator SepExec4;
        private ToolStripButton BtnExecTraining;
        private ToolStripSeparator SepExec5;
        private ToolStripLabel LbBatch;
        private ToolStripLabel LbData;
        private ToolStripSeparator SepExec6;
        private ToolStripMenuItem MnuContextInitBias;
        private ToolStripMenuItem MnuContextInitWeight;
    }
}