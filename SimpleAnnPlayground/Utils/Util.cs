// <copyright file="Util.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Reflection;
using System.Text.RegularExpressions;

namespace SimpleAnnPlayground.Utils
{
    /// <summary>
    /// Utility functions for miscellaneous operations.
    /// </summary>
    internal static class Util
    {
        /// <summary>
        /// Separates a camel case string with spaces between words.
        /// </summary>
        /// <param name="input">The input string in CamelCase format.</param>
        /// <returns>The string with spaces.</returns>
        public static string SplitCamelCase(string input)
        {
            return Regex.Replace(input, "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled);
        }

        /// <summary>
        /// Gets the type from a string containing the type name.
        /// </summary>
        /// <param name="typeName">The type name.</param>
        /// <returns>The correspondent type.</returns>
        public static Type GetTypeFromString(string typeName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return asm.GetTypes().First(type => type.FullName == typeName);
        }
    }
}
