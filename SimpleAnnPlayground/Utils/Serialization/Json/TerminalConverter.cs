// <copyright file="TerminalConverter.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Graphical.Terminals;
using SimpleAnnPlayground.Graphical.Visualization;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Utils.Serialization.Json
{
    /// <summary>
    /// Converter class to serialize object type.
    /// </summary>
#pragma warning disable CA1812
    internal class TerminalConverter : JsonConverter<Terminal>
#pragma warning restore CA1812
    {
        /// <summary>
        /// Gets or sets the conversion context.
        /// </summary>
        public static Collection<CanvasObject> Context { get; set; } = new Collection<CanvasObject>();

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, Terminal? value, JsonSerializer serializer)
        {
            if (writer != null && value != null)
            {
                writer.WriteValue($"{value.Owner.Id}, {value.Index}");
            }
        }

        /// <inheritdoc/>
        public override Terminal? ReadJson(JsonReader reader, Type objectType, Terminal? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));
            string value = serializer.Deserialize<string>(reader) ?? throw new ArgumentNullException(nameof(reader));
            string[] data = value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int id = Convert.ToInt32(data[0], 10);
            int index = Convert.ToInt32(data[1], 10);
            var obj = Context.First(o => o.Id == id);
            return obj.Terminals[0];
        }
    }
}
