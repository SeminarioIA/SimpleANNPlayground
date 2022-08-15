// <copyright file="Comment.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SourceGenerator.Generator.CodeSections
{
    /// <summary>
    /// Represents a comment line in the code.
    /// </summary>
    public class Comment : CodeSection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.
        /// </summary>
        /// <param name="comment">The comment to add.</param>
        public Comment(string comment)
        {
            Text = comment;
        }

        /// <summary>
        /// Gets the code line.
        /// </summary>
        public string Text { get; }

        /// <inheritdoc/>
        public override string ToString() => Text;
    }
}
