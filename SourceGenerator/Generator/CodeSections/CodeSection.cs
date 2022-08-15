// <copyright file="CodeSection.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.Types;
using System.Text;

namespace SourceGenerator.Generator.CodeSections
{
    /// <summary>
    /// Represents a section of code.
    /// </summary>
    public abstract class CodeSection
    {
        /// <summary>
        /// Generates the <see cref="CodeSection"/> source code.
        /// </summary>
        /// <param name="source">The <see cref="StringBuilder"/> to append the source code.</param>
        /// <param name="identation">The identation to follow when appending the code.</param>
        internal virtual void Generate(StringBuilder source, int identation)
        {
            SourceSnippet.Ident(source, identation);
            _ = source.AppendLine(ToString());
        }
    }
}
