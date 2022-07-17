// <copyright file="ElementsFinder.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace SourceGenerator
{
    /// <summary>
    /// Finds all the elements types in the project.
    /// </summary>
    internal class ElementsFinder : ISyntaxReceiver
    {
        /// <summary>
        /// Gets the list of Element types in the project.
        /// </summary>
        public List<string> Elements { get; } = new List<string>();

        /// <inheritdoc/>
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDeclaration)
            {
                if (classDeclaration.BaseList?.Types.Any(@base => @base.ToString() == "Element") ?? false)
                {
                    Elements.Add(classDeclaration.Identifier.Text);
                }
            }
        }
    }
}
