// <copyright file="Parameters.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Storage
{
    /// <summary>
    /// Storage class for the network parameters.
    /// </summary>
    internal class Parameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters"/> class.
        /// </summary>
        /// <param name="learningRate">The learning rate.</param>
        /// <param name="batchSize">The batch size.</param>
        public Parameters(decimal learningRate, int batchSize)
        {
            LearningRate = learningRate;
            BatchSize = batchSize;
        }

        /// <summary>
        /// Gets or sets the neural network learning rate.
        /// </summary>
        public decimal LearningRate { get; set; }

        /// <summary>
        /// Gets or sets the model batch size for training.
        /// </summary>
        public int BatchSize { get; set; }
    }
}
