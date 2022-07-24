// <copyright file="Canvas.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using SimpleAnnPlayground.Graphical.Terminals;
using SimpleAnnPlayground.Graphical.Tools;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Graphical.Visualization
{
    /// <summary>
    /// Represents a canvas to draw graphical objects.
    /// </summary>
    internal class Canvas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Canvas"/> class.
        /// </summary>
        public Canvas()
        {
            Objects = new Collection<CanvasObject>();
            Connections = new List<Connection>();
        }

        /// <summary>
        /// Gets the list of objects on this canvas.
        /// </summary>
        protected Collection<CanvasObject> Objects { get; }

        /// <summary>
        /// Gets the list of connections on this canvas.
        /// </summary>
        protected List<Connection> Connections { get; }

        /// <summary>
        /// Converts a color object into another color with less bright.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <param name="shadow">Indicates if the operation will be performed.</param>
        /// <returns>The resulting shadow color.</returns>
        public static Color GetShadowColor(Color color, bool shadow)
        {
            return shadow ? Color.FromArgb(ShadowValue(color.R), ShadowValue(color.G), ShadowValue(color.B)) : color;
        }

        /// <summary>
        /// Adds an object to the canvas.
        /// </summary>
        /// <param name="obj">The object to be added.</param>
        public virtual void AddObject(CanvasObject obj) => Objects.Add(obj);

        /// <summary>
        /// Adds a connection between two object to this canvas.
        /// </summary>
        /// <param name="connection">The connection to be added.</param>
        public virtual void AddConnection(Connection connection) => Connections.Add(connection);

        /// <summary>
        /// Determines if a location touches a <see cref="CanvasObject"/>.
        /// </summary>
        /// <param name="location">The location to test.</param>
        /// <returns>The object in the location, otherwise null.</returns>
        public CanvasObject? IsObject(PointF location)
        {
            foreach (var obj in Objects.Reverse())
            {
                if (obj.HasPoint(location))
                    return obj;
            }

            return null;
        }

        /// <summary>
        /// Determines if an object intersects another object.
        /// </summary>
        /// <param name="object">The object to test.</param>
        /// <returns>True if there is an object intercting, otherwise false.</returns>
        public bool IntesectsObject(CanvasObject @object)
        {
            foreach (var obj in Objects)
            {
                if (obj != @object && obj.SelectionArea.IntersectsWith(@object.SelectionArea))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the object with an active connector.
        /// </summary>
        /// <param name="except">The known active object to except.</param>
        /// <returns>The active object.</returns>
        internal Terminal? GetActiveObject(CanvasObject except)
        {
            foreach (var obj in Objects)
            {
                if (obj != except && obj.ActiveTerminal != null) return obj.ActiveTerminal;
            }

            return null;
        }

        /// <summary>
        /// Selects the objects in the given collection.
        /// </summary>
        /// <param name="objects">The collection of objects to select.</param>
        internal void Select(Collection<CanvasObject> objects)
        {
            foreach (var obj in objects)
            {
                if (Objects.Contains(obj)) obj.SetStateFlag(Component.State.Selected);
            }
        }

        /// <summary>
        /// Selects all the objects on this canvas.
        /// </summary>
        internal void SelectAll()
        {
            foreach (var obj in Objects)
            {
                obj.SetStateFlag(Component.State.Selected);
            }
        }

        /// <summary>
        /// Deselects all the objects on this canvas.
        /// </summary>
        internal void UnselectAll()
        {
            foreach (var obj in Objects)
            {
                obj.ClearStateFlag(Component.State.Selected | Component.State.Hover);
            }
        }

        /// <summary>
        /// Selects all the objects contained in the selection box.
        /// </summary>
        /// <param name="box">The selection box.</param>
        internal void SelectArea(SelectionBox box)
        {
            if (box.Inclusive)
            {
                foreach (var obj in Objects)
                {
                    _ = obj.AdjustStateFlag(Component.State.Selected, box.Rectangle.IntersectsWith(obj.SelectionArea));
                }
            }
            else
            {
                foreach (var obj in Objects)
                {
                    _ = obj.AdjustStateFlag(Component.State.Selected, box.Rectangle.Contains(obj.SelectionArea));
                }
            }
        }

        /// <summary>
        /// Obtains a collection of the selected objects.
        /// </summary>
        /// <returns>The collection of selected objects.</returns>
        internal Collection<CanvasObject> GetSelectedObjects()
        {
            var selected = new Collection<CanvasObject>();
            foreach (var obj in Objects)
            {
                if (obj.State.HasFlag(Component.State.Selected)) selected.Add(obj);
            }

            return selected;
        }

        /// <summary>
        /// Updated the mouse position in the workspace.
        /// </summary>
        /// <param name="location">The mouse location.</param>
        internal void UpdateMousePosition(PointF location)
        {
            foreach (var obj in Objects)
            {
                obj.OnMouseMove(Point.Truncate(location));
            }
        }

        /// <summary>
        /// Updated the mouse position in the workspace when connecting.
        /// </summary>
        /// <param name="location">The mouse location.</param>
        /// <param name="connecting">The object being connected.</param>
        internal void UpdateConnectingPosition(PointF location, ConnectingLine connecting)
        {
            foreach (var obj in Objects)
            {
                if (obj != connecting.Start.Owner) obj.OnMouseConnecting(Point.Truncate(location), connecting.Type);
            }
        }

        /// <summary>
        /// Draws all the canvas objects over a graphics.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        internal void Paint(Graphics graphics)
        {
            // Paint the objects.
            foreach (CanvasObject obj in Objects)
            {
                obj.Paint(graphics);
            }

            // Paint the connections.
            foreach (Connection conn in Connections)
            {
                conn.Paint(graphics);
            }
        }

        private static int ShadowValue(byte value)
        {
            int diff = byte.MaxValue - value;
            int inc = 93 * diff / 100;
            return inc + value;
        }
    }
}
