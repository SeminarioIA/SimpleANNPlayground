// <copyright file="ActivationFunction.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Ann.Activation
{
    /// <summary>
    /// Represents a neuron activation function.
    /// </summary>
    public abstract class ActivationFunction
    {
        /// <summary>
        /// Gets the name of the activation function.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Executes the activation function operation to calculate the output a.
        /// </summary>
        /// <param name="z">The fuction input.</param>
        /// <returns>The function output.</returns>
        internal abstract decimal Execute(decimal z);

        /// <summary>
        /// Calculates the value using the derivade of the activation function.
        /// </summary>
        /// <param name="z">The fuction input.</param>
        /// <returns>The function output.</returns>
        internal abstract decimal Derivative(decimal z);

        /// <summary>
        /// Draws the function representation in the given graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        internal abstract void Paint(Graphics graphics);
    }
}
