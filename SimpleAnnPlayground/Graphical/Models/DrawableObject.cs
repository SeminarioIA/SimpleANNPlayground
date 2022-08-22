// <copyright file="DrawableObject.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using System.Security.Cryptography;

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
        [JsonIgnore]
        private static int _instances;

        /// <summary>
        /// The global ids count.
        /// </summary>
        private static int _ids;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableObject"/> class.
        /// </summary>
        /// <param name="other">The other object to copy.</param>
        /// <param name="mode">The creation mode.</param>
        protected DrawableObject(DrawableObject other, CreationMode mode)
        {
            Instance = _instances++;
            Id = mode switch
            {
                CreationMode.Clone => other.Id,
                CreationMode.Copy => _ids++,
                _ => throw new NotImplementedException(),
            };
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
        /// Type of object to create.
        /// </summary>
        public enum CreationMode
        {
            /// <summary>
            /// Creates a copy object.
            /// </summary>
            Copy,

            /// <summary>
            /// Creates a clone object.
            /// </summary>
            Clone,
        }

        /// <summary>
        /// Gets the instance number of this object.
        /// </summary>
        [JsonIgnore]
        public int Instance { get; }

        /// <summary>
        /// Gets the id number of this object.
        /// </summary>
        public int Id { get; private set; }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is DrawableObject other && other.Id == Id;

        /// <inheritdoc/>
        public override int GetHashCode() => Id;

        /// <inheritdoc/>
        public override string ToString() => $"{GetType().Name}: Id={Id} (Instance={Instance})";

        /// <summary>
        /// Resets the Ids to be assigned to new objects.
        /// </summary>
        internal static void ResetIds()
        {
            _ids = 0;
        }

        /// <summary>
        /// Force a <see cref="DrawableObject"/> to get an id.
        /// </summary>
        /// <param name="obj">The object to force.</param>
        /// <param name="id">The id to be set.</param>
        internal static void ForceId(DrawableObject obj, int id)
        {
            obj.Id = id;
            _ids = Math.Max(id + 1, _ids);
        }

        /// <summary>
        /// Converts the object from a clone into a copy.
        /// </summary>
        protected void ConvertToCopy() => Id = _ids++;
    }
}