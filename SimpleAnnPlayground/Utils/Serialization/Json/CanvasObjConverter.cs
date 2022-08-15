// <copyright file="CanvasObjConverter.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleAnnPlayground.Graphical.Visualization;

namespace SimpleAnnPlayground.Utils.Serialization.Json
{
    /// <summary>
    /// Converter class to serialize object type.
    /// </summary>
#pragma warning disable CA1812
    internal class CanvasObjConverter : JsonConverter<CanvasObject>
#pragma warning restore CA1812
    {
        /// <inheritdoc/>
        public override bool CanWrite => false;

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, CanvasObject? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override CanvasObject? ReadJson(JsonReader reader, Type objectType, CanvasObject? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            if (jo == null) return null;
            string? typeName = jo["Component"]?.Value<string>();
            if (typeName == null) return null;

            return null;
        }
    }
}
