// <copyright file="ClassSource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.Members.Methods;
using SourceGenerator.Generator.Members.Properties;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SourceGenerator.Generator.Types
{
    /// <summary>
    /// Specifies the <see cref="ClassScope"/> attributes used for <see cref="ClassSource"/>.
    /// </summary>
    public enum ClassScope
    {
        /// <summary>
        /// The class does not contains defined attributes.
        /// </summary>
        Normal = 0x00,

        /// <summary>
        /// The class does not provide an implementation.
        /// </summary>
        Abstract = 0x01,

        /// <summary>
        /// Prevents other classes from inheriting from it.
        /// </summary>
        Sealed = 0x02,

        /// <summary>
        /// The class contains only static members.
        /// </summary>
        Static = 0x03,

        /// <summary>
        /// The mask of the scope.
        /// </summary>
        ScopeMask = 0x0F,

        /// <summary>
        /// The class is a partial definition.
        /// </summary>
        Partial = 0x10,
    }

    /// <summary>
    /// Specifies the <see cref="ClassAccess"/> attributes used for <see cref="ClassSource"/>.
    /// </summary>
    public enum ClassAccess
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
    /// Represents a class source code.
    /// </summary>
    public class ClassSource : SourceSnippet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassSource"/> class.
        /// </summary>
        /// <param name="parent">The parent source element.</param>
        /// <param name="access">The <see cref="ClassAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="ClassScope"/> attributes.</param>
        /// <param name="name">The <see cref="ClassSource"/> name.</param>
        internal ClassSource(SourceSnippet parent, ClassAccess access, ClassScope scope, string name)
            : base(parent, name)
        {
            Access = access;
            Scope = scope;
            Members = new Collection<SourceSnippet>();
        }

        /// <summary>
        /// Gets the <see cref="ClassAccess"/> attributes.
        /// </summary>
        public ClassAccess Access { get; }

        /// <summary>
        /// Gets the <see cref="ClassScope"/> attributes.
        /// </summary>
        public ClassScope Scope { get; }

        /// <summary>
        /// Gets this <see cref="ClassSource"/> members.
        /// </summary>
        public Collection<SourceSnippet> Members { get; }

        /// <summary>
        /// Adds a new <see cref="ConstructorSource"/> to the <see cref="ClassSource"/>.
        /// </summary>
        /// <param name="access">The <see cref="MethodAccess"/> attributes.</param>
        /// <returns>The new added <see cref="ConstructorSource"/>.</returns>
        public ConstructorSource AddConstructor(MethodAccess access)
        {
            var constructor = new ConstructorSource(this, access, this);
            Members.Add(constructor);
            return constructor;
        }

        /// <summary>
        /// Adds a new <see cref="MethodSource"/> to the <see cref="ClassSource"/>.
        /// </summary>
        /// <param name="access">The <see cref="MethodAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="MethodScope"/> attributes.</param>
        /// <param name="name">The method name.</param>
        /// <param name="description">The method description to add in the documentation.</param>
        /// <returns>The new added <see cref="MethodSource"/>.</returns>
        public MethodSource AddMethod(MethodAccess access, MethodScope scope, string name, string description = "")
        {
            var method = new MethodSource(this, access, scope, name, description);
            Members.Add(method);
            return method;
        }

        /// <summary>
        /// Adds a new <see cref="FunctionSource"/> to the <see cref="ClassSource"/>.
        /// </summary>
        /// <param name="access">The <see cref="MethodAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="MethodScope"/> attributes.</param>
        /// <param name="name">The method name.</param>
        /// <param name="description">The method description to add in the documentation.</param>
        /// <returns>The new added <see cref="FunctionSource"/>.</returns>
        public FunctionSource AddFunction(MethodAccess access, MethodScope scope, string name, string description = "")
        {
            var function = new FunctionSource(this, access, scope, name, description);
            Members.Add(function);
            return function;
        }

        /// <summary>
        /// Adds a new <see cref="PropertySource"/> to the <see cref="ClassSource"/>.
        /// </summary>
        /// <param name="access">The <see cref="PropertyAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="PropertyScope"/> attributes.</param>
        /// <param name="type">The <see cref="PropertySource"/> type.</param>
        /// <param name="name">The <see cref="PropertySource"/> name.</param>
        /// <param name="value">The property initialization value.</param>
        /// <returns>The current <see cref="ClassSource"/>.</returns>
        public PropertySource AddProperty(PropertyAccess access, PropertyScope scope, string type, string name, string value = "")
        {
            var property = new PropertySource(this, access, scope, type, name, value, true);
            Members.Add(property);
            return property;
        }

        /// <summary>
        /// Adds a new <see cref="PropertySource"/> to the <see cref="ClassSource"/>.
        /// </summary>
        /// <param name="access">The <see cref="PropertyAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="PropertyScope"/> attributes.</param>
        /// <param name="type">The <see cref="PropertySource"/> type.</param>
        /// <param name="name">The <see cref="PropertySource"/> name.</param>
        /// <param name="value">The property initialization value.</param>
        /// <returns>The current <see cref="ClassSource"/>.</returns>
        public PropertySource AddPropertyWithValue(PropertyAccess access, PropertyScope scope, string type, string name, string value = "")
        {
            var property = new PropertySource(this, access, scope, type, name, value, false);
            Members.Add(property);
            return property;
        }

        /// <summary>
        /// Adds a new <see cref="AutoPropertySource"/> to the <see cref="ClassSource"/>.
        /// </summary>
        /// <param name="access">The <see cref="PropertyAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="PropertyScope"/> attributes.</param>
        /// <param name="type">The <see cref="PropertySource"/> type.</param>
        /// <param name="name">The <see cref="PropertySource"/> name.</param>
        /// <param name="setAccess">The <see cref="PropertyAccess"/> attributes for the set property.</param>
        /// <param name="value">The property initialization value.</param>
        /// <returns>The current <see cref="ClassSource"/>.</returns>
        public PropertySource AddAutoProperty(PropertyAccess access, PropertyScope scope, string type, string name, PropertyAccess setAccess, string value = "")
        {
            var property = new AutoPropertySource(this, access, scope, type, name, setAccess, value);
            Members.Add(property);
            return property;
        }

        /// <summary>
        /// Adds a new <see cref="EnumSource"/> to the class source code.
        /// </summary>
        /// <param name="access">The <see cref="EnumAccess"/> attributes.</param>
        /// <param name="name">The <see cref="EnumSource"/> name.</param>
        /// <returns>The new added <see cref="EnumSource"/>.</returns>
        public EnumSource AddEnum(EnumAccess access, string name)
        {
            var @enum = new EnumSource(this, access, name);
            Members.Add(@enum);
            return @enum;
        }

        /// <summary>
        /// Adds the description to the last member added to the class source codes.
        /// </summary>
        /// <param name="description">Description to add to the laset added source member.</param>
        /// <returns>This <see cref="ClassSource"/>.</returns>
        public ClassSource AddDoc(string description)
        {
            SetDescription(description);
            return this;
        }

        /// <inheritdoc/>
        public override string ToString() => $"class {Name}";

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            GenerateSummary(source, identation);

            Ident(source, identation);
            switch (Access)
            {
                case ClassAccess.Public:
                    _ = source.Append("public ");
                    break;
                case ClassAccess.Internal:
                    _ = source.Append("internal ");
                    break;
                case ClassAccess.Protected:
                    _ = source.Append("protected ");
                    break;
                case ClassAccess.Private:
                default:
                    _ = source.Append("private ");
                    break;
            }

            switch (Scope & ClassScope.ScopeMask)
            {
                case ClassScope.Abstract:
                    _ = source.Append("abstract ");
                    break;
                case ClassScope.Sealed:
                    _ = source.Append("sealed ");
                    break;
                case ClassScope.Static:
                    _ = source.Append("static ");
                    break;
                case ClassScope.Normal:
                default:
                    break;
            }

            if (Scope.HasFlag(ClassScope.Partial)) _ = source.Append("partial ");

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
