// <copyright file="SubGraph.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Data;
using SimpleAnnPlayground.Utils.Graphics;

namespace SimpleAnnPlayground.Ann.Networks
{
    /// <summary>
    /// Represents a sub graph to calculate a neuron output.
    /// </summary>
    internal class SubGraph : Graph
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubGraph"/> class.
        /// </summary>
        /// <param name="node">The end graph node.</param>
        /// <param name="table">The data table.</param>
        public SubGraph(Node node, DataTable table)
        {
            Node = node;
            Table = table;
            var layer = node.Layer;
            while (layer.Previous is not null)
            {
                layer = layer.Previous;
                Layers.Insert(0, layer);
            }
        }

        /// <summary>
        /// Gets the reference to the end node.
        /// </summary>
        public Node Node { get; }

        /// <summary>
        /// Gets the reference to the data table.
        /// </summary>
        public DataTable Table { get; }

        /// <summary>
        /// Paints the neuron output detail.
        /// </summary>
        /// <param name="graphics">The graphics object.</param>
        /// <param name="bounds">The bounds to draw the output.</param>
        public virtual void Paint(Graphics graphics, Rectangle bounds)
        {
            if (Layers.Count == 0)
            {
                Table.Plot(graphics, bounds, false, false);
            }
            else
            {
                int px1 = 0, px2 = 0;
                using (Bitmap map = new Bitmap(40, 40))
                {
                    double resolution = 20.0 / map.Width;
                    for (double x2 = 10; px2 < map.Height; x2 -= resolution)
                    {
                        for (double x1 = -10; px1 < map.Width; x1 += resolution)
                        {
                            double y = Math.Max(Math.Min(CalcOutput(x1, x2), 1.0), 0.0);
                            var color = Colors.WhiteGradient(Color.Blue, Color.Orange, y);
                            map.SetPixel(px1, px2, color);
                            px1++;
                        }

                        px1 = 0;
                        px2++;
                    }

                    Rectangle rect = new Rectangle(Point.Empty, bounds.Size);
                    graphics.DrawImage(map, bounds);
                }
            }
        }

        /// <summary>
        /// Calculates an output based in a pair of given inputs.
        /// </summary>
        /// <param name="x1">The x1 input.</param>
        /// <param name="x2">The x2 input.</param>
        /// <returns>The neuron output.</returns>
        internal double CalcOutput(double x1, double x2)
        {
            var a = new Dictionary<Node, double>
            {
                { Layers.First().Nodes[0], x1 },
                { Layers.First().Nodes[1], x2 },
            };

            var b = new Dictionary<Node, double>();
            double z;
            foreach (Layer layer in Layers.Skip(1))
            {
                foreach (Node node in layer.Nodes)
                {
                    if (node.Neuron.Bias is null || node.Neuron.Activation is null) throw new InvalidOperationException();
                    z = (double)node.Neuron.Bias.Value;
                    foreach (Link link in node.Previous)
                    {
                        if (link.Connection.Weight is null) throw new InvalidOperationException();
                        z += (double)link.Connection.Weight.Value * a[link.Previous];
                    }

                    b.Add(node, (double)node.Neuron.Activation.Execute((decimal)z));
                }

                a = b;
            }

            if (Node.Neuron.Bias is null || Node.Neuron.Activation is null) throw new InvalidOperationException();
            z = (double)Node.Neuron.Bias.Value;
            foreach (Link link in Node.Previous)
            {
                if (link.Connection.Weight is null) throw new InvalidOperationException();
                z += (double)link.Connection.Weight.Value * a[link.Previous];
            }

            return (double)Node.Neuron.Activation.Execute((decimal)z);
        }
    }
}
