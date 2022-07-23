namespace SimpleAnnPlayground.Debugging
{
    partial class FrmObjectsViewer
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
            this.PgdView = new System.Windows.Forms.PropertyGrid();
            this.LbType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PgdView
            // 
            this.PgdView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PgdView.Location = new System.Drawing.Point(0, 27);
            this.PgdView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PgdView.Name = "PgdView";
            this.PgdView.Size = new System.Drawing.Size(348, 457);
            this.PgdView.TabIndex = 0;
            this.PgdView.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PgdView_PropertyValueChanged);
            // 
            // LbType
            // 
            this.LbType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LbType.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbType.Location = new System.Drawing.Point(0, 0);
            this.LbType.Name = "LbType";
            this.LbType.Size = new System.Drawing.Size(348, 27);
            this.LbType.TabIndex = 1;
            this.LbType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmObjectsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 484);
            this.Controls.Add(this.PgdView);
            this.Controls.Add(this.LbType);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmObjectsViewer";
            this.Text = "Objects Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmObjectsViewer_FormClosing);
            this.Load += new System.EventHandler(this.FrmObjectsViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertyGrid PgdView;
        private Label LbType;
    }
}