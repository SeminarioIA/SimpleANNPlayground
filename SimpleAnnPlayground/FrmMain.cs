// <copyright file="FrmMain.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Networks;
using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Debugging;
using SimpleAnnPlayground.Graphical;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Environment.EventsArgs;
using SimpleAnnPlayground.Graphical.Tools;
using SimpleAnnPlayground.Graphical.Visualization;
using SimpleAnnPlayground.Screens;
using SimpleAnnPlayground.Storage;
using SimpleAnnPlayground.UI;
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
            { "Spanish", new() { "Spanish", "Espa�ol" } },

            // Window text.
            { nameof(FrmMain), new() { "Interactive Artificial Neural Network", "Red Neuronal Artificial Interactiva" } },

            // File menus texts.
            { nameof(MnuFile), new() { "&File", "&Archivo" } },
            { nameof(MnuFileNew), new() { "&New", "&Nuevo" } },
            { nameof(MnuFileOpen), new() { "&Open", "&Abrir" } },
            { nameof(MnuFileSave), new() { "&Save", "&Guardar" } },
            { nameof(MnuFileSaveAs), new() { "Save &As", "Guardar &como" } },
            { nameof(MnuFileExit), new() { "&Exit", "&Salir" } },

            // Edit menus texts.
            { nameof(MnuEdit), new() { "&Edit", "&Edici�n" } },
            { nameof(MnuEditUndo), new() { "&Undo", "&Deshacer" } },
            { nameof(MnuEditRedo), new() { "&Redo", "&Rehacer" } },
            { nameof(MnuEditDelete), new() { "&Delete", "&Eliminar" } },
            { nameof(MnuEditCopy), new() { "&Copy", "&Copiar" } },
            { nameof(MnuEditCut), new() { "Cu&t", "Cor&tar" } },
            { nameof(MnuEditPaste), new() { "&Paste", "&Pegar" } },
            { nameof(MnuEditOptions), new() { "&Options", "&Opciones" } },

            // View menus texts.
            { nameof(MnuView), new() { "&View", "&Ver" } },
            { nameof(MnuViewCenterScreen), new() { "&Center screen,", "&Centrar pantalla" } },

            // Tools menus texts.
            { nameof(MnuTools), new() { "&Tools", "&Herramientas" } },
            { nameof(MnuToolsLanguage), new () { "&Language", "&Idioma" } },

            // Help menus texts.
            { nameof(MnuHelp), new() { "&Help", "Ay&uda" } },
            { nameof(MnuHelpAbout), new() { "&About", "&Acerca de" } },

            // Buttons texts.
            { nameof(BtnNew), new() { "New", "Nuevo" } },
            { nameof(BtnOpen), new() { "Open", "Abrir" } },
            { nameof(BtnSave), new() { "Save", "Guardar" } },
            { nameof(BtnInputNeurone), new() { "Input", "Entrada" } },
            { nameof(BtnInternalNeurone), new() { "Internal", "Interna" } },
            { nameof(BtnOutputNeurone), new() { "Output", "Salida" } },
            { nameof(BtnCheck), new() { "Check", "Verificar" } },
            { nameof(BtnClean), new() { "Clean", "Limpiar" } },
            { nameof(BtnData), new() { "Data", "Datos" } },
            { nameof(BtnTraining), new() { "Training", "Entrenamiento" } },
            { nameof(BtnTest), new() { "Testing", "Prueba" } },
            { nameof(BtnTemplate), new() { "Template", "Plantilla" } },

            // Context menus.
            { nameof(MnuContextLinkTo), new() { "&Link to", "&Asignar a" } },
            { nameof(MnuContextCopy), new() { "&Copy", "&Copiar" } },
            { nameof(MnuContextCut), new() { "Cu&t", "Cor&tar" } },
            { nameof(MnuContextPaste), new() { "&Paste", "&Pegar" } },
            { nameof(MnuContextDelete), new() { "&Delete", "&Eliminar" } },
            { nameof(MnuContextCenterScreen), new() { "&Center screen,", "&Centrar pantalla" } },

            // Message box.
            { nameof(ShowSaveDialog), new() { "If you have made changes to the document they will be lost, do you want to save your changes before continuing?", "Si ha hecho cambios en el documento se perder�n, �desea guardar los cambios antes de seguir?" } },
            { "Warning", new() { "Warning", "Advertencia" } },

            // Template menus.
            { nameof(FrmTemplate), new() { "Template", "Plantilla" } },
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
            _workspace = new Workspace(PicWorkspace, HsbMain, VsbMain, TtMessages);
            _workspace.MouseTool.MouseMove += MouseTool_MouseMove;
            _workspace.MouseTool.ObjectAdded += MouseTool_ObjectAdded;
            _workspace.MouseTool.SelectionChanged += Workspace_SelectionChanged;
            _workspace.SelectionChanged += Workspace_SelectionChanged;
            _workspace.Actions.ActionPerformed += Actions_ActionPerformed;
            _network = new Network(_workspace);
            _fileManager = new TextFileManager();
            _fileManager.AddFileFormat("annpj", "Artificial neural network project");
            _fileManager.FilePathChanged += FileManager_FilePathChanged;

