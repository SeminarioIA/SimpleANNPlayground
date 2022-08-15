﻿// <copyright file="CanvasObject.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using SimpleAnnPlayground.Graphical.Models;
using SimpleAnnPlayground.Graphical.Terminals;
using SimpleAnnPlayground.Utils;
using SimpleAnnPlayground.Utils.Serialization.Json;
using static SimpleAnnPlayground.Graphical.Component;

namespace SimpleAnnPlayground.Graphical.Visualization
{
    /// <summary>
    /// Represents an object to be drawn on a <seealso cref="Canvas"/>.
    /// </summary>
    [JsonConverter(typeof(CanvasObjConverter))]
    internal abstract class CanvasObject : DrawableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasObject"/> class.
        /// </summary>
        /// <param name="other">Other object to copy.</param>
        /// <param name="mode">The creation mode.</param>
        protected CanvasObject(CanvasObject other, CreationMode mode)
            : base(other, mode)
        {
            Location = other.Location;
            Component = other.Component;
            Inputs = other.Inputs.ConvertAll(input => new InputTerminal(input));
            Outputs = other.Outputs.ConvertAll(output => new OutputTerminal(output));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasObject"/> class.
        /// </summary>
        /// <param name="component">The graphical component linked to this object.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        protected CanvasObject(Component component, int x, int y)
        {
            Location = new Point(x, y);
            Component = component;
            Inputs = new List<InputTerminal>();
            Outputs = new List<OutputTerminal>();

            int inIndex = 0, outIndex = 0;
            foreach (var connector in component.Connectors)
            {
                if (connector.Type == Connector.Types.Input) Inputs.Add(new InputTerminal(this, connector, inIndex++));
                else if (connector.Type == Connector.Types.Output) Outputs.Add(new OutputTerminal(this, connector, outIndex++));
                else throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the graphical component linked to this object.
        /// </summary>
        [JsonConverter(typeof(ComponentConverter))]
        public Component Component { get; }

        /// <summary>
        /// Gets the connectors of this object.
        /// </summary>
        [JsonIgnore]
        public List<InputTerminal> Inputs { get; }

        /// <summary>
        /// Gets the connectors of this object.
        /// </summary>
        [JsonIgnore]
        public List<OutputTerminal> Outputs { get; }

        /// <summary>
        /// Gets the list of all the terminals.
        /// </summary>
        [JsonIgnore]
        public List<Terminal> Terminals => new List<Terminal>().Union(Inputs).Union(Outputs).ToList();

        /// <summary>
        /// Gets or sets the state of this object.
        /// </summary>
        [JsonIgnore]
        public State State { get; set; }

        /// <summary>
        /// Gets the active connector with the cursor over it.
        /// </summary>
        [JsonIgnore]
        public Terminal? ActiveTerminal { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the object is selected.
        /// </summary>
        [JsonIgnore]
        public bool Selected => State.HasFlag(State.Selected);

        /// <summary>
        /// Gets or sets the object location in the draw.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Gets the selection area of this object.
        /// </summary>
        [JsonIgnore]
        public RectangleF SelectionArea
        {
            get
            {
                RectangleF rect = Component.Selector.Rectangle;
                rect.Location = GetAbsolute(rect.Location);
                return rect;
            }
        }

        /// <summary>
        /// Gets the bounds rectangle for this object.
        /// </summary>
        [JsonIgnore]
        public RectangleF Bounds => Component.Selector.Rectangle.OffsetTo(((PointF)Location).OffsetTo(Component.Center));

        /// <summary>
        /// Gets a generic clone of a <see cref="CanvasObject"/>.
        /// </summary>
        /// <param name="other">The object to copy.</param>
        /// <returns>A new object clone of <paramref name="other"/>.</returns>
        public static CanvasObject Clone(CanvasObject other)
        {
            return Activator.CreateInstance(other.GetType(), other, CreationMode.Clone) as CanvasObject ?? throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a generic copy of a <see cref="CanvasObject"/>.
        /// </summary>
        /// <param name="other">The object to copy.</param>
        /// <returns>A new object copy of <paramref name="other"/>.</returns>
        public static CanvasObject Copy(CanvasObject other)
        {
            return Activator.CreateInstance(other.GetType(), other, CreationMode.Copy) as CanvasObject ?? throw new NotImplementedException();
        }

        /// <summary>
        /// Copies the current object properties values to another object.
        /// </summary>
        /// <param name="other">The object to receive the values.</param>
        public void CopyTo(CanvasObject other)
        {
            other.Location = Location;
        }

        /// <summary>
        /// Draws the object over a canvas.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        public void Paint(Graphics graphics)
        {
            Component.Paint(graphics, Location, State, ActiveTerminal?.Connector);
        }

        /// <summary>
        /// Returns if a point belongs to this object.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>True if the point belongs to this object.</returns>
        public bool HasPoint(PointF point)
        {
            MakeRelative(ref point);
            var rect = Component.Selector.Rectangle;
            return rect.Contains(point);
        }

        /// <summary>
        /// Method to be called when the mouse moves over the object.
        /// </summary>
        /// <param name="location">The cursor location.</param>
        public void OnMouseMove(Point location)
        {
            if (AdjustStateFlag(State.Hover, HasPoint(location)))
            {
                SelectConnector(location);
            }
            else
            {
                ActiveTerminal = null;
            }
        }

        /// <summary>
        /// Method to be called when the mouse is connecting over the object.
        /// </summary>
        /// <param name="location">The cursor location.</param>
        /// <param name="type">The connector type looking for.</param>
        public void OnMouseConnecting(Point location, Connector.Types type)
        {
            if (HasPoint(location))
            {
                SelectConnector(location, type);
            }
            else
            {
                ActiveTerminal = null;
            }
        }

        /// <summary>
        /// Adjust a state flag from a boolean value.
        /// </summary>
        /// <param name="flag">The flag to set or clear.</param>
        /// <param name="set">The boolean value that indicates if clear or set the flag.</param>
        /// <returns>The value being set.</returns>
        internal bool AdjustStateFlag(State flag, bool set)
        {
            if (set) SetStateFlag(flag);
            else ClearStateFlag(flag);
            return set;
        }

        /// <summary>
        /// Sets a flag for the state.
        /// </summary>
        /// <param name="flag">The flag to set.</param>
        internal void SetStateFlag(State flag)
        {
            State |= flag;
        }

        /// <summary>
        /// Clears a flag for the state.
        /// </summary>
        /// <param name="flag">The flag to clear.</param>
        internal void ClearStateFlag(State flag)
        {
            State &= ~flag;
        }

        /// <summary>
        /// Gets the absolute location of this object.
        /// </summary>
        /// <param name="point">The point to adjust.</param>
        /// <returns>The relative point.</returns>
        internal PointF GetAbsolute(PointF point)
        {
            point.X += Location.X - Component.Center.X;
            point.Y += Location.Y - Component.Center.Y;
            return point;
        }

        /// <summary>
        /// Gets the relative location of this object.
        /// </summary>
        /// <param name="point">The point to adjust.</param>
        private void MakeRelative(ref PointF point)
        {
            point.X += Component.Center.X - Location.X;
            point.Y += Component.Center.Y - Location.Y;
        }

        /// <summary>
        /// Selects the connector if the passed location belongs to it.
        /// </summary>
        /// <param name="location">The location point.</param>
        /// <param name="type">The connector type to looking for.</param>
        private void SelectConnector(PointF location, Connector.Types? type = null)
        {
            MakeRelative(ref location);
            if (type == Connector.Types.Input)
            {
                foreach (var terminal in Inputs)
                {
                    ActiveTerminal = terminal;
                    return;
                }
            }
            else if (type == Connector.Types.Output)
            {
                foreach (var terminal in Outputs)
                {
                    ActiveTerminal = terminal;
                    return;
                }
            }
            else
            {
                foreach (var terminal in Terminals)
                {
                    if (terminal.Connector.HasPoint(location))
                    {
                        ActiveTerminal = terminal;
                        return;
                    }
                }
            }

            ActiveTerminal = null;
        }
    }
}
