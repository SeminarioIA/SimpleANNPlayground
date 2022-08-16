// <copyright file="FieldValue.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Text;

namespace SourceGenerator.Generator.CodeSections
{
    /// <summary>
    /// Represents a initialization value.
    /// </summary>
    public class FieldValue : CodeSection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> class.
        /// </summary>
        /// <param name="parent">The parent <see cref="CodeSection"/>.</param>
        /// <param name="value">The value to initialize.</param>
        public FieldValue(CodeSection parent, string value)
            : base(parent)
        {
            Value = value;
            Code = new CodeBlock(this, true);
        }

        /// <summary>
        /// Gets the initialization value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets the code for the initialization value.
        /// </summary>
        public CodeBlock Code { get; }

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            _ = source.Append(Value);

            if (Code.Sections.Count > 0)
            {
                _ = source.AppendLine();
                Code.Generate(source, identation);
            }
            else
            {
                _ = source.Append(';');
            }
        }
    }
}
