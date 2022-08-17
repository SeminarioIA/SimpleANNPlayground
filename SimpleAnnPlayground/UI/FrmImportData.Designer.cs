using SimpleAnnPlayground.UI.Controls;

namespace SimpleAnnPlayground.UI
{
    partial class FrmImportData
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
                _checkRow.Dispose();
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
            this.LbRegisters = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsBar = new System.Windows.Forms.ToolStrip();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.BtnImport = new System.Windows.Forms.ToolStripButton();
            this.LbSelect = new System.Windows.Forms.ToolStripLabel();
            this.TkSelect = new SimpleAnnPlayground.UI.Controls.ToolStripTrackBar();
            this.DgImport = new System.Windows.Forms.DataGridView();
            this.SsBar.SuspendLayout();
            this.TsBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgImport)).BeginInit();
            this.SuspendLayout();
            // 
            // SsBar
            // 
            this.SsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbColumns,
            this.LbRegisters});
            this.SsBar.Location = new System.Drawing.Point(0, 374);
            this.SsBar.Name = "SsBar";
            this.SsBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.SsBar.Size = new System.Drawing.Size(812, 24);
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
            this.LbColumns.Size = new System.Drawing.Size(100, 19);
            this.LbColumns.Text = "Columns:";
            this.LbColumns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbRegisters
            // 
            this.LbRegisters.AutoSize = false;
            this.LbRegisters.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LbRegisters.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LbRegisters.Name = "LbRegisters";
            this.LbRegisters.Size = new System.Drawing.Size(100, 19);
            this.LbRegisters.Text = "Registers: ";
            this.LbRegisters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TsBar
            // 
            this.TsBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnCancel,
            this.BtnImport,
            this.LbSelect,
            this.TkSelect});
            this.TsBar.Location = new System.Drawing.Point(0, 0);
            this.TsBar.Name = "TsBar";
            this.TsBar.Size = new System.Drawing.Size(812, 25);
            this.TsBar.TabIndex = 1;
            this.TsBar.Text = "toolStrip1";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnCancel.Image = global::SimpleAnnPlayground.Properties.Resources.cancel_32;
            this.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(63, 22);
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnImport.Image = global::SimpleAnnPlayground.Properties.Resources.ok_32;
            this.BtnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(63, 22);
            this.BtnImport.Text = "Import";
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // LbSelect
            // 
            this.LbSelect.AutoSize = false;
            this.LbSelect.Name = "LbSelect";
            this.LbSelect.Size = new System.Drawing.Size(80, 22);
            this.LbSelect.Text = "Import: 100 %";
            // 
            // TkSelect
            // 
            this.TkSelect.Name = "TkSelect";
            this.TkSelect.Size = new System.Drawing.Size(100, 22);
            this.TkSelect.Value = 100;
            // 
            // DgImport
            // 
            this.DgImport.AllowUserToAddRows = false;
            this.DgImport.AllowUserToDeleteRows = false;
            this.DgImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgImport.Location = new System.Drawing.Point(0, 25);
            this.DgImport.Name = "DgImport";
            this.DgImport.RowTemplate.Height = 25;
            this.DgImport.Size = new System.Drawing.Size(812, 349);
            this.DgImport.TabIndex = 2;
            // 
            // FrmImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 398);
            this.Controls.Add(this.DgImport);
            this.Controls.Add(this.TsBar);
            this.Controls.Add(this.SsBar);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmImportData";
            this.Text = "ImportData";
            this.Load += new System.EventHandler(this.FrmImportData_Load);
            this.SsBar.ResumeLayout(false);
            this.SsBar.PerformLayout();
            this.TsBar.ResumeLayout(false);
            this.TsBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgImport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip SsBar;
        private ToolStripStatusLabel LbColumns;
        private ToolStripStatusLabel LbRegisters;
        private ToolStrip TsBar;
        private DataGridView DgImport;
        private ToolStripButton BtnCancel;
        private ToolStripButton BtnImport;
        private ToolStripLabel LbSelect;
        private ToolStripTrackBar TkSelect;
    }
}