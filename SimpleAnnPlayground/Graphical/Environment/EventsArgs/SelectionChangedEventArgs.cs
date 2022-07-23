// <copyright file="SelectionChangedEventArgs.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Graphical.Environment.EventsArgs
{
    /// <summary>
    /// Event arguments for the <see cref="MouseTool.SelectionChanged"/> event.
    /// </summary>
    internal class SelectionChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionChangedEventArgs"/> class.
        /// </summary>
        /// <param name="selectedObject">The object that was selected.</param>
        public SelectionChangedEventArgs(object? selectedObject)
        {
            SelectedObject = selectedObject;
        }

        /// <summary>
        /// Gets the selected object.
        /// </summary>
        public object? SelectedObject { get; }
    }
}
