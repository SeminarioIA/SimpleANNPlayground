// <copyright file="DataTable.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Microsoft.Win32;
using Newtonsoft.Json;
using SimpleAnnPlayground.Data.Values;
using SimpleAnnPlayground.Utils.Graphics;

namespace SimpleAnnPlayground.Data
{
    /// <summary>
    /// Represents a table of data.
    /// </summary>
    internal class DataTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataTable"/> class.
        /// </summary>
        public DataTable()
        {
            Labels = new List<DataLabel>();
            Registers = new List<DataRegister>();
            Training = 80;
        }

        /// <summary>
        /// Gets or sets the proportion of data to be use for training.
        /// </summary>
        public int Training { get; set; }

        /// <summary>
        /// Gets the training data count.
        /// </summary>
        public int TrainingCount => Math.Max(Training * Registers.Count / 100, 1);

        /// <summary>
        /// Gets the list of values.
        /// </summary>
        public List<DataLabel> Labels { get; }

        /// <summary>
        /// Gets the list of values.
        /// </summary>
        [JsonIgnore]
        public List<DataRegister> Registers { get; }

        /// <summary>
        /// Gets the selected register for simulation.
        /// </summary>
        [JsonIgnore]
        public DataRegister? SelectedRegister { get; private set; }

        /// <summary>
        /// Gets the labels on this table of type input.
        /// </summary>
        [JsonIgnore]
        public IEnumerable<DataLabel> Inputs => Labels.Where(label => label.DataType == DataType.Input);

        /// <summary>
        /// Gets the labels on this table of type output.
        /// </summary>
        [JsonIgnore]
        public IEnumerable<DataLabel> Outputs => Labels.Where(label => label.DataType == DataType.Output);

        [JsonRequired]
#pragma warning disable IDE0051 // Remove unused private members
        private string RegistersCSV
#pragma warning restore IDE0051 // Remove unused private members
        {
            get => string.Join(Environment.NewLine, Registers);
            set
            {
                Registers.Clear();
                if (string.IsNullOrEmpty(value)) return;
                foreach (string line in value.Split(Environment.NewLine))
                {
                    Registers.Add(new DataRegister(line));
                }
            }
        }

        /// <summary>
        /// Determines if the <see cref="DataTable"/> contains data.
        /// </summary>
        /// <returns>True if contains data, otherwise false.</returns>
        public bool HasData() => Registers.Any();

        /// <summary>
        /// Adds a new label to the <see cref="DataTable"/>.
        /// </summary>
        /// <param name="name">The name of the label.</param>
        /// <param name="type">The data type for this label.</param>
        public void AddLabel(string name, DataType type)
        {
            Labels.Add(new DataLabel(this, name, type));
        }

        /// <summary>
        /// Adds a new register to the <see cref="DataTable"/>.
        /// </summary>
        /// <param name="id">The register id.</param>
        /// <param name="fields">The register values.</param>
        /// <exception cref="ArgumentException">If the count of register values does not match the <see cref="DataTable"/> labels.</exception>
        public void AddRegister(int id, params string[] fields)
        {
            if (fields.Length != Labels.Count) throw new ArgumentException("Fields count does not match the labels count.", nameof(fields));
            var register = new DataRegister(id);
            Registers.Add(register);
            foreach (string field in fields)
            {
                var value = new Text(field);
                register.Fields.Add(value);
            }
        }

        /// <summary>
        /// Adds a new register to the <see cref="DataTable"/>.
        /// </summary>
        /// <param name="id">The register id.</param>
        /// <param name="fields">The register values.</param>
        /// <exception cref="ArgumentException">If the count of register values does not match the <see cref="DataTable"/> labels.</exception>
        public void AddRegister(int id, params double[] fields)
        {
            if (fields.Length != Labels.Count) throw new ArgumentException("Fields count does not match the labels count.", nameof(fields));
            var register = new DataRegister(id);
            Registers.Add(register);
            foreach (double field in fields)
            {
                var value = new Numeric(field);
                register.Fields.Add(value);
            }
        }

