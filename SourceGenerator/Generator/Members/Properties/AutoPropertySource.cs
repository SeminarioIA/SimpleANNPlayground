// <copyright file="AutoPropertySource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.CodeSections;
using SourceGenerator.Generator.Members.Methods;
using System.Text;

namespace SourceGenerator.Generator.Members.Properties
{
    /// <summary>
    /// Specifies member access attributes used for <see cref="PropertySource"/>.
    /// </summary>
    public enum SetPropertyAccess
    {
        /// <summary>
        /// The property is accesible externally.
        /// </summary>
        Public,

        /// <summary>
        /// The property can be accessed only from the same library.
        /// </summary>
        Internal,

        /// <summary>
        /// The property can be accessed only from derived classes.
        /// </summary>
        Protected,

        /// <summary>
        /// The property can only be accessed from the owner class.
        /// </summary>
        Private,

        /// <summary>
        /// Prevents derived classes from continue inheriting the property.
        /// </summary>
        Sealed,
    }

    /// <summary>
    /// Represents an auto property source code.
    /// </summary>
    internal class AutoPropertySource : PropertySource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoPropertySource"/> class.
        /// </summary>
        /// <param name="access">The <see cref="MethodAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="MethodScope"/> attributes.</param>
        /// <param name="name">The property name.</param>
        /// <param name="description">The property description to add in the documentation.</param>
        public AutoPropertySource(PropertyAccess access, PropertyScope scope, string name, string description = "")
            : base(access, scope, name, description)
        {
        }

        /// <summary>
        /// Gets the <see cref="SetPropertyAccess"/> attributes of this <see cref="AutoPropertySource"/>.
        /// </summary>
        public PropertyAccess SetAccess { get; }

        /// <summary>
        /// Gets the <see cref="CodeBlock"/> of this property.
        /// </summary>
        public CodeBlock SetCode { get; private set; }

        /// <summary>
        /// Gets the property expression body.
        /// </summary>
        public string SetBody { get; private set; }

        /// <summary>
        /// Sets the code of this method as Expression body.
        /// </summary>
        /// <param name="code">The expression code.</param>
        public void SetExpressionSetBody(string code)
        {
            SetCode = null;
            SetBody = code;
        }

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            GenerateDeclaration(source, identation);

            if (Code.Sections.Count == 0)
            {
                _ = ExpressionBody == null ? source.AppendLine(" { get; }") : source.AppendLine(" => " + ExpressionBody);
            }
            else
            {
                _ = source.AppendLine();
                Ident(source, identation++);
                _ = source.AppendLine("{");

                _ = source.AppendLine("get");
                Ident(source, identation++);
                _ = source.AppendLine("{");

                _ = source.AppendLine();
                Code.Generate(source, identation);

                Ident(source, --identation);
                _ = source.AppendLine("}");

                Ident(source, --identation);
                _ = source.AppendLine("}");
            }
        }
    }
}
