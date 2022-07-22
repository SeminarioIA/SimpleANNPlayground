// <copyright file="Workspace.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Drawing.Drawing2D;

namespace SimpleAnnPlayground.Graphical.Environment
{
    /// <summary>
    /// Graphical workspace helper class.
    /// </summary>
    internal class Workspace
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Workspace"/> class.
        /// </summary>
        /// <param name="pictureBox">The PictureBox for this workspace.</param>
        public Workspace(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            MouseTool = new MouseTool(this);
            Transform = new Matrix();
            Canvas = new Canvas();
            Shadow = new ShadowCanvas();

            PictureBox.Paint += PictureBox_Paint;
        }

        /// <summary>
        /// Gets the <seealso cref="PictureBox"/> object linked to this workspace.
        /// </summary>
        public PictureBox PictureBox { get; private set; }

        /// <summary>
        /// Gets the active <seealso cref="MouseTool"/> object.
        /// </summary>
        public MouseTool MouseTool { get; private set; }

        /// <summary>
        /// Gets the transform of this <see cref="Workspace"/>.
        /// </summary>
        public Matrix Transform { get; private set; }

        /// <summary>
        /// Gets the main canvas where the objects are drawn.
        /// </summary>
        public Canvas Canvas { get; private set; }

        /// <summary>
        /// Gets the shadow canvas where the original objects are saved.
        /// </summary>
        public ShadowCanvas Shadow { get; private set; }

        /// <summary>
        /// Forces to paint the workspace.
        /// </summary>
        public void Refresh() => PictureBox.Invalidate();

        private void PictureBox_Paint(object? sender, PaintEventArgs e)
        {
            // Draw the shadow canvas.
            Shadow.Paint(e.Graphics);

            // Draw the main canvas.
            Canvas.Paint(e.Graphics);

            // Draw mouse tool controls.
            MouseTool.Paint(e.Graphics);
        }
    }
}
