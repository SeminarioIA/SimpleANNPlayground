// <copyright file="FrmElementDesigner.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical;
using SimpleAnnPlayground.Utils.FileManagment;

namespace SimpleAnnPlayground.Debugging
{
    /// <summary>
    /// Element Designer form to create visual elements.
    /// </summary>
    public partial class FrmElementDesigner : Form
    {
        /// <summary>
        /// The component being edited.
        /// </summary>
        private readonly Component _component;

        /// <summary>
        /// Indicates if there is an operation being executed.
        /// </summary>
        private bool _busy;

        /// <summary>
        /// The component center is being drawn.
        /// </summary>
        private bool _drawCenter;

        /// <summary>
        /// The state to draw the component.
        /// </summary>
        private Component.State _state = Component.State.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmElementDesigner"/> class.
        /// </summary>
        public FrmElementDesigner()
        {
            InitializeComponent();

            _component = new Component();

            FileManager = new TextFileManager();
            FileManager.AddFileFormat("cmpt", "Draw component.");
            FileManager.FilePathChanged += FileManager_FilePathChanged;

            _busy = true;
            foreach (Component.State mode in Enum.GetValues(typeof(Component.State)))
            {
                _ = LstModes.Items.Add(mode);
            }

            _busy = false;
        }

        /// <summary>
        /// Gets the <see cref="FileManager"/> for the current document.
        /// </summary>
        public TextFileManager FileManager { get; private set; }

        private void FrmElementDesigner_Load(object sender, EventArgs e)
        {
            Element.AddMenuPerElement(BtnAdd, BtnAdd_Click);
        }

        /// <summary>
        /// Ocurs when the file path changes and inserts the file name into the windows title bar.
        /// </summary>
        private void FileManager_FilePathChanged(object? sender, EventArgs e)
        {
            Text = "Elements Designer" + (string.IsNullOrWhiteSpace(FileManager.FileName) ? string.Empty : $" - {FileManager.FileName}");
        }

