// <copyright file="ConstructorSource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SourceGenerator.Generator.Types;

namespace SourceGenerator.Generator.Members.Methods
{
    /// <summary>
    /// Represents a class constructor source code.
    /// </summary>
    public class ConstructorSource : MethodSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructorSource"/> class.
        /// </summary>
        /// <param name="access">The <see cref="MethodAccess"/> attributes.</param>
        /// <param name="class">The <see cref="ClassSource"/> reference object.</param>
        internal ConstructorSource(MethodAccess access, ClassSource @class)
            : base(access, MethodScope.None, @class?.Name, $"Initializes a new instance of the <see cref=\"{@class.Name}\"/> class.")
        {
        }

        /// <inheritdoc/>
        public override string ToString() => $"{Name}({string.Join(", ", Parameters)})";
    }
}
