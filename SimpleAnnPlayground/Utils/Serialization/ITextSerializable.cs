// <copyright file="ITextSerializable.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Utils.Serialization
{
    /// <summary>
    /// Interface of types that can be serialized from text strings.
    /// </summary>
    internal interface ITextSerializable
    {
        /// <summary>
        /// Serializes the object into a text string.
        /// </summary>
        /// <returns>The text string that represents the serialized object.</returns>
        string Serialize();

        /// <summary>
        /// Deserializes an object properties from a text string.
        /// </summary>
        /// <param name="text">The string containing the object properties.</param>
        void Deserialize(string text);
    }
}
