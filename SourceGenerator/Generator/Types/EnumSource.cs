// <copyright file="EnumSource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.CodeSections;
using SourceGenerator.Generator.Members.Methods;
using System;
using System.Collections.Generic;
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
        /// <param name="parent">The parent source element.</param>
        /// <param name="name">The <see cref="EnumSource"/> name.</param>
        internal EnumSource(SourceSnippet parent, EnumAccess access, string name)
            : base(parent, name)
        {
            Access = access;
            Elements = new Collection<EnumElement>();
        }

        /// <summary>
        /// Gets the <see cref="EnumAccess"/> attributes of this <see cref="EnumSource"/>.
        /// </summary>
        public EnumAccess Access { get; }

        /// <summary>
        /// Gets the collection of <see cref="EnumElement"/> of this <see cref="EnumSource"/>.
        /// </summary>
        public Collection<EnumElement> Elements { get; }

        /// <summary>
        /// Adds the description to the last member added to the class source codes.
        /// </summary>
        /// <param name="description">Description to add to the laset added source member.</param>
        /// <returns>This <see cref="EnumSource"/>.</returns>
        public EnumSource AddDoc(string description)
        {
            SetDescription(description);
            return this;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumElement"/> class.
        /// </summary>
        /// <param name="name">The name of the enum element.</param>
        /// <param name="description">The description of the enum element.</param>
        /// <returns>The current enum.</returns>
        public EnumSource AddElement(string name, string description)
        {
            var element = new EnumElement(this, name, description);
            Elements.Add(element);
            return this;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumElement"/> class.
        /// </summary>
        /// <param name="names">Collection of strings containing the elements names.</param>
        /// <param name="description">Function to get the element description from the element name.</param>
        /// <returns>The current enum.</returns>
        public EnumSource AddElements(ICollection<string> names, Func<string, string> description)
        {
            if (names == null) throw new ArgumentNullException(nameof(names));
            foreach (string name in names)
            {
                var element = new EnumElement(this, name, description?.Invoke(name));
                Elements.Add(element);
            }

            return this;
        }

        /// <inheritdoc/>
        public override string ToString() => $"enum {Name}";

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            GenerateSummary(source, identation);

            Ident(source, identation);
            switch (Access)
            {
                case EnumAccess.Public:
                    _ = source.Append("public ");
                    break;
                case EnumAccess.Internal:
                    _ = source.Append("internal ");
                    break;
                case EnumAccess.Protected:
                    _ = source.Append("protected ");
                    break;
                case EnumAccess.Private:
                default:
                    _ = source.Append("private ");
                    break;
            }

            _ = source.AppendLine(ToString());

            Ident(source, identation);
            _ = source.Append('{');
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
