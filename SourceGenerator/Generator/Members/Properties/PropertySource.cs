// <copyright file="PropertySource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.CodeSections;
using SourceGenerator.Generator.Members.Methods;
using SourceGenerator.Generator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGenerator.Generator.Members.Properties
{
    /// <summary>
    /// Specifies member scope attributes used for <see cref="PropertySource"/>.
    /// </summary>
    public enum PropertyScope
    {
        /// <summary>
        /// No specified.
        /// </summary>
        None,

        /// <summary>
        /// The property does not provide an implementation.
        /// </summary>
        Abstract,

        /// <summary>
        /// Replaces the parent class property implementation.
        /// </summary>
        Override,

        /// <summary>
        /// Prevents other classes from continue inheriting the property.
        /// </summary>
        Virtual,

        /// <summary>
        /// The property does not require an object instance.
        /// </summary>
        Static,
    }

    /// <summary>
    /// Specifies member access attributes used for <see cref="PropertySource"/>.
    /// </summary>
    public enum PropertyAccess
    {
        /// <summary>
        /// The same access as the Property Get.
        /// </summary>
        Default,

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
    /// Represents a property source code.
    /// </summary>
    public class PropertySource : MemberSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertySource"/> class.
        /// </summary>
        /// <param name="parent">The parent source element.</param>
        /// <param name="access">The <see cref="MethodAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="MethodScope"/> attributes.</param>
        /// <param name="name">The property name.</param>
        /// <param name="type">The property type.</param>
        /// <param name="value">The property initialization value.</param>
        /// <param name="expresionBody">The property is implemented in the expression body form.</param>
        public PropertySource(SourceSnippet parent, PropertyAccess access, PropertyScope scope, string type, string name, string value = "", bool expresionBody = true)
            : base(parent, name)
        {
            Access = access;
            Scope = scope;
            Type = type;
            Value = new FieldValue(this, value);
            ExpressionBodyValue = expresionBody;
        }

        /// <summary>
        /// Gets the <see cref="PropertyAccess"/> attributes of this <see cref="PropertySource"/>.
        /// </summary>
        public PropertyAccess Access { get; }

        /// <summary>
        /// Gets the <see cref="PropertyScope"/> attributes of this <see cref="PropertySource"/>.
        /// </summary>
        public PropertyScope Scope { get; }

        /// <summary>
        /// Gets the <see cref="PropertySource"/> type.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the <see cref="PropertySource"/> value.
        /// </summary>
        public FieldValue Value { get; private set; }

        /// <summary>
        /// Gets a value indicating whether if the property is implemented as expression body.
        /// </summary>
        public bool ExpressionBodyValue { get; private set; }

        /// <summary>
        /// Adds the description to the last member added to the class source codes.
        /// </summary>
        /// <param name="description">Description to add to the laset added source member.</param>
        /// <returns>This <see cref="PropertySource"/>.</returns>
        public PropertySource AddDoc(string description)
        {
            SetDescription(description);
            return this;
        }

        /// <summary>
        /// Adds a new <see cref="CodeLine"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <param name="line">The line of code to add.</param>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public PropertySource AddValue(string line)
        {
            Value.Code.Sections.Add(new CodeLine(this, line));

            return this;
        }

        /// <summary>
        /// Adds a new <see cref="CodeLine"/> to this <see cref="CodeBlock"/>.
        /// </summary>
        /// <param name="items">A collection of items.</param>
        /// <param name="line">A function that return the code line.</param>
        /// <returns>The current <see cref="CodeBlock"/>.</returns>
        public PropertySource AddValues(ICollection<string> items, Func<string, string> line)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (string item in items)
            {
                Value.Code.Sections.Add(new CodeLine(this, line?.Invoke(item)));
            }

            return this;
        }

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            GenerateDeclaration(source, identation);

            if (Code.Sections.Count == 0)
            {
                if (ExpressionBody == null)
                {
                    if (string.IsNullOrWhiteSpace(Value.Value))
                    {
                        _ = source.AppendLine(" { get; }");
                    }
                    else
                    {
                        _ = ExpressionBodyValue
                            ? source.AppendLine("=> " + Value.Value)
                            : source.AppendLine("{ get; } = " + Value.Value + (Value.Code.Sections.Count > 0 ? string.Empty : ";"));

                        if (Value.Code.Sections.Count > 0)
                        {
                            Value.Code.Generate(source, identation);
                        }
                    }
                }
                else
                {
                    _ = source.AppendLine(" => " + ExpressionBody);
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

                Ident(source, --identation);
                _ = source.AppendLine("}");
            }
        }

        /// <summary>
        /// Generates the declaration <see cref="PropertySource"/> source code.
        /// </summary>
        /// <param name="source">The <see cref="StringBuilder"/> to append the source code.</param>
        /// <param name="identation">The identation to follow when appending the code.</param>
        protected void GenerateDeclaration(StringBuilder source, int identation)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (string.IsNullOrWhiteSpace(Description) && Scope == PropertyScope.Override)
            {
                _ = source.AppendLine();
                Ident(source, identation);
                _ = source.AppendLine("/// <inheritdoc/>");
            }
            else
            {
                GenerateSummary(source, identation);
            }

            Ident(source, identation);

            switch (Access)
            {
                case PropertyAccess.Public:
                    _ = source.Append("public ");
                    break;
                case PropertyAccess.Internal:
                    _ = source.Append("internal ");
                    break;
                case PropertyAccess.Protected:
                    _ = source.Append("protected ");
                    break;
                case PropertyAccess.Private:
                default:
                    _ = source.Append("private ");
                    break;
            }

            if (Access.HasFlag(PropertyAccess.Sealed)) _ = source.Append("sealed ");

            switch (Scope)
            {
                case PropertyScope.Abstract:
                    _ = source.Append("abstract ");
                    break;
                case PropertyScope.Override:
                    _ = source.Append("override ");
                    break;
                case PropertyScope.Virtual:
                    _ = source.Append("virtual ");
                    break;
                case PropertyScope.Static:
                    _ = source.Append("static ");
                    break;
                default:
                    break;
            }

            _ = source.Append($"{Type} {Name} ");
        }
    }
}
