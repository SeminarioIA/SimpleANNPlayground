// <copyright file="MetricsUpdatedEventArgs.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// Contains the data related to the <see cref="Execution.MetricsUpdated"/> event.
    /// </summary>
    internal class MetricsUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="totalError">The total error.</param>
        public MetricsUpdatedEventArgs(decimal? totalError)
        {
            TotalError = totalError;
        }

        /// <summary>
        /// Gets the total error.
        /// </summary>
        public decimal? TotalError { get; }
    }
}
