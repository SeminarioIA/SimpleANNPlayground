// <copyright file="FrmElementDesigner.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Graphical;
using SimpleAnnPlayground.Utils.FileManagment;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Debugging
{
    /// <summary>
    /// Element Designer form to create visual elements.
    /// </summary>
    public partial class FrmElementDesigner : Form
    {
        /// <summary>
        /// Indicates if a list is being ordered.
        /// </summary>
        private bool _ordering;

        /// <summary>
        /// Indicates if a list item is being selected.
        /// </summary>
        private bool _selecting;

        /// <summary>
        /// Indicates if a list item is being checked.
        /// </summary>
        private bool _checking;

        /// <summary>
        /// The component being edited.
        /// </summary>
        private Component _component;

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
                var element = Activator.CreateInstance(elementType, Color.Black, 0f, 0f) as Element;
                ClbElements.SelectedIndex = ClbElements.Items.Add(element, true);

                // Refresh elements in the picture box.
                PicDraw.Invalidate();
            }
        }

        private void ClbElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selecting) return;
            _selecting = true;
            LstConnectors.SelectedItem = null;

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

            _selecting = false;
        }

        private void ClbElements_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_checking) return;
            PicDraw.Invalidate();
        }

        private void PgdProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) => PicDraw.Invalidate();

        /// <summary>
        /// Paints the picture box content.
        /// </summary>
        private void PicDraw_Paint(object sender, PaintEventArgs e)
        {
            if (_ordering) return;

            // Paint only the checked items.
            if (CkbElements.Checked)
            {
                foreach (Element element in ClbElements.CheckedItems)
                {
                    element?.Paint(e.Graphics);
                }
            }

            // Paint connectors if the connectors box is checked.
            if (CkbConnectors.Checked)
            {
                foreach (Connector connector in LstConnectors.Items)
                {
                    connector?.Paint(e.Graphics);
                }
            }
        }

        /// <summary>
        /// Encodes the data to be saved in a file.
        /// </summary>
        /// <returns>The encoded data in string format.</returns>
        private string SerializeData()
        {
            var elements = new Collection<Element>();
            foreach (Element element in ClbElements.Items)
            {
                elements.Add(element);
            }

            var connectors = new Collection<Connector>();
            foreach (Connector connector in LstConnectors.Items)
            {
                connectors.Add(connector);
            }

            _component = new Component(elements, connectors);

            string json = JsonConvert.SerializeObject(_component, Formatting.Indented);

            return json; // Component.Serialize(elements);
        }

        /// <summary>
        /// Decodes the content read from a file.
        /// </summary>
        /// <param name="content">The file content.</param>
        private void DeserializeData(string content)
        {
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

            // Paint objects in the picture box
            PicDraw.Invalidate();
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
            _ordering = true;
            object element = ClbElements.SelectedItem;
            int index = ClbElements.SelectedIndex - 1;
            bool itemChecked = ClbElements.GetItemChecked(index);
            ClbElements.Items.Remove(ClbElements.SelectedItem);
            ClbElements.Items.Insert(index, element);
            ClbElements.SetItemChecked(index, itemChecked);
            ClbElements.SelectedItem = element;
            _ordering = false;

            PicDraw.Invalidate();
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            _ordering = true;
            object element = ClbElements.SelectedItem;
            int index = ClbElements.SelectedIndex + 1;
            bool itemChecked = ClbElements.GetItemChecked(index);
            ClbElements.Items.Remove(ClbElements.SelectedItem);
            ClbElements.Items.Insert(index, element);
            ClbElements.SetItemChecked(index, itemChecked);
            ClbElements.SelectedItem = element;
            _ordering = false;

            PicDraw.Invalidate();
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
            var connector = new Connector(0f, 0f);
            LstConnectors.SelectedIndex = LstConnectors.Items.Add(connector);
        }

        private void BtnDeleteConnector_Click(object sender, EventArgs e)
        {
            LstConnectors.Items.Remove(LstConnectors.SelectedItem);
        }

        private void LstConnectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selecting) return;
            _selecting = true;
            ClbElements.SelectedItem = null;

            if (LstConnectors.SelectedItem is Connector connector)
            {
                PgdProperties.SelectedObject = connector;
                BtnDeleteConnector.Enabled = true;
            }
            else
            {
                BtnDeleteConnector.Enabled = false;
            }

            _selecting = false;
        }

        private void CkbConnectors_CheckedChanged(object sender, EventArgs e)
        {
            PicDraw.Invalidate();
        }

        private void CkbElements_CheckedChanged(object sender, EventArgs e)
        {
            _checking = true;
            for (int index = 0; index < ClbElements.Items.Count; index++)
            {
                ClbElements.SetItemChecked(index, CkbElements.Checked);
            }

            _checking = false;
            PicDraw.Invalidate();
        }
    }
}