        /// <summary>
        /// Clears all the content of the data table.
        /// </summary>
        public void Clear()
        {
            Labels.Clear();
            Registers.Clear();
        }

        /// <summary>
        /// Gets the enumerator for the training data.
        /// </summary>
        /// <returns>The training data enumerator.</returns>
        internal IEnumerator<DataRegister> GetTrainingEnumerator() => Registers.Take(TrainingCount).ToList().GetEnumerator();

        /// <summary>
        /// Gets the enumerator for the testing data.
        /// </summary>
        /// <returns>The testing data enumerator.</returns>
        internal IEnumerator<DataRegister> GetTestingEnumerator() => Registers.Skip(TrainingCount).ToList().GetEnumerator();

        /// <summary>
        /// Gets the enumerator for the training data.
        /// </summary>
        /// <returns>The training data enumerator.</returns>
        internal IEnumerator<DataRegister> GetTestEnumerator() => Registers.Skip(TrainingCount).GetEnumerator();

        /// <summary>
        /// Selects the specified register in the table.
        /// </summary>
        /// <param name="register">The register to select.</param>
        internal void SelectRegister(DataRegister register)
        {
            SelectedRegister = register;
        }

        /// <summary>
        /// Gets a value from the selected register.
        /// </summary>
        /// <param name="dataLabel">The label to read.</param>
        /// <returns>The value in decimal format.</returns>
        internal decimal GetValue(DataLabel dataLabel)
        {
            if (SelectedRegister != null)
            {
                int index = Labels.IndexOf(dataLabel);
                decimal value;
                switch (SelectedRegister.Fields[index])
                {
                    case Text text:
                        _ = decimal.TryParse(text.Value, out value);
                        break;
                    case Numeric numeric:
                        value = (decimal)numeric.Value;
                        break;
                    default:
                        throw new NotImplementedException($"{nameof(DataValue)} not implemented.");
                }

                return value;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Plots the contained data in the graphics object adapting to the passed bounds.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        /// <param name="bounds">The drawing object bounds.</param>
        /// <param name="grid">Draw the gird.</param>
        /// <param name="borders">Draw the borders.</param>
        internal void Plot(Graphics graphics, Rectangle bounds, bool grid, bool borders)
        {
            graphics.TranslateTransform(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
            graphics.ScaleTransform(bounds.Width / 20f, -bounds.Height / 20f);

            if (grid)
            {
                using (var pen = new Pen(Color.WhiteSmoke, 0.01f))
                {
                    for (int i = -10; i <= 10; i++)
                    {
                        graphics.DrawLine(pen, -10, i, 10, i);
                        graphics.DrawLine(pen, i, -10, i, 10);
                    }
                }
            }

            using (var pen = new Pen(Color.LightGray, 0.01f))
            {
                graphics.DrawLine(pen, -10, 0, 10, 0);
                graphics.DrawLine(pen, 0, -10, 0, 10);
            }

            foreach (var register in Registers)
            {
                var fields = register.GetFields<Numeric>();
                var color = Colors.GetGradient(Color.Blue, Color.Orange, fields[2].Value);
                using (var brush = new SolidBrush(color))
                {
                    graphics.FillEllipse(brush, (float)fields[0].Value, (float)fields[1].Value, 0.5f, 0.5f);
                }

                if (borders)
                {
                    using (var pen = new Pen(Color.Gray, 0.01f))
                    {
                        graphics.DrawEllipse(pen, (float)fields[0].Value, (float)fields[1].Value, 0.5f, 0.5f);
                    }
                }
            }

            if (SelectedRegister is not null)
            {
                var fields = SelectedRegister.GetFields<Numeric>();
                using (var pen = new Pen(Color.Red, 0.01f))
                {
                    graphics.DrawLine(pen, -10, (float)fields[0].Value, 10, (float)fields[0].Value);
                    graphics.DrawLine(pen, (float)fields[1].Value, -10, (float)fields[1].Value, 10);
                }
            }

            graphics.ScaleTransform(20f / bounds.Width, -20f / bounds.Height);
            graphics.TranslateTransform(-bounds.X - bounds.Width / 2, -bounds.Y - bounds.Height / 2);
        }
    }
}