        /// <summary>
        /// Adds a new element to the draw.
        /// </summary>
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem mnuItem && mnuItem.Tag is Type elementType)
            {
                _busy = true;
                var element = Activator.CreateInstance(elementType, Color.Black, 0f, 0f) as Element;
                ClbElements.SelectedIndex = ClbElements.Items.Add(element, true);
                BtnDelete.Enabled = true;
                BtnUp.Enabled = true;
                BtnDown.Enabled = false;
                PgdProperties.SelectedObject = element;

                // Refresh elements in the picture box.
                PicDraw.Invalidate();
                _busy = false;
            }
        }

        private void ClbElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_busy) return;
            _busy = true;
            LstConnectors.SelectedItem = null;
            _drawCenter = false;

            if (ClbElements.SelectedItem is Element element)
            {
                PgdProperties.SelectedObject = element;
                BtnDelete.Enabled = true;
                BtnUp.Enabled = ClbElements.SelectedIndex > 0;
                BtnDown.Enabled = ClbElements.SelectedIndex < ClbElements.Items.Count - 1;
            }
            else
            {
                BtnDelete.Enabled = false;
                BtnUp.Enabled = false;
                BtnDown.Enabled = false;
            }

            PicDraw.Invalidate();
            _busy = false;
        }

        private void ClbElements_SelectedValueChanged(object sender, EventArgs e)
        {
            PicDraw.Invalidate();
        }

        private void PgdProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) => PicDraw.Invalidate();

        /// <summary>
        /// Paints the picture box content.
        /// </summary>
        private void PicDraw_Paint(object sender, PaintEventArgs e)
        {
            // Paint only the checked items.
            _component.Elements.Clear();
            if (CkbElements.Checked)
            {
                foreach (Element element in ClbElements.CheckedItems)
                {
                    _component.Elements.Add(element);
                }
            }

            // Paint connectors if the connectors box is checked.
            _component.Connectors.Clear();
            if (CkbConnectors.Checked)
            {
                foreach (Connector connector in LstConnectors.Items)
                {
                    _component.Connectors.Add(connector);
                }
            }

            _component.Paint(e.Graphics, PointF.Empty, _state, CkbConnectors.Checked, LstConnectors.SelectedItem as Connector);

            // Paint the component center with a cross.
            if (_drawCenter)
            {
                using (Pen pen = new Pen(Color.Red, 0.1f))
                {
                    const int CROSS_SIZE = 3;
                    e.Graphics.DrawLine(pen, _component.X - CROSS_SIZE, _component.Y, _component.X + CROSS_SIZE, _component.Y);
                    e.Graphics.DrawLine(pen, _component.X, _component.Y - CROSS_SIZE, _component.X, _component.Y + CROSS_SIZE);
                }
            }
        }

        /// <summary>
        /// Encodes the data to be saved in a file.
        /// </summary>
        /// <returns>The encoded data in string format.</returns>
        private string SerializeData()
        {
            _component.Elements.Clear();
            foreach (Element element in ClbElements.Items)
            {
                _component.Elements.Add(element);
            }

            _component.Connectors.Clear();
            foreach (Connector connector in LstConnectors.Items)
            {
                _component.Connectors.Add(connector);
            }

            return _component.Serialize();
        }

        /// <summary>
        /// Decodes the content read from a file.
        /// </summary>
        /// <param name="content">The file content.</param>
        private void DeserializeData(string content)
        {
            _busy = true;
            _component.Deserialize(content);

            // Add the elements
            ClbElements.Items.Clear();
            foreach (var element in _component.Elements)
            {
                _ = ClbElements.Items.Add(element, true);
            }

            // Add the connectors
            LstConnectors.Items.Clear();
            foreach (var connector in _component.Connectors)
            {
                _ = LstConnectors.Items.Add(connector);
            }

            LstModes.SelectedIndex = 0;

            // Paint objects in the picture box
            PicDraw.Invalidate();
            _busy = false;
        }

        private void BtnSave_Click(object sender, EventArgs e) => _ = FileManager.Save(SerializeData());

        private void BtnSaveAs_Click(object sender, EventArgs e) => _ = FileManager.SaveAs(SerializeData());

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (FileManager.Open() && FileManager.FileContent is string data)
            {
                DeserializeData(data);
            }
        }

        private void BtnNew_Click(object sender, EventArgs e) => FileManager.New();

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ClbElements.Items.Remove(ClbElements.SelectedItem);
            PicDraw.Invalidate();
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            _busy = true;
            object element = ClbElements.SelectedItem;
            int index = ClbElements.SelectedIndex - 1;
            bool itemChecked = ClbElements.GetItemChecked(index);
            ClbElements.Items.Remove(ClbElements.SelectedItem);
            ClbElements.Items.Insert(index, element);
            ClbElements.SetItemChecked(index, itemChecked);
            ClbElements.SelectedItem = element;

            PicDraw.Invalidate();
            _busy = false;
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            _busy = true;
            object element = ClbElements.SelectedItem;
            int index = ClbElements.SelectedIndex + 1;
            bool itemChecked = ClbElements.GetItemChecked(index);
            ClbElements.Items.Remove(ClbElements.SelectedItem);
            ClbElements.Items.Insert(index, element);
            ClbElements.SetItemChecked(index, itemChecked);
            ClbElements.SelectedItem = element;

            PicDraw.Invalidate();
            _busy = false;
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            if (Owner is FrmMain frmMain)
            {
                frmMain.ReloadComponents();
            }
        }

        private void BtnAddConnector_Click(object sender, EventArgs e)
        {
            _busy = true;
            var connector = new Connector(0f, 0f);
            LstConnectors.SelectedIndex = LstConnectors.Items.Add(connector);
            PicDraw.Invalidate();
            _busy = false;
        }

        private void BtnDeleteConnector_Click(object sender, EventArgs e)
        {
            _busy = true;
            LstConnectors.Items.Remove(LstConnectors.SelectedItem);
            PicDraw.Invalidate();
            _busy = false;
        }

        private void LstConnectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_busy) return;
            _busy = true;
            ClbElements.SelectedItem = null;
            _drawCenter = false;

            if (LstConnectors.SelectedItem is Connector connector)
            {
                PgdProperties.SelectedObject = connector;
                BtnDeleteConnector.Enabled = true;
            }
            else
            {
                BtnDeleteConnector.Enabled = false;
            }

            PicDraw.Invalidate();
            _busy = false;
        }

        private void CkbConnectors_CheckedChanged(object sender, EventArgs e)
        {
            PicDraw.Invalidate();
        }

        private void CkbElements_CheckedChanged(object sender, EventArgs e)
        {
            _busy = true;
            for (int index = 0; index < ClbElements.Items.Count; index++)
            {
                ClbElements.SetItemChecked(index, CkbElements.Checked);
            }

            PicDraw.Invalidate();
            _busy = false;
        }

        private void PicDraw_Click(object sender, EventArgs e)
        {
            if (_busy) return;
            _busy = true;
            ClbElements.SelectedItem = null;
            LstConnectors.SelectedItem = null;
            _drawCenter = true;
            PgdProperties.SelectedObject = _component;
            PicDraw.Invalidate();
            _busy = false;
        }

        private void LstModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_busy) return;
            _busy = true;
            if (LstModes.SelectedItem != null)
            {
                _state = (Component.State)LstModes.SelectedItem;
                if (_state.HasFlag(Component.State.SimulationStep)
                        || _state.HasFlag(Component.State.SimulationPass)
                        || _state.HasFlag(Component.State.SimulationError))
                {
                    ClbElements.SelectedItem = null;
                    LstConnectors.SelectedItem = null;
                    PgdProperties.SelectedObject = _component.Selector;
                }

                PicDraw.Invalidate();
            }

            _busy = false;
        }

        private void FrmElementDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            _ = Owner.Focus();
        }
    }
}
