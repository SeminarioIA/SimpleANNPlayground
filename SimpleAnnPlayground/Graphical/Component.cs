// <copyright file="Component.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Represents a graphical component formed by multiple elements.
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="elements">List of elements to add to this component.</param>
        protected Component(Collection<Element> elements)
        {
            Elements = new ReadOnlyCollection<Element>(elements);
        }

        /// <summary>
        /// Gets the collection of <seealso cref="Element"/> objects of this component.
        /// </summary>
        public ReadOnlyCollection<Element> Elements { get; private set; }

        /// <summary>
        /// Gets or sets the location of this component.
        /// </summary>
        public PointF Location { get; set; }

        /// <summary>
        /// Serializes a collection of elements into a string.
        /// </summary>
        /// <param name="elements">The collection of elements.</param>
        /// <returns>A string with all the elements serialized.</returns>
        internal static string Serialize(Collection<Element> elements)
        {
            var data = new StringBuilder();
            foreach (Element element in elements)
            {
                _ = data.AppendLine(element.Serialize());
            }

            return data.ToString();
        }

        /// <summary>
        /// Deserializes a string containing all the elementes serialized.
        /// </summary>
        /// <param name="content">The string containing the serialized elements.</param>
        /// <returns>A new <see cref="Component"/> from the serialized content.</returns>
        internal static Collection<Element> Deserialize(string content)
        {
            Collection<Element> elements = new Collection<Element>();
            foreach (string line in content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                var data = new List<string>(line.Split(", ", StringSplitOptions.None));
                var elementTypeName = Enum.Parse<ElementsHelper.Types>(data.First());
                var elementType = ElementsHelper.ElementsTypes[(int)elementTypeName];
                var element = Activator.CreateInstance(elementType, Color.Black, 0f, 0f) as Element;
                foreach (string param in data.Skip(1))
                {
                    string[] nameValue = param.Split(": ");
                    string name = nameValue[0];
                    string value = nameValue[1];
                    var property = elementType.GetProperty(name);
                    if (property != null)
                    {
                        if (property.PropertyType == typeof(float))
                        {
                            property.SetValue(element, float.Parse(value, CultureInfo.CurrentCulture));
                        }
                        else if (property.PropertyType == typeof(Color?))
                        {
                            if (string.IsNullOrEmpty(value))
                            {
                                property.SetValue(element, null);
                            }
                            else
                            {
                                property.SetValue(element, Color.FromName(value));
                            }
                        }
                        else if (property.PropertyType == typeof(Color))
                        {
                            property.SetValue(element, Color.FromName(value));
                        }
                    }
                }

                if (element != null) elements.Add(element);
            }

            return elements;
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

            graphics.TranslateTransform(location.Value.X, location.Value.Y);
            foreach (Element element in Elements)
            {
                element.Paint(graphics);
            }

            graphics.TranslateTransform(-location.Value.X, -location.Value.Y);
        }
    }
}
