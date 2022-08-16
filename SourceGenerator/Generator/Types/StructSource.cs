// <copyright file="StructSource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using System.Text;

namespace SourceGenerator.Generator.Types
{
    /// <summary>
    /// Specifies the <see cref="StructScope"/> attributes used for <see cref="ClassSource"/>.
    /// </summary>
    public enum StructScope
    {
        /// <summary>
        /// The class does not contains defined attributes.
        /// </summary>
        Normal,

        /// <summary>
        /// The class does not provide an implementation.
        /// </summary>
        Abstract,

        /// <summary>
        /// Prevents other classes from inheriting from it.
        /// </summary>
        Sealed,

        /// <summary>
        /// The class contains only static members.
        /// </summary>
        Static,
    }

    /// <summary>
    /// Specifies the <see cref="StructAccess"/> attributes used for <see cref="ClassSource"/>.
    /// </summary>
    public enum StructAccess
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
    /// Represents a struct source code.
    /// </summary>
    public class StructSource : SourceSnippet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StructSource"/> class.
        /// </summary>
        /// <param name="parent">The parent source element.</param>
        /// <param name="access">The <see cref="StructAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="StructScope"/> attributes.</param>
        /// <param name="name">The <see cref="ClassSource"/> name.</param>
        public StructSource(SourceSnippet parent, StructAccess access, StructScope scope, string name)
            : base(parent, name)
        {
            Access = access;
            Scope = scope;
            Members = new Collection<SourceSnippet>();
            SetDescription($"Initializes a new instance of the <see cref=\"{name}\"/> struct.");
        }

        /// <summary>
        /// Gets the <see cref="ClassAccess"/> attributes.
        /// </summary>
        public StructAccess Access { get; }

        /// <summary>
        /// Gets the <see cref="ClassScope"/> attributes.
        /// </summary>
        public StructScope Scope { get; }

        /// <summary>
        /// Gets this <see cref="ClassSource"/> members.
        /// </summary>
        public Collection<SourceSnippet> Members { get; }

        /// <inheritdoc/>
        public override string ToString() => $"class {Name}";

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            GenerateSummary(source, identation);

            Ident(source, identation);
            switch (Access)
            {
                case StructAccess.Public:
                    _ = source.Append("public ");
                    break;
                case StructAccess.Internal:
                    _ = source.Append("internal ");
                    break;
                case StructAccess.Protected:
                    _ = source.Append("protected ");
                    break;
                case StructAccess.Private:
                default:
                    _ = source.Append("private ");
                    break;
            }

            switch (Scope)
            {
                case StructScope.Abstract:
                    _ = source.Append("abstract ");
                    break;
                case StructScope.Sealed:
                    _ = source.Append("sealed ");
                    break;
                case StructScope.Static:
                    _ = source.Append("static ");
                    break;
                case StructScope.Normal:
                default:
                    break;
            }

            _ = source.AppendLine(ToString());
            Ident(source, identation);
            _ = source.Append('{');
            identation++;

            foreach (var member in Members)
            {
                member.Generate(source, identation);
            }

            identation--;
            Ident(source, identation);
            _ = source.AppendLine("}");
        }
    }
}
