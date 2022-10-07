// <copyright file="DataRegister.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Data.Values;

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
                Fields.Add(new Text(value));
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

        /// <summary>
        /// Gets or sets data related to the register.
        /// </summary>
        public object? Tag { get; set; }

        /// <summary>
        /// Obtains the list of fields in it type.
        /// </summary>
        /// <typeparam name="T">The field type.</typeparam>
        /// <returns>The list of fields.</returns>
        public List<T> GetFields<T>()
            where T : DataValue
        {
            return Fields.ConvertAll(field => field as T ?? throw new InvalidOperationException()).ToList();
        }

        /// <inheritdoc/>
        public override string ToString() => $"{Id},{string.Join(',', Fields)}";

        /// <summary>
        /// Gets all the <see cref="DataRegister"/> <see cref="DataValue"/> as a string array.
        /// </summary>
        /// <returns>The array of values names.</returns>
        public string[] GetStrings() => Fields.ConvertAll(field => field.ToString()).ToArray();
    }
}
