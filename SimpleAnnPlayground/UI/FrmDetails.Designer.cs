namespace SimpleAnnPlayground.UI
{
    partial class FrmDetails
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
            this.RtbInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RtbInfo
            // 
            this.RtbInfo.BackColor = System.Drawing.SystemColors.Info;
            this.RtbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbInfo.Location = new System.Drawing.Point(0, 0);
            this.RtbInfo.Name = "RtbInfo";
            this.RtbInfo.ReadOnly = true;
            this.RtbInfo.Size = new System.Drawing.Size(270, 244);
            this.RtbInfo.TabIndex = 0;
            this.RtbInfo.Text = "";
            // 
            // FrmDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 244);
            this.Controls.Add(this.RtbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operation Details";
            this.ResumeLayout(false);

        }

        #endregion

        internal RichTextBox RtbInfo;
    }
}