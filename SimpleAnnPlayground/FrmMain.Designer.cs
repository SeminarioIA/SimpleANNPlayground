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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnOpen = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnInputNeurone = new System.Windows.Forms.ToolStripButton();
            this.BtnInternalNeurone = new System.Windows.Forms.ToolStripButton();
            this.BtnOutputNeurone = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
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
            this.BtnInputNeurone.Image = ((System.Drawing.Image)(resources.GetObject("BtnInputNeurone.Image")));
            this.BtnInputNeurone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnInputNeurone.Name = "BtnInputNeurone";
            this.BtnInputNeurone.Size = new System.Drawing.Size(41, 53);
            this.BtnInputNeurone.Text = "Input";
            this.BtnInputNeurone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnInternalNeurone
            // 
            this.BtnInternalNeurone.Image = ((System.Drawing.Image)(resources.GetObject("BtnInternalNeurone.Image")));
            this.BtnInternalNeurone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnInternalNeurone.Name = "BtnInternalNeurone";
            this.BtnInternalNeurone.Size = new System.Drawing.Size(55, 53);
            this.BtnInternalNeurone.Text = "Internal";
            this.BtnInternalNeurone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BtnOutputNeurone
            // 
            this.BtnOutputNeurone.Image = ((System.Drawing.Image)(resources.GetObject("BtnOutputNeurone.Image")));
            this.BtnOutputNeurone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOutputNeurone.Name = "BtnOutputNeurone";
            this.BtnOutputNeurone.Size = new System.Drawing.Size(52, 53);
            this.BtnOutputNeurone.Text = "Output";
            this.BtnOutputNeurone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 56);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(777, 395);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 473);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "Red Neuronal Artificial Interactiva";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private PictureBox pictureBox1;
    }
}