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
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.TmptGroupBoxInput.Size = new System.Drawing.Size(189, 51);
            this.TmptGroupBoxInput.TabIndex = 0;
            this.TmptGroupBoxInput.TabStop = false;
            this.TmptGroupBoxInput.Text = "Input Layer";
            // 
            // comboBoxInputNum
            // 
            this.comboBoxInputNum.FormattingEnabled = true;
            this.comboBoxInputNum.Location = new System.Drawing.Point(103, 16);
            this.comboBoxInputNum.Name = "comboBoxInputNum";
            this.comboBoxInputNum.Size = new System.Drawing.Size(75, 23);
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
            this.TmptGroupBoxHidden.Size = new System.Drawing.Size(189, 84);
            this.TmptGroupBoxHidden.TabIndex = 1;
            this.TmptGroupBoxHidden.TabStop = false;
            this.TmptGroupBoxHidden.Text = "Hidden Layer";
            // 
            // comboBoxHidNumber
            // 
            this.comboBoxHidNumber.FormattingEnabled = true;
            this.comboBoxHidNumber.Location = new System.Drawing.Point(103, 50);
            this.comboBoxHidNumber.Name = "comboBoxHidNumber";
            this.comboBoxHidNumber.Size = new System.Drawing.Size(75, 23);
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
            this.comboBoxHidLayers.Location = new System.Drawing.Point(103, 16);
            this.comboBoxHidLayers.Name = "comboBoxHidLayers";
            this.comboBoxHidLayers.Size = new System.Drawing.Size(75, 23);
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
            this.TmptGroupBoxOutput.Size = new System.Drawing.Size(189, 53);
            this.TmptGroupBoxOutput.TabIndex = 2;
            this.TmptGroupBoxOutput.TabStop = false;
            this.TmptGroupBoxOutput.Text = "Output Layer";
            // 
            // comboBoxOutNum
            // 
            this.comboBoxOutNum.FormattingEnabled = true;
            this.comboBoxOutNum.Location = new System.Drawing.Point(103, 16);
            this.comboBoxOutNum.Name = "comboBoxOutNum";
            this.comboBoxOutNum.Size = new System.Drawing.Size(75, 23);
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
            this.TmptGroupBoxOptions.Controls.Add(this.radioButton2);
            this.TmptGroupBoxOptions.Controls.Add(this.radioButton1);
            this.TmptGroupBoxOptions.Location = new System.Drawing.Point(12, 214);
            this.TmptGroupBoxOptions.Name = "TmptGroupBoxOptions";
            this.TmptGroupBoxOptions.Size = new System.Drawing.Size(189, 75);
            this.TmptGroupBoxOptions.TabIndex = 3;
            this.TmptGroupBoxOptions.TabStop = false;
            this.TmptGroupBoxOptions.Text = "Options";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 47);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(135, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Custom connections";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(109, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Fully connected";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // FrmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 328);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TmptGroupBoxOptions);
            this.Controls.Add(this.TmptGroupBoxOutput);
            this.Controls.Add(this.TmptGroupBoxHidden);
            this.Controls.Add(this.TmptGroupBoxInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTemplate";
            this.Text = "Templates";
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
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button1;
        private Button button2;
    }
}