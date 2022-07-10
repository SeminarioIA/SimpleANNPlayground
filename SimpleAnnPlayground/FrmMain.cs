// <copyright file="FrmMain.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

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
        /// Initializes a new instance of the <see cref="FrmMain"/> class.
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Changing the form language
#pragma warning disable IDE0022 // Use expression body for methods
            Languages.ChangeFormLanguage(this, FormWords, Languages.Language.Spanish);
#pragma warning restore IDE0022 // Use expression body for methods
        }
    }
}