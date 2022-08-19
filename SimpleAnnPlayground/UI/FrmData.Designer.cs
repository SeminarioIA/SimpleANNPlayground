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
                _typeRow.Dispose();
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
            this.LbColumns = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbInputs = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbOutputs = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbRegisters = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsTools = new System.Windows.Forms.ToolStrip();
            this.BtnImport = new System.Windows.Forms.ToolStripButton();
            this.LbTest = new System.Windows.Forms.ToolStripLabel();
            this.PbData = new SimpleAnnPlayground.UI.Controls.ToolStripTrackBar();
            this.LbTraining = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnShuffle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DgData = new System.Windows.Forms.DataGridView();
            this.SsBar.SuspendLayout();
            this.TsTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgData)).BeginInit();
            this.SuspendLayout();
            // 
            // SsBar
            // 
            this.SsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbColumns,
            this.LbInputs,
            this.LbOutputs,
            this.LbRegisters});
            this.SsBar.Location = new System.Drawing.Point(0, 411);
            this.SsBar.Name = "SsBar";
            this.SsBar.Size = new System.Drawing.Size(590, 22);
            this.SsBar.TabIndex = 0;
            this.SsBar.Text = "statusStrip1";
            // 
            // LbColumns
            // 
            this.LbColumns.AutoSize = false;
            this.LbColumns.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LbColumns.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LbColumns.Name = "LbColumns";
            this.LbColumns.Size = new System.Drawing.Size(100, 17);
            this.LbColumns.Text = "Columns:";
            this.LbColumns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbInputs
            // 
            this.LbInputs.AutoSize = false;
            this.LbInputs.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LbInputs.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LbInputs.Name = "LbInputs";
            this.LbInputs.Size = new System.Drawing.Size(100, 17);
            this.LbInputs.Text = "Inputs:";
            this.LbInputs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbOutputs
            // 
            this.LbOutputs.AutoSize = false;
            this.LbOutputs.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LbOutputs.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LbOutputs.Name = "LbOutputs";
            this.LbOutputs.Size = new System.Drawing.Size(100, 17);
            this.LbOutputs.Text = "Outputs:";
            this.LbOutputs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbRegisters
            // 
            this.LbRegisters.AutoSize = false;
            this.LbRegisters.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LbRegisters.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LbRegisters.Name = "LbRegisters";
            this.LbRegisters.Size = new System.Drawing.Size(100, 17);
            this.LbRegisters.Text = "Registers: ";
            this.LbRegisters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TsTools
            // 
            this.TsTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TsTools.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnImport,
            this.LbTest,
            this.PbData,
            this.LbTraining,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.BtnShuffle,
            this.toolStripSeparator3});
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
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // BtnShuffle
            // 
            this.BtnShuffle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnShuffle.Image = global::SimpleAnnPlayground.Properties.Resources.Shuffle_32;
            this.BtnShuffle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnShuffle.Name = "BtnShuffle";
            this.BtnShuffle.Size = new System.Drawing.Size(72, 28);
            this.BtnShuffle.Text = "Shuffle";
            this.BtnShuffle.Click += new System.EventHandler(this.BtnShuffle_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // DgData
            // 
            this.DgData.AllowUserToAddRows = false;
            this.DgData.AllowUserToDeleteRows = false;
            this.DgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgData.Location = new System.Drawing.Point(0, 31);
            this.DgData.Name = "DgData";
            this.DgData.RowTemplate.Height = 25;
            this.DgData.Size = new System.Drawing.Size(590, 380);
            this.DgData.TabIndex = 2;
            // 
            // FrmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 433);
            this.Controls.Add(this.DgData);
            this.Controls.Add(this.TsTools);
            this.Controls.Add(this.SsBar);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmData";
            this.Text = "Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmData_FormClosing);
            this.Load += new System.EventHandler(this.FrmData_Load);
            this.SsBar.ResumeLayout(false);
            this.SsBar.PerformLayout();
            this.TsTools.ResumeLayout(false);
            this.TsTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgData)).EndInit();
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
        private DataGridView DgData;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton BtnShuffle;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripStatusLabel LbInputs;
        private ToolStripStatusLabel LbOutputs;
        private ToolStripStatusLabel LbColumns;
        private ToolStripStatusLabel LbRegisters;
    }
}