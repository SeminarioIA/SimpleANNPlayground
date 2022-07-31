namespace SimpleAnnPlayground.Debugging
{
    partial class FrmActionsViewer
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
                _transform.Dispose();
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
            this.ScImages = new System.Windows.Forms.SplitContainer();
            this.PicBefore = new System.Windows.Forms.PictureBox();
            this.LbBefore = new System.Windows.Forms.Label();
            this.PicAfter = new System.Windows.Forms.PictureBox();
            this.LbAfter = new System.Windows.Forms.Label();
            this.ScProperties = new System.Windows.Forms.SplitContainer();
            this.ScActions = new System.Windows.Forms.SplitContainer();
            this.LstUndo = new System.Windows.Forms.ListBox();
            this.LbUndo = new System.Windows.Forms.Label();
            this.LstRedo = new System.Windows.Forms.ListBox();
            this.LbRedo = new System.Windows.Forms.Label();
            this.PgdAction = new System.Windows.Forms.PropertyGrid();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LbPos = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
            this.ScMain.Panel1.SuspendLayout();
            this.ScMain.Panel2.SuspendLayout();
            this.ScMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScImages)).BeginInit();
            this.ScImages.Panel1.SuspendLayout();
            this.ScImages.Panel2.SuspendLayout();
            this.ScImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScProperties)).BeginInit();
            this.ScProperties.Panel1.SuspendLayout();
            this.ScProperties.Panel2.SuspendLayout();
            this.ScProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScActions)).BeginInit();
            this.ScActions.Panel1.SuspendLayout();
            this.ScActions.Panel2.SuspendLayout();
            this.ScActions.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScMain
            // 
            this.ScMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScMain.Location = new System.Drawing.Point(0, 0);
            this.ScMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScMain.Name = "ScMain";
            // 
            // ScMain.Panel1
            // 
            this.ScMain.Panel1.Controls.Add(this.ScImages);
            // 
            // ScMain.Panel2
            // 
            this.ScMain.Panel2.Controls.Add(this.ScProperties);
            this.ScMain.Size = new System.Drawing.Size(500, 478);
            this.ScMain.SplitterDistance = 320;
            this.ScMain.SplitterWidth = 5;
            this.ScMain.TabIndex = 0;
            // 
            // ScImages
            // 
            this.ScImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScImages.IsSplitterFixed = true;
            this.ScImages.Location = new System.Drawing.Point(0, 0);
            this.ScImages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScImages.Name = "ScImages";
            this.ScImages.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ScImages.Panel1
            // 
            this.ScImages.Panel1.Controls.Add(this.PicBefore);
            this.ScImages.Panel1.Controls.Add(this.LbBefore);
            // 
            // ScImages.Panel2
            // 
            this.ScImages.Panel2.Controls.Add(this.PicAfter);
            this.ScImages.Panel2.Controls.Add(this.LbAfter);
            this.ScImages.Size = new System.Drawing.Size(320, 478);
            this.ScImages.SplitterDistance = 236;
            this.ScImages.SplitterWidth = 5;
            this.ScImages.TabIndex = 2;
            // 
            // PicBefore
            // 
            this.PicBefore.BackColor = System.Drawing.Color.White;
            this.PicBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBefore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBefore.Location = new System.Drawing.Point(0, 26);
            this.PicBefore.Name = "PicBefore";
            this.PicBefore.Size = new System.Drawing.Size(320, 210);
            this.PicBefore.TabIndex = 0;
            this.PicBefore.TabStop = false;
            this.PicBefore.Paint += new System.Windows.Forms.PaintEventHandler(this.PicBefore_Paint);
            this.PicBefore.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            this.PicBefore.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
            // 
            // LbBefore
            // 
            this.LbBefore.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbBefore.Location = new System.Drawing.Point(0, 0);
            this.LbBefore.Name = "LbBefore";
            this.LbBefore.Size = new System.Drawing.Size(320, 26);
            this.LbBefore.TabIndex = 3;
            this.LbBefore.Text = "Before";
            this.LbBefore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicAfter
            // 
            this.PicAfter.BackColor = System.Drawing.Color.White;
            this.PicAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicAfter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicAfter.Location = new System.Drawing.Point(0, 26);
            this.PicAfter.Name = "PicAfter";
            this.PicAfter.Size = new System.Drawing.Size(320, 211);
            this.PicAfter.TabIndex = 0;
            this.PicAfter.TabStop = false;
            this.PicAfter.Paint += new System.Windows.Forms.PaintEventHandler(this.PicAfter_Paint);
            this.PicAfter.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            this.PicAfter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
            // 
            // LbAfter
            // 
            this.LbAfter.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbAfter.Location = new System.Drawing.Point(0, 0);
            this.LbAfter.Name = "LbAfter";
            this.LbAfter.Size = new System.Drawing.Size(320, 26);
            this.LbAfter.TabIndex = 4;
            this.LbAfter.Text = "After";
            this.LbAfter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScProperties
            // 
            this.ScProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScProperties.Location = new System.Drawing.Point(0, 0);
            this.ScProperties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScProperties.Name = "ScProperties";
            this.ScProperties.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ScProperties.Panel1
            // 
            this.ScProperties.Panel1.Controls.Add(this.ScActions);
            // 
            // ScProperties.Panel2
            // 
            this.ScProperties.Panel2.Controls.Add(this.PgdAction);
            this.ScProperties.Size = new System.Drawing.Size(175, 478);
            this.ScProperties.SplitterDistance = 219;
            this.ScProperties.SplitterWidth = 5;
            this.ScProperties.TabIndex = 5;
            // 
            // ScActions
            // 
            this.ScActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScActions.Location = new System.Drawing.Point(0, 0);
            this.ScActions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScActions.Name = "ScActions";
            this.ScActions.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ScActions.Panel1
            // 
            this.ScActions.Panel1.Controls.Add(this.LstUndo);
            this.ScActions.Panel1.Controls.Add(this.LbUndo);
            // 
            // ScActions.Panel2
            // 
            this.ScActions.Panel2.Controls.Add(this.LstRedo);
            this.ScActions.Panel2.Controls.Add(this.LbRedo);
            this.ScActions.Size = new System.Drawing.Size(175, 219);
            this.ScActions.SplitterDistance = 142;
            this.ScActions.SplitterWidth = 5;
            this.ScActions.TabIndex = 6;
            // 
            // LstUndo
            // 
            this.LstUndo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstUndo.FormattingEnabled = true;
            this.LstUndo.ItemHeight = 20;
            this.LstUndo.Location = new System.Drawing.Point(0, 20);
            this.LstUndo.Name = "LstUndo";
            this.LstUndo.Size = new System.Drawing.Size(175, 122);
            this.LstUndo.TabIndex = 0;
            this.LstUndo.SelectedIndexChanged += new System.EventHandler(this.LstUndo_SelectedIndexChanged);
            // 
            // LbUndo
            // 
            this.LbUndo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbUndo.Location = new System.Drawing.Point(0, 0);
            this.LbUndo.Name = "LbUndo";
            this.LbUndo.Size = new System.Drawing.Size(175, 20);
            this.LbUndo.TabIndex = 1;
            this.LbUndo.Text = "Undo stack";
            this.LbUndo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LstRedo
            // 
            this.LstRedo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstRedo.FormattingEnabled = true;
            this.LstRedo.ItemHeight = 20;
            this.LstRedo.Location = new System.Drawing.Point(0, 20);
            this.LstRedo.Name = "LstRedo";
            this.LstRedo.Size = new System.Drawing.Size(175, 52);
            this.LstRedo.TabIndex = 1;
            this.LstRedo.SelectedIndexChanged += new System.EventHandler(this.LstRedo_SelectedIndexChanged);
            // 
            // LbRedo
            // 
            this.LbRedo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbRedo.Location = new System.Drawing.Point(0, 0);
            this.LbRedo.Name = "LbRedo";
            this.LbRedo.Size = new System.Drawing.Size(175, 20);
            this.LbRedo.TabIndex = 1;
            this.LbRedo.Text = "Redo stack";
            this.LbRedo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PgdAction
            // 
            this.PgdAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PgdAction.Location = new System.Drawing.Point(0, 0);
            this.PgdAction.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PgdAction.Name = "PgdAction";
            this.PgdAction.Size = new System.Drawing.Size(175, 254);
            this.PgdAction.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbPos});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(500, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LbPos
            // 
            this.LbPos.Name = "LbPos";
            this.LbPos.Size = new System.Drawing.Size(49, 17);
            this.LbPos.Text = "X: -, Y: -";
            // 
            // FrmActionsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.ScMain);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmActionsViewer";
            this.Text = "FrmActionsViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmActionsViewer_FormClosing);
            this.Load += new System.EventHandler(this.FrmActionsViewer_Load);
            this.ScMain.Panel1.ResumeLayout(false);
            this.ScMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
            this.ScMain.ResumeLayout(false);
            this.ScImages.Panel1.ResumeLayout(false);
            this.ScImages.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScImages)).EndInit();
            this.ScImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAfter)).EndInit();
            this.ScProperties.Panel1.ResumeLayout(false);
            this.ScProperties.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScProperties)).EndInit();
            this.ScProperties.ResumeLayout(false);
            this.ScActions.Panel1.ResumeLayout(false);
            this.ScActions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScActions)).EndInit();
            this.ScActions.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer ScMain;
        private SplitContainer ScImages;
        private SplitContainer ScProperties;
        private SplitContainer ScActions;
        private ListBox LstUndo;
        private Label LbUndo;
        private ListBox LstRedo;
        private Label LbRedo;
        private PropertyGrid PgdAction;
        private PictureBox PicBefore;
        private Label LbBefore;
        private PictureBox PicAfter;
        private Label LbAfter;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel LbPos;
    }
}