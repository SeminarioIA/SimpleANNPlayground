﻿// <copyright file="CodeLine.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SourceGenerator.Generator.CodeSections
{
    /// <summary>
    /// Represents a line of code.
    /// </summary>
    public class CodeLine : CodeSection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeLine"/> class.
        /// </summary>
        /// <param name="code">The code to add.</param>
        public CodeLine(string code)
        {
            Code = code;
        }

        /// <summary>
        /// Gets the code line.
        /// </summary>
        public string Code { get; }

        /// <inheritdoc/>
        public override string ToString() => Code;
    }
}
