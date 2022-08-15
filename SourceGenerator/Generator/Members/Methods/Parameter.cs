// <copyright file="Parameter.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.Types;
using System;
using System.Text;

namespace SourceGenerator.Generator.Members.Methods
{
    /// <summary>
    /// Specifies member attributes used for <see cref="Parameter"/>.
    /// </summary>
    public enum ParameterAttributes
    {
        /// <summary>
        /// The parameter does not contains defined attributes.
        /// </summary>
        None,

        /// <summary>
        /// The paremeter is returned with a value.
        /// </summary>
        Out,

        /// <summary>
        /// The parameter is passed by reference.
        /// </summary>
        Ref,
    }

    /// <summary>
    /// Represents a <see cref="MethodSource"/> parameter.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="type">The <see cref="Parameter"/> type.</param>
        /// <param name="name">The <see cref="Parameter"/> name.</param>
        /// <param name="description">The <see cref="Parameter"/> description.</param>
        internal Parameter(string type, string name, string description)
        {
            Type = type;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Gets the <see cref="Parameter"/> type.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the <see cref="Parameter"/> name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the <see cref="Parameter"/> description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets or sets the attributes for this <see cref="Parameter"/>.
        /// </summary>
        public ParameterAttributes Attributes { get; set; }

        /// <summary>
        /// Gets or sets a predefined value for this <see cref="Parameter"/>.
        /// </summary>
        public string PredefinedValue { get; set; }

        /// <summary>
        /// Generates the <see cref="Parameter"/> documentation.
        /// </summary>
        /// <param name="source">The <see cref="StringBuilder"/> to append the source code.</param>
        /// <param name="identation">The identation to follow when appending the code.</param>
        public void GenerateDoc(StringBuilder source, int identation)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            SourceSnippet.Ident(source, identation);
            _ = source.AppendLine($"/// <param name=\"{Name}\">{Description}.</param>");
        }

        /// <summary>
        /// Generates the <see cref="Parameter"/> source code.
        /// </summary>
        /// <param name="source">The <see cref="StringBuilder"/> to append the source code.</param>
        public void Generate(StringBuilder source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            switch (Attributes)
            {
                case ParameterAttributes.Out:
                    _ = source.Append(ParameterAttributes.Out.ToString().ToLowerInvariant() + ' ');
                    break;
                case ParameterAttributes.Ref:
                    _ = source.Append(ParameterAttributes.Ref.ToString().ToLowerInvariant() + ' ');
                    break;
            }

            _ = source.Append(Name);

            if (!string.IsNullOrWhiteSpace(PredefinedValue))
                _ = source.Append($" = {PredefinedValue}");
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var source = new StringBuilder();
            Generate(source);
            return source.ToString();
        }
    }
}
