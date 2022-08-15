// <copyright file="MemberSource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.Types;

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
        /// <param name="name">The <see cref="MemberSource"/> name.</param>
        protected MemberSource(string name)
            : base(name)
        {
        }
    }
}
