// <copyright file="FrmTemplate.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Activation;
using SimpleAnnPlayground.Ann.Networks;
using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.UI.Controls;
using SimpleAnnPlayground.Utils;
using SimpleAnnPlayground.Utils.DataView;
using SimpleAnnPlayground.Utils.Items;

namespace SimpleAnnPlayground.UI
{
    /// <summary>
    /// Window to create neural networks with a template.
    /// </summary>
    internal partial class FrmTemplate : Form
    {
        private const int SeparationX = 150;
        private const int SeparationY = 100;
        private const int MargingX = 200;
        private const int MargingY = 100;

        /// <summary>
        /// Contains the words for each control.
        /// </summary>
        private static readonly Dictionary<string, List<string>> FormWords = new()
        {
            // Window text.
            { nameof(FrmTemplate), new() { "New file from template", "Nuevo documento desde plantilla" } },

            // Labels.
            { nameof(RbFully), new() { "Fully connected.", "Totalmente conectado." } },
            { nameof(RbCustom), new() { "Custom connections.", "Conexiones personalizadas." } },

            // Buttons.
            { nameof(BtnCancel), new() { "&Cancel", "&Cancelar" } },
            { nameof(BtnCreate), new() { "Create", "Crear" } },

            // Text areas.
            { nameof(GbOptions), new() { "Options:", "Opciones:" } },

            // ComboBoxItems
            { nameof(CbiClassification), new() { "Classification", "Clasificación" } },
            { nameof(CbiTwoGroups), new() { "Two groups", "Dos grupos" } },
            { nameof(CbiCircle), new() { "Circle", "Concentricos" } },
            { nameof(CbiRegression), new() { "Regression", "Regresión" } },
            { nameof(CbiPlane), new() { "Plane", "Plano" } },
        };

#pragma warning disable SA1306, SX1309
        private readonly ComboBoxItem CbiClassification;
        private readonly ComboBoxItem CbiTwoGroups;
        private readonly ComboBoxItem CbiCircle;

        private readonly ComboBoxItem CbiRegression;
        private readonly ComboBoxItem CbiPlane;

        private readonly ComboBoxItem CbiWeightsRandomDot3;
        private readonly ComboBoxItem CbiWeightsRandomZeroOne;
        private readonly ComboBoxItem CbiWeightsRandomOnes;
        private readonly ComboBoxItem CbiWeightsXavier;
        private readonly ComboBoxItem CbiWeightsNormXavier;
        private readonly ComboBoxItem CbiWeightsHe;
        private readonly ComboBoxItem CbiWeightsZeros;
#pragma warning restore SA1306, SX1309

        private readonly DataGridViewEditor _editor;

        private readonly Workspace _workspace;

        private DataTable? _dataTable;

        private bool _lock = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmTemplate"/> class.
        /// </summary>
        /// <param name="workspace">The workspace.</param>
        public FrmTemplate(Workspace workspace)
        {
            InitializeComponent();

            // DataGridView editor.
            _editor = new DataGridViewEditor(DgTemplate);
            _editor.CellValueChanged += Editor_CellValueChanged;
            _workspace = workspace;

            // Data examples.
            CbiClassification = new ComboBoxItem(nameof(CbiClassification));
            CbiTwoGroups = new ComboBoxItem(nameof(CbiTwoGroups));
            CbiCircle = new ComboBoxItem(nameof(CbiCircle));

            CbiRegression = new ComboBoxItem(nameof(CbiRegression));
            CbiPlane = new ComboBoxItem(nameof(CbiPlane));

            // Adding Data examples.
            _ = CbProblemType.Items.Add(CbiClassification);
            _ = CbProblemType.Items.Add(CbiRegression);
            CbProblemType.SelectedIndex = 0;

            // Weights initializations.
            CbiWeightsRandomDot3 = new ComboBoxItem(nameof(CbiWeightsRandomDot3), "Random [-0.3, 0.3]");
            CbiWeightsRandomZeroOne = new ComboBoxItem(nameof(CbiWeightsRandomZeroOne), "Random [0, 1]");
            CbiWeightsRandomOnes = new ComboBoxItem(nameof(CbiWeightsRandomOnes), "Random [-1, 1]");
            CbiWeightsXavier = new ComboBoxItem(nameof(CbiWeightsXavier), "Xavier");
            CbiWeightsNormXavier = new ComboBoxItem(nameof(CbiWeightsNormXavier), "Normalized Xavier");
            CbiWeightsHe = new ComboBoxItem(nameof(CbiWeightsHe), "He");
            CbiWeightsZeros = new ComboBoxItem(nameof(CbiWeightsZeros), "Zeros");

            // Adding weights initializations.
            _ = CbWeights.Items.Add(CbiWeightsRandomOnes);
            _ = CbWeights.Items.Add(CbiWeightsRandomZeroOne);
            _ = CbWeights.Items.Add(CbiWeightsRandomDot3);
            _ = CbWeights.Items.Add(CbiWeightsXavier);
            /*_ = CbWeights.Items.Add(CbiWeightsNormXavier);
            _ = CbWeights.Items.Add(CbiWeightsHe);*/
            _ = CbWeights.Items.Add(CbiWeightsZeros);
            CbWeights.SelectedIndex = 0;
        }

