// <copyright file="Component.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Utils.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

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
            Elements = new Collection<Element>();
            Connectors = new Collection<Connector>();
            Selector = new Selector(0f, 0f);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class, it's an override of the previous Component() method.
        /// </summary>
        /// <param name="xSize">The center width of the parent.</param>
        /// <param name="ySize">The center height of the parent.</param>
        public Component(float xSize, float ySize)
        {
            Elements = new Collection<Element>();
            Connectors = new Collection<Connector>();
            Selector = new Selector(0f, 0f);
            X = xSize;
            Y = ySize;
            DefaultX = X;
            DefaultY = Y;
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
        /// <param name="selector">The selector object.</param>
        internal Component(Collection<Element> elements, Collection<Connector> connectors, Selector selector)
        {
            Elements = elements;
            Connectors = connectors;
            Selector = selector;
        }

        /// <summary>
        /// Defines the state for the component.
        /// </summary>3
        [Flags]
        public enum State
        {
            /// <summary>
            /// The component is being drawn alone.
            /// </summary>
            None = 0,

            /// <summary>
            /// The component is being drawn alone in the background.
            /// </summary>
            Shadow = 1,

            /// <summary>
            /// The component has the cursor on it.
            /// </summary>
            Hover = 2,

            /// <summary>
            /// The component is selected.
            /// </summary>
            Selected = 4,

            /// <summary>
            /// The component is going to be executed in the simulation.
            /// </summary>
            SimulationStep = 8,

            /// <summary>
            /// The component was succesfully simulated.
            /// </summary>
            SimulationPass = 16,

            /// <summary>
            /// The component had a simulation error.
            /// </summary>
            SimulationError = 32,

            /// <summary>
            /// There is a warning about the component.
            /// </summary>
            ComponentWarn = 64,

            /// <summary>
            /// There is an error about the component.
            /// </summary>
            ComponentError = 128,
        }

        /// <summary>
        /// Gets or sets the X center of component <seealso cref="DefaultX"/> objects of this component.
        /// </summary>
        public float DefaultX { get; set; }

        /// <summary>
        /// Gets or sets the Y center of component <seealso cref="DefaultY"/> objects of this component.
        /// </summary>
        public float DefaultY { get; set; }

        /// <summary>
        /// Gets the collection of <seealso cref="Connector"/> objects of this component.
        /// </summary>
        [Browsable(false)]
        public Collection<Connector> Connectors { get; private set; }

        /// <summary>
        /// Gets the collection of <seealso cref="Element"/> objects of this component.
        /// </summary>
        [Browsable(false)]
        public Collection<Element> Elements { get; private set; }

        /// <summary>
        /// Gets the collection of <seealso cref="Element"/> objects of this component.
        /// </summary>
        [Browsable(false)]
        public Selector Selector { get; private set; }

        /// <summary>
        /// Gets or sets the center X coordinate of this component.
        /// </summary>
        [Category("Center")]
        [Description("The center X coordinate of this element.")]
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the center Y coordinate of this component.
        /// </summary>
        [Category("Center")]
        [Description("The center Y coordinate of this element.")]
        public float Y { get; set; }

        /// <summary>
        /// Gets the component location.
        /// </summary>
        [Browsable(false)]
        public PointF Center => new (X, Y);

        /// <summary>
        /// Serializes a collection of elements into a string.
        /// </summary>
        /// <returns>A string with all the elements serialized.</returns>
        public string Serialize()
        {
            var data = new List<KeyValuePair<string, string>>();

            // Serialize elements.
            var elements = new List<KeyValuePair<string, string>>();
            foreach (Element element in Elements)
            {
                elements.Add(new KeyValuePair<string, string>(element.ToString(), element.Serialize()));
            }

            data.Add(new KeyValuePair<string, string>(nameof(Elements), TextSerializer.Serialize(elements)));

            // Serialize connectors.
            var connectors = new List<string>();
            foreach (Connector connector in Connectors)
            {
                connectors.Add(connector.Serialize());
            }

            data.Add(new KeyValuePair<string, string>(nameof(Connectors), TextSerializer.SerializeList(connectors)));

            // Serialize the selector.
            data.Add(new KeyValuePair<string, string>(nameof(Selector), Selector.Serialize()));

            // Serialize the component center.
            data.Add(new KeyValuePair<string, string>(nameof(Center), $"X: {X}, Y: {Y}"));

            return TextSerializer.Serialize(data);
        }

        /// <summary>
        /// Deserializes a string containing this Component properties.
        /// </summary>
        /// <param name="text">The string containing the serialized elements.</param>
        public void Deserialize(string text)
        {
            X = DefaultX;
            Y = DefaultY;
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
                        Elements = elements;
                        break;
                    }

                    case nameof(Connectors):
                    {
                        foreach (string conn in TextSerializer.DeserializeList(item.Value))
                        {
                            var connector = new Connector();
                            connector.Deserialize(conn);
                            connectors.Add(connector);
                        }

                        // Assing the connectors list.
                        Connectors = connectors;
                        break;
                    }

                    case nameof(Selector):
                    {
                        Selector.Deserialize(item.Value);
                        break;
                    }

                    case nameof(Center):
                    {
                        var center = TextSerializer.Deserialize(item.Value).ToDictionary(pair => pair.Key, pair => float.Parse(pair.Value, CultureInfo.CurrentCulture));
                        X += -center[nameof(X)];
                        Y += -center[nameof(Y)];
                        X = -X;
                        Y = -Y;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Paints the component on a graphics object in the given location,
        /// if the location is omitted then the object is painted on its location.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        /// <param name="location">The location to draw the component.</param>
        /// <param name="state">The component state.</param>
        /// <param name="selectConnector">Indicates if a connector will be selected.</param>
        internal void Paint(Graphics graphics, PointF location, State state = State.None, Connector? selectConnector = null)
        {
            // Translate the transform to the componnent coordinates.
            graphics.TranslateTransform(location.X - Center.X, location.Y - Center.Y);

            // Draw backgroung selector
            if (state.HasFlag(State.SimulationStep) || state.HasFlag(State.SimulationPass) || state.HasFlag(State.SimulationError))
            {
                Selector.Paint(graphics, false, state);
            }

            // Draw component elements.
            foreach (Element element in Elements)
            {
                element.Paint(graphics, state.HasFlag(State.Shadow));
            }

            // Draw connectors.
            if (!state.HasFlag(State.Shadow))
            {
                if (state.HasFlag(State.Hover))
                {
                    // Draw elements connectors.
                    foreach (Connector connector in Connectors)
                    {
                        connector.Paint(graphics, true);
                    }
                }

                if (selectConnector != null && Connectors.Contains(selectConnector))
                {
                    selectConnector.Paint(graphics);
                }
            }

            // Draw Selector
            if (state.HasFlag(State.Selected))
            {
                Selector.Paint(graphics, true);
            }

            // Restore transform.
            graphics.TranslateTransform(Center.X - location.X, Center.Y - location.Y);
        }
    }
}
