namespace SimpleAnnPlayground.UI
{
    partial class FrmTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTemplate));
            this.TmptGroupBoxInput = new System.Windows.Forms.GroupBox();
            this.comboBoxInputNum = new System.Windows.Forms.ComboBox();
            this.labelInpText = new System.Windows.Forms.Label();
            this.TmptGroupBoxHidden = new System.Windows.Forms.GroupBox();
            this.comboBoxHidNumber = new System.Windows.Forms.ComboBox();
            this.labelHidText = new System.Windows.Forms.Label();
            this.comboBoxHidLayers = new System.Windows.Forms.ComboBox();
            this.labelHidNumLay = new System.Windows.Forms.Label();
            this.TmptGroupBoxOutput = new System.Windows.Forms.GroupBox();
            this.comboBoxOutNum = new System.Windows.Forms.ComboBox();
            this.labelOutText = new System.Windows.Forms.Label();
            this.TmptGroupBoxOptions = new System.Windows.Forms.GroupBox();
            this.radioCustom = new System.Windows.Forms.RadioButton();
            this.radioFully = new System.Windows.Forms.RadioButton();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.TmptGroupBoxInput.SuspendLayout();
            this.TmptGroupBoxHidden.SuspendLayout();
            this.TmptGroupBoxOutput.SuspendLayout();
            this.TmptGroupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // TmptGroupBoxInput
            // 
            this.TmptGroupBoxInput.Controls.Add(this.comboBoxInputNum);
            this.TmptGroupBoxInput.Controls.Add(this.labelInpText);
            this.TmptGroupBoxInput.Location = new System.Drawing.Point(12, 8);
            this.TmptGroupBoxInput.Name = "TmptGroupBoxInput";
            this.TmptGroupBoxInput.Size = new System.Drawing.Size(217, 51);
            this.TmptGroupBoxInput.TabIndex = 0;
            this.TmptGroupBoxInput.TabStop = false;
            this.TmptGroupBoxInput.Text = "Input Layer";
            // 
            // comboBoxInputNum
            // 
            this.comboBoxInputNum.FormattingEnabled = true;
            this.comboBoxInputNum.ItemHeight = 15;
            this.comboBoxInputNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxInputNum.Location = new System.Drawing.Point(103, 16);
            this.comboBoxInputNum.MaxDropDownItems = 5;
            this.comboBoxInputNum.Name = "comboBoxInputNum";
            this.comboBoxInputNum.Size = new System.Drawing.Size(108, 23);
            this.comboBoxInputNum.TabIndex = 1;
            // 
            // labelInpText
            // 
            this.labelInpText.AutoSize = true;
            this.labelInpText.Location = new System.Drawing.Point(6, 19);
            this.labelInpText.Name = "labelInpText";
            this.labelInpText.Size = new System.Drawing.Size(76, 15);
            this.labelInpText.TabIndex = 0;
            this.labelInpText.Text = "Perceptrones";
            // 
            // TmptGroupBoxHidden
            // 
            this.TmptGroupBoxHidden.Controls.Add(this.comboBoxHidNumber);
            this.TmptGroupBoxHidden.Controls.Add(this.labelHidText);
            this.TmptGroupBoxHidden.Controls.Add(this.comboBoxHidLayers);
            this.TmptGroupBoxHidden.Controls.Add(this.labelHidNumLay);
            this.TmptGroupBoxHidden.Location = new System.Drawing.Point(12, 65);
            this.TmptGroupBoxHidden.Name = "TmptGroupBoxHidden";
            this.TmptGroupBoxHidden.Size = new System.Drawing.Size(217, 84);
            this.TmptGroupBoxHidden.TabIndex = 1;
            this.TmptGroupBoxHidden.TabStop = false;
            this.TmptGroupBoxHidden.Text = "Hidden Layer";
            // 
            // comboBoxHidNumber
            // 
            this.comboBoxHidNumber.FormattingEnabled = true;
            this.comboBoxHidNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxHidNumber.Location = new System.Drawing.Point(103, 50);
            this.comboBoxHidNumber.MaxDropDownItems = 5;
            this.comboBoxHidNumber.Name = "comboBoxHidNumber";
            this.comboBoxHidNumber.Size = new System.Drawing.Size(108, 23);
            this.comboBoxHidNumber.TabIndex = 3;
            // 
            // labelHidText
            // 
            this.labelHidText.AutoSize = true;
            this.labelHidText.Location = new System.Drawing.Point(6, 53);
            this.labelHidText.Name = "labelHidText";
            this.labelHidText.Size = new System.Drawing.Size(76, 15);
            this.labelHidText.TabIndex = 2;
            this.labelHidText.Text = "Perceptrones";
            // 
            // comboBoxHidLayers
            // 
            this.comboBoxHidLayers.FormattingEnabled = true;
            this.comboBoxHidLayers.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxHidLayers.Location = new System.Drawing.Point(103, 16);
            this.comboBoxHidLayers.MaxDropDownItems = 5;
            this.comboBoxHidLayers.Name = "comboBoxHidLayers";
            this.comboBoxHidLayers.Size = new System.Drawing.Size(108, 23);
            this.comboBoxHidLayers.TabIndex = 1;
            // 
            // labelHidNumLay
            // 
            this.labelHidNumLay.AutoSize = true;
            this.labelHidNumLay.Location = new System.Drawing.Point(6, 19);
            this.labelHidNumLay.Name = "labelHidNumLay";
            this.labelHidNumLay.Size = new System.Drawing.Size(80, 15);
            this.labelHidNumLay.TabIndex = 0;
            this.labelHidNumLay.Text = "Capas ocultas";
            // 
            // TmptGroupBoxOutput
            // 
            this.TmptGroupBoxOutput.Controls.Add(this.comboBoxOutNum);
            this.TmptGroupBoxOutput.Controls.Add(this.labelOutText);
            this.TmptGroupBoxOutput.Location = new System.Drawing.Point(12, 155);
            this.TmptGroupBoxOutput.Name = "TmptGroupBoxOutput";
            this.TmptGroupBoxOutput.Size = new System.Drawing.Size(217, 53);
            this.TmptGroupBoxOutput.TabIndex = 2;
            this.TmptGroupBoxOutput.TabStop = false;
            this.TmptGroupBoxOutput.Text = "Output Layer";
            // 
            // comboBoxOutNum
            // 
            this.comboBoxOutNum.FormattingEnabled = true;
            this.comboBoxOutNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxOutNum.Location = new System.Drawing.Point(103, 16);
            this.comboBoxOutNum.MaxDropDownItems = 5;
            this.comboBoxOutNum.Name = "comboBoxOutNum";
            this.comboBoxOutNum.Size = new System.Drawing.Size(108, 23);
            this.comboBoxOutNum.TabIndex = 1;
            // 
            // labelOutText
            // 
            this.labelOutText.AutoSize = true;
            this.labelOutText.Location = new System.Drawing.Point(6, 19);
            this.labelOutText.Name = "labelOutText";
            this.labelOutText.Size = new System.Drawing.Size(76, 15);
            this.labelOutText.TabIndex = 0;
            this.labelOutText.Text = "Perceptrones";
            // 
            // TmptGroupBoxOptions
            // 
            this.TmptGroupBoxOptions.Controls.Add(this.radioCustom);
            this.TmptGroupBoxOptions.Controls.Add(this.radioFully);
            this.TmptGroupBoxOptions.Location = new System.Drawing.Point(12, 214);
            this.TmptGroupBoxOptions.Name = "TmptGroupBoxOptions";
            this.TmptGroupBoxOptions.Size = new System.Drawing.Size(217, 75);
            this.TmptGroupBoxOptions.TabIndex = 3;
            this.TmptGroupBoxOptions.TabStop = false;
            this.TmptGroupBoxOptions.Text = "Options";
            // 
            // radioCustom
            // 
            this.radioCustom.AutoSize = true;
            this.radioCustom.Location = new System.Drawing.Point(6, 47);
            this.radioCustom.Name = "radioCustom";
            this.radioCustom.Size = new System.Drawing.Size(135, 19);
            this.radioCustom.TabIndex = 1;
            this.radioCustom.TabStop = true;
            this.radioCustom.Text = "Custom connections";
            this.radioCustom.UseVisualStyleBackColor = true;
            // 
            // radioFully
            // 
            this.radioFully.AutoSize = true;
            this.radioFully.Location = new System.Drawing.Point(6, 22);
            this.radioFully.Name = "radioFully";
            this.radioFully.Size = new System.Drawing.Size(109, 19);
            this.radioFully.TabIndex = 0;
            this.radioFully.TabStop = true;
            this.radioFully.Text = "Fully connected";
            this.radioFully.UseVisualStyleBackColor = true;
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(148, 295);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(75, 23);
            this.GenerateBtn.TabIndex = 4;
            this.GenerateBtn.Text = "Generar";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(12, 295);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancelar";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // FrmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 342);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.GenerateBtn);
            this.Controls.Add(this.TmptGroupBoxOptions);
            this.Controls.Add(this.TmptGroupBoxOutput);
            this.Controls.Add(this.TmptGroupBoxHidden);
            this.Controls.Add(this.TmptGroupBoxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrmTemplate";
            this.Text = "Templates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTemplate_FormClosing);
            this.Load += new System.EventHandler(this.FrmTemplate_Load);
            this.TmptGroupBoxInput.ResumeLayout(false);
            this.TmptGroupBoxInput.PerformLayout();
            this.TmptGroupBoxHidden.ResumeLayout(false);
            this.TmptGroupBoxHidden.PerformLayout();
            this.TmptGroupBoxOutput.ResumeLayout(false);
            this.TmptGroupBoxOutput.PerformLayout();
            this.TmptGroupBoxOptions.ResumeLayout(false);
            this.TmptGroupBoxOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox TmptGroupBoxInput;
        private ComboBox comboBoxInputNum;
        private Label labelInpText;
        private GroupBox TmptGroupBoxHidden;
        private ComboBox comboBoxHidNumber;
        private Label labelHidText;
        private ComboBox comboBoxHidLayers;
        private Label labelHidNumLay;
        private GroupBox TmptGroupBoxOutput;
        private ComboBox comboBoxOutNum;
        private Label labelOutText;
        private GroupBox TmptGroupBoxOptions;
        private RadioButton radioCustom;
        private RadioButton radioFully;
        private Button GenerateBtn;
        private Button CancelBtn;
    }
}