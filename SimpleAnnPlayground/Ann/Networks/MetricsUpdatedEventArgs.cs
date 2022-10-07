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
        /// <param name="batch">The current batch number.</param>
        /// <param name="epoch">The current epoch number.</param>
        /// <param name="totalError">The total error.</param>
        public MetricsUpdatedEventArgs(int batch, int epoch, decimal? totalError)
        {
            Batch = batch;
            Epoch = epoch;
            TotalError = totalError;
        }

        /// <summary>
        /// Gets the current batch number.
        /// </summary>
        public int Batch { get; }

        /// <summary>
        /// Gets the current epoch number.
        /// </summary>
        public int Epoch { get; }

        /// <summary>
        /// Gets the total error.
        /// </summary>
        public decimal? TotalError { get; }
    }
}
