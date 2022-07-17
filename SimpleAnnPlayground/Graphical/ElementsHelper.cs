﻿// <copyright file="ElementsHelper.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical.Elements;

namespace SimpleAnnPlayground.Graphical
{
    /// <summary>
    /// Helper class to make operations with the Graphical Elements.
    /// </summary>
    internal static class ElementsHelper
    {
        /// <summary>
        /// Enumerates the types of Graphical Elements.
        /// </summary>
        internal enum Types
        {
            /// <summary>
            /// Connector element class.
            /// </summary>
            Connector,

            /// <summary>
            /// Ellipse element class.
            /// </summary>
            Ellipse,

            /// <summary>
            /// Line element class.
            /// </summary>
            Line,

            /// <summary>
            /// Rectangle element class.
            /// </summary>
            Rectangle,
        }

        /// <summary>
        /// Gets an array containing the types of Elements.
        /// </summary>
        internal static Type[] ElementsTypes => new Type[] {
            typeof(Connector),
            typeof(Ellipse),
            typeof(Line),
            typeof(Elements.Rectangle),
        };

        /// <summary>
        /// Adds a menu item for each existing element.
        /// </summary>
        /// <param name="item">The menu to add the elements.</param>
        /// <param name="clickEventHandler">The event handler for the click action.</param>
        internal static void AddMenuPerElement(ToolStripDropDownItem item, EventHandler clickEventHandler)
        {
            // Iterate for each element type.
            foreach (Types elementType in Enum.GetValues<Types>())
            {
                // Create its correspondig menu item.
                var mnuItem = new ToolStripMenuItem
                {
                    Name = $"MnuAdd{elementType}",
                    Text = elementType.ToString(),

                    // Store the Element type in the item Tag
                    Tag = ElementsTypes[(int)elementType],
                };

                // Add the menu item to the Add button.
                _ = item.DropDownItems.Add(mnuItem);

                // Link the click event with the passed event handler.
                mnuItem.Click += clickEventHandler;
            }
        }
    }
}
