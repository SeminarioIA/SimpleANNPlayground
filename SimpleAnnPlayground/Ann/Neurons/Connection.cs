// <copyright file="Connection.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Graphical;

namespace SimpleAnnPlayground.Ann.Neurons
{
    /// <summary>
    /// Represents the connection between two components.
    /// </summary>
    internal class Connection
    {
        private const float Width = 0.1f;
        private readonly Color _color = Color.Black;

        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="source">The source component.</param>
        /// <param name="input">The input connector in the source component.</param>
        /// <param name="destination">The destination component.</param>
        /// <param name="output">The output connector in the destination component.</param>
        public Connection(CanvasObject source, Connector input, CanvasObject destination, Connector output)
        {
            Source = source;
            Input = input;
            Destination = destination;
            Output = output;
        }

        /// <summary>
        /// Gets the source object.
        /// </summary>
        public CanvasObject Source { get; private set; }

        /// <summary>
        /// Gets the input connector.
        /// </summary>
        public Connector Input { get; private set; }

        /// <summary>
        /// Gets the destination object.
        /// </summary>
        public CanvasObject Destination { get; private set; }

        /// <summary>
        /// Gets the output connector.
        /// </summary>
        public Connector Output { get; private set; }

        /// <summary>
        /// Paints the connection in a <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        internal void Paint(Graphics graphics)
        {
            using (Pen pen = new Pen(_color, Width))
            {
                graphics.DrawLine(pen, Source.GetAbsolute(Input.Location), Destination.GetAbsolute(Output.Location));
            }
        }
    }
}
