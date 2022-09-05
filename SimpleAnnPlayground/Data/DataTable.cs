// <copyright file="DataTable.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;

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
        /// Clears all the content of the data table.
        /// </summary>
        public void Clear()
        {
            Labels.Clear();
            Registers.Clear();
        }

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
                _ = decimal.TryParse(SelectedRegister.Fields[index].Text, out decimal value);
                return value;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
