// <copyright file="CustomRichTextBox.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.ComponentModel;
using System.Runtime.InteropServices;

#pragma warning disable SA1121, IDE0049, SA1600, CA1815, CS1591, CA1823, SA1310, CA1707, CA5392, SA1307, SA1129, IDE0058, IDE0051

namespace SimpleAnnPlayground.UI.Controls
{
    /// <summary>
    /// Custom RichTextbox class.
    /// </summary>
    public partial class CustomRichTextBox : RichTextBox
    {
        public const int PFM_LINESPACING = 256;
        public const int EM_SETPARAFORMAT = 1095;
        private const int SCF_SELECTION = 1;
        private const int WM_SETFOCUS = 0x0007;
        private const int WM_KILLFOCUS = 0x0008;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomRichTextBox"/> class.
        /// </summary>
        public CustomRichTextBox()
        {
            InitializeComponent();

            BorderStyle = BorderStyle.None;
            BackColor = Color.White;
            Cursor = Cursors.Arrow; // mouse cursor like in other controls
            SelectionHighlightEnabled = false;
        }

        [DefaultValue(false)]
        public bool SelectionHighlightEnabled { get; set; }

        public void SetSelectionLineSpacing(byte bLineSpacingRule, int dyLineSpacing)
        {
            PARAFORMAT2 format = new PARAFORMAT2();
            format.cbSize = Marshal.SizeOf(format);
            format.dwMask = PFM_LINESPACING;
            format.dyLineSpacing = dyLineSpacing;
            format.bLineSpacingRule = bLineSpacingRule;
            SendMessage(Handle, EM_SETPARAFORMAT, SCF_SELECTION, ref format);
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, ref PARAFORMAT2 lParam);

        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        protected struct PARAFORMAT2
        {
            public int cbSize;
            public uint dwMask;
            public Int16 wNumbering;
            public Int16 wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public Int16 wAlignment;
            public Int16 cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public Int16 sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public Int16 wShadingWeight;
            public Int16 wShadingStyle;
            public Int16 wNumberingStart;
            public Int16 wNumberingStyle;
            public Int16 wNumberingTab;
            public Int16 wBorderSpace;
            public Int16 wBorderWidth;
            public Int16 wBorders;
        }
    }
}
