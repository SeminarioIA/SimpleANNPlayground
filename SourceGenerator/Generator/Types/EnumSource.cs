// <copyright file="EnumSource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.CodeSections;
using System.Collections.ObjectModel;
using System.Text;

namespace SourceGenerator.Generator.Types
{
    /// <summary>
    /// Specifies the <see cref="EnumAccess"/> attributes used for <see cref="EnumSource"/>.
    /// </summary>
    public enum EnumAccess
    {
        /// <summary>
        /// The class can only be accessed from the parent class.
        /// </summary>
        Private,

        /// <summary>
        /// The class can be accessed only from derived classes.
        /// </summary>
        Protected,

        /// <summary>
        /// The class can be accessed only from the same library.
        /// </summary>
        Internal,

        /// <summary>
        /// The class is accesible externally.
        /// </summary>
        Public,
    }

    /// <summary>
    /// Represents an enum source code.
    /// </summary>
    public class EnumSource : SourceSnippet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSource"/> class.
        /// </summary>
        /// <param name="access">The <see cref="EnumAccess"/> attributes.</param>
        /// <param name="name">The <see cref="EnumSource"/> name.</param>
        /// <param name="description">The <see cref="EnumSource"/> description.</param>
        internal EnumSource(EnumAccess access, string name, string description)
            : base(name)
        {
            Access = access;
            Elements = new Collection<EnumElement>();
            SetDescription(description);
        }

        /// <summary>
        /// Gets the <see cref="EnumAccess"/> attributes of this <see cref="EnumSource"/>.
        /// </summary>
        public EnumAccess Access { get; }

        /// <summary>
        /// Gets the collection of <see cref="EnumElement"/> of this <see cref="EnumSource"/>.
        /// </summary>
        public Collection<EnumElement> Elements { get; }

        /// <inheritdoc/>
        public override string ToString() => $"class {Name}";

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            GenerateSummary(source, identation);
            Ident(source, identation);
            _ = source.AppendLine("{");
            identation++;

            foreach (var element in Elements)
            {
                element.Generate(source, identation);
            }

            identation--;
            SourceSnippet.Ident(source, identation);
            _ = source.AppendLine("}");
        }
    }
}
