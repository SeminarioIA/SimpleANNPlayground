// <copyright file="DataModel.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Data
{
    /// <summary>
    /// Represents a data generator.
    /// </summary>
    internal abstract partial class DataModel
    {
        /// <summary>
        /// Generates the data model with the passed parameters.
        /// </summary>
        /// <param name="count">The quantity of values to generate.</param>
        /// <param name="noise">The noise to introduce to the data.</param>
        /// <returns>A data table containing the generated data.</returns>
        public abstract DataTable GenerateData(int count, int noise);
    }
}
