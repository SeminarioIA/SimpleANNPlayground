// <copyright file="CanvasObject.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using static SimpleAnnPlayground.Graphical.Component;

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Represents an object to be drawn on a <seealso cref="Canvas"/>.
    /// </summary>
    internal abstract class CanvasObject
    {
        /// <summary>
        ///  The global instances count.
        /// </summary>
        private static int _instances;

        /// <summary>
        /// The global ids count.
        /// </summary>
        private static int _ids;

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasObject"/> class.
        /// </summary>
        /// <param name="other">Other object to copy.</param>
        public CanvasObject(CanvasObject other)
        {
            Instance = _instances++;
            Id = other.Id;
            Component = other.Component;
            Connectors = other.Component.Connectors;
            Location = other.Location;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasObject"/> class.
        /// </summary>
        /// <param name="component">The graphical component linked to this object.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        protected CanvasObject(Component component, int x, int y)
        {
            Instance = _instances++;
            Id = _ids++;
            Component = component;
            Connectors = component.GetConnectorsCopy();
            Location = new Point(x, y);
        }

        /// <summary>
        /// Gets the graphical component linked to this object.
        /// </summary>
        public Component Component { get; private set; }

        /// <summary>
        /// Gets the connectors of this object.
        /// </summary>
        public Collection<Connector> Connectors { get; private set; }

        /// <summary>
        /// Gets or sets the state of this object.
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// Gets the active connector with the cursor over it.
        /// </summary>
        public Connector? ActiveConnector { get; private set; }

        /// <summary>
        /// Gets the instance number of this object.
        /// </summary>
        public int Instance { get; }

        /// <summary>
        /// Gets the id number of this object.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets a value indicating whether the object is selected.
        /// </summary>
        public bool Selected => State.HasFlag(State.Selected);

        /// <summary>
        /// Gets or sets the object location in the draw.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Gets the selection area of this object.
        /// </summary>
        public RectangleF SelectionArea
        {
            get
            {
                RectangleF rect = Component.Selector.Rectangle;
                rect.X += Location.X;
                rect.Y += Location.Y;
                return rect;
            }
        }

        /// <summary>
        /// Draws the object over a canvas.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        public void Draw(Graphics graphics)
        {
            Component?.Paint(graphics, Location, State, false, ActiveConnector);
        }

        /// <summary>
        /// Returns if a point belongs to this object.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>True if the point belongs to this object.</returns>
        public bool HasPoint(PointF point)
        {
            point.X += Component.Center.X - Location.X;
            point.Y += Component.Center.Y - Location.Y;
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
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is CanvasObject other && other.Id == Id;

        /// <inheritdoc/>
        public override int GetHashCode() => Id;

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
        /// Selects the connector if the passed location belongs to it.
        /// </summary>
        /// <param name="location">The location point.</param>
        private void SelectConnector(PointF location)
        {
            location.X -= Location.X;
            location.Y -= Location.Y;
            foreach (var connector in Component.Connectors)
            {
                if (connector.HasPoint(location))
                {
                    ActiveConnector = connector;
                    return;
                }
            }

            ActiveConnector = null;
        }
    }
}
