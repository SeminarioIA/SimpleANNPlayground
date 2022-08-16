// <copyright file="CodeBlock.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.Types;
using System;
using System.Collections.Generic;
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
        /// <param name="parent">The parent <see cref="CodeSection"/> of this <see cref="CodeBlock"/>.</param>
        /// <param name="semiColon">Indicates if the block is semi-colon ended.</param>
        public CodeBlock(CodeSection parent, bool semiColon = false)
            : base(parent)
        {
            Sections = new Collection<CodeSection>();
            SemiColon = semiColon;
        }

        /// <summary>
        /// Gets the <see cref="CodeSection"/> collection of this <see cref="CodeBlock"/>.
        /// </summary>
        public Collection<CodeSection> Sections { get; }

        /// <summary>
        /// Gets a value indicating whether the code block is semiColon ended.
        /// </summary>
        public bool SemiColon { get; }

        /// <summary>
        /// Adds a new <see cref="CodeLine"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <param name="line">The line of code to add.</param>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public CodeBlock AddLine(string line) => AddSection(new CodeLine(this, line));

        /// <summary>
        /// Adds a new <see cref="CodeLine"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <param name="items">A collection of items.</param>
        /// <param name="line">A function that return the code line.</param>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public CodeBlock AddLines(ICollection<string> items, Func<string, string> line)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (string item in items)
            {
                Sections.Add(new CodeLine(this, line?.Invoke(item)));
            }

            return this;
        }

        /// <summary>
        /// Adds a new <see cref="EmptyLine"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public CodeBlock AddEmptyLine() => AddSection(new EmptyLine(this));

        /// <summary>
        /// Adds a new <see cref="Comment"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <param name="text">The text to add as a comment.</param>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public CodeBlock AddComment(string text) => AddSection(new Comment(this, text));

        /// <summary>
        /// Adds a nested <see cref="CodeBlock"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <param name="semiColon">Indicates if the block is semi-colon ended.</param>
        /// <returns>The new added <see cref="CodeBlock"/>.</returns>
        public CodeBlock AddBlock(bool semiColon = false)
        {
            var block = new CodeBlock(this, semiColon);
            Sections.Add(block);
            return block;
        }

        /// <summary>
        /// Closes the current <see cref="CodeBlock"/> and continues with the parent.
        /// </summary>
        /// <returns>The parent <see cref="CodeBlock"/>.</returns>
        public CodeBlock Close() => Parent as CodeBlock;

        /// <summary>
        /// Adds a new <see cref="FieldValue"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <param name="value">The value to initialize.</param>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public CodeBlock AddFieldValue(string value)
        {
            var fieldValue = new FieldValue(this, value);
            Sections.Add(fieldValue);
            return this;
        }

        /// <summary>
        /// Adds a new <see cref="FieldValue"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <param name="value">The value to initialize.</param>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public FieldValue AddFieldValueBlock(string value)
        {
            var fieldValue = new FieldValue(this, value);
            Sections.Add(fieldValue);
            return fieldValue;
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
            _ = source.Append('}');
            if (SemiColon) _ = source.Append(';');
            _ = source.AppendLine();
        }

        private CodeBlock AddSection(CodeSection section)
        {
            Sections.Add(section);
            return this;
        }
    }
}
