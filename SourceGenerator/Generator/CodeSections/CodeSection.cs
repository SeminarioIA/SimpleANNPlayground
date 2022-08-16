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
        /// Initializes a new instance of the <see cref="CodeSection"/> class.
        /// </summary>
        /// <param name="parent">The parent <see cref="CodeSection"/>.</param>
        protected CodeSection(CodeSection parent)
        {
            Parent = parent ?? this;
        }

        /// <summary>
        /// Gets the source snippet parent.
        /// </summary>
        public CodeSection Parent { get; }

        /// <summary>
        /// Ends the <see cref="SourceSnippet"/> code adding.
        /// </summary>
#pragma warning disable CA1822 // Mark members as static
        public void End()
#pragma warning restore CA1822 // Mark members as static
        {
        }

        /// <summary>
        /// Returns the parent object to continue adding code.
        /// </summary>
        /// <typeparam name="T">The type of the parent object.</typeparam>
        /// <returns>The parent object.</returns>
        public T BackTo<T>()
            where T : SourceSnippet
        {
            return Parent as T;
        }

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
