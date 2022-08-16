// <copyright file="EmptyLine.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Text;

namespace SourceGenerator.Generator.CodeSections
{
    /// <summary>
    /// Represents an empty line of code.
    /// </summary>
    internal class EmptyLine : CodeSection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyLine"/> class.
        /// </summary>
        /// <param name="parent">The parent <see cref="CodeSection"/>.</param>
        public EmptyLine(CodeSection parent)
            : base(parent)
        {
        }

        /// <inheritdoc/>
        public override string ToString() => string.Empty;

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation) => source.AppendLine();
    }
}
