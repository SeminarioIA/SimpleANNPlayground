namespace SimpleAnnPlayground.Debugging
{
    partial class FrmElementDesigner
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
            this.SpcMain = new System.Windows.Forms.SplitContainer();
            this.PicDraw = new System.Windows.Forms.PictureBox();
            this.HscDraw = new System.Windows.Forms.HScrollBar();
            this.VscDraw = new System.Windows.Forms.VScrollBar();
            this.SpcElements = new System.Windows.Forms.SplitContainer();
            this.ClbElements = new System.Windows.Forms.CheckedListBox();
            this.PgdProperties = new System.Windows.Forms.PropertyGrid();
            this.TstElements = new System.Windows.Forms.ToolStrip();
            this.BtnAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnUp = new System.Windows.Forms.ToolStripButton();
            this.BtnDown = new System.Windows.Forms.ToolStripButton();
            this.TstButtons = new System.Windows.Forms.ToolStrip();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnOpen = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.BtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.StsBar = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.SpcMain)).BeginInit();
            this.SpcMain.Panel1.SuspendLayout();
            this.SpcMain.Panel2.SuspendLayout();
            this.SpcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicDraw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpcElements)).BeginInit();
            this.SpcElements.Panel1.SuspendLayout();
            this.SpcElements.Panel2.SuspendLayout();
            this.SpcElements.SuspendLayout();
            this.TstElements.SuspendLayout();
            this.TstButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpcMain
            // 
            this.SpcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SpcMain.Location = new System.Drawing.Point(0, 31);
            this.SpcMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpcMain.Name = "SpcMain";
            // 
            // SpcMain.Panel1
            // 
            this.SpcMain.Panel1.Controls.Add(this.PicDraw);
            this.SpcMain.Panel1.Controls.Add(this.HscDraw);
            this.SpcMain.Panel1.Controls.Add(this.VscDraw);
            // 
            // SpcMain.Panel2
            // 
            this.SpcMain.Panel2.Controls.Add(this.SpcElements);
            this.SpcMain.Panel2.Controls.Add(this.TstElements);
            this.SpcMain.Size = new System.Drawing.Size(1105, 440);
            this.SpcMain.SplitterDistance = 466;
            this.SpcMain.SplitterWidth = 5;
            this.SpcMain.TabIndex = 0;
            // 
            // PicDraw
            // 
            this.PicDraw.BackColor = System.Drawing.Color.White;
            this.PicDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicDraw.Location = new System.Drawing.Point(0, 0);
            this.PicDraw.Name = "PicDraw";
            this.PicDraw.Size = new System.Drawing.Size(449, 423);
            this.PicDraw.TabIndex = 0;
            this.PicDraw.TabStop = false;
            this.PicDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.PicDraw_Paint);
            // 
            // HscDraw
            // 
            this.HscDraw.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HscDraw.Location = new System.Drawing.Point(0, 423);
            this.HscDraw.Name = "HscDraw";
            this.HscDraw.Size = new System.Drawing.Size(449, 17);
            this.HscDraw.TabIndex = 2;
            // 
            // VscDraw
            // 
            this.VscDraw.Dock = System.Windows.Forms.DockStyle.Right;
            this.VscDraw.Location = new System.Drawing.Point(449, 0);
            this.VscDraw.Name = "VscDraw";
            this.VscDraw.Size = new System.Drawing.Size(17, 440);
            this.VscDraw.TabIndex = 1;
            // 
            // SpcElements
            // 
            this.SpcElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpcElements.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SpcElements.Location = new System.Drawing.Point(38, 0);
            this.SpcElements.Name = "SpcElements";
            // 
            // SpcElements.Panel1
            // 
            this.SpcElements.Panel1.Controls.Add(this.ClbElements);
            // 
            // SpcElements.Panel2
            // 
            this.SpcElements.Panel2.Controls.Add(this.PgdProperties);
            this.SpcElements.Size = new System.Drawing.Size(596, 440);
            this.SpcElements.SplitterDistance = 175;
            this.SpcElements.TabIndex = 2;
            // 
            // ClbElements
            // 
            this.ClbElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClbElements.FormattingEnabled = true;
            this.ClbElements.Location = new System.Drawing.Point(0, 0);
            this.ClbElements.Name = "ClbElements";
            this.ClbElements.Size = new System.Drawing.Size(175, 440);
            this.ClbElements.TabIndex = 0;
            this.ClbElements.UseCompatibleTextRendering = true;
            this.ClbElements.SelectedIndexChanged += new System.EventHandler(this.ClbElements_SelectedIndexChanged);
            this.ClbElements.SelectedValueChanged += new System.EventHandler(this.ClbElements_SelectedValueChanged);
            // 
            // PgdProperties
            // 
            this.PgdProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PgdProperties.Location = new System.Drawing.Point(0, 0);
            this.PgdProperties.Name = "PgdProperties";
            this.PgdProperties.Size = new System.Drawing.Size(417, 440);
            this.PgdProperties.TabIndex = 0;
            this.PgdProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PgdProperties_PropertyValueChanged);
            // 
            // TstElements
            // 
            this.TstElements.Dock = System.Windows.Forms.DockStyle.Left;
            this.TstElements.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TstElements.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TstElements.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAdd,
            this.BtnDelete,
            this.toolStripSeparator1,
            this.BtnUp,
            this.BtnDown});
            this.TstElements.Location = new System.Drawing.Point(0, 0);
            this.TstElements.Name = "TstElements";
            this.TstElements.Size = new System.Drawing.Size(38, 440);
            this.TstElements.TabIndex = 0;
            this.TstElements.Text = "toolStrip1";
            // 
            // BtnAdd
            // 
            this.BtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAdd.Image = global::SimpleAnnPlayground.Properties.Resources.d_add;
            this.BtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(35, 28);
            this.BtnAdd.Text = "Add";
            // 
            // BtnDelete
            // 
            this.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDelete.Enabled = false;
            this.BtnDelete.Image = global::SimpleAnnPlayground.Properties.Resources.d_remove;
            this.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(35, 28);
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(35, 6);
            // 
            // BtnUp
            // 
            this.BtnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnUp.Enabled = false;
            this.BtnUp.Image = global::SimpleAnnPlayground.Properties.Resources.d_up;
            this.BtnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(35, 28);
            this.BtnUp.Text = "Move up";
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // BtnDown
            // 
            this.BtnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDown.Enabled = false;
            this.BtnDown.Image = global::SimpleAnnPlayground.Properties.Resources.d_down;
            this.BtnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(35, 28);
            this.BtnDown.Text = "Move down";
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // TstButtons
            // 
            this.TstButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TstButtons.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TstButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnOpen,
            this.BtnSave,
            this.BtnSaveAs});
            this.TstButtons.Location = new System.Drawing.Point(0, 0);
            this.TstButtons.Name = "TstButtons";
            this.TstButtons.Size = new System.Drawing.Size(1105, 31);
            this.TstButtons.TabIndex = 1;
            this.TstButtons.Text = "toolStrip1";
            // 
            // BtnNew
            // 
            this.BtnNew.Image = global::SimpleAnnPlayground.Properties.Resources.d_new;
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(59, 28);
            this.BtnNew.Text = "New";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Image = global::SimpleAnnPlayground.Properties.Resources.d_open;
            this.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(64, 28);
            this.BtnOpen.Text = "Open";
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = global::SimpleAnnPlayground.Properties.Resources.d_save;
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(59, 28);
            this.BtnSave.Text = "Save";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnSaveAs
            // 
            this.BtnSaveAs.Image = global::SimpleAnnPlayground.Properties.Resources.d_save_as;
            this.BtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSaveAs.Name = "BtnSaveAs";
            this.BtnSaveAs.Size = new System.Drawing.Size(75, 28);
            this.BtnSaveAs.Text = "Save As";
            this.BtnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // StsBar
            // 
            this.StsBar.Location = new System.Drawing.Point(0, 471);
            this.StsBar.Name = "StsBar";
            this.StsBar.Size = new System.Drawing.Size(1105, 22);
            this.StsBar.TabIndex = 2;
            this.StsBar.Text = "statusStrip1";
            // 
            // FrmElementDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 493);
            this.Controls.Add(this.SpcMain);
            this.Controls.Add(this.TstButtons);
            this.Controls.Add(this.StsBar);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmElementDesigner";
            this.Text = "Element Designer";
            this.Load += new System.EventHandler(this.FrmElementDesigner_Load);
            this.SpcMain.Panel1.ResumeLayout(false);
            this.SpcMain.Panel2.ResumeLayout(false);
            this.SpcMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpcMain)).EndInit();
            this.SpcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicDraw)).EndInit();
            this.SpcElements.Panel1.ResumeLayout(false);
            this.SpcElements.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpcElements)).EndInit();
            this.SpcElements.ResumeLayout(false);
            this.TstElements.ResumeLayout(false);
            this.TstElements.PerformLayout();
            this.TstButtons.ResumeLayout(false);
            this.TstButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer SpcMain;
        private PictureBox PicDraw;
        private ToolStrip TstButtons;
        private StatusStrip StsBar;
        private HScrollBar HscDraw;
        private VScrollBar VscDraw;
        private ToolStrip TstElements;
        private ToolStripButton BtnDelete;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton BtnUp;
        private ToolStripButton BtnDown;
        private ToolStripButton BtnNew;
        private ToolStripButton BtnOpen;
        private ToolStripButton BtnSave;
        private ToolStripButton BtnSaveAs;
        private SplitContainer SpcElements;
        private PropertyGrid PgdProperties;
        private ToolStripDropDownButton BtnAdd;
        private CheckedListBox ClbElements;
    }
}