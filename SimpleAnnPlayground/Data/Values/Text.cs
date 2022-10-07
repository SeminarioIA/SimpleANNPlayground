// <copyright file="Text.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Data.Values
{
    /// <summary>
    /// Represents a text <see cref="DataValue"/>.
    /// </summary>
    internal class Text : DataValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Text"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Text(string value)
            : base(value)
        {
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public new string Value
        {
            get => (string)base.Value;
            set => base.Value = value;
        }

        /// <inheritdoc/>
        public override string ToString() => Value;
    }
}
