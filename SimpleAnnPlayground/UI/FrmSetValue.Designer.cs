namespace SimpleAnnPlayground.UI
{
    partial class FrmSetValue
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnApply = new System.Windows.Forms.Button();
            this.TbValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(92, 48);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 42;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnApply
            // 
            this.BtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnApply.Location = new System.Drawing.Point(11, 48);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(75, 23);
            this.BtnApply.TabIndex = 41;
            this.BtnApply.Text = "Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            // 
            // TbValue
            // 
            this.TbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbValue.Location = new System.Drawing.Point(12, 12);
            this.TbValue.Name = "TbValue";
            this.TbValue.Size = new System.Drawing.Size(155, 23);
            this.TbValue.TabIndex = 43;
            this.TbValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbValue_KeyPress);
            // 
            // FrmSetValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 83);
            this.Controls.Add(this.TbValue);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSetValue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set value";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnCancel;
        private Button BtnApply;
        private TextBox TbValue;
    }
}