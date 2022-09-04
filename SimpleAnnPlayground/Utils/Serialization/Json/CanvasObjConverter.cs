// <copyright file="CanvasObjConverter.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleAnnPlayground.Ann.Activation;
using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Models;
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
        private bool _canWrite = true;

        /// <inheritdoc/>
        public override bool CanWrite => _canWrite;

        /// <summary>
        /// Gets the Canvas where placing the deserialized objects.
        /// </summary>
        internal static Canvas? Canvas { get; private set; }

        /// <summary>
        /// Gets the list of objects to parse the connections.
        /// </summary>
        internal static ICollection<CanvasObject>? Objects { get; private set; }

        /// <summary>
        /// Gets the dictionary containing the Objects Ids equivalence.
        /// </summary>
        internal static Dictionary<int, int>? Ids { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the conversion is when deserializing a document.
        /// </summary>
        internal static bool DocumentDeserialization { get; private set; }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, CanvasObject? value, JsonSerializer serializer)
        {
            if (writer != null && value != null)
            {
                writer.WriteStartObject();

                // Type
                writer.WritePropertyName(nameof(value.Type));
                serializer.Serialize(writer, value.Type);

                writer.WritePropertyName(nameof(value.Location));
                serializer.Serialize(writer, value.Location);

                writer.WritePropertyName(nameof(value.Id));
                serializer.Serialize(writer, value.Id);
                switch (value)
                {
                    case Neuron neuron:
                        writer.WritePropertyName(nameof(neuron.Activation));
                        serializer.Serialize(writer, neuron.Activation?.Name);
                        break;
                }

                writer.WriteEndObject();
            }
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

            // Check if the object is a neuron
            if (obj is Neuron neuron)
            {
                string? activation = jo["Activation"]?.Value<string>();
                if (!string.IsNullOrEmpty(activation))
                {
                    neuron.Activation = Enum.Parse<Functions>(activation).GetActivationFunction();
                }
            }

            Objects?.Add(obj);
            if (DocumentDeserialization)
            {
                DrawableObject.ForceId(obj, id);
            }
            else
            {
                Ids?.Add(id, obj.Id);
            }

            return obj;
        }

        /// <summary>
        /// Prepares the <see cref="CanvasObjConverter"/> for the conversion.
        /// </summary>
        /// <param name="canvas">The canvas object to use for the deserialization.</param>
        /// <param name="documentDeserialization">Indicates if the conversion is from a document.</param>
        internal static void OpenDeserialization(Canvas canvas, bool documentDeserialization)
        {
            Canvas = canvas;
            DocumentDeserialization = documentDeserialization;
            Objects = new List<CanvasObject>();
            Ids = new Dictionary<int, int>();
        }

        /// <summary>
        /// Deinitializes all the objects related to the serialization.
        /// </summary>
        internal static void CloseDeserialization()
        {
            DocumentDeserialization = false;
            Canvas = null;
            Objects = null;
            Ids = null;
        }
    }
}
