// <copyright file="FrmElementDesigner.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical;
using SimpleAnnPlayground.Utils.FileManagment;
using System.Globalization;
using System.Text;

namespace SimpleAnnPlayground.Debugging
{
    /// <summary>
    /// Element Designer form to create visual elements.
    /// </summary>
    public partial class FrmElementDesigner : Form
    {
        /// <summary>
        /// Indicates if the list is being ordered.
        /// </summary>
        private bool _ordering;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmElementDesigner"/> class.
        /// </summary>
        public FrmElementDesigner()
        {
            InitializeComponent();

            FileManager = new TextFileManager();
            FileManager.FilePathChanged += FileManager_FilePathChanged;
        }

        /// <summary>
        /// Gets the <see cref="FileManager"/> for the current document.
        /// </summary>
        public TextFileManager FileManager { get; private set; }

        private void FrmElementDesigner_Load(object sender, EventArgs e)
        {
            ElementsHelper.AddMenuPerElement(BtnAdd, BtnAdd_Click);
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
        }

        private void ClbElements_SelectedValueChanged(object sender, EventArgs e) => PicDraw.Invalidate();

        private void PgdProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) => PicDraw.Invalidate();

        /// <summary>
        /// Paints the picture box content.
        /// </summary>
        private void PicDraw_Paint(object sender, PaintEventArgs e)
        {
            if (_ordering) return;

            // Paint only the checked items.
            foreach (Element element in ClbElements.CheckedItems)
            {
                element?.Paint(e.Graphics);
            }
        }

        /// <summary>
        /// Encodes the data to be saved in a file.
        /// </summary>
        /// <returns>The encoded data in string format.</returns>
        private string SerializeData()
        {
            var data = new StringBuilder();
            foreach (Element element in ClbElements.Items)
            {
                _ = data.AppendLine(element.Serialize());
            }

            return data.ToString();
        }

        /// <summary>
        /// Decodes the content read from a file.
        /// </summary>
        /// <param name="content">The file content.</param>
        private void DeserializeData(string content)
        {
            ClbElements.Items.Clear();

            foreach (string line in content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                var data = new List<string>(line.Split(", ", StringSplitOptions.None));
                var elementTypeName = Enum.Parse<ElementsHelper.Types>(data.First());
                var elementType = ElementsHelper.ElementsTypes[(int)elementTypeName];
                var element = Activator.CreateInstance(elementType, Color.Black, 0f, 0f) as Element;
                foreach (string param in data.Skip(1))
                {
                    string[] nameValue = param.Split(": ");
                    string name = nameValue[0];
                    string value = nameValue[1];
                    var property = elementType.GetProperty(name);
                    if (property != null)
                    {
                        if (property.PropertyType == typeof(float))
                        {
                            property.SetValue(element, float.Parse(value, CultureInfo.CurrentCulture));
                        }
                        else if (property.PropertyType == typeof(Color?))
                        {
                            if (string.IsNullOrEmpty(value))
                            {
                                property.SetValue(element, null);
                            }
                            else
                            {
                                property.SetValue(element, Color.FromName(value));
                            }
                        }
                        else if (property.PropertyType == typeof(Color))
                        {
                            property.SetValue(element, Color.FromName(value));
                        }
                    }
                }

                if (element != null) _ = ClbElements.Items.Add(element, true);
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
    }
}
