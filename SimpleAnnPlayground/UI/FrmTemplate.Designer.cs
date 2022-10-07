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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTemplate));
            this.GbOptions = new System.Windows.Forms.GroupBox();
            this.TbRate = new System.Windows.Forms.TextBox();
            this.LbRate = new System.Windows.Forms.Label();
            this.TkRate = new System.Windows.Forms.TrackBar();
            this.RbCustom = new System.Windows.Forms.RadioButton();
            this.TkBatch = new System.Windows.Forms.TrackBar();
            this.TbBatch = new System.Windows.Forms.TextBox();
            this.RbFully = new System.Windows.Forms.RadioButton();
            this.LbBatch = new System.Windows.Forms.Label();
            this.CbWeights = new System.Windows.Forms.ComboBox();
            this.LbWeights = new System.Windows.Forms.Label();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.DgTemplate = new System.Windows.Forms.DataGridView();
            this.CnLayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CnNeurons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PbPlot = new System.Windows.Forms.PictureBox();
            this.ScMain = new System.Windows.Forms.SplitContainer();
            this.TbRatio = new System.Windows.Forms.TextBox();
            this.TbDataSize = new System.Windows.Forms.TextBox();
            this.TbNoise = new System.Windows.Forms.TextBox();
            this.CbDataSet = new System.Windows.Forms.ComboBox();
            this.CbProblemType = new System.Windows.Forms.ComboBox();
            this.LbDataSet = new System.Windows.Forms.Label();
            this.LbProblemType = new System.Windows.Forms.Label();
            this.TkRatio = new System.Windows.Forms.TrackBar();
            this.TkNoise = new System.Windows.Forms.TrackBar();
            this.TkDataSize = new System.Windows.Forms.TrackBar();
            this.LbRatio = new System.Windows.Forms.Label();
            this.LbNoise = new System.Windows.Forms.Label();
            this.LbDataSize = new System.Windows.Forms.Label();
            this.LbDataTitle = new System.Windows.Forms.Label();
            this.ScNetwork = new System.Windows.Forms.SplitContainer();
            this.LbNetworkTitle = new System.Windows.Forms.Label();
            this.PnButtons = new System.Windows.Forms.Panel();
            this.BtnRegenerate = new System.Windows.Forms.Button();
            this.GbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TkRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TkBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
            this.ScMain.Panel1.SuspendLayout();
            this.ScMain.Panel2.SuspendLayout();
            this.ScMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TkRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TkNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TkDataSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScNetwork)).BeginInit();
            this.ScNetwork.Panel1.SuspendLayout();
            this.ScNetwork.Panel2.SuspendLayout();
            this.ScNetwork.SuspendLayout();
            this.PnButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbOptions
            // 
            this.GbOptions.Controls.Add(this.TbRate);
            this.GbOptions.Controls.Add(this.LbRate);
            this.GbOptions.Controls.Add(this.TkRate);
            this.GbOptions.Controls.Add(this.RbCustom);
            this.GbOptions.Controls.Add(this.TkBatch);
            this.GbOptions.Controls.Add(this.TbBatch);
            this.GbOptions.Controls.Add(this.RbFully);
            this.GbOptions.Controls.Add(this.LbBatch);
            this.GbOptions.Controls.Add(this.CbWeights);
            this.GbOptions.Controls.Add(this.LbWeights);
            this.GbOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbOptions.Location = new System.Drawing.Point(0, 0);
            this.GbOptions.Name = "GbOptions";
            this.GbOptions.Size = new System.Drawing.Size(168, 304);
            this.GbOptions.TabIndex = 3;
            this.GbOptions.TabStop = false;
            this.GbOptions.Text = "Options";
            // 
            // TbRate
            // 
            this.TbRate.Location = new System.Drawing.Point(91, 212);
            this.TbRate.Name = "TbRate";
            this.TbRate.ReadOnly = true;
            this.TbRate.Size = new System.Drawing.Size(57, 23);
            this.TbRate.TabIndex = 30;
            this.TbRate.Text = "0.00001";
            this.TbRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LbRate
            // 
            this.LbRate.AutoSize = true;
            this.LbRate.Location = new System.Drawing.Point(6, 215);
            this.LbRate.Name = "LbRate";
            this.LbRate.Size = new System.Drawing.Size(79, 15);
            this.LbRate.TabIndex = 29;
            this.LbRate.Text = "Learning rate:";
            // 
            // TkRate
            // 
            this.TkRate.Location = new System.Drawing.Point(6, 241);
            this.TkRate.Name = "TkRate";
            this.TkRate.Size = new System.Drawing.Size(142, 45);
            this.TkRate.TabIndex = 29;
            this.TkRate.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TkRate.Value = 5;
            this.TkRate.ValueChanged += new System.EventHandler(this.TkRate_ValueChanged);
            // 
            // RbCustom
            // 
            this.RbCustom.AutoSize = true;
            this.RbCustom.Location = new System.Drawing.Point(16, 43);
            this.RbCustom.Name = "RbCustom";
            this.RbCustom.Size = new System.Drawing.Size(135, 19);
            this.RbCustom.TabIndex = 1;
            this.RbCustom.Text = "Custom connections";
            this.RbCustom.UseVisualStyleBackColor = true;
            // 
            // TkBatch
            // 
            this.TkBatch.Location = new System.Drawing.Point(6, 161);
            this.TkBatch.Maximum = 30;
            this.TkBatch.Minimum = 1;
            this.TkBatch.Name = "TkBatch";
            this.TkBatch.Size = new System.Drawing.Size(142, 45);
            this.TkBatch.TabIndex = 27;
            this.TkBatch.TickFrequency = 2;
            this.TkBatch.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TkBatch.Value = 1;
            this.TkBatch.ValueChanged += new System.EventHandler(this.TkBatch_ValueChanged);
            // 
            // TbBatch
            // 
            this.TbBatch.Location = new System.Drawing.Point(91, 132);
            this.TbBatch.Name = "TbBatch";
            this.TbBatch.ReadOnly = true;
            this.TbBatch.Size = new System.Drawing.Size(57, 23);
            this.TbBatch.TabIndex = 28;
            this.TbBatch.Text = "1";
            this.TbBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RbFully
            // 
            this.RbFully.AutoSize = true;
            this.RbFully.Checked = true;
            this.RbFully.Location = new System.Drawing.Point(16, 21);
            this.RbFully.Name = "RbFully";
            this.RbFully.Size = new System.Drawing.Size(109, 19);
            this.RbFully.TabIndex = 0;
            this.RbFully.TabStop = true;
            this.RbFully.Text = "Fully connected";
            this.RbFully.UseVisualStyleBackColor = true;
            // 
            // LbBatch
            // 
            this.LbBatch.AutoSize = true;
            this.LbBatch.Location = new System.Drawing.Point(6, 135);
            this.LbBatch.Name = "LbBatch";
            this.LbBatch.Size = new System.Drawing.Size(62, 15);
            this.LbBatch.TabIndex = 26;
            this.LbBatch.Text = "Batch size:";
            // 
            // CbWeights
            // 
            this.CbWeights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbWeights.FormattingEnabled = true;
            this.CbWeights.Location = new System.Drawing.Point(6, 91);
            this.CbWeights.Name = "CbWeights";
            this.CbWeights.Size = new System.Drawing.Size(142, 23);
            this.CbWeights.TabIndex = 7;
            // 
            // LbWeights
            // 
            this.LbWeights.AutoSize = true;
            this.LbWeights.Location = new System.Drawing.Point(16, 73);
            this.LbWeights.Name = "LbWeights";
            this.LbWeights.Size = new System.Drawing.Size(120, 15);
            this.LbWeights.TabIndex = 6;
            this.LbWeights.Text = "Weights initialization:";
            // 
            // BtnCreate
            // 
            this.BtnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnCreate.Enabled = false;
            this.BtnCreate.Location = new System.Drawing.Point(676, 16);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(75, 23);
            this.BtnCreate.TabIndex = 4;
            this.BtnCreate.Text = "Create";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(757, 16);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // DgTemplate
            // 
            this.DgTemplate.AllowUserToAddRows = false;
            this.DgTemplate.AllowUserToDeleteRows = false;
            this.DgTemplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgTemplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CnLayers,
            this.CnCount,
            this.CnNeurons});
            this.DgTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgTemplate.Location = new System.Drawing.Point(0, 0);
            this.DgTemplate.Name = "DgTemplate";
            this.DgTemplate.RowHeadersVisible = false;
            this.DgTemplate.RowTemplate.Height = 25;
            this.DgTemplate.Size = new System.Drawing.Size(241, 304);
            this.DgTemplate.TabIndex = 6;
            // 
            // CnLayers
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CnLayers.DefaultCellStyle = dataGridViewCellStyle1;
            this.CnLayers.HeaderText = "Layers";
            this.CnLayers.Name = "CnLayers";
            this.CnLayers.ReadOnly = true;
            // 
            // CnCount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CnCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.CnCount.HeaderText = "Count";
            this.CnCount.Name = "CnCount";
            this.CnCount.Width = 60;
            // 
            // CnNeurons
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CnNeurons.DefaultCellStyle = dataGridViewCellStyle3;
            this.CnNeurons.HeaderText = "Neurons";
            this.CnNeurons.Name = "CnNeurons";
            this.CnNeurons.Width = 60;
            // 
            // PbPlot
            // 
            this.PbPlot.BackColor = System.Drawing.Color.White;
            this.PbPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbPlot.Location = new System.Drawing.Point(3, 27);
            this.PbPlot.Name = "PbPlot";
            this.PbPlot.Size = new System.Drawing.Size(280, 295);
            this.PbPlot.TabIndex = 7;
            this.PbPlot.TabStop = false;
            this.PbPlot.Paint += new System.Windows.Forms.PaintEventHandler(this.PbPlot_Paint);
            // 
            // ScMain
            // 
            this.ScMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ScMain.Location = new System.Drawing.Point(0, 0);
            this.ScMain.Name = "ScMain";
            // 
            // ScMain.Panel1
            // 
            this.ScMain.Panel1.Controls.Add(this.TbRatio);
            this.ScMain.Panel1.Controls.Add(this.TbDataSize);
            this.ScMain.Panel1.Controls.Add(this.TbNoise);
            this.ScMain.Panel1.Controls.Add(this.CbDataSet);
            this.ScMain.Panel1.Controls.Add(this.CbProblemType);
            this.ScMain.Panel1.Controls.Add(this.LbDataSet);
            this.ScMain.Panel1.Controls.Add(this.LbProblemType);
            this.ScMain.Panel1.Controls.Add(this.TkRatio);
            this.ScMain.Panel1.Controls.Add(this.TkNoise);
            this.ScMain.Panel1.Controls.Add(this.TkDataSize);
            this.ScMain.Panel1.Controls.Add(this.LbRatio);
            this.ScMain.Panel1.Controls.Add(this.LbNoise);
            this.ScMain.Panel1.Controls.Add(this.LbDataSize);
            this.ScMain.Panel1.Controls.Add(this.LbDataTitle);
            this.ScMain.Panel1.Controls.Add(this.PbPlot);
            // 
            // ScMain.Panel2
            // 
            this.ScMain.Panel2.Controls.Add(this.ScNetwork);
            this.ScMain.Panel2.Controls.Add(this.LbNetworkTitle);
            this.ScMain.Size = new System.Drawing.Size(844, 328);
            this.ScMain.SplitterDistance = 427;
            this.ScMain.TabIndex = 8;
            // 
            // TbRatio
            // 
            this.TbRatio.Location = new System.Drawing.Point(381, 261);
            this.TbRatio.Name = "TbRatio";
            this.TbRatio.ReadOnly = true;
            this.TbRatio.Size = new System.Drawing.Size(41, 23);
            this.TbRatio.TabIndex = 25;
            this.TbRatio.Text = "80 %";
            this.TbRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TbDataSize
            // 
            this.TbDataSize.Location = new System.Drawing.Point(381, 118);
            this.TbDataSize.Name = "TbDataSize";
            this.TbDataSize.Size = new System.Drawing.Size(41, 23);
            this.TbDataSize.TabIndex = 24;
            this.TbDataSize.Text = "500";
            this.TbDataSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbDataSize.TextChanged += new System.EventHandler(this.TbDataSize_TextChanged);
            this.TbDataSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // TbNoise
            // 
            this.TbNoise.Location = new System.Drawing.Point(381, 190);
            this.TbNoise.Name = "TbNoise";
            this.TbNoise.Size = new System.Drawing.Size(41, 23);
            this.TbNoise.TabIndex = 23;
            this.TbNoise.Text = "0";
            this.TbNoise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbNoise.TextChanged += new System.EventHandler(this.TbNoise_TextChanged);
            this.TbNoise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // CbDataSet
            // 
            this.CbDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDataSet.FormattingEnabled = true;
            this.CbDataSet.Location = new System.Drawing.Point(289, 89);
            this.CbDataSet.Name = "CbDataSet";
            this.CbDataSet.Size = new System.Drawing.Size(133, 23);
            this.CbDataSet.TabIndex = 19;
            this.CbDataSet.SelectedValueChanged += new System.EventHandler(this.CbDataSet_SelectedValueChanged);
            // 
            // CbProblemType
            // 
            this.CbProblemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbProblemType.FormattingEnabled = true;
            this.CbProblemType.Location = new System.Drawing.Point(289, 45);
            this.CbProblemType.Name = "CbProblemType";
            this.CbProblemType.Size = new System.Drawing.Size(133, 23);
            this.CbProblemType.TabIndex = 18;
            this.CbProblemType.SelectedValueChanged += new System.EventHandler(this.CbProblemType_SelectedValueChanged);
            // 
            // LbDataSet
            // 
            this.LbDataSet.AutoSize = true;
            this.LbDataSet.Location = new System.Drawing.Point(289, 71);
            this.LbDataSet.Name = "LbDataSet";
            this.LbDataSet.Size = new System.Drawing.Size(52, 15);
            this.LbDataSet.TabIndex = 17;
            this.LbDataSet.Text = "Data set:";
            // 
            // LbProblemType
            // 
            this.LbProblemType.AutoSize = true;
            this.LbProblemType.Location = new System.Drawing.Point(289, 27);
            this.LbProblemType.Name = "LbProblemType";
            this.LbProblemType.Size = new System.Drawing.Size(81, 15);
            this.LbProblemType.TabIndex = 16;
            this.LbProblemType.Text = "Problem type:";
            // 
            // TkRatio
            // 
            this.TkRatio.LargeChange = 10;
            this.TkRatio.Location = new System.Drawing.Point(289, 282);
            this.TkRatio.Maximum = 90;
            this.TkRatio.Minimum = 10;
            this.TkRatio.Name = "TkRatio";
            this.TkRatio.Size = new System.Drawing.Size(133, 45);
            this.TkRatio.SmallChange = 5;
            this.TkRatio.TabIndex = 15;
            this.TkRatio.TickFrequency = 10;
            this.TkRatio.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TkRatio.Value = 80;
            this.TkRatio.ValueChanged += new System.EventHandler(this.TkRatio_ValueChanged);
            // 
            // TkNoise
            // 
            this.TkNoise.LargeChange = 10;
            this.TkNoise.Location = new System.Drawing.Point(289, 210);
            this.TkNoise.Maximum = 50;
            this.TkNoise.Name = "TkNoise";
            this.TkNoise.Size = new System.Drawing.Size(133, 45);
            this.TkNoise.SmallChange = 5;
            this.TkNoise.TabIndex = 14;
            this.TkNoise.TickFrequency = 5;
            this.TkNoise.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TkNoise.ValueChanged += new System.EventHandler(this.TkNoise_ValueChanged);
            // 
            // TkDataSize
            // 
            this.TkDataSize.LargeChange = 100;
            this.TkDataSize.Location = new System.Drawing.Point(289, 139);
            this.TkDataSize.Maximum = 1000;
            this.TkDataSize.Minimum = 200;
            this.TkDataSize.Name = "TkDataSize";
            this.TkDataSize.Size = new System.Drawing.Size(133, 45);
            this.TkDataSize.SmallChange = 50;
            this.TkDataSize.TabIndex = 13;
            this.TkDataSize.TickFrequency = 50;
            this.TkDataSize.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TkDataSize.Value = 500;
            this.TkDataSize.ValueChanged += new System.EventHandler(this.TkDataSize_ValueChanged);
            // 
            // LbRatio
            // 
            this.LbRatio.AutoSize = true;
            this.LbRatio.Location = new System.Drawing.Point(289, 264);
            this.LbRatio.Name = "LbRatio";
            this.LbRatio.Size = new System.Drawing.Size(77, 15);
            this.LbRatio.TabIndex = 12;
            this.LbRatio.Text = "Training/Test:";
            // 
            // LbNoise
            // 
            this.LbNoise.AutoSize = true;
            this.LbNoise.Location = new System.Drawing.Point(289, 192);
            this.LbNoise.Name = "LbNoise";
            this.LbNoise.Size = new System.Drawing.Size(40, 15);
            this.LbNoise.TabIndex = 11;
            this.LbNoise.Text = "Noise:";
            // 
            // LbDataSize
            // 
            this.LbDataSize.AutoSize = true;
            this.LbDataSize.Location = new System.Drawing.Point(289, 121);
            this.LbDataSize.Name = "LbDataSize";
            this.LbDataSize.Size = new System.Drawing.Size(74, 15);
            this.LbDataSize.TabIndex = 10;
            this.LbDataSize.Text = "Data set size:";
            // 
            // LbDataTitle
            // 
            this.LbDataTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LbDataTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbDataTitle.Location = new System.Drawing.Point(0, 0);
            this.LbDataTitle.Name = "LbDataTitle";
            this.LbDataTitle.Size = new System.Drawing.Size(427, 24);
            this.LbDataTitle.TabIndex = 9;
            this.LbDataTitle.Text = "Data Set";
            this.LbDataTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScNetwork
            // 
            this.ScNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScNetwork.Location = new System.Drawing.Point(0, 24);
            this.ScNetwork.Name = "ScNetwork";
            // 
            // ScNetwork.Panel1
            // 
            this.ScNetwork.Panel1.Controls.Add(this.DgTemplate);
            // 
            // ScNetwork.Panel2
            // 
            this.ScNetwork.Panel2.Controls.Add(this.GbOptions);
            this.ScNetwork.Size = new System.Drawing.Size(413, 304);
            this.ScNetwork.SplitterDistance = 241;
            this.ScNetwork.TabIndex = 0;
            // 
            // LbNetworkTitle
            // 
            this.LbNetworkTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LbNetworkTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbNetworkTitle.Location = new System.Drawing.Point(0, 0);
            this.LbNetworkTitle.Name = "LbNetworkTitle";
            this.LbNetworkTitle.Size = new System.Drawing.Size(413, 24);
            this.LbNetworkTitle.TabIndex = 8;
            this.LbNetworkTitle.Text = "Neural Network";
            this.LbNetworkTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnButtons
            // 
            this.PnButtons.Controls.Add(this.BtnRegenerate);
            this.PnButtons.Controls.Add(this.BtnCancel);
            this.PnButtons.Controls.Add(this.BtnCreate);
            this.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnButtons.Location = new System.Drawing.Point(0, 328);
            this.PnButtons.Name = "PnButtons";
            this.PnButtons.Size = new System.Drawing.Size(844, 51);
            this.PnButtons.TabIndex = 9;
            // 
            // BtnRegenerate
            // 
            this.BtnRegenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnRegenerate.Location = new System.Drawing.Point(12, 16);
            this.BtnRegenerate.Name = "BtnRegenerate";
            this.BtnRegenerate.Size = new System.Drawing.Size(87, 23);
            this.BtnRegenerate.TabIndex = 6;
            this.BtnRegenerate.Text = "Regenerate";
            this.BtnRegenerate.UseVisualStyleBackColor = true;
            this.BtnRegenerate.Click += new System.EventHandler(this.BtnRegenerate_Click);
            // 
            // FrmTemplate
            // 
            this.AcceptButton = this.BtnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(844, 379);
            this.Controls.Add(this.ScMain);
            this.Controls.Add(this.PnButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrmTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Templates";
            this.Load += new System.EventHandler(this.FrmTemplate_Load);
            this.GbOptions.ResumeLayout(false);
            this.GbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TkRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TkBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPlot)).EndInit();
            this.ScMain.Panel1.ResumeLayout(false);
            this.ScMain.Panel1.PerformLayout();
            this.ScMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
            this.ScMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TkRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TkNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TkDataSize)).EndInit();
            this.ScNetwork.Panel1.ResumeLayout(false);
            this.ScNetwork.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScNetwork)).EndInit();
            this.ScNetwork.ResumeLayout(false);
            this.PnButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox GbOptions;
        private RadioButton RbFully;
        private Button BtnCreate;
        private Button BtnCancel;
        private RadioButton RbCustom;
        private DataGridView DgTemplate;
        private DataGridViewTextBoxColumn CnLayers;
        private DataGridViewTextBoxColumn CnCount;
        private DataGridViewTextBoxColumn CnNeurons;
        private PictureBox PbPlot;
        private SplitContainer ScMain;
        private ComboBox CbDataSet;
        private ComboBox CbProblemType;
        private Label LbDataSet;
        private Label LbProblemType;
        private TrackBar TkRatio;
        private TrackBar TkNoise;
        private TrackBar TkDataSize;
        private Label LbRatio;
        private Label LbNoise;
        private Label LbDataSize;
        private Label LbDataTitle;
        private SplitContainer ScNetwork;
        private Label LbNetworkTitle;
        private Panel PnButtons;
        private TextBox TbNoise;
        private TextBox TbRatio;
        private TextBox TbDataSize;
        private ComboBox CbWeights;
        private Label LbWeights;
        private Label LbRate;
        private TextBox TbBatch;
        private TrackBar TkBatch;
        private Label LbBatch;
        private TextBox TbRate;
        private TrackBar TkRate;
        private Button BtnRegenerate;
    }
}