// <copyright file="Canvas.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Tools;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Graphical
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
            Objects = new List<CanvasObject>();
        }

        /// <summary>
        /// Gets the list of objects on this canvas.
        /// </summary>
        protected List<CanvasObject> Objects { get; private set; }

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
        /// Determines if a location touches a <see cref="CanvasObject"/>.
        /// </summary>
        /// <param name="location">The location to test.</param>
        /// <returns>The object in the location, otherwise null.</returns>
        public CanvasObject? IsObject(PointF location)
        {
            foreach (var obj in Objects)
            {
                if (obj.HasPoint(location))
                {
                    return obj;
                }
            }

            return null;
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
                obj.ClearStateFlag(Component.State.Selected);
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
                if (obj != connecting.Source) obj.OnMouseConnecting(Point.Truncate(location), connecting.Type);
            }
        }

        /// <summary>
        /// Draws all the canvas objects over a graphics.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        internal void Draw(Graphics graphics)
        {
            foreach (CanvasObject obj in Objects)
            {
                obj.Draw(graphics);
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
