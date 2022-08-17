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
        public DataRegister(string id)
        {
            Id = id;
            Fields = new List<DataValue>();
        }

        /// <summary>
        /// Gets the register id.
        /// </summary>
        public string Id { get; }

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
