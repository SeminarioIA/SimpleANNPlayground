// <copyright file="CodeBlock.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.Types;
using System.Collections.ObjectModel;
using System.Text;

namespace SourceGenerator.Generator.CodeSections
{
    /// <summary>
    /// Represents a block of code.
    /// </summary>
    public class CodeBlock : CodeSection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeBlock"/> class.
        /// </summary>
        /// <param name="parent">The parent <see cref="CodeBlock"/> of this <see cref="CodeBlock"/>.</param>
        public CodeBlock(CodeBlock parent = null)
        {
            Sections = new Collection<CodeSection>();
            Parent = parent;
        }

        /// <summary>
        /// Gets the <see cref="CodeSection"/> collection of this <see cref="CodeBlock"/>.
        /// </summary>
        public Collection<CodeSection> Sections { get; }

        /// <summary>
        /// Gets the parent <see cref="CodeBlock"/> of this <see cref="CodeBlock"/>.
        /// </summary>
        public CodeBlock Parent { get; }

        /// <summary>
        /// Adds a new <see cref="CodeLine"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <param name="line">The line of code to add.</param>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public CodeBlock AddLine(string line) => AddSection(new CodeLine(line));

        /// <summary>
        /// Adds a new <see cref="EmptyLine"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public CodeBlock AddEmptyLine() => AddSection(new EmptyLine());

        /// <summary>
        /// Adds a new <see cref="Comment"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <param name="text">The text to add as a comment.</param>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public CodeBlock AddComment(string text) => AddSection(new Comment(text));

        /// <summary>
        /// Adds a nested <see cref="CodeBlock"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <returns>The new added <see cref="CodeBlock"/>.</returns>
        public CodeBlock AddBlock()
        {
            var block = new CodeBlock(this);
            Sections.Add(block);
            return block;
        }

        /// <summary>
        /// Closes the current <see cref="CodeBlock"/> and continues with the <see cref="Parent"/>.
        /// </summary>
        /// <returns>The parent <see cref="CodeBlock"/>.</returns>
        public CodeBlock Close() => Parent;

        /// <summary>
        /// Ends the <see cref="CodeBlock"/> code adding.
        /// </summary>
#pragma warning disable CA1822 // Mark members as static
        public void End()
#pragma warning restore CA1822 // Mark members as static
        {
        }

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            SourceSnippet.Ident(source, identation);
            _ = source.AppendLine("{");
            identation++;

            foreach (var section in Sections)
            {
                section.Generate(source, identation);
            }

            identation--;
            SourceSnippet.Ident(source, identation);
            _ = source.AppendLine("}");
        }

        private CodeBlock AddSection(CodeSection section)
        {
            Sections.Add(section);
            return this;
        }
    }
}
