// <copyright file="DataModels.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Data.Models;

namespace SimpleAnnPlayground.Data
{
    /// <summary>
    /// Represents a data generator.
    /// </summary>
    internal abstract partial class DataModel
    {
        /// <summary>
        /// Gets the a reference to an <see cref="CircleDataModel"/> object.
        /// </summary>
        public static CircleDataModel CircleDataModel { get; } = new CircleDataModel();

        /// <summary>
        /// Gets the a reference to an <see cref="PlaneDataModel"/> object.
        /// </summary>
        public static PlaneDataModel PlaneDataModel { get; } = new PlaneDataModel();

        /// <summary>
        /// Gets the a reference to an <see cref="TwoGroupsDataModel"/> object.
        /// </summary>
        public static TwoGroupsDataModel TwoGroupsDataModel { get; } = new TwoGroupsDataModel();
    }
}
