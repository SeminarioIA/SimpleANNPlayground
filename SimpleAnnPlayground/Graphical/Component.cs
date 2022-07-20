// <copyright file="Component.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Utils.Serialization;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Represents a graphical component formed by multiple elements.
    /// </summary>
    public partial class Component : ITextSerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        public Component()
        {
            Elements = new ReadOnlyCollection<Element>(new Collection<Element>());
            Connectors = new ReadOnlyCollection<Connector>(new Collection<Connector>());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="text">The text string containing the Component information.</param>
        public Component(string text)
            : this()
        {
            Deserialize(text);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="elements">The list of elements.</param>
        /// <param name="connectors">The list of components.</param>
        internal Component(Collection<Element> elements, Collection<Connector> connectors)
        {
            Elements = new ReadOnlyCollection<Element>(elements);
            Connectors = new ReadOnlyCollection<Connector>(connectors);
        }

        /// <summary>
        /// Gets the collection of <seealso cref="Element"/> objects of this component.
        /// </summary>
        public ReadOnlyCollection<Element> Elements { get; private set; }

        /// <summary>
        /// Gets the collection of <seealso cref="Connector"/> objects of this component.
        /// </summary>
        public ReadOnlyCollection<Connector> Connectors { get; private set; }

        /// <summary>
        /// Gets or sets the location of this component.
        /// </summary>
        public PointF Location { get; set; }

        /// <summary>
        /// Serializes a collection of elements into a string.
        /// </summary>
        /// <returns>A string with all the elements serialized.</returns>
        public string Serialize()
        {
            var data = new List<KeyValuePair<string, string>>();
            foreach (Element element in Elements)
            {
                data.Add(new KeyValuePair<string, string>(element.ToString(), element.Serialize()));
            }

            foreach (Connector connector in Connectors)
            {
                data.Add(new KeyValuePair<string, string>(nameof(Connector), connector.Serialize()));
            }

            return TextSerializer.Serialize(data);
        }

        /// <summary>
        /// Deserializes a string containing this Component properties.
        /// </summary>
        /// <param name="text">The string containing the serialized elements.</param>
        public void Deserialize(string text)
        {
            if (text == null) return;
            var elements = new Collection<Element>();
            var connectors = new Collection<Connector>();

            // Iterate the list of keys in the string.
            foreach (var item in TextSerializer.Deserialize(text))
            {
                // Get the elements for this object.
                switch (item.Key)
                {
                    case nameof(Elements):
                    {
                        // Iterate for each element in the item value.
                        foreach (var element in TextSerializer.Deserialize(item.Value))
                        {
                            elements.Add(Element.Deserialize(Enum.Parse<Element.Types>(element.Key), element.Value));
                        }

                        // Assing the elements list.
                        Elements = new ReadOnlyCollection<Element>(elements);
                        break;
                    }

                    case nameof(Connectors):
                    {
                        foreach (string conn in TextSerializer.DeserializeList(item.Value))
                        {
                            var connector = new Connector(0f, 0f);
                            connector.Deserialize(conn);
                            connectors.Add(connector);
                        }

                        // Assing the connectors list.
                        Connectors = new ReadOnlyCollection<Connector>(connectors);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Reloads the graphical elements for this component.
        /// </summary>
        /// <param name="elements">The new graphical elements.</param>
        internal void ReloadElements(Collection<Element> elements)
        {
            Elements = new ReadOnlyCollection<Element>(elements);
        }

        /// <summary>
        /// Paints the component on a graphics object in the given location,
        /// if the location is omitted then the object is painted on its location.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        /// <param name="location">The location to draw the component.</param>
        internal void Paint(Graphics graphics, PointF? location = null)
        {
            if (location == null) location = Location;

            // Translate the transform to the componnent coordinates.
            graphics.TranslateTransform(location.Value.X, location.Value.Y);

            // Draw component elements.
            foreach (Element element in Elements)
            {
                element.Paint(graphics);
            }

            // Draw elements connectors.
            foreach (Connector connector in Connectors)
            {
                connector.Paint(graphics);
            }

            // Restore transform.
            graphics.TranslateTransform(-location.Value.X, -location.Value.Y);
        }
    }
}
