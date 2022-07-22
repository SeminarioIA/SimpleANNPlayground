// <copyright file="IConnectableOutputs.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Ann.Neurons;
using System.Collections.ObjectModel;

namespace SimpleAnnPlayground.Graphical.Interfaces
{
    /// <summary>
    /// Interfaces objects with connectable outputs.
    /// </summary>
    internal interface IConnectableOutputs
    {
        /// <summary>
        /// Gets the collection of connectable outputs.
        /// </summary>
        Collection<Connection> Outputs { get; }
    }
}
