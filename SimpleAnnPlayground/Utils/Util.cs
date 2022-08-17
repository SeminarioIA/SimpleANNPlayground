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

        /// <summary>
        /// Gets a rows range from a <see cref="DataGridView"/> control.
        /// </summary>
        /// <param name="dgv">The <see cref="DataGridView"/> control.</param>
        /// <param name="start">The start index.</param>
        /// <param name="count">The rows count to retrieve.</param>
        /// <returns>An enumerable with the rows.</returns>
        public static IEnumerable<DataGridViewRow> GetRowRange(this DataGridView dgv, int start, int count)
        {
            int end = start + count;
            for (int rowIndex = start; rowIndex < end; rowIndex++)
            {
                yield return dgv.Rows[rowIndex];
            }
        }

        /// <summary>
        /// Converts a row cells values into a strings array.
        /// </summary>
        /// <param name="dgv">The <see cref="DataGridView"/> control.</param>
        /// <returns>The string array with the cells values.</returns>
        public static IEnumerable<string> ColumnsNames(this DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                yield return column.HeaderText;
            }
        }

        /// <summary>
        /// Converts a row cells values into a strings array.
        /// </summary>
        /// <param name="row">The <see cref="DataGridViewRow"/>.</param>
        /// <returns>The string array with the cells values.</returns>
        public static IEnumerable<string> AsEnumerable(this DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                yield return cell.Value?.ToString() ?? string.Empty;
            }
        }
    }
}
