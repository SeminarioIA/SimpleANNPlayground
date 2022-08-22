// <copyright file="CellValueChangedEventArgs.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Utils.DataView
{
    /// <summary>
    /// Event arguments class for the <see cref="DataGridViewEditor.CellValueChanged"/> event.
    /// </summary>
    public class CellValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CellValueChangedEventArgs"/> class.
        /// </summary>
        /// <param name="cell">The cell changing value.</param>
        public CellValueChangedEventArgs(DataGridViewCell cell)
        {
            Cell = cell;
        }

        /// <summary>
        /// Gets the cell than is changing its values.
        /// </summary>
        public DataGridViewCell Cell { get; }
    }
}
