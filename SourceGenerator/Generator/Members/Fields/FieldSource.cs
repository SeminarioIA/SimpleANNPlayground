// <copyright file="FieldSource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Text;

namespace SourceGenerator.Generator.Members.Fields
{
    /// <summary>
    /// Specifies member access attributes used for <see cref="FieldAttributes"/>.
    /// </summary>
    public enum FieldAttributes
    {
        /// <summary>
        /// Field without attributes.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// The field is accesible externally.
        /// </summary>
        Public = 0x01,

        /// <summary>
        /// The field can be accessed only from the same library.
        /// </summary>
        Internal = 0x02,

        /// <summary>
        /// The field can only be accessed from the owner class.
        /// </summary>
        Private = 0x03,

        /// <summary>
        /// Mask to get the field access.
        /// </summary>
        AccessMask = 0x0F,

        /// <summary>
        /// The field does not require an object instance.
        /// </summary>
        Static = 0x10,

        /// <summary>
        /// The field does not require an object instance.
        /// </summary>
        ReadOnly = 0x20,

        /// <summary>
        /// The field does not require an object instance.
        /// </summary>
        Const = 0x30,
    }

    /// <summary>
    /// Represents a field element source code.
    /// </summary>
    internal class FieldSource : MemberSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldSource"/> class.
        /// </summary>
        /// <param name="attributes">The <see cref="FieldAttributes"/>.</param>
        /// <param name="name">The <see cref="FieldSource"/> name.</param>
        /// <param name="value">The <see cref="FieldSource"/> value.</param>
        /// <param name="description">The method description to add in the documentation.</param>
        internal FieldSource(FieldAttributes attributes, string name, string value, string description = "")
            : base(name)
        {
            Attributes = attributes;
            SetDescription(description);
            SetExpressionBody(value);
        }

        /// <summary>
        /// Gets the <see cref="FieldAttributes"/> of this <see cref="FieldSource"/>.
        /// </summary>
        public FieldAttributes Attributes { get; }

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            GenerateSummary(source, identation);

            Ident(source, identation);
            switch (Attributes | FieldAttributes.AccessMask)
            {
                case FieldAttributes.Public:
                    _ = source.Append("public ");
                    break;
                case FieldAttributes.Internal:
                    _ = source.Append("internal ");
                    break;
                case FieldAttributes.Private:
                default:
                    _ = source.Append("private ");
                    break;
            }

            if (Attributes.HasFlag(FieldAttributes.Const))
            {
                _ = source.Append("const ");
            }
            else
            {
                if (Attributes.HasFlag(FieldAttributes.Static)) _ = source.Append("static ");
                if (Attributes.HasFlag(FieldAttributes.ReadOnly)) _ = source.Append("readonly ");
            }

            _ = source.Append(ToString());
            _ = source.AppendLine(" = " + ExpressionBody);
            }
    }
}
