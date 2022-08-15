// <copyright file="AutoPropertySource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.CodeSections;
using System;
using System.Text;

namespace SourceGenerator.Generator.Members.Properties
{
    /// <summary>
    /// Represents an auto property source code.
    /// </summary>
    public class AutoPropertySource : PropertySource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoPropertySource"/> class.
        /// </summary>
        /// <param name="access">The <see cref="PropertyAccess"/> attributes for the get property.</param>
        /// <param name="scope">The <see cref="PropertyScope"/> attributes for the property.</param>
        /// <param name="type">The property type.</param>
        /// <param name="name">The property name.</param>
        /// <param name="setAccess">The <see cref="PropertyAccess"/> attributes for the set property.</param>
        /// <param name="value">The property initialization value.</param>
        public AutoPropertySource(PropertyAccess access, PropertyScope scope, string type, string name, PropertyAccess setAccess = PropertyAccess.Default, string value = "")
            : base(access, scope, type, name, value)
        {
            SetAccess = setAccess;
            SetCode = new CodeBlock();
        }

        /// <summary>
        /// Gets the <see cref="PropertyAccess"/> attributes of this <see cref="AutoPropertySource"/>.
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

            string access;
            switch (SetAccess)
            {
                case PropertyAccess.Public:
                    access = "public ";
                    break;
                case PropertyAccess.Internal:
                    access = "internal ";
                    break;
                case PropertyAccess.Protected:
                    access = "protected ";
                    break;
                case PropertyAccess.Private:
                    access = "private ";
                    break;
                default:
                    access = string.Empty;
                    break;
            }

            if (Code.Sections.Count == 0 && SetCode.Sections.Count == 0)
            {
                if (ExpressionBody == null && SetBody == null)
                {
                    _ = source.Append($"{{ get; {access}set; }}");
                }
                else if (ExpressionBody != null && SetBody != null)
                {
                    _ = source.AppendLine();
                    Ident(source, identation++);
                    _ = source.AppendLine("{");

                    _ = source.AppendLine("get => " + ExpressionBody);
                    _ = source.AppendLine($"{access}set => " + SetBody);

                    Ident(source, --identation);
                    _ = source.Append('}');
                }
                else
                {
                    throw new InvalidOperationException();
                }
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

                _ = source.AppendLine($"{access}set");
                Ident(source, identation++);
                _ = source.AppendLine("{");

                _ = source.AppendLine();
                SetCode.Generate(source, identation);

                Ident(source, --identation);
                _ = source.AppendLine("}");

                Ident(source, --identation);
                _ = source.Append('}');
            }

            _ = string.IsNullOrWhiteSpace(Value) ? source.AppendLine() : source.AppendLine($" = {Value};");
        }
    }
}
