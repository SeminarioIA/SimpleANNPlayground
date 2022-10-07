// <copyright file="Numeric.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Data.Values
{
    /// <summary>
    /// Represents a numeric <see cref="DataValue"/>.
    /// </summary>
    internal class Numeric : DataValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Numeric"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Numeric(double value)
            : base(value)
        {
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public new double Value
        {
            get => (double)base.Value;
            set => base.Value = value;
        }

        /// <inheritdoc/>
        public override string ToString() => Value.ToString("F3");
    }
}
