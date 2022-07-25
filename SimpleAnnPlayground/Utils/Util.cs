// <copyright file="Util.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

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
    }
}
