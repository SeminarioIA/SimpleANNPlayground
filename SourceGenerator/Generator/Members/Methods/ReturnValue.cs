// <copyright file="ReturnValue.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.Types;
using System;
using System.Text;

namespace SourceGenerator.Generator.Members.Methods
{
    /// <summary>
    /// Represents a <see cref="ReturnValue"/> for a <see cref="FunctionSource"/>.
    /// </summary>
    public class ReturnValue
    {
        /// <summary>
        /// Default <see cref="ReturnValue"/>.
        /// </summary>
        public static readonly ReturnValue Default = new ReturnValue("int", "Default return value.");

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnValue"/> class.
        /// </summary>
        /// <param name="type">The <see cref="ReturnValue"/> type.</param>
        /// <param name="description">The <see cref="ReturnValue"/> description.</param>
        internal ReturnValue(string type, string description)
        {
            Type = type;
            Description = description;
        }

        /// <summary>
        /// Gets the <see cref="ReturnValue"/> type.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the <see cref="ReturnValue"/> description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Generates the <see cref="Parameter"/> documentation.
        /// </summary>
        /// <param name="source">The <see cref="StringBuilder"/> to append the source code.</param>
        /// <param name="identation">The identation to follow when appending the code.</param>
        public void GenerateDoc(StringBuilder source, int identation)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            SourceSnippet.Ident(source, identation);
            _ = source.AppendLine($"/// <returns>{Description}</returns>");
        }
    }
}
