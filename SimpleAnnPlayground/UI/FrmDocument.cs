// <copyright file="FrmDocument.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Utils;

namespace SimpleAnnPlayground.UI
{
    /// <summary>
    /// Document options window.
    /// </summary>
    internal partial class FrmDocument : Form
    {
        /// <summary>
        /// Contains the words for each control.
        /// </summary>
        private static readonly Dictionary<string, List<string>> FormWords = new()
        {
            // Window text.
            { nameof(FrmDocument), new() { "Document options", "Opciones del documento" } },

            // Buttons texts.
            { nameof(BtnApply), new() { "&Apply", "&Aplicar" } },
            { nameof(BtnCancel), new() { "&Cancel", "&Cancelar" } },

            // Document size group.
            { nameof(GbSheetSize), new() { "Sheet size:", "Tamaño de la hoja:" } },
            { nameof(LbSheetWidth), new() { "Width:", "Ancho:" } },
            { nameof(LbSheetHeight), new() { "Height:", "Alto:" } },

            // Center cross group.
            { nameof(GbCenterCross), new() { "Center cross:", "Marca de origen:" } },
            { nameof(CkCrossVisible), new() { "Visible", "Visible" } },
            { nameof(LbCrossColor), new() { "Color:", "Color:" } },
        };

        private readonly WorkSheet _sheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmDocument"/> class.
        /// </summary>
        /// <param name="sheet">The document sheet.</param>
        public FrmDocument(WorkSheet sheet)
        {
            InitializeComponent();

            _sheet = sheet;
        }

        private void FrmDocument_Load(object sender, EventArgs e)
        {
            // Load document sheet size.
            TbSheetWidth.Text = _sheet.Size.Width.ToString();
            TbSheetHeight.Text = _sheet.Size.Height.ToString();

            // Load center cross properties.
            CkCrossVisible.Checked = _sheet.Cross.Visible;
            PbCrossColor.BackColor = _sheet.Cross.Color;

            // Getting application language from user settings.
            var formLanguage = Languages.GetApplicationLanguage();

            // Applying form language.
            Languages.ChangeFormLanguage(this, FormWords, formLanguage);
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            // Get the values from the window.
            _sheet.Resize(int.Parse(TbSheetWidth.Text), int.Parse(TbSheetHeight.Text));
            _sheet.Cross.Visible = CkCrossVisible.Checked;
            _sheet.Cross.Color = PbCrossColor.BackColor;
        }

        private void PbCrossColor_Click(object sender, EventArgs e)
        {
            if (CdCrossColor.ShowDialog(this) == DialogResult.OK)
            {
                PbCrossColor.BackColor = CdCrossColor.Color;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is(< '0' or > '9') and not '\x8')
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }
    }
}
