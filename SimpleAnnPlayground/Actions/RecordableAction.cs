// <copyright file="RecordableAction.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Environment;
using SimpleAnnPlayground.Graphical.Visualization;
using SimpleAnnPlayground.Utils;
using System.Drawing.Drawing2D;

namespace SimpleAnnPlayground.Actions
{
    /// <summary>
    /// Represents an action in the document.
    /// </summary>
    internal abstract class RecordableAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecordableAction"/> class.
        /// </summary>
        /// <param name="workspace">The reference to the current workspace.</param>
        /// <param name="actionType">The type of action.</param>
        protected RecordableAction(Workspace workspace, ActionType actionType)
        {
            Workspace = workspace;
            Type = actionType;
        }

        /// <summary>
        /// List of actions allowed by the application.
        /// </summary>
        public enum ActionType
        {
            /// <summary>
            /// A new <see cref="CanvasObject"/> was inserting.
            /// </summary>
            Inserted,

            /// <summary>
            /// A group of selected objects was moved.
            /// </summary>
            Moved,

            /// <summary>
            /// A connection between two neurons was performed.
            /// </summary>
            Connected,

            /// <summary>
            /// A group of selected objects was deleted.
            /// </summary>
            Deleted,

            /// <summary>
            /// A group of selected objects was cut.
            /// </summary>
            Cut,
        }

        /// <summary>
        /// Gets the type of this action.
        /// </summary>
        public ActionType Type { get; }

        /// <summary>
        /// Gets the workspace.
        /// </summary>
        public Workspace Workspace { get; }

        /// <summary>
        /// Undoes the action.
        /// </summary>
        public abstract void Undo();

        /// <summary>
        /// Performs the action.
        /// </summary>
        public abstract void Redo();

        /// <summary>
        /// Paints the before actions picture.
        /// </summary>
        /// <param name="graphics">The graphics object to paint.</param>
        public abstract void PaintBefore(Graphics graphics);

        /// <summary>
        /// Paints the after actions picture.
        /// </summary>
        /// <param name="graphics">The graphics object to paint.</param>
        public abstract void PaintAfter(Graphics graphics);

        /// <inheritdoc/>
        public override string ToString() => Type.ToString();

        /// <summary>
        /// Adjusts a transform to the action bounds.
        /// </summary>
        /// <param name="transform">The transform.</param>
        /// <param name="pictureBounds">The <see cref="PictureBox"/> bounds.</param>
        internal void AdjustTransformToBounds(ref Matrix transform, Rectangle pictureBounds)
        {
            transform.Reset();
            var actionBounds = CalcBounds();
            transform.Translate(pictureBounds.Width / 2, pictureBounds.Height / 2);
            float scale = Math.Min(pictureBounds.Width / actionBounds.Width, Math.Min(pictureBounds.Height / actionBounds.Height, 1));
            transform.Scale(scale, scale);
            transform.Translate(35f - (actionBounds.X + actionBounds.Width / 2), -(actionBounds.Y + actionBounds.Height / 2));
        }

        /// <summary>
        /// Expands the bounds with respect to a point.
        /// </summary>
        /// <param name="topLeft">The top-left point of the bounds.</param>
        /// <param name="botomRight">The botom-right point of the bounds.</param>
        /// <param name="point">The point to expand the bounds.</param>
        protected static void ExpandBounds(ref PointF topLeft, ref PointF botomRight, PointF point)
        {
            if (topLeft == PointF.Empty && botomRight == PointF.Empty)
            {
                topLeft = point;
                botomRight = point;
            }
            else
            {
                if (point.X > botomRight.X) botomRight.X = point.X;
                else if (point.X < topLeft.X) topLeft.X = point.X;
                if (point.Y > botomRight.Y) botomRight.Y = point.Y;
                else if (point.Y < topLeft.Y) topLeft.Y = point.Y;
            }
        }

        /// <summary>
        /// Expands the bounds with respect to a rectangle.
        /// </summary>
        /// <param name="topLeft">The top-left point of the bounds.</param>
        /// <param name="botomRight">The botom-right point of the bounds.</param>
        /// <param name="rect">The rectangle to expand the bounds.</param>
        protected static void ExpandBounds(ref PointF topLeft, ref PointF botomRight, RectangleF rect)
        {
            var corner = rect.Location.OffsetTo(rect.Size.ToPointF());
            if (topLeft == PointF.Empty && botomRight == PointF.Empty)
            {
                topLeft = rect.Location;
                botomRight = corner;
            }
            else
            {
                if (rect.X < topLeft.X) topLeft.X = rect.X;
                if (rect.Y < topLeft.Y) topLeft.Y = rect.Y;
                if (corner.X > botomRight.X) botomRight.X = corner.X;
                if (corner.Y > botomRight.Y) botomRight.Y = corner.Y;
            }
        }

        /// <summary>
        /// Calculates the bounds for all the objects contained on this action.
        /// </summary>
        /// <returns>A rectangle thar represents the bounds.</returns>
        protected abstract RectangleF CalcBounds();
    }
}