#if DEBUG
            // Add debug elements.
            MnuDebug.Visible = true;
            _frmElementDesigner = new FrmElementDesigner();
            _frmObjectsViewer = new FrmObjectsViewer(_workspace);
            _frmActionsViewer = new FrmActionsViewer(_workspace.Actions);
#endif
            _frmData = new FrmData(_workspace);
            TspExecution.Visible = false;
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

        private DialogResult ShowSaveDialog() => MessageBox.Show(Languages.GetString(nameof(ShowSaveDialog), FormWords), Languages.GetString("Warning", FormWords), MessageBoxButtons.YesNoCancel);

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Getting application language from user settings.
            var formLanguage = Languages.GetApplicationLanguage();

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

            // Create a new file.
            _fileManager.New(_workspace.GenerateDocument().Serialize());
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
            if (_fileManager.HadChanged(_workspace.GenerateDocument().Serialize()))
            {
                DialogResult selection = ShowSaveDialog();
                if (selection == DialogResult.OK)
                {
                    MnuFileSave_Click(sender, e);
                }
                else if (selection == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            e.Cancel = false;
        }

        private void UncheckToolsButtons(ToolStripButton? button)
        {
            var insertButtons = new ToolStripButton[] { BtnInputNeurone, BtnInternalNeurone, BtnOutputNeurone };

            if (button?.Checked ?? false) button = null;

            foreach (var btn in insertButtons)
            {
                btn.Checked = btn == button;
            }
        }

        private void BtnInsertNeurone_Click(object? sender, EventArgs e)
        {
            ToolStripButton? button = sender as ToolStripButton;
            UncheckToolsButtons(button);
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
            if (_workspace.ReadOnly) return;
            _workspace.Actions.Undo();
            MnuEditUndo.Enabled = _workspace.Actions.CanUndo;
            MnuEditRedo.Enabled = _workspace.Actions.CanRedo;
            _frmActionsViewer.RefreshActions();
        }

        private void MnuEditRedo_Click(object sender, EventArgs e)
        {
            if (_workspace.ReadOnly) return;
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
            if (_workspace.ReadOnly) return;
            _workspace.Actions.AddRemoveAction(Actions.RecordableAction.ActionType.Deleted);
        }

        private void MnuEditCopy_Click(object sender, EventArgs e)
        {
            if (_workspace.ReadOnly || !_workspace.Canvas.AnySelected()) return;
            var copyBag = new ClipboardBag(_workspace);
            Clipboard.SetData("SimpleAnnPlayground.Copy", copyBag.Serialize());
            MnuEditPaste.Enabled = true;
        }

        private void MnuEditPaste_Click(object sender, EventArgs e)
        {
            if (_workspace.ReadOnly) return;
            if (Clipboard.GetData("SimpleAnnPlayground.Copy") is string data)
            {
                var pasteBag = ClipboardBag.Deserialize(_workspace, data);
                pasteBag.Paste(_workspace);
            }
        }

        private void MnuEditCut_Click(object sender, EventArgs e)
        {
            if (_workspace.ReadOnly || !_workspace.Canvas.AnySelected()) return;
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
            BtnTest.Enabled = false;
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

        private void MnuFileNew_Click(object sender, EventArgs e)
        {
            if (_fileManager.HadChanged(_workspace.GenerateDocument().Serialize()))
            {
                DialogResult selection = ShowSaveDialog();
                if (selection == DialogResult.OK)
                {
                    MnuFileSave_Click(sender, e);
                }
                else if (selection == DialogResult.Cancel)
                {
                    return;
                }
            }

            _workspace.Clean();
            _fileManager.New(_workspace.GenerateDocument().Serialize());
            UncheckToolsButtons(null);
        }

        private void MnuFileOpen_Click(object sender, EventArgs e)
        {
            if (_fileManager.HadChanged(_workspace.GenerateDocument().Serialize()))
            {
                DialogResult selection = ShowSaveDialog();
                if (selection == DialogResult.OK)
                {
                    MnuFileSave_Click(sender, e);
                }
                else if (selection == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (_fileManager.Open() && _fileManager.FileContent is string data)
            {
                _workspace.LoadDocument(Document.Deserialize(data));
                UncheckToolsButtons(null);
            }
        }

        private void FileManager_FilePathChanged(object? sender, EventArgs e)
        {
            Text = "SimpleAnnPlayground" + (string.IsNullOrWhiteSpace(_fileManager.FileName) ? string.Empty : $" - {_fileManager.FileName}");
        }

        private void ContextMenuState(bool link, bool copyPaste, bool delete)
        {
            MnuContextLinkTo.Visible = link;
            MnuContextSep1.Visible = link;
            MnuContextCopy.Visible = copyPaste;
            MnuContextCut.Visible = copyPaste;
            MnuContextPaste.Visible = copyPaste;
            MnuContextSep2.Visible = copyPaste && delete;
            MnuContextDelete.Visible = delete;
            MnuContextCenterScreen.Visible = !link && !copyPaste && !delete;
        }

        private void CmsDraw_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(_workspace.ReadOnly)
            {
                e.Cancel = true;
                return;
            }

            switch (_workspace.Canvas.GetSelectedObjects().Count)
            {
                case 0:
                {
                    if (_workspace.MouseTool.GetConnectionOver() is Connection)
                    {
                        ContextMenuState(link: false, copyPaste: false, delete: true);
                    }
                    else
                    {
                        ContextMenuState(link: false, copyPaste: false, delete: false);
                    }

                    break;
                }

                case 1:
                {
                    if (_workspace.MouseTool.GetObjectOver() is CanvasObject obj)
                    {
                        switch (obj)
                        {
                            case Input input:
                                ContextMenuState(link: _workspace.DataTable.Inputs.Any(), copyPaste: true, delete: true);
                                MnuContextLinkTo.Tag = input;
                                MnuContextLinkTo.DropDownItems.Clear();
                                foreach (DataLabel label in _workspace.DataTable.Inputs)
                                {
                                    var mnuContextLinkToInput = MnuContextLinkTo.DropDownItems.Add(label.Text);
                                    mnuContextLinkToInput.Click += MnuContextLinkToInput_Click;
                                    mnuContextLinkToInput.Tag = label;
                                }

                                break;
                            case Output output:
                                ContextMenuState(link: _workspace.DataTable.Outputs.Any(), copyPaste: true, delete: true);
                                MnuContextLinkTo.Tag = output;
                                MnuContextLinkTo.DropDownItems.Clear();
                                foreach (DataLabel label in _workspace.DataTable.Outputs)
                                {
                                    var mnuContextLinkToOutput = MnuContextLinkTo.DropDownItems.Add(label.Text);
                                    mnuContextLinkToOutput.Click += MnuContextLinkToOutput_Click;
                                    mnuContextLinkToOutput.Tag = label;
                                }

                                break;
                            case Internal:
                                ContextMenuState(link: false, copyPaste: true, delete: true);
                                break;
                        }
                    }

                    break;
                }

                default:
                {
                    ContextMenuState(link: false, copyPaste: false, delete: false);
                    break;
                }
            }
        }

        private void MnuContextLinkToInput_Click(object? sender, EventArgs e)
        {
            if (MnuContextLinkTo.Tag is Input input && sender is ToolStripItem item && item.Tag is DataLabel label)
            {
                input.DataLabel = label;
                _workspace.Refresh();
            }
        }

        private void MnuContextLinkToOutput_Click(object? sender, EventArgs e)
        {
            if (MnuContextLinkTo.Tag is Output output && sender is ToolStripItem item && item.Tag is DataLabel label)
            {
                output.DataLabel = label;
                _workspace.Refresh();
            }
        }

        private void BtnTraining_Click(object sender, EventArgs e)
        {
            MnuEdit.Enabled = false;
            TspEdition.Visible = false;
            TspExecution.Visible = true;
            UncheckToolsButtons(null);
            _workspace.SetReadOnly();
            _network.Start();
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            MnuEdit.Enabled = false;
            TspEdition.Visible = false;
            TspExecution.Visible = true;
            UncheckToolsButtons(null);
            _workspace.SetReadOnly();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            MnuEdit.Enabled = true;
            TspEdition.Visible = true;
            TspExecution.Visible = false;
            _network.Stop();
            _workspace.SetEditable();
        }

        private void BtnCxStep_Click(object sender, EventArgs e)
        {
            _network.Execution?.StepIntoCx();
        }

        private void BtnTemplate_Click(object sender, EventArgs e)
        {
            if (_fileManager.HadChanged(_workspace.GenerateDocument().Serialize()))
            {
                DialogResult selection = ShowSaveDialog();
                if (selection == DialogResult.OK)
                {
                    MnuFileSave_Click(sender, e);
                }
                else if (selection == DialogResult.Cancel)
                {
                    return;
                }
            }

            using (var frmTemplate = new FrmTemplate())
            {
                if (frmTemplate.GetData())
                {
                    _workspace.Clean();
                    int numberOfLayers = 2;
                    if (frmTemplate.HiddenLayers != null)
                    {
                        numberOfLayers += int.Parse(frmTemplate.HiddenLayers);
                    }

                    int eachLayerSpaceWidth = _workspace.WorkSheet.Size.Width / numberOfLayers;
                    int inputLayerSpaceWidth = -(_workspace.WorkSheet.Size.Width / 2) + eachLayerSpaceWidth / 2;
                    int numberOfInputNeurons = 0;
                    if (frmTemplate.InputNeuronsAmount != null)
                    {
                        numberOfInputNeurons = int.Parse(frmTemplate.InputNeuronsAmount);
                    }

                    int eachInputNeuronSpace = _workspace.WorkSheet.Size.Height / numberOfInputNeurons;
                    int inputLayerSpaceHeight = -_workspace.WorkSheet.Size.Height / 2;
                    for (int i = 0; i < numberOfInputNeurons; i++)
                    {
                        inputLayerSpaceHeight += eachInputNeuronSpace / 2;
                        _workspace.MouseTool.InsertObject(new Ann.Neurons.Input(_workspace.Canvas, inputLayerSpaceWidth, inputLayerSpaceHeight));
                        _workspace.MouseTool.FinishOperation();
                        inputLayerSpaceHeight += eachInputNeuronSpace / 2;
                    }

                    int hiddenLayerSpaceWidth = -(_workspace.WorkSheet.Size.Width / 2) + eachLayerSpaceWidth;
                    int hiddenLayerSpaceHeight = -_workspace.WorkSheet.Size.Height / 2;
                    int numberOfHiddenNeurons = 0;
                    if (frmTemplate.HiddenNeuronsAmount != null)
                    {
                        numberOfHiddenNeurons = int.Parse(frmTemplate.HiddenNeuronsAmount);
                    }

                    int eachHiddenNeuronSpace = _workspace.WorkSheet.Size.Height / numberOfHiddenNeurons;
                    for (int i = 0; i < numberOfLayers - 2; i++)
                    {
                        hiddenLayerSpaceWidth += eachLayerSpaceWidth / 2;
                        for (int j = 0; j < numberOfHiddenNeurons; j++)
                        {
                            hiddenLayerSpaceHeight += eachHiddenNeuronSpace / 2;
                            _workspace.MouseTool.InsertObject(new Ann.Neurons.Internal(_workspace.Canvas, hiddenLayerSpaceWidth, hiddenLayerSpaceHeight));
                            _workspace.MouseTool.FinishOperation();
                            hiddenLayerSpaceHeight += eachHiddenNeuronSpace / 2;
                        }

                        hiddenLayerSpaceWidth += eachLayerSpaceWidth / 2;
                        hiddenLayerSpaceHeight = -_workspace.WorkSheet.Size.Height / 2;
                    }

                    int outputLayerSpaceWidth = hiddenLayerSpaceWidth + eachLayerSpaceWidth / 2;
                    int numberOfOutputNeurons = 0;
                    if (frmTemplate.OutputNeuronsAmount != null)
                    {
                        numberOfOutputNeurons = int.Parse(frmTemplate.OutputNeuronsAmount);
                    }

                    int eachOutputNeuronSpace = _workspace.WorkSheet.Size.Height / numberOfOutputNeurons;
                    int outputLayerSpaceHeight = -_workspace.WorkSheet.Size.Height / 2;
                    for (int i = 0; i < numberOfOutputNeurons; i++)
                    {
                        outputLayerSpaceHeight += eachOutputNeuronSpace / 2;
                        _workspace.MouseTool.InsertObject(new Ann.Neurons.Output(_workspace.Canvas, outputLayerSpaceWidth, outputLayerSpaceHeight));
                        _workspace.MouseTool.FinishOperation();
                        outputLayerSpaceHeight += eachOutputNeuronSpace / 2;
                    }
                }
                else
                {
                    Debug.WriteLine("Cancel selected");
                }
            }
        }
    }
}