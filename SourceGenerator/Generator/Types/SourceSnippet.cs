// <copyright file="SourceSnippet.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Text;

namespace SourceGenerator.Generator.Types
{
    /// <summary>
    /// Represents a source code element.
    /// </summary>
    public abstract class SourceSnippet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceSnippet"/> class.
        /// </summary>
        /// <param name="name">The <see cref="SourceSnippet"/> name.</param>
        protected SourceSnippet(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the <see cref="SourceSnippet"/> name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the <see cref="SourceSnippet"/> description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Adds the description to the class.
        /// </summary>
        /// <param name="description">Description to add to the class.</param>
        public void SetDescription(string description) => Description = description;

        /// <inheritdoc/>
        public override string ToString() => Name;

        /// <summary>
        /// Appends the identation space in the source code.
        /// </summary>
        /// <param name="source">The <see cref="StringBuilder"/> to append the source code.</param>
        /// <param name="identation">The identation to follow when appending the code.</param>
        internal static void Ident(StringBuilder source, int identation) => source.Append(' ', identation * SourceFileGenerator.IndexationSpaces);

        /// <summary>
        /// Generates this <see cref="SourceSnippet"/> source code and appends the code into a <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="source">The <see cref="StringBuilder"/> to append the source code.</param>
        /// <param name="identation">The identation to follow when appending the code.</param>
        /// <param name="description">The description to include in the summary.</param>
        internal static void GenerateSummary(StringBuilder source, int identation, string description)
        {
            _ = source.AppendLine();
            Ident(source, identation);
            _ = source.AppendLine("/// <summary>");
            Ident(source, identation);
            _ = source.AppendLine($"/// {description}");
            Ident(source, identation);
            _ = source.AppendLine("/// </summary>");
        }

        /// <summary>
        /// Generates the <see cref="SourceSnippet"/> source code.
        /// </summary>
        /// <param name="source">The <see cref="StringBuilder"/> to append the source code.</param>
        /// <param name="identation">The identation to follow when appending the code.</param>
        internal abstract void Generate(StringBuilder source, int identation);

        /// <summary>
        /// Generates this <see cref="SourceSnippet"/> source code and appends the code into a <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="source">The <see cref="StringBuilder"/> to append the source code.</param>
        /// <param name="identation">The identation to follow when appending the code.</param>
        internal void GenerateSummary(StringBuilder source, int identation) => GenerateSummary(source, identation, Description);
    }
}
