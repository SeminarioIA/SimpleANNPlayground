namespace SimpleAnnPlayground.UI
{
    partial class FrmModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModel));
            this.TbRate = new System.Windows.Forms.TextBox();
            this.LbRate = new System.Windows.Forms.Label();
            this.TkRate = new System.Windows.Forms.TrackBar();
            this.TkBatch = new System.Windows.Forms.TrackBar();
            this.TbBatch = new System.Windows.Forms.TextBox();
            this.LbBatch = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TkRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TkBatch)).BeginInit();
            this.SuspendLayout();
            // 
            // TbRate
            // 
            this.TbRate.Location = new System.Drawing.Point(264, 15);
            this.TbRate.Name = "TbRate";
            this.TbRate.ReadOnly = true;
            this.TbRate.Size = new System.Drawing.Size(57, 23);
            this.TbRate.TabIndex = 38;
            this.TbRate.Text = "0.00001";
            this.TbRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbRate_KeyPress);
            // 
            // LbRate
            // 
            this.LbRate.AutoSize = true;
            this.LbRate.Location = new System.Drawing.Point(179, 18);
            this.LbRate.Name = "LbRate";
            this.LbRate.Size = new System.Drawing.Size(79, 15);
            this.LbRate.TabIndex = 36;
            this.LbRate.Text = "Learning rate:";
            // 
            // TkRate
            // 
            this.TkRate.Location = new System.Drawing.Point(179, 44);
            this.TkRate.Minimum = -1;
            this.TkRate.Name = "TkRate";
            this.TkRate.Size = new System.Drawing.Size(142, 45);
            this.TkRate.TabIndex = 37;
            this.TkRate.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TkRate.Value = 5;
            this.TkRate.ValueChanged += new System.EventHandler(this.TkRate_ValueChanged);
            // 
            // TkBatch
            // 
            this.TkBatch.Location = new System.Drawing.Point(12, 44);
            this.TkBatch.Maximum = 30;
            this.TkBatch.Minimum = 1;
            this.TkBatch.Name = "TkBatch";
            this.TkBatch.Size = new System.Drawing.Size(142, 45);
            this.TkBatch.TabIndex = 34;
            this.TkBatch.TickFrequency = 2;
            this.TkBatch.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TkBatch.Value = 1;
            this.TkBatch.ValueChanged += new System.EventHandler(this.TkBatch_ValueChanged);
            // 
            // TbBatch
            // 
            this.TbBatch.Location = new System.Drawing.Point(97, 15);
            this.TbBatch.Name = "TbBatch";
            this.TbBatch.ReadOnly = true;
            this.TbBatch.Size = new System.Drawing.Size(57, 23);
            this.TbBatch.TabIndex = 35;
            this.TbBatch.Text = "1";
            this.TbBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LbBatch
            // 
            this.LbBatch.AutoSize = true;
            this.LbBatch.Location = new System.Drawing.Point(12, 18);
            this.LbBatch.Name = "LbBatch";
            this.LbBatch.Size = new System.Drawing.Size(62, 15);
            this.LbBatch.TabIndex = 33;
            this.LbBatch.Text = "Batch size:";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(259, 108);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 40;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnApply
            // 
            this.BtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnApply.Location = new System.Drawing.Point(178, 108);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(75, 23);
            this.BtnApply.TabIndex = 39;
            this.BtnApply.Text = "Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // FrmModel
            // 
            this.AcceptButton = this.BtnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(346, 143);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.TbRate);
            this.Controls.Add(this.LbRate);
            this.Controls.Add(this.TkRate);
            this.Controls.Add(this.TkBatch);
            this.Controls.Add(this.TbBatch);
            this.Controls.Add(this.LbBatch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Model Parameters";
            this.Load += new System.EventHandler(this.FrmModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TkRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TkBatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TbRate;
        private Label LbRate;
        private TrackBar TkRate;
        private TrackBar TkBatch;
        private TextBox TbBatch;
        private Label LbBatch;
        private Button BtnCancel;
        private Button BtnApply;
    }
}