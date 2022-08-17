// <copyright file="FrmMain.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Networks;
using SimpleAnnPlayground.Debugging;
using SimpleAnnPlayground.Graphical;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Environment.EventsArgs;
using SimpleAnnPlayground.Graphical.Tools;
using SimpleAnnPlayground.Screens;
using SimpleAnnPlayground.Utils;
using SimpleAnnPlayground.Utils.FileManagment;
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
            { "English", new() { "English", "Ingles" } },

            // Spanish language text.
            { "Spanish", new() { "Spanish", "Español" } },

            // Window text.
            { "FrmMain", new() { "Interactive Artificial Neural Network", "Red Neuronal Artificial Interactiva" } },

            // File menus texts.
            { "MnuFile", new() { "&File", "&Archivo" } },
            { "MnuFileNew", new() { "&New", "&Nuevo" } },
            { "MnuFileOpen", new() { "&Open", "&Abrir" } },
            { "MnuFileSave", new() { "&Save", "&Guardar" } },
            { "MnuFileSaveAs", new() { "Save &As", "Guardar &como" } },
            { "MnuFileExit", new() { "&Exit", "&Salir" } },

            // Edit menus texts.
            { "MnuEdit", new() { "&Edit", "&Edición" } },
            { "MnuEditUndo", new() { "&Undo", "&Deshacer" } },
            { "MnuEditRedo", new() { "&Redo", "&Rehacer" } },
            { "MnuEditDelete", new() { "&Delete", "&Eliminar" } },
            { "MnuEditCopy", new() { "&Copy", "&Copiar" } },
            { "MnuEditCut", new() { "Cu&t", "Cor&tar" } },
            { "MnuEditPaste", new() { "&Paste", "&Pegar" } },
            { "MnuEditOptions", new() { "&Options", "&Opciones" } },

            // View menus texts.
            { "MnuView", new() { "&View,", "&Ver" } },
            { "MnuViewCenterScreen", new() { "&Center screen,", "&Centrar pantalla" } },

            // Tools menus texts.
            { "MnuTools", new() { "&Tools", "&Herramientas" } },
            { "MnuToolsLanguage", new () { "&Language", "&Idioma" } },

            // Help menus texts.
            { "MnuHelp", new() { "&Help", "Ay&uda" } },
            { "MnuHelpAbout", new() { "&About", "&Acerca de" } },

            // Buttons texts.
            { "BtnNew", new() { "New", "Nuevo" } },
            { "BtnOpen", new() { "Open", "Abrir" } },
            { "BtnSave", new() { "Save", "Guardar" } },
            { "BtnInputNeurone", new() { "Input", "Entrada" } },
            { "BtnInternalNeurone", new() { "Internal", "Interna" } },
            { "BtnOutputNeurone", new() { "Output", "Salida" } },
        };

#if DEBUG
        /// <summary>
        /// The form to design components using elements.
        /// </summary>
        private readonly FrmElementDesigner _frmElementDesigner;

        /// <summary>
        /// The form to view the selected object properties.
        /// </summary>
        private readonly FrmObjectsViewer _frmObjectsViewer;

        /// <summary>
        /// The form to view the document actions.
        /// </summary>
        private readonly FrmActionsViewer _frmActionsViewer;
#endif

        /// <summary>
        /// The form to import the model data.
        /// </summary>
        private readonly FrmData _frmData;

        /// <summary>
        /// The design workspace area.
        /// </summary>
        private readonly Workspace _workspace;

        /// <summary>
        /// The neural network to be executed.
        /// </summary>
        private readonly Network _network;

        /// <summary>
        /// The file manager to handle file operations.
        /// </summary>
        private readonly TextFileManager _fileManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmMain"/> class.
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            // Add workspace object.
            _workspace = new Workspace(PicWorkspace, HsbMain, VsbMain);
            _workspace.MouseTool.MouseMove += MouseTool_MouseMove;
            _workspace.MouseTool.ObjectAdded += MouseTool_ObjectAdded;
            _workspace.MouseTool.SelectionChanged += Workspace_SelectionChanged;
            _workspace.SelectionChanged += Workspace_SelectionChanged;
            _workspace.Actions.ActionPerformed += Actions_ActionPerformed;
            _network = new Network(_workspace);
            _fileManager = new TextFileManager();
            _fileManager.AddFileFormat("annpj", "Artificial neural network project");

#if DEBUG
            // Add debug elements.
            MnuDebug.Visible = true;
            _frmElementDesigner = new FrmElementDesigner();
            _frmObjectsViewer = new FrmObjectsViewer(_workspace);
            _frmActionsViewer = new FrmActionsViewer(_workspace.Actions);
#endif
            _frmData = new FrmData();
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

        private void Workspace_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
#if DEBUG
            _frmObjectsViewer.SelectObject(e.SelectedObject ?? _workspace);
#endif
            MnuEditDelete.Enabled = e.SelectedObject != null;
            MnuEditCopy.Enabled = e.SelectedObject != null;
            MnuEditCut.Enabled = e.SelectedObject != null;
        }

        private void MouseTool_MouseMove(object? sender, EventArgs e)
        {
            LblMousePosition.Text = _workspace.MouseTool.Location is PointF point ? $"X: {point.X}, Y: {point.Y}" : "X: -, Y: -";
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

        private void MnuDebugElementDesigner_Click(object sender, EventArgs e)
        {
#if DEBUG
            _frmElementDesigner.Show(this);
            ReloadComponents();
#endif
        }

        private void MnuDebugObjectsViewer_Click(object sender, EventArgs e)
        {
#if DEBUG
            _frmObjectsViewer.Show(this);
#endif
        }

        private void MnuDebugActionsViewer_Click(object sender, EventArgs e)
        {
#if DEBUG
            _frmActionsViewer.RefreshActions();
            _frmActionsViewer.Show(this);
#endif
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void BtnInsertNeurone_Click(object? sender, EventArgs e)
        {
            var insertButtons = new ToolStripButton[] { BtnInputNeurone, BtnInternalNeurone, BtnOutputNeurone };
            ToolStripButton? button = sender as ToolStripButton;

            if (button?.Checked ?? false) button = null;

            foreach (var btn in insertButtons)
            {
                btn.Checked = btn == button;
            }

            if (button == BtnInputNeurone) _workspace.MouseTool.InsertObject(new Ann.Neurons.Input(_workspace.Canvas, 0, 0));
            else if (button == BtnInternalNeurone) _workspace.MouseTool.InsertObject(new Ann.Neurons.Internal(_workspace.Canvas, 0, 0));
            else if (button == BtnOutputNeurone) _workspace.MouseTool.InsertObject(new Ann.Neurons.Output(_workspace.Canvas, 0, 0));
            else _workspace.MouseTool.CancelOperation();
        }

        private void MouseTool_ObjectAdded(object? sender, ObjectAddedEventArgs e)
        {
            BtnInsertNeurone_Click(null, new EventArgs());
        }

        private void LbZoom_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Label label)
            {
                label.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void LbZoom_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Label label)
            {
                label.BorderStyle = BorderStyle.None;
            }
        }

        private void LbZoomOut_Click(object sender, EventArgs e)
        {
            _workspace.ZoomOut();
            LbZoom.Text = $"{_workspace.Zoom} %";
        }

        private void LbZoomIn_Click(object sender, EventArgs e)
        {
            _workspace.ZoomIn();
            LbZoom.Text = $"{_workspace.Zoom} %";
        }

        private void LbZoom_Click(object sender, EventArgs e)
        {
            _workspace.RestoreZoom();
            LbZoom.Text = $"{_workspace.Zoom} %";
        }

        private void MnuViewCenterScreen_Click(object sender, EventArgs e)
        {
            _workspace.CenterSheetView();
        }

        private void MnuEditUndo_Click(object sender, EventArgs e)
        {
            _workspace.Actions.Undo();
            MnuEditUndo.Enabled = _workspace.Actions.CanUndo;
            MnuEditRedo.Enabled = _workspace.Actions.CanRedo;
            _frmActionsViewer.RefreshActions();
        }

        private void MnuEditRedo_Click(object sender, EventArgs e)
        {
            _workspace.Actions.Redo();
            MnuEditUndo.Enabled = _workspace.Actions.CanUndo;
            MnuEditRedo.Enabled = _workspace.Actions.CanRedo;
            _frmActionsViewer.RefreshActions();
        }

        private void Actions_ActionPerformed(object? sender, EventArgs e)
        {
            MnuEditUndo.Enabled = _workspace.Actions.CanUndo;
            MnuEditRedo.Enabled = _workspace.Actions.CanRedo;
            BtnTraining.Enabled = false;
            BtnTest.Enabled = false;
            _frmActionsViewer.RefreshActions();
        }

        private void MnuEditDelete_Click(object sender, EventArgs e)
        {
            _workspace.Actions.AddRemoveAction(Actions.RecordableAction.ActionType.Deleted);
        }

        private void MnuEditCopy_Click(object sender, EventArgs e)
        {
            if (!_workspace.Canvas.AnySelected()) return;
            var copyBag = new ClipboardBag(_workspace);
            Clipboard.SetData("SimpleAnnPlayground.Copy", copyBag.Serialize());
            MnuEditPaste.Enabled = true;
        }

        private void MnuEditPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetData("SimpleAnnPlayground.Copy") is string data)
            {
                var pasteBag = ClipboardBag.Deserialize(data);
                pasteBag.Paste(_workspace);
            }
        }

        private void MnuEditCut_Click(object sender, EventArgs e)
        {
            if (!_workspace.Canvas.AnySelected()) return;
            var cutBag = new ClipboardBag(_workspace);
            Clipboard.SetData("SimpleAnnPlayground.Copy", cutBag.Serialize());
            MnuEditPaste.Enabled = true;
            _workspace.Actions.AddRemoveAction(Actions.RecordableAction.ActionType.Cut);
        }

        private void BtnData_Click(object sender, EventArgs e)
        {
            _frmData.Show(this);
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            bool result = _network.Build();
            BtnTraining.Enabled = result;
            BtnTest.Enabled = result;
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            _network.Clean();
        }

        private void MnuFileSave_Click(object sender, EventArgs e)
        {
            _ = _fileManager.Save(_workspace.GenerateDocument().Serialize());
        }

        private void MnuFileSaveAs_Click(object sender, EventArgs e)
        {
            _ = _fileManager.SaveAs(_workspace.GenerateDocument().Serialize());
        }
    }
}