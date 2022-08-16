// <copyright file="ClipboardBag.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Visualization;
using SimpleAnnPlayground.Utils.Serialization.Json;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Graphical.Tools
{
    /// <summary>
    /// Helper class to copy multiple <see cref="CanvasObject"/>s a the <see cref="Workspace"/>.
    /// </summary>
    internal class ClipboardBag
    {
        private const int OffsetIncrement = 30;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClipboardBag"/> class.
        /// </summary>
        /// <param name="workspace">The origin workspace with the objects to copy.</param>
        public ClipboardBag(Workspace workspace)
        {
            Objects = new Collection<CanvasObject>();
            foreach (CanvasObject obj in workspace.Canvas.GetSelectedObjects())
            {
                Objects.Add(CanvasObject.Clone(obj));
            }

            Connections = new Collection<Connection>();
            foreach (Connection conn in workspace.Canvas.GetSelectedConnections())
            {
                Connections.Add(new Connection(conn, Objects, DrawableObject.CreationMode.Clone));
            }

            Offset = OffsetIncrement;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClipboardBag"/> class.
        /// </summary>
        /// <param name="objects">The objects to add.</param>
        /// <param name="connections">The connections to add.</param>
        [JsonConstructor]
        public ClipboardBag(Collection<CanvasObject> objects, Collection<Connection> connections)
        {
            Objects = objects;
            Connections = connections;
        }

        /// <summary>
        /// Gets the paste offset for the objects contained in this bag.
        /// </summary>
        public static int Offset { get; private set; }

        /// <summary>
        /// Gets the list of <see cref="CanvasObject"/>.
        /// </summary>
        public Collection<CanvasObject> Objects { get; }

        /// <summary>
        /// Gets the list of <see cref="Connection"/>.
        /// </summary>
        public Collection<Connection> Connections { get; }

        /// <summary>
        /// Deserializes a object from the JSON data.
        /// </summary>
        /// <param name="data">The JSON data.</param>
        /// <returns>The deserialized object.</returns>
        public static ClipboardBag Deserialize(string data)
        {
            ConnectionConverter.Objects.Clear();
            ConnectionConverter.Ids.Clear();
            return JsonConvert.DeserializeObject<ClipboardBag>(data) ?? throw new ArgumentException("Invalid data string.", nameof(data));
        }

        /// <summary>
        /// Updates the destination point for the objects in the bag.
        /// </summary>
        /// <param name="workspace">The workspace where the object are being inserted.</param>
        public void Paste(Workspace workspace)
        {
            workspace.Canvas.UnselectAll();

            foreach (CanvasObject obj in Objects)
            {
                var location = obj.Location;
                location.Offset(Offset, Offset);
                obj.Location = location;
                workspace.Canvas.AddObject(obj);
                workspace.Shadow.AddObject(obj);
                obj.SetStateFlag(Component.State.Selected);
            }

            foreach (Connection conn in Connections)
            {
                // Add the new connection.
                workspace.Canvas.AddConnection(conn);
            }

            Offset += OffsetIncrement;
            workspace.Refresh();
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
