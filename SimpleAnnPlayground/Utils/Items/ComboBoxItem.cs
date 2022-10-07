// <copyright file="ComboBoxItem.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Utils.Items
{
    /// <summary>
    /// Represents a <see cref="ComboBox"/> item.
    /// </summary>
    internal class ComboBoxItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxItem"/> class.
        /// </summary>
        /// <param name="name">The item name.</param>
        /// <param name="text">The item text.</param>
        public ComboBoxItem(string name, string text = "")
        {
            Name = name;
            Text = text;
        }

        /// <summary>
        /// Gets the item name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the object that contains data about the control.
        /// </summary>
        public object? Tag { get; set; }

        /// <summary>
        /// Gets or sets the item text.
        /// </summary>
        public string Text { get; set; }

        /// <inheritdoc/>
        public override string ToString() => Text;
    }
}
