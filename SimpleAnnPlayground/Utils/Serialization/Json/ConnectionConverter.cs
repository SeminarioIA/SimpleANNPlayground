// <copyright file="ConnectionConverter.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleAnnPlayground.Ann.Neurons;

namespace SimpleAnnPlayground.Utils.Serialization.Json
{
    /// <summary>
    /// Converter class to serialize object type.
    /// </summary>
#pragma warning disable CA1812
    internal class ConnectionConverter : JsonConverter<Connection>
#pragma warning restore CA1812
    {
        /// <inheritdoc/>
        public override bool CanWrite => false;

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, Connection? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override Connection? ReadJson(JsonReader reader, Type objectType, Connection? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Load the Json object.
            JObject jo = JObject.Load(reader);
            if (jo == null) return null;

            // Get the connection source.
            string? source = jo["Source"]?.Value<string>();
            if (source == null) return null;
            string[] sourceData = source.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (sourceData.Length != 2) return null;
            int sourceObjectId = Convert.ToInt32(sourceData[0], 10);
            if (!CanvasObjConverter.DocumentDeserialization) sourceObjectId = CanvasObjConverter.Ids?[sourceObjectId] ?? throw new InvalidOperationException();
            var sourceObject = CanvasObjConverter.Objects?.First(obj => obj.Id == sourceObjectId) ?? throw new InvalidOperationException();
            int sourceTerminalIndex = Convert.ToInt32(sourceData[1], 10);
            var sourceTerminal = sourceObject.Outputs[sourceTerminalIndex];

            // Get the connection destination.
            string? destination = jo["Destination"]?.Value<string>();
            if (destination == null) return null;
            string[] destinationData = destination.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (destinationData.Length != 2) return null;
            int destinationObjectId = Convert.ToInt32(destinationData[0], 10);
            if (!CanvasObjConverter.DocumentDeserialization) destinationObjectId = CanvasObjConverter.Ids?[destinationObjectId] ?? throw new InvalidOperationException();
            var destinationObject = CanvasObjConverter.Objects?.First(obj => obj.Id == destinationObjectId) ?? throw new InvalidOperationException();
            int destinationTerminalIndex = Convert.ToInt32(destinationData[1], 10);
            var destinationTerminal = destinationObject.Inputs[destinationTerminalIndex];

            // Create a new object instance.
            return new Connection(sourceTerminal, destinationTerminal);
        }
    }
}
