// <copyright file="DataValue.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Data
{
    /// <summary>
    /// Represents a value from a table.
    /// </summary>
    internal class DataValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataValue"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public DataValue(string value)
        {
            Text = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Text { get; set; }

        /// <inheritdoc/>
        public override string ToString() => Text;
    }
}
