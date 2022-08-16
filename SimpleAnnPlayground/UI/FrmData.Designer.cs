using SimpleAnnPlayground.UI.Controls;

namespace SimpleAnnPlayground.Screens
{
    partial class FrmData
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
            this.SsBar = new System.Windows.Forms.StatusStrip();
            this.TsTools = new System.Windows.Forms.ToolStrip();
            this.BtnImport = new System.Windows.Forms.ToolStripButton();
            this.LbTest = new System.Windows.Forms.ToolStripLabel();
            this.PbData = new SimpleAnnPlayground.UI.Controls.ToolStripTrackBar();
            this.LbTraining = new System.Windows.Forms.ToolStripLabel();
            this.DgvData = new System.Windows.Forms.DataGridView();
            this.TsTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // SsBar
            // 
            this.SsBar.Location = new System.Drawing.Point(0, 411);
            this.SsBar.Name = "SsBar";
            this.SsBar.Size = new System.Drawing.Size(590, 22);
            this.SsBar.TabIndex = 0;
            this.SsBar.Text = "statusStrip1";
            // 
            // TsTools
            // 
            this.TsTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TsTools.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnImport,
            this.LbTest,
            this.PbData,
            this.LbTraining});
            this.TsTools.Location = new System.Drawing.Point(0, 0);
            this.TsTools.Name = "TsTools";
            this.TsTools.Size = new System.Drawing.Size(590, 31);
            this.TsTools.TabIndex = 1;
            this.TsTools.Text = "toolStrip1";
            // 
            // BtnImport
            // 
            this.BtnImport.Image = global::SimpleAnnPlayground.Properties.Resources.import_32;
            this.BtnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(71, 28);
            this.BtnImport.Text = "Import";
            // 
            // LbTest
            // 
            this.LbTest.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LbTest.AutoSize = false;
            this.LbTest.Name = "LbTest";
            this.LbTest.Size = new System.Drawing.Size(80, 28);
            this.LbTest.Text = "20 % - Test";
            // 
            // PbData
            // 
            this.PbData.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.PbData.Name = "PbData";
            this.PbData.Size = new System.Drawing.Size(100, 28);
            this.PbData.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PbData.Value = 80;
            // 
            // LbTraining
            // 
            this.LbTraining.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LbTraining.AutoSize = false;
            this.LbTraining.Name = "LbTraining";
            this.LbTraining.Size = new System.Drawing.Size(90, 28);
            this.LbTraining.Text = "Training - 80 %";
            // 
            // DgvData
            // 
            this.DgvData.AllowUserToAddRows = false;
            this.DgvData.AllowUserToDeleteRows = false;
            this.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvData.Location = new System.Drawing.Point(0, 31);
            this.DgvData.Name = "DgvData";
            this.DgvData.ReadOnly = true;
            this.DgvData.RowTemplate.Height = 25;
            this.DgvData.Size = new System.Drawing.Size(590, 380);
            this.DgvData.TabIndex = 2;
            // 
            // FrmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 433);
            this.Controls.Add(this.DgvData);
            this.Controls.Add(this.TsTools);
            this.Controls.Add(this.SsBar);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmData";
            this.Text = "Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmData_FormClosing);
            this.TsTools.ResumeLayout(false);
            this.TsTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip SsBar;
        private ToolStrip TsTools;
        private ToolStripButton BtnImport;
        private ToolStripLabel LbTest;
        private ToolStripTrackBar PbData;
        private ToolStripLabel LbTraining;
        private DataGridView DgvData;
    }
}