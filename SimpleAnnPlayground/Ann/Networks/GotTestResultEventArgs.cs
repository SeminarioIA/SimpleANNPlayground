// <copyright file="GotTestResultEventArgs.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// The <see cref="Execution.GotTestResult"/> event args.
    /// </summary>
    internal class GotTestResultEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GotTestResultEventArgs"/> class.
        /// </summary>
        /// <param name="label">The test sample label value.</param>
        /// <param name="output">The test result output value.</param>
        public GotTestResultEventArgs(decimal label, decimal output)
        {
            Label = label;
            Output = output;
        }

        /// <summary>
        /// Gets the test result value.
        /// </summary>
        public decimal Output { get; private set; }

        /// <summary>
        /// Gets the test result value.
        /// </summary>
        public decimal Label { get; private set; }
    }
}
