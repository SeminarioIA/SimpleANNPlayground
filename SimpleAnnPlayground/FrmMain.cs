// <copyright file="FrmMain.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Debugging;
using SimpleAnnPlayground.Graphical;
using System.Diagnostics;

namespace SimpleAnnPlayground
{
    /// <summary>
    /// Main window for the application.
    /// </summary>
    public partial class FrmMain : Form
    {
        /// <summary>
        /// Contains the words for each control.
        /// </summary>
        private static readonly Dictionary<string, List<string>> FormWords = new ()
        {
            // English language text.
            { "English", new () { "English", "Ingles" } },

            // Spanish language text.
            { "Spanish", new () { "Spanish", "Español" } },

            // Window text.
            { "FrmMain", new () { "Interactive Artificial Neural Network", "Red Neuronal Artificial Interactiva" } },

            // File menus texts.
            { "MnuFile", new () { "&File", "&Archivo" } },
            { "MnuFileNew", new () { "&New", "&Nuevo" } },
            { "MnuFileOpen", new () { "&Open", "&Abrir" } },
            { "MnuFileSave", new () { "&Save", "&Guardar" } },
            { "MnuFileSaveAs", new () { "Save &As", "Guardar &como" } },
            { "MnuFileExit", new () { "&Exit", "&Salir" } },

            // Edit menus texts.
            { "MnuEdit", new () { "&Edit", "&Edición" } },
            { "MnuEditUndo", new () { "&Undo", "&Deshacer" } },
            { "MnuEditRedo", new () { "&Redo", "&Rehacer" } },
            { "MnuEditDelete", new () { "&Delete", "&Eliminar" } },
            { "MnuEditCopy", new () { "&Copy", "&Copiar" } },
            { "MnuEditCut", new () { "Cu&t", "Cor&tar" } },
            { "MnuEditPaste", new () { "&Paste", "&Pegar" } },
            { "MnuEditOptions", new () { "&Options", "&Opciones" } },

            // Tools menus texts.
            { "MnuTools", new () { "&Tools", "&Herramientas" } },
            { "MnuToolsLanguage", new () { "&Language", "&Idioma" } },

            // Help menus texts.
            { "MnuHelp", new () { "&Help", "Ay&uda" } },
            { "MnuHelpAbout", new () { "&About", "&Acerca de" } },

            // Buttons texts.
            { "BtnNew", new () { "New", "Nuevo" } },
            { "BtnOpen", new () { "Open", "Abrir" } },
            { "BtnSave", new () { "Save", "Guardar" } },
            { "BtnInputNeurone", new () { "Input", "Entrada" } },
            { "BtnInternalNeurone", new () { "Internal", "Interna" } },
            { "BtnOutputNeurone", new () { "Output", "Salida" } },
        };

        /// <summary>
        /// The main canvas to be displayed by the application.
        /// </summary>
        private readonly Canvas _picture;

        /// <summary>
        /// The shadow canvas to save the current state.
        /// </summary>
        private readonly Canvas _shadow;

        /// <summary>
        /// The form to design components using elements.
        /// </summary>
        private readonly FrmElementDesigner _frmElementDesigner;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmMain"/> class.
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

#if DEBUG
            // Add debug elements.
            MnuDebug.Visible = true;
#endif
            _frmElementDesigner = new FrmElementDesigner();

            _picture = new Canvas();
            _shadow = new Canvas();
        }

        /// <summary>
        /// Reloads the graphical components from the file system.
        /// </summary>
        internal void ReloadComponents()
        {
            string path = Debugger.IsAttached ? @"..\..\..\Graphical\Components" : ".";
            Component.ReloadComponents(path);
            PicWorkspace.Invalidate();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Getting application language from user settings.
            Languages.Language formLanguage = Enum.TryParse(typeof(Languages.Language), Properties.Settings.Default.DefaultLanguage, out object? objLanguage) && objLanguage is not null
                ? (Languages.Language)objLanguage
                : Languages.Language.English;

            // Filling language menu
            foreach (Languages.Language language in Enum.GetValues(typeof(Languages.Language)))
            {
                if (MnuToolsLanguage.DropDownItems.Add(language.ToString()) is ToolStripMenuItem mnuLang)
                {
                    // Set language item name
                    mnuLang.Name = language.ToString();

                    // Add item Click event
                    mnuLang.Click += MnuLang_Click;

                    // Store the language represented by the item in the object tag.
                    mnuLang.Tag = language;

                    // Check the item to let know the user which language is selected.
                    if (language == formLanguage) mnuLang.Checked = true;
                }
            }

            // Applying form language.
            Languages.ChangeFormLanguage(this, FormWords, formLanguage);

            // Load components
            Component.ReloadComponents(@"Graphical\Components");
        }

        private void MnuLang_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem selectetItem)
            {
                // Get the new selected language.
                Languages.Language language = (Languages.Language)selectetItem.Tag;

                // Apply language to the form.
                Languages.ChangeFormLanguage(this, FormWords, language);

                // Uncheck all the language items and check only the selected one.
                foreach (ToolStripMenuItem item in MnuToolsLanguage.DropDownItems)
                {
                    item.Checked = item == selectetItem;
                }

                // Save language selection in the application settings.
                Properties.Settings.Default.DefaultLanguage = language.ToString();
                Properties.Settings.Default.Save();
            }
        }

        private void MnuElementDesigner_Click(object sender, EventArgs e)
        {
            _frmElementDesigner.Show(this);
            ReloadComponents();
        }

        private void BtnInputNeurone_Click(object sender, EventArgs e)
        {
            var neuron = new Ann.Neurons.Input(5, 30);
            _picture.Objects.Add(neuron);
            _shadow.Objects.Add(neuron);
            PicWorkspace.Invalidate();
        }

        private void BtnInternalNeurone_Click(object sender, EventArgs e)
        {
            var neuron = new Ann.Neurons.Internal(50, 30);
            _picture.Objects.Add(neuron);
            _shadow.Objects.Add(neuron);
            PicWorkspace.Invalidate();
        }

        private void PicWorkspace_Paint(object sender, PaintEventArgs e)
        {
            _picture.Draw(e.Graphics);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}