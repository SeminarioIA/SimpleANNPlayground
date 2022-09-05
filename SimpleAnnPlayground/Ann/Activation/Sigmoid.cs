// <copyright file="Sigmoid.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Ann.Activation
{
    /// <summary>
    /// Represents the sigmoid activation function.
    /// </summary>
    public class Sigmoid : ActivationFunction
    {
        /// <inheritdoc/>
        public override string Name => nameof(Sigmoid);

        /// <inheritdoc/>
        public override bool OutputSupported => true;

        /// <inheritdoc/>
        public override bool InternalSupported => true;

        /// <inheritdoc/>
        internal override decimal Execute(decimal z) => 1m / (1m + (decimal)Math.Exp(-(double)z));

        /// <inheritdoc/>
        internal override decimal Derivative(decimal a) => a * (1 - a);

        /// <inheritdoc/>
        internal override void Paint(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.Black))
            {
                graphics.DrawBezier(pen, -5, 9, 5, 9, -5, 0, 5, 0);
            }
        }
    }
}
