// <copyright file="DataTable.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

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
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTable"/> class.
        /// </summary>
        /// <param name="labels">The header labels for this table.</param>
        public DataTable(IEnumerable<string> labels)
        {
            Labels = labels.ToList().ConvertAll(label => new DataLabel(label));
            Registers = new List<DataRegister>();
        }

        /// <summary>
        /// Gets the list of values.
        /// </summary>
        public List<DataLabel> Labels { get; }

        /// <summary>
        /// Gets the list of values.
        /// </summary>
        public List<DataRegister> Registers { get; }
    }
}
