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
        /// <summary>
        /// Gets or sets the Canvas where placing the deserialized objects.
        /// </summary>
        public static Canvas? Canvas { get; set; }

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
            if (Canvas == null) throw new InvalidOperationException(nameof(Canvas));

            // Load the Json object.
            JObject jo = JObject.Load(reader);
            if (jo == null) return null;

            // Get the object Id.
            string? objId = jo["Id"]?.Value<string>();
            if (objId == null) return null;
            int id = Convert.ToInt32(objId, 10);

            // Get the object location.
            string? location = jo["Location"]?.Value<string>();
            if (location == null) return null;
            string[] coordinates = location.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (coordinates.Length != 2) return null;
            int x = Convert.ToInt32(coordinates[0], 10);
            int y = Convert.ToInt32(coordinates[1], 10);

            // Get the object type.
            string? typeName = jo["Type"]?.Value<string>();
            if (typeName == null) return null;
            Type myType = Util.GetTypeFromString(typeName);

            // Create a new object instance.
            if (Activator.CreateInstance(myType, Canvas, x, y) is not CanvasObject obj) return null;

            // Register the new object in the ConnectionCoverter.
            ConnectionConverter.Objects.Add(obj);
            ConnectionConverter.Ids.Add(id, obj.Id);

            return obj;
        }
    }
}
