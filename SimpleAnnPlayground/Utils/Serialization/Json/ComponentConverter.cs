// <copyright file="ComponentConverter.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Graphical;

namespace SimpleAnnPlayground.Utils.Serialization.Json
{
    /// <summary>
    /// Converter class to serialize object type.
    /// </summary>
    public class ComponentConverter : JsonConverter<Component>
    {
        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, Component? value, JsonSerializer serializer)
        {
            if (writer != null && value != null)
            {
                writer.WriteValue(value.Name);
            }
        }

        /// <inheritdoc/>
        public override Component? ReadJson(JsonReader reader, Type objectType, Component? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));
            string component = serializer.Deserialize<string>(reader) ?? throw new ArgumentNullException(nameof(reader));
            Type componentType = typeof(Component);
            var property = componentType.GetProperty(component);
            return property?.GetValue(componentType) as Component;
        }
    }
}