        private static int GetSheetWidth(List<int> networkConfig) => networkConfig.Count * SeparationX + MargingX;

        private static int GetSheetHeight(List<int> networkConfig) => networkConfig.Max() * SeparationY + MargingY;

        private void FrmTemplate_Load(object sender, EventArgs e)
        {
            // Getting application language from user settings.
            var formLanguage = Languages.GetApplicationLanguage();

            // Applying form language.
            Languages.ChangeFormLanguage(this, FormWords, formLanguage);

            // Updating rate value.
            TkRate_ValueChanged(TkRate, EventArgs.Empty);

            // Adding Input layer row
            var row = new DataGridViewRow();
            _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "Input neurons" });
            _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "1" });
            /*_ = row.Cells.Add(new DataGridViewNumericUpDownCell { Value = 2, Minimum = 1, Maximum = 10 });*/
            _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "2" });
            row.Cells[1].ReadOnly = true;
            row.DefaultCellStyle.BackColor = Color.LightGreen;
            _ = _editor.Viewer.Rows.Add(row);

            // Adding Internal layer row
            row = new DataGridViewRow();
            _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "Internal layers" });
            _ = row.Cells.Add(new DataGridViewNumericUpDownCell { Value = 1, Minimum = 1, Maximum = 3 });
            _ = row.Cells.Add(new DataGridViewTextBoxCell());
            row.Cells[2].ReadOnly = true;
            _ = _editor.Viewer.Rows.Add(row);

            // Adding Internal layer row
            row = new DataGridViewRow();
            _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "Internal neurons" });
            _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "1" });
            _ = row.Cells.Add(new DataGridViewNumericUpDownCell { Value = 3, Minimum = 1, Maximum = 10 });
            row.Cells[1].ReadOnly = true;
            _ = _editor.Viewer.Rows.Add(row);

            // Adding Outpur layer row
            row = new DataGridViewRow();
            _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "Output neurons" });
            _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "1" });
            /*_ = row.Cells.Add(new DataGridViewNumericUpDownCell { Value = 1, Minimum = 1, Maximum = 10 });*/
            _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "1" });
            row.Cells[1].ReadOnly = true;
            _ = _editor.Viewer.Rows.Add(row);
            row.DefaultCellStyle.BackColor = Color.LightGreen;

            // Adding dummy row
            _ = _editor.Viewer.Rows.Add(string.Empty, string.Empty, string.Empty);
            _lock = false;
        }

        private void Editor_CellValueChanged(object? sender, CellValueChangedEventArgs e)
        {
            if (_lock) return;

            if (e.Cell.ColumnIndex == 1)
            {
                string str = e.Cell.Value?.ToString() ?? string.Empty;
                int layers = int.Parse(str);
                int current = _editor.Viewer.RowCount - 4;

                while (layers > current)
                {
#pragma warning disable CA2000 // Dispose objects before losing scope
                    var row = new DataGridViewRow();
#pragma warning restore CA2000 // Dispose objects before losing scope
                    _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "Internal neurons" });
                    _ = row.Cells.Add(new DataGridViewTextBoxCell { Value = "1" });
                    _ = row.Cells.Add(new DataGridViewNumericUpDownCell { Value = 2, Minimum = 1, Maximum = 10 });
                    row.Cells[1].ReadOnly = true;
                    _editor.Viewer.Rows.Insert(current + 2, row);
                    current++;
                }

                while (layers < current)
                {
                    _editor.Viewer.Rows.RemoveAt(current + 1);
                    current--;
                }
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (_dataTable is null) throw new InvalidOperationException();
            _workspace.Clean();

            // Data loading.
            _workspace.SetDataTable(_dataTable);
            _dataTable.Training = TkRatio.Value;

            // Network creation.
            var networkConfig = GetNetworkConfig();
            _workspace.WorkSheet.Resize(GetSheetWidth(networkConfig), GetSheetHeight(networkConfig));

            // Network parameters.
            _workspace.Network.LearningRate = Network.LearningRates[TkRate.Value];
            _workspace.Network.BatchSize = TkBatch.Value;

            var network = new List<List<Neuron>>
            {
                new List<Neuron>(),
            };
            int layersCount = networkConfig.Count;
            int inputNeurons = networkConfig.First();
            int startX = -(layersCount * SeparationY) / 2;
            int startY = -(inputNeurons - 1) * SeparationY / 2;
            var layer = network.First();

            // Add input neurons.
            for (int neuronIndex = 0; neuronIndex < inputNeurons; neuronIndex++)
            {
                var neuron = new Input(_workspace.Canvas, startX, startY);
                layer.Add(neuron);
                neuron.DataLabel = _dataTable.Labels[neuronIndex];
                _workspace.Canvas.AddObject(neuron);
                _workspace.Shadow.AddObject(neuron);
                startY += SeparationY;
            }

            // Add internal layers.
            foreach (int internalNeurons in networkConfig.Skip(1).Take(layersCount - 2))
            {
                startX += SeparationX;
                startY = -(internalNeurons - 1) * SeparationY / 2;
                layer = new List<Neuron>();
                network.Add(layer);

                // Add input neurons.
                for (int neuronIndex = 0; neuronIndex < internalNeurons; neuronIndex++)
                {
                    var neuron = new Internal(_workspace.Canvas, startX, startY);
                    layer.Add(neuron);
                    neuron.Activation = ActivationFunctions.Sigmoid;
                    _workspace.Canvas.AddObject(neuron);
                    _workspace.Shadow.AddObject(neuron);
                    startY += SeparationY;
                }
            }

            int outputNeurons = networkConfig.Last();
            startY = -(outputNeurons - 1) * SeparationY / 2;
            startX += SeparationX;
            layer = new List<Neuron>();
            network.Add(layer);

            // Add output neurons.
            for (int neuronIndex = 0; neuronIndex < outputNeurons; neuronIndex++)
            {
                var neuron = new Output(_workspace.Canvas, startX, startY);
                layer.Add(neuron);
                neuron.DataLabel = _dataTable.Labels[inputNeurons + neuronIndex];
                neuron.Activation = ActivationFunctions.Sigmoid;
                _workspace.Canvas.AddObject(neuron);
                _workspace.Shadow.AddObject(neuron);
                startY += SeparationY;
            }

            // Interconnections.
            if (RbFully.Checked)
            {
                layer = network.First();
                foreach (var endLayer in network.Skip(1))
                {
                    foreach (var neuron in layer)
                    {
                        foreach (var endNeuron in endLayer)
                        {
                            decimal weight = GetWeight(layer.Count);
                            var conn = new Connection(neuron.Outputs.First(), endNeuron.Inputs.First(), weight);
                            _workspace.Canvas.Connections.Add(conn);
                            _workspace.Shadow.AddConnection(conn);
                        }
                    }

                    layer = endLayer;
                }
            }
        }

        private decimal GetWeight(int nodes)
        {
            if (CbWeights.SelectedItem == CbiWeightsRandomDot3)
            {
                return Util.GetRandom(-0.3m, 0.3m, 8);
            }
            else if (CbWeights.SelectedItem == CbiWeightsRandomZeroOne)
            {
                return Util.GetRandom(0m, 1m, 8);
            }
            else if (CbWeights.SelectedItem == CbiWeightsRandomOnes)
            {
                return Util.GetRandom(-1m, 1m, 8);
            }
            else if (CbWeights.SelectedItem == CbiWeightsXavier)
            {
                return Util.GetRandom(-1m / (decimal)Math.Sqrt(nodes), 1m / (decimal)Math.Sqrt(nodes), 8);
            }
            else if (CbWeights.SelectedItem == CbiWeightsNormXavier)
            {
                throw new NotImplementedException();
            }
            else if (CbWeights.SelectedItem == CbiWeightsHe)
            {
                throw new NotImplementedException();
            }
            else if (CbWeights.SelectedItem == CbiWeightsZeros)
            {
                return 0;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private List<int> GetNetworkConfig()
        {
            List<int> networkConfig = new List<int>();

            // Input layer.
            string inputNeuronsStr = DgTemplate.Rows[0].Cells[2].Value?.ToString() ?? string.Empty;
            int inputNeurons = int.Parse(inputNeuronsStr);
            networkConfig.Add(inputNeurons);

            // Internal layers.
            int internalLayers = _editor.Viewer.RowCount - 4;
            for (int internalLayerIndex = 0; internalLayerIndex < internalLayers; internalLayerIndex++)
            {
                string internalNeuronsStr = DgTemplate.Rows[internalLayerIndex + 2].Cells[2].Value?.ToString() ?? string.Empty;
                int internalNeurons = int.Parse(internalNeuronsStr);
                networkConfig.Add(internalNeurons);
            }

            // Output layer
            string outputNeuronsStr = DgTemplate.Rows[internalLayers + 2].Cells[2].Value?.ToString() ?? string.Empty;
            int outputNeurons = int.Parse(outputNeuronsStr);
            networkConfig.Add(outputNeurons);

            return networkConfig;
        }

        private void TkDataSize_ValueChanged(object sender, EventArgs e)
        {
            _lock = true;
            TbDataSize.Text = TkDataSize.Value.ToString();
            _lock = false;
            GenerateData();
        }

        private void TkNoise_ValueChanged(object sender, EventArgs e)
        {
            _lock = true;
            TbNoise.Text = TkNoise.Value.ToString();
            _lock = false;
            GenerateData();
        }

        private void TkRatio_ValueChanged(object sender, EventArgs e)
        {
            _lock = true;
            TbRatio.Text = $"{TkRatio.Value} %";
            _lock = false;
        }

        private void TbDataSize_TextChanged(object sender, EventArgs e)
        {
            if (_lock) return;
            TbDataSize.BackColor = int.TryParse(TbDataSize.Text, out int value)
                ? value >= TkDataSize.Minimum && value <= TkDataSize.Maximum ? Color.White : Color.LightSalmon
                : Color.LightSalmon;
            if (TbDataSize.BackColor == Color.White) TkDataSize.Value = value;
        }

        private void TbNoise_TextChanged(object sender, EventArgs e)
        {
            if (_lock) return;
            TbNoise.BackColor = int.TryParse(TbDataSize.Text, out int value)
                ? value >= TkNoise.Minimum && value <= TkNoise.Maximum ? Color.White : Color.LightSalmon
                : Color.LightSalmon;
            if (TbNoise.BackColor == Color.White) TkNoise.Value = value;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is(< '0' or > '9') and not '\x8')
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        private void CbProblemType_SelectedValueChanged(object sender, EventArgs e)
        {
            CbDataSet.Items.Clear();
            if (CbProblemType.SelectedIndex == -1) return;
            if (CbProblemType.SelectedItem == CbiClassification)
            {
                _ = CbDataSet.Items.Add(CbiTwoGroups);
                _ = CbDataSet.Items.Add(CbiCircle);
                Languages.ApplyComboBoxItemsLanguage(CbDataSet, FormWords);
            }
            else if (CbProblemType.SelectedItem == CbiRegression)
            {
                _ = CbDataSet.Items.Add(CbiPlane);
                Languages.ApplyComboBoxItemsLanguage(CbDataSet, FormWords);
            }
            else
            {
                throw new NotImplementedException();
            }

            CbDataSet.SelectedIndex = 0;
        }

        private void CbDataSet_SelectedValueChanged(object sender, EventArgs e)
        {
            GenerateData();
        }

        private void GenerateData()
        {
#pragma warning disable IDE0045 // Convert to conditional expression
            if (CbDataSet.SelectedItem == CbiTwoGroups)
            {
                _dataTable = DataModel.TwoGroupsDataModel.GenerateData(TkDataSize.Value, TkNoise.Value);
            }
            else if (CbDataSet.SelectedItem == CbiCircle)
            {
                _dataTable = DataModel.CircleDataModel.GenerateData(TkDataSize.Value, TkNoise.Value);
            }
            else if (CbDataSet.SelectedItem == CbiPlane)
            {
                _dataTable = DataModel.PlaneDataModel.GenerateData(TkDataSize.Value, TkNoise.Value);
            }
            else
            {
                throw new NotImplementedException();
            }
#pragma warning restore IDE0045 // Convert to conditional expression

            BtnCreate.Enabled = true;
            PbPlot.Invalidate();
        }

        private void PbPlot_Paint(object sender, PaintEventArgs e)
        {
            if (_dataTable is null) return;
            _dataTable.Plot(e.Graphics, new Rectangle(Point.Empty, PbPlot.Size), true, true);
        }

        private void TkBatch_ValueChanged(object sender, EventArgs e)
        {
            TbBatch.Text = TkBatch.Value.ToString();
        }

        private void TkRate_ValueChanged(object sender, EventArgs e)
        {
            TbRate.Text = Network.LearningRates[TkRate.Value].ToString();
        }

        private void BtnRegenerate_Click(object sender, EventArgs e)
        {
            GenerateData();
        }
    }
}
