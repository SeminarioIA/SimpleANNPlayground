// <copyright file="MemberSource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.CodeSections;
using SourceGenerator.Generator.Types;
using System.Text;

namespace SourceGenerator.Generator.Members
{
    /// <summary>
    /// Represents a class member <see cref="SourceSnippet"/>.
    /// </summary>
    public abstract class MemberSource : SourceSnippet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberSource"/> class.
        /// </summary>
        /// <param name="parent">The parent source element.</param>
        /// <param name="name">The <see cref="MemberSource"/> name.</param>
        protected MemberSource(SourceSnippet parent, string name)
            : base(parent, name)
        {
            Code = new CodeBlock(this);
        }

        /// <summary>
        /// Gets the <see cref="CodeBlock"/> of this method.
        /// </summary>
        public CodeBlock Code { get; private set; }

        /// <summary>
        /// Gets the method expression body.
        /// </summary>
        public string ExpressionBody { get; private set; }

        /// <summary>
        /// Sets the code of this method as Expression body.
        /// </summary>
        /// <param name="code">The expression code.</param>
        public void SetExpressionBody(string code)
        {
            Code = null;
            ExpressionBody = code;
        }

        /// <inheritdoc/>
        internal override void Generate(StringBuilder source, int identation)
        {
            if (ExpressionBody != null)
            {
                _ = source.AppendLine(" => " + ExpressionBody);
            }
            else
            {
                _ = source.AppendLine();
                Code.Generate(source, identation);
            }
        }
    }
}
