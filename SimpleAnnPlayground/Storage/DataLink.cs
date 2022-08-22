// <copyright file="DataLink.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Storage
{
    /// <summary>
    /// Represents a connection between a Neurone and a DataLabel.
    /// </summary>
    internal class DataLink
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLink"/> class.
        /// </summary>
        /// <param name="id">The object Id.</param>
        /// <param name="label">The label name.</param>
        public DataLink(int id, string label)
        {
            Id = id;
            Label = label;
        }

        /// <summary>
        /// Gets the object Id.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the label name.
        /// </summary>
        public string Label { get; }
    }
}
