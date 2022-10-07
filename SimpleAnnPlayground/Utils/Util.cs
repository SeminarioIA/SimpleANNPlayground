// <copyright file="Util.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Reflection;
using System.Security.Cryptography;
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

        /// <summary>
        /// Gets an integer random number in the passed range.
        /// </summary>
        /// <param name="start">The range start, inclusive.</param>
        /// <param name="end">The range end, exclusive.</param>
        /// <returns>The generated random number.</returns>
        public static int GetRandom(int start, int end) => RandomNumberGenerator.GetInt32(start, end);

        /// <summary>
        /// Gets a decimal random number in the passed range.
        /// </summary>
        /// <param name="start">The range start, inclusive.</param>
        /// <param name="end">The range end, exclusive.</param>
        /// <param name="digits">The decimal digits.</param>
        /// <returns>The generated random number.</returns>
        public static double GetRandom(double start, double end, int digits)
        {
            int decimalSeed = (int)Math.Pow(10, digits);
            int startSeed = (int)(start * decimalSeed);
            int endSeed = (int)(end * decimalSeed);
            int random = RandomNumberGenerator.GetInt32(startSeed, endSeed);
            return (double)random / decimalSeed;
        }

        /// <summary>
        /// Gets a decimal random number in the passed range.
        /// </summary>
        /// <param name="start">The range start, inclusive.</param>
        /// <param name="end">The range end, exclusive.</param>
        /// <param name="digits">The decimal digits.</param>
        /// <returns>The generated random number.</returns>
        public static decimal GetRandom(decimal start, decimal end, int digits)
        {
            int decimalSeed = (int)Math.Pow(10, digits);
            int startSeed = (int)(start * decimalSeed);
            int endSeed = (int)(end * decimalSeed);
            int random = RandomNumberGenerator.GetInt32(startSeed, endSeed);
            return (decimal)random / decimalSeed;
        }

        /// <summary>
        /// Gets a decimal random number in the passed range.
        /// </summary>
        /// <param name="start">The range start, inclusive.</param>
        /// <param name="end">The range end, exclusive.</param>
        /// <param name="digits">The decimal digits.</param>
        /// <returns>The generated random number.</returns>
        public static double GetRandom(int start, int end, int digits)
        {
            int decimalSeed = (int)Math.Pow(10, digits);
            int startSeed = start * decimalSeed;
            int endSeed = end * decimalSeed;
            int random = RandomNumberGenerator.GetInt32(startSeed, endSeed);
            return (double)random / decimalSeed;
        }

        /// <summary>
        /// Converts a polar coordinate to a rectangle coordinate.
        /// </summary>
        /// <param name="radio">The radio from the origin.</param>
        /// <param name="angle">The angle from x axis.</param>
        /// <returns>The equivalent coordinates pair.</returns>
        public static (double, double) ToRect(double radio, double angle)
        {
            double x = radio * Math.Cos(angle);
            double y = radio * Math.Sin(angle);
            return (x, y);
        }

        /// <summary>
        /// Converts a polar coordinate to a rectangle coordinate.
        /// </summary>
        /// <param name="radio">The radio from the origin.</param>
        /// <param name="angle">The angle from x axis.</param>
        /// <returns>The equivalent coordinates pair.</returns>
        public static (decimal, decimal) ToRect(decimal radio, decimal angle)
        {
            decimal x = radio * (decimal)Math.Cos((double)angle);
            decimal y = radio * (decimal)Math.Sin((double)angle);
            return (x, y);
        }
    }
}
