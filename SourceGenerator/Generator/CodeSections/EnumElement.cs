// <copyright file="EnumElement.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.Types;
using System.Text;

namespace SourceGenerator.Generator.CodeSections
{
    /// <summary>
    /// Represents an enum element.
    /// </summary>
    public class EnumElement : CodeSection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumElement"/> class.
        /// </summary>
        /// <param name="name">The name of the enum element.</param>
        /// <param name="description">The description of the enum element.</param>
        internal EnumElement(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumElement"/> class.
        /// </summary>
        /// <param name="name">The name of the enum element.</param>
        /// <param name="value">The enum element value.</param>
        /// <param name="description">The description of the enum element.</param>
        internal EnumElement(string name, string value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        /// <summary>
        /// Gets the name of this <see cref="EnumElement"/>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of this <see cref="EnumElement"/>.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets the description of this <see cref="EnumElement"/>.
        /// </summary>
        public string Description { get; }

        /// <inheritdoc/>
        public override string ToString() => Name;

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            SourceSnippet.Ident(source, identation);
            SourceSnippet.GenerateSummary(source, identation, Description);
            SourceSnippet.Ident(source, identation);

            _ = Value != null ? source.AppendLine($"{Name} = {Value}") : source.AppendLine($"{Name},");
        }
    }
}
