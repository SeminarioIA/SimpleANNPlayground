// <copyright file="IConnectableInputs.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Graphical.Interfaces
{
    /// <summary>
    /// Interfaces objects with connectable inputs.
    /// </summary>
    internal interface IConnectableInputs
    {
        /// <summary>
        /// Gets the collection of connectable inputs.
        /// </summary>
        Collection<Connection> Inputs { get; }
    }
}
