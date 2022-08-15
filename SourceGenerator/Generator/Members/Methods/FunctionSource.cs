// <copyright file="FunctionSource.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SourceGenerator.Generator.Members.Methods
{
    /// <summary>
    /// Represents a class function source code.
    /// </summary>
    public class FunctionSource : MethodSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionSource"/> class.
        /// </summary>
        /// <param name="access">The <see cref="MethodAccess"/> attributes.</param>
        /// <param name="scope">The <see cref="MethodScope"/> attributes.</param>
        /// <param name="name">The function name.</param>
        /// <param name="description">The method description to add in the documentation.</param>
        internal FunctionSource(MethodAccess access, MethodScope scope, string name, string description)
            : base(access, scope, name, description)
        {
        }

        /// <summary>
        /// Gets the <see cref="FunctionSource"/> return value.
        /// </summary>
        public ReturnValue Return { get; private set; } = ReturnValue.Default;

        /// <summary>
        /// Adds a new <see cref="ReturnValue"/> to the source file.
        /// </summary>
        /// <param name="type">The <see cref="ReturnValue"/> type.</param>
        /// <param name="description">The <see cref="ReturnValue"/> description.</param>
        /// <returns>The current <see cref="FunctionSource"/>.</returns>
        public FunctionSource SetReturnValue(string type, string description = "")
        {
            Return = new ReturnValue(type, description);
            return this;
        }

        /// <inheritdoc/>
        public override string ToString() => $"{Return.Type} {Name}({string.Join(", ", Parameters)})";
    }
}
