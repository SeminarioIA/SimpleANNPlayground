// <copyright file="MethodSource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.CodeSections;
using SourceGenerator.Generator.Types;
using System.Collections.ObjectModel;
using System.Text;

namespace SourceGenerator.Generator.Members.Methods
{
    /// <summary>
    /// Specifies member scope attributes used for <see cref="MethodSource"/>.
    /// </summary>
    public enum MethodScope
    {
        /// <summary>
        /// No specified.
        /// </summary>
        None,

        /// <summary>
        /// The method does not provide an implementation.
        /// </summary>
        Abstract,

        /// <summary>
        /// Replaces the parent class method implementation.
        /// </summary>
        Override,

        /// <summary>
        /// Prevents other classes from continue inheriting the method.
        /// </summary>
        Virtual,

        /// <summary>
        /// The method does not require an object instance.
        /// </summary>
        Static,
    }

    /// <summary>
    /// Specifies member access attributes used for <see cref="MethodSource"/>.
    /// </summary>
    public enum MethodAccess
    {
        /// <summary>
        /// The method is accesible externally.
        /// </summary>
        Public,

        /// <summary>
        /// The method can be accessed only from the same library.
        /// </summary>
        Internal,

        /// <summary>
        /// The method can be accessed only from derived classes.
        /// </summary>
        Protected,

        /// <summary>
        /// The method can only be accessed from the owner class.
        /// </summary>
        Private,

        /// <summary>
        /// Prevents derived classes from continue inheriting the method.
        /// </summary>
        Sealed,
    }

    /// <summary>
    /// Represents a class method source code.
    /// </summary>
    public class MethodSource : MemberSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodSource"/> class.
        /// </summary>
        /// <param name="parent">The parent source element.</param>
        /// <param name="access">The <see cref="MethodAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="MethodScope"/> attributes.</param>
        /// <param name="name">The method name.</param>
        /// <param name="description">The method description to add in the documentation.</param>
        internal MethodSource(SourceSnippet parent, MethodAccess access, MethodScope scope, string name, string description = "")
            : base(parent, name)
        {
            Access = access;
            Scope = scope;
            Parameters = new Collection<Parameter>();
            SetDescription(description);
        }

        /// <summary>
        /// Gets the <see cref="MethodAccess"/> attributes of this <see cref="MethodSource"/>.
        /// </summary>
        public MethodAccess Access { get; }

        /// <summary>
        /// Gets the <see cref="MethodScope"/> attributes of this <see cref="MethodSource"/>.
        /// </summary>
        public MethodScope Scope { get; }

        /// <summary>
        /// Gets the list of <see cref="Parameter"/> defined for this <see cref=" MethodSource"/>.
        /// </summary>
        public Collection<Parameter> Parameters { get; }

        /// <summary>
        /// Adds the description to this <see cref="MethodSource"/>.
        /// </summary>
        /// <param name="description">Description to add to the laset added source member.</param>
        /// <returns>This <see cref="MethodSource"/>.</returns>
        public MethodSource AddDoc(string description)
        {
            SetDescription(description);
            return this;
        }

        /// <summary>
        /// Adds a new <see cref="Parameter"/> to the source file.
        /// </summary>
        /// <param name="type">The <see cref="Parameter"/> type.</param>
        /// <param name="name">The <see cref="Parameter"/> name.</param>
        /// <param name="description">The <see cref="Parameter"/> description.</param>
        /// <returns>The current <see cref="MethodSource"/>.</returns>
        public MethodSource AddParameter(string type, string name, string description)
        {
            var param = new Parameter(type, name, description);
            Parameters.Add(param);
            return this;
        }

        /// <summary>
        /// Gets the <see cref="CodeBlock"/> object of this method.
        /// </summary>
        /// <param name="codeBlock">The <see cref="CodeBlock"/> of this method.</param>
        /// <returns>The current method.</returns>
        public MethodSource GetCodeBlock(out CodeBlock codeBlock)
        {
            codeBlock = Code;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString() => $"void {Name}({string.Join(", ", Parameters)})";

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            if (string.IsNullOrWhiteSpace(Description) && Scope == MethodScope.Override)
            {
                _ = source.AppendLine();
                Ident(source, identation);
                _ = source.AppendLine("/// <inheritdoc/>");
            }
            else
            {
                GenerateSummary(source, identation);
                foreach (var param in Parameters)
                {
                    param.GenerateDoc(source, identation);
                }
            }

            Ident(source, identation);

            switch (Access)
            {
                case MethodAccess.Public:
                    _ = source.Append("public ");
                    break;
                case MethodAccess.Internal:
                    _ = source.Append("internal ");
                    break;
                case MethodAccess.Protected:
                    _ = source.Append("protected ");
                    break;
                case MethodAccess.Private:
                default:
                    _ = source.Append("private ");
                    break;
            }

            if (Access.HasFlag(MethodAccess.Sealed)) _ = source.Append("sealed ");

            switch (Scope)
            {
                case MethodScope.Abstract:
                    _ = source.Append("abstract ");
                    break;
                case MethodScope.Override:
                    _ = source.Append("override ");
                    break;
                case MethodScope.Virtual:
                    _ = source.Append("virtual ");
                    break;
                case MethodScope.Static:
                    _ = source.Append("static ");
                    break;
                default:
                    break;
            }

            _ = source.Append(ToString());

            base.Generate(source, identation);
        }
    }
}
