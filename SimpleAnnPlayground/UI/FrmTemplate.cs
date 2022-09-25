// <copyright file="FrmTemplate.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

// using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleAnnPlayground.UI
{
    /// <summary>
    /// Class for template window.
    /// </summary>
    public partial class FrmTemplate : Form
    {
        /// <summary>
        /// Contains the words for each control.
        /// </summary>
        private static readonly Dictionary<string, List<string>> FormWords = new()
        {
            // Window text.
            { nameof(FrmTemplate), new() { "Template", "Plantilla" } },

            // Labels.
            { nameof(labelInpText), new() { "Perceptrons", "Perceptrones" } },
            { nameof(labelHidNumLay), new() { "Hidden Layers", "Capas ocultas" } },
            { nameof(labelHidText), new() { "Perceptrons", "Perceptrones" } },
            { nameof(labelOutText), new() { "Perceptrons", "Perceptrones" } },
            { nameof(radioFully), new() { "Fully connected", "Totalmente conectado" } },
            { nameof(radioCustom), new() { "Custom connections", "Conexiones personalizadas" } },

            // Buttons.
            { nameof(CancelBtn), new() { "Cancel", "Cancelar" } },
            { nameof(GenerateBtn), new() { "Generate", "Generar" } },

            // Text areas.
            { nameof(TmptGroupBoxInput), new() { "Input Layer", "Capa de entrada" } },
            { nameof(TmptGroupBoxHidden), new() { "Hidden Layer", "Capa oculta" } },
            { nameof(TmptGroupBoxOutput), new() { "Output Layer", "Capa de salida" } },
            { nameof(TmptGroupBoxOptions), new() { "Options", "Opciones" } },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmTemplate"/> class.
        /// </summary>
        public FrmTemplate()
        {
            InitializeComponent();
            InputNeuronsAmount = "0";
            HiddenLayers = "0";
            HiddenNeuronsAmount = "0";
            OutputNeuronsAmount = "0";
            comboBoxInputNum.SelectedIndex = 0;
            comboBoxHidLayers.SelectedIndex = 0;
            comboBoxHidNumber.SelectedIndex = 0;
            comboBoxOutNum.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets or sets the data table.
        /// </summary>
        public string? InputNeuronsAmount { get; set; }

        /// <summary>
        /// Gets or sets the data table.
        /// </summary>
        public string? HiddenLayers { get; set; }

        /// <summary>
        /// Gets or sets the data table.
        /// </summary>
        public string? HiddenNeuronsAmount { get; set; }

        /// <summary>
        /// Gets or sets the data table.
        /// </summary>
        public string? OutputNeuronsAmount { get; set; }

        /// <summary>
        /// Shows the window and returns the selected data.
        /// </summary>
        /// <returns>True if there was selection made, otherwise false.</returns>
        internal bool GetData()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return true;
            }

            return false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FrmTemplate_Load(object sender, EventArgs e)
        {
            // Getting application language from user settings.
            var formLanguage = Languages.GetApplicationLanguage();

            // Applying form language.
            Languages.ChangeFormLanguage(this, FormWords, formLanguage);
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            InputNeuronsAmount = comboBoxInputNum.SelectedItem.ToString();
            HiddenLayers = comboBoxHidLayers.SelectedItem.ToString();
            HiddenNeuronsAmount = comboBoxHidNumber.SelectedItem.ToString();
            OutputNeuronsAmount = comboBoxOutNum.SelectedItem.ToString();
        }
    }
}
