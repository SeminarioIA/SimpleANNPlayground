namespace SimpleAnnPlayground.UI
{
    partial class FrmDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocument));
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.GbSheetSize = new System.Windows.Forms.GroupBox();
            this.TbSheetHeight = new System.Windows.Forms.TextBox();
            this.TbSheetWidth = new System.Windows.Forms.TextBox();
            this.LbSheetHeight = new System.Windows.Forms.Label();
            this.LbSheetWidth = new System.Windows.Forms.Label();
            this.GbCenterCross = new System.Windows.Forms.GroupBox();
            this.PbCrossColor = new System.Windows.Forms.PictureBox();
            this.LbCrossColor = new System.Windows.Forms.Label();
            this.CkCrossVisible = new System.Windows.Forms.CheckBox();
            this.CdCrossColor = new System.Windows.Forms.ColorDialog();
            this.GbSheetSize.SuspendLayout();
            this.GbCenterCross.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbCrossColor)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnApply
            // 
            this.BtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnApply.Location = new System.Drawing.Point(184, 130);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(75, 23);
            this.BtnApply.TabIndex = 0;
            this.BtnApply.Text = "Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(265, 130);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // GbSheetSize
            // 
            this.GbSheetSize.Controls.Add(this.TbSheetHeight);
            this.GbSheetSize.Controls.Add(this.TbSheetWidth);
            this.GbSheetSize.Controls.Add(this.LbSheetHeight);
            this.GbSheetSize.Controls.Add(this.LbSheetWidth);
            this.GbSheetSize.Location = new System.Drawing.Point(12, 12);
            this.GbSheetSize.Name = "GbSheetSize";
            this.GbSheetSize.Size = new System.Drawing.Size(200, 102);
            this.GbSheetSize.TabIndex = 2;
            this.GbSheetSize.TabStop = false;
            this.GbSheetSize.Text = "Sheet size:";
            // 
            // TbSheetHeight
            // 
            this.TbSheetHeight.Location = new System.Drawing.Point(69, 51);
            this.TbSheetHeight.MaxLength = 4;
            this.TbSheetHeight.Name = "TbSheetHeight";
            this.TbSheetHeight.Size = new System.Drawing.Size(100, 23);
            this.TbSheetHeight.TabIndex = 3;
            this.TbSheetHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbSheetHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // TbSheetWidth
            // 
            this.TbSheetWidth.Location = new System.Drawing.Point(69, 22);
            this.TbSheetWidth.MaxLength = 4;
            this.TbSheetWidth.Name = "TbSheetWidth";
            this.TbSheetWidth.Size = new System.Drawing.Size(100, 23);
            this.TbSheetWidth.TabIndex = 2;
            this.TbSheetWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbSheetWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // LbSheetHeight
            // 
            this.LbSheetHeight.AutoSize = true;
            this.LbSheetHeight.Location = new System.Drawing.Point(17, 54);
            this.LbSheetHeight.Name = "LbSheetHeight";
            this.LbSheetHeight.Size = new System.Drawing.Size(46, 15);
            this.LbSheetHeight.TabIndex = 1;
            this.LbSheetHeight.Text = "Height:";
            this.LbSheetHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LbSheetWidth
            // 
            this.LbSheetWidth.AutoSize = true;
            this.LbSheetWidth.Location = new System.Drawing.Point(21, 25);
            this.LbSheetWidth.Name = "LbSheetWidth";
            this.LbSheetWidth.Size = new System.Drawing.Size(42, 15);
            this.LbSheetWidth.TabIndex = 0;
            this.LbSheetWidth.Text = "Width:";
            this.LbSheetWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GbCenterCross
            // 
            this.GbCenterCross.Controls.Add(this.PbCrossColor);
            this.GbCenterCross.Controls.Add(this.LbCrossColor);
            this.GbCenterCross.Controls.Add(this.CkCrossVisible);
            this.GbCenterCross.Location = new System.Drawing.Point(218, 12);
            this.GbCenterCross.Name = "GbCenterCross";
            this.GbCenterCross.Size = new System.Drawing.Size(120, 102);
            this.GbCenterCross.TabIndex = 3;
            this.GbCenterCross.TabStop = false;
            this.GbCenterCross.Text = "Center cross:";
            // 
            // PbCrossColor
            // 
            this.PbCrossColor.BackColor = System.Drawing.Color.Gray;
            this.PbCrossColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbCrossColor.Location = new System.Drawing.Point(62, 51);
            this.PbCrossColor.Name = "PbCrossColor";
            this.PbCrossColor.Size = new System.Drawing.Size(23, 23);
            this.PbCrossColor.TabIndex = 2;
            this.PbCrossColor.TabStop = false;
            this.PbCrossColor.Click += new System.EventHandler(this.PbCrossColor_Click);
            // 
            // LbCrossColor
            // 
            this.LbCrossColor.AutoSize = true;
            this.LbCrossColor.Location = new System.Drawing.Point(17, 54);
            this.LbCrossColor.Name = "LbCrossColor";
            this.LbCrossColor.Size = new System.Drawing.Size(39, 15);
            this.LbCrossColor.TabIndex = 1;
            this.LbCrossColor.Text = "Color:";
            this.LbCrossColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CkCrossVisible
            // 
            this.CkCrossVisible.AutoSize = true;
            this.CkCrossVisible.Location = new System.Drawing.Point(17, 24);
            this.CkCrossVisible.Name = "CkCrossVisible";
            this.CkCrossVisible.Size = new System.Drawing.Size(60, 19);
            this.CkCrossVisible.TabIndex = 0;
            this.CkCrossVisible.Text = "Visible";
            this.CkCrossVisible.UseVisualStyleBackColor = true;
            // 
            // FrmDocument
            // 
            this.AcceptButton = this.BtnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(352, 165);
            this.Controls.Add(this.GbCenterCross);
            this.Controls.Add(this.GbSheetSize);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Document options";
            this.Load += new System.EventHandler(this.FrmDocument_Load);
            this.GbSheetSize.ResumeLayout(false);
            this.GbSheetSize.PerformLayout();
            this.GbCenterCross.ResumeLayout(false);
            this.GbCenterCross.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbCrossColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnApply;
        private Button BtnCancel;
        private GroupBox GbSheetSize;
        private TextBox TbSheetHeight;
        private TextBox TbSheetWidth;
        private Label LbSheetHeight;
        private Label LbSheetWidth;
        private GroupBox GbCenterCross;
        private PictureBox PbCrossColor;
        private Label LbCrossColor;
        private CheckBox CkCrossVisible;
        private ColorDialog CdCrossColor;
    }
}