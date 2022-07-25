// <copyright file="DrawableObject.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Graphical.Models
{
    /// <summary>
    /// Represents any drawable object.
    /// </summary>
    internal abstract class DrawableObject
    {
        /// <summary>
        ///  The global instances count.
        /// </summary>
        private static int _instances;

        /// <summary>
        /// The global ids count.
        /// </summary>
        private static int _ids;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableObject"/> class.
        /// </summary>
        /// <param name="other">The other object to copy.</param>
        protected DrawableObject(DrawableObject other)
        {
            Instance = _instances++;
            Id = other.Id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableObject"/> class.
        /// </summary>
        protected DrawableObject()
        {
            Instance = _instances++;
            Id = _ids++;
        }

        /// <summary>
        /// Gets the instance number of this object.
        /// </summary>
        public int Instance { get; }

        /// <summary>
        /// Gets the id number of this object.
        /// </summary>
        public int Id { get; }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is DrawableObject other && other.Id == Id;

        /// <inheritdoc/>
        public override int GetHashCode() => Id;

        /// <inheritdoc/>
        public override string ToString() => $"{GetType().Name}: Id={Id} (Instance={Instance})";
    }
}