// <copyright file="Document.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Ann.Networks;
using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Visualization;
using SimpleAnnPlayground.Utils.Serialization.Json;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Storage
{
    /// <summary>
    /// Represents all the elements that can be saved in a file.
    /// </summary>
    internal class Document
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        /// <param name="workSheet">The document workspace sheet.</param>
        /// <param name="objects">The objects to add.</param>
        /// <param name="connections">The connections to add.</param>
        /// <param name="dataTable">The document data.</param>
        /// <param name="dataLinks">The list of <see cref="DataLink"/>.</param>
        /// <param name="parameters">The network parameters.</param>
        [JsonConstructor]
        public Document(WorkSheet workSheet, Collection<CanvasObject> objects, Collection<Connection> connections, DataTable dataTable, Collection<DataLink> dataLinks, Parameters parameters)
        {
            WorkSheet = workSheet;
            Canvas = objects.Any() ? objects.First().Canvas : new Canvas();
            objects.ToList().ForEach(obj => Canvas.AddObject(obj));
            connections.ToList().ForEach(connection => Canvas.AddConnection(connection));
            DataTable = dataTable;
            DataLinks = dataLinks;
            Parameters = parameters;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        /// <param name="workSheet">The document workspace sheet.</param>
        /// <param name="canvas">The canvas holding the objects and collections.</param>
        /// <param name="dataTable">The document data.</param>
        /// <param name="dataLinks">The list of <see cref="DataLink"/>.</param>
        /// <param name="network">The network parameters.</param>
        public Document(WorkSheet workSheet, Canvas canvas, DataTable dataTable, Collection<DataLink> dataLinks, Network network)
        {
            WorkSheet = workSheet;
            Canvas = canvas;
            DataTable = dataTable;
            DataLinks = dataLinks;
            Parameters = new Parameters(network.LearningRate, network.BatchSize);
        }

        /// <summary>
        /// Gets the document workspace sheet.
        /// </summary>
        public WorkSheet WorkSheet { get; private set; }

        /// <summary>
        /// Gets the list of <see cref="CanvasObject"/>.
        /// </summary>
        public Collection<CanvasObject> Objects => Canvas.Objects;

        /// <summary>
        /// Gets the list of <see cref="Connection"/>.
        /// </summary>
        public Collection<Connection> Connections => Canvas.Connections;

        /// <summary>
        /// Gets the document data.
        /// </summary>
        public DataTable DataTable { get; }

        /// <summary>
        /// Gets the list of <see cref="DataLink"/>.
        /// </summary>
        public Collection<DataLink> DataLinks { get; }

        /// <summary>
        /// Gets the network parameters.
        /// </summary>
        public Parameters Parameters { get; }

        /// <summary>
        /// Gets the document canvas holding all the objects.
        /// </summary>
        [JsonIgnore]
        public Canvas Canvas { get; }

        /// <summary>
        /// Deserializes a object from the JSON data.
        /// </summary>
        /// <param name="data">The JSON data.</param>
        /// <returns>The deserialized object.</returns>
        public static Document Deserialize(string data)
        {
            CanvasObjConverter.OpenDeserialization(new Canvas(), true);
            var document = JsonConvert.DeserializeObject<Document>(data) ?? throw new ArgumentException("Invalid data string.", nameof(data));

            // Desersialize links between data and neurons.
            foreach (var dataLink in document.DataLinks)
            {
                var obj = CanvasObjConverter.Objects?.First(obj => obj.Id == dataLink.Id);
                var label = document.DataTable.Labels.First(label => label.Text == dataLink.Label);
                switch (obj)
                {
                    case Input input:
                        input.DataLabel = label;
                        break;
                    case Output output:
                        output.DataLabel = label;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            CanvasObjConverter.CloseDeserialization();
            return document;
        }

        /// <summary>
        /// Serializes the bag data into a JSON string.
        /// </summary>
        /// <returns>The JSON string.</returns>
        public string Serialize() => JsonConvert.SerializeObject(this, Formatting.Indented);

        /// <inheritdoc/>
        public override string ToString() => $"{nameof(Objects)}: {Objects.Count}, {nameof(Connections)}: {Connections.Count}";
    }
}
