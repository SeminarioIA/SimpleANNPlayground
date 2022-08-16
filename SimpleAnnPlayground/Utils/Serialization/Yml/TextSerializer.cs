// <copyright file="TextSerializer.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Globalization;
using System.Text;

namespace SimpleAnnPlayground.Utils.Serialization.Yml
{
    /// <summary>
    /// Serializes and deserializes lists and dictionaries from a text input.
    /// </summary>
    internal static class TextSerializer
    {
        /// <summary>
        /// The serialization format.
        /// </summary>
        public enum Format
        {
            /// <summary>
            /// The data is serialized using idented blocks.
            /// </summary>
            Idented,

            /// <summary>
            /// The data is serialized using the same text line.
            /// </summary>
            Line,

            /// <summary>
            /// The data is serialized using multiple lines.
            /// </summary>
            MultiLine,
        }

        /// <summary>
        /// Serializes a list of key/value pairs.
        /// </summary>
        /// <param name="data">The list of key/value pairs.</param>
        /// <returns>The serialized string.</returns>
        public static string Serialize(List<KeyValuePair<string, string>> data)
        {
            // Get the serialization format.
            if (data.All(pair => !pair.Value.Contains(Environment.NewLine, StringComparison.Ordinal) && !pair.Value.Contains(',', StringComparison.Ordinal)))
            {
                // Line format.
                return SerializeLined(data);
            }
            else
            {
                // Idented format.
                return SerializeIdented(data);
            }
        }

        /// <summary>
        /// Serializes a list of elements using.
        /// </summary>
        /// <param name="data">The list of elements.</param>
        /// <returns>The serialized string.</returns>
        public static string SerializeList(List<string> data)
        {
            return string.Join(Environment.NewLine, data.ConvertAll(line => $"{line}"));
        }

        /// <summary>
        /// Deserialized a list of key/value elements from a text string.
        /// </summary>
        /// <param name="text">The text string.</param>
        /// <returns>The list of key/value elements.</returns>
        public static List<KeyValuePair<string, string>> Deserialize(string text)
        {
            // Get all the text lines.
            string[] lines = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Get the first line.
            int index = 0;
            while (index < lines.Length && lines[index].StartsWith('#')) index++;

            // Return an empty list if there is no lines to process.
            if (index == lines.Length || lines[index].StartsWith(' ')) return new List<KeyValuePair<string, string>>();

            // Get if the content is in a block or a line.
            return lines[index].EndsWith(':') ?
                DeserializeIdented(lines.Skip(index)) : DeserializeLine(lines[index]);
        }

        /// <summary>
        /// Deserialized a list of elements from a text string.
        /// </summary>
        /// <param name="text">The text string.</param>
        /// <returns>The list of elements.</returns>
        public static List<string> DeserializeList(string text)
        {
            var lines = new List<string>();
            foreach (string line in text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                lines.Add(line);
            }

            return lines;
        }

        private static string SerializeIdented(List<KeyValuePair<string, string>> data)
        {
            var content = new StringBuilder();
            foreach (var pair in data)
            {
                _ = content.AppendLine(CultureInfo.CurrentCulture, $"{pair.Key}:");
                foreach (string line in pair.Value.Split(Environment.NewLine))
                {
                    _ = content.AppendLine(CultureInfo.CurrentCulture, $"  {line}");
                }
            }

            return content.ToString();
        }

        private static string SerializeLined(List<KeyValuePair<string, string>> data)
        {
            var content = new StringBuilder(string.Join(", ", data.ConvertAll(pair => $"{pair.Key}: {pair.Value}")));
            return content.ToString();
        }

        private static List<KeyValuePair<string, string>> DeserializeIdented(IEnumerable<string> lines)
        {
            var data = new List<KeyValuePair<string, string>>();
            var content = new StringBuilder();
            string key = string.Empty;

            foreach (string line in lines)
            {
                if (line.StartsWith(' '))
                {
                    _ = content.AppendLine(line.Substring(2));
                }
                else if (line.EndsWith(':'))
                {
                    if (key.Length > 0)
                    {
                        data.Add(new KeyValuePair<string, string>(key, content.ToString()));
                        _ = content.Clear();
                    }

                    key = line.Substring(0, line.Length - 1);
                }
                else if (!line.StartsWith('#'))
                {
                    throw new FormatException($"Unexpected line start found: {line[0]}");
                }
            }

            data.Add(new KeyValuePair<string, string>(key, content.ToString()));
            return data;
        }

        private static List<KeyValuePair<string, string>> DeserializeLine(string line)
        {
            var data = new List<KeyValuePair<string, string>>();
            string[] keyValues = line.Split(',');
            foreach (string pair in keyValues)
            {
                string[] keyValue = pair.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (keyValue.Length == 2)
                {
                    data.Add(new KeyValuePair<string, string>(keyValue[0], keyValue[1]));
                }
                else
                {
                    throw new FormatException($"Unexpected line format found: {line[0]}");
                }
            }

            return data;
        }
    }
}
