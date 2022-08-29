// <copyright file="FrmTemplate.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

// using SimpleAnnPlayground.Graphical.Environment;
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
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FrmTemplate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            _ = Owner.Focus();
        }

        private void FrmTemplate_Load(object sender, EventArgs e)
        {
            // Getting application language from user settings.
            var formLanguage = Languages.GetApplicationLanguage();

            // Applying form language.
            Languages.ChangeFormLanguage(this, FormWords, formLanguage);
        }
    }
}
