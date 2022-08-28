// <copyright file="FrmTemplate.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

// using SimpleAnnPlayground.Graphical.Environment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleAnnPlayground.UI
{
    /// <summary>
    /// Class for template window.
    /// </summary>
    public partial class FrmTemplate : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmTemplate"/> class.
        /// </summary>
        public FrmTemplate()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        /*
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmTemplate"/> class.
        /// </summary>
        /// <param name="workspace">The workspace containing the data.</param>
        public FrmTemplate(Workspace workspace)
        {
            InitializeComponent();
            Workspace = workspace;
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        public Workspace Workspace { get; }

        */
    }
}
