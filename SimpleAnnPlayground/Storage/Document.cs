// <copyright file="Document.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
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
        [JsonConstructor]
        public Document(WorkSheet workSheet, Collection<CanvasObject> objects, Collection<Connection> connections, DataTable dataTable)
        {
            WorkSheet = workSheet;
            Objects = objects;
            Connections = connections;
            DataTable = dataTable;
        }

        /// <summary>
        /// Gets the document workspace sheet.
        /// </summary>
        public WorkSheet WorkSheet { get; private set; }

        /// <summary>
        /// Gets the list of <see cref="CanvasObject"/>.
        /// </summary>
        public Collection<CanvasObject> Objects { get; }

        /// <summary>
        /// Gets the list of <see cref="Connection"/>.
        /// </summary>
        public Collection<Connection> Connections { get; }

        /// <summary>
        /// Gets the document data.
        /// </summary>
        public DataTable DataTable { get; }

        /// <summary>
        /// Deserializes a object from the JSON data.
        /// </summary>
        /// <param name="workspace">The workspace to deserialize the objects.</param>
        /// <param name="data">The JSON data.</param>
        /// <returns>The deserialized object.</returns>
        public static Document Deserialize(Workspace workspace, string data)
        {
            CanvasObjConverter.Canvas = workspace.Canvas;
            ConnectionConverter.Objects.Clear();
            ConnectionConverter.Ids.Clear();
            return JsonConvert.DeserializeObject<Document>(data) ?? throw new ArgumentException("Invalid data string.", nameof(data));
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
