// <copyright file="DataRegister.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Data
{
    /// <summary>
    /// Represents a row from a table.
    /// </summary>
    internal class DataRegister
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRegister"/> class.
        /// </summary>
        /// <param name="id">The register id.</param>
        public DataRegister(int id)
        {
            Id = id;
            Fields = new List<DataValue>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataRegister"/> class.
        /// </summary>
        /// <param name="csvLine">A text line from a CSV file.</param>
        public DataRegister(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Id = Convert.ToInt32(values[0], 10);
            Fields = new List<DataValue>();
            foreach (string value in values.Skip(1))
            {
                Fields.Add(new DataValue(value));
            }
        }

        /// <summary>
        /// Gets the register id.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the list of values.
        /// </summary>
        public List<DataValue> Fields { get; }

        /// <inheritdoc/>
        public override string ToString() => $"{Id},{string.Join(',', Fields)}";

        /// <summary>
        /// Gets all the <see cref="DataRegister"/> <see cref="DataValue"/> as a string array.
        /// </summary>
        /// <returns>The array of values names.</returns>
        public string[] GetStrings() => Fields.ConvertAll(field => field.Text).ToArray();
    }
}
