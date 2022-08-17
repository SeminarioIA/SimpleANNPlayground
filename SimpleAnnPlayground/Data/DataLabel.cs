// <copyright file="DataLabel.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Data
{
    /// <summary>
    /// Represents the type of data in a table.
    /// </summary>
    internal enum DataType
    {
        /// <summary>
        /// Input column data.
        /// </summary>
        Input,

        /// <summary>
        /// Output column data.
        /// </summary>
        Output,
    }

    /// <summary>
    /// Represents a <see cref="DataTable"/> column label.
    /// </summary>
    internal class DataLabel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLabel"/> class.
        /// </summary>
        /// <param name="text">The label text.</param>
        public DataLabel(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Gets or sets the label value.
        /// </summary>
        public string Text { get; set; }
    }
}
