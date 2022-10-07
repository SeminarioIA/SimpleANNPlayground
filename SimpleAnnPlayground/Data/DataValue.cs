// <copyright file="DataValue.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Data
{
    /// <summary>
    /// Represents a value from a table.
    /// </summary>
    internal abstract class DataValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataValue"/> class.
        /// </summary>
        /// <param name="value">The data value.</param>
        public DataValue(object value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }

        /// <inheritdoc/>
        public override string ToString() => Value?.ToString() ?? string.Empty;
    }
}
