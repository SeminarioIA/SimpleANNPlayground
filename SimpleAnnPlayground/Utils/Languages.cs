// <copyright file="Languages.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Utils
{
    /// <summary>
    /// Class that contains all the strings for the supported languages.
    /// </summary>
    internal static class Languages
    {
        /// <summary>
        /// Enumeration of the supported languages.
        /// </summary>
        internal enum Language
        {
            /// <summary>
            /// English language.
            /// </summary>
            English,

            /// <summary>
            /// Spanish language.
            /// </summary>
            Spanish,
        }

        /// <summary>
        /// Gets the application language from the application settings.
        /// </summary>
        /// <returns>The active application language.</returns>
        internal static Languages.Language GetApplicationLanguge()
        {
            return Enum.TryParse(typeof(Languages.Language), Properties.Settings.Default.DefaultLanguage, out object? objLanguage) && objLanguage is not null
                ? (Languages.Language)objLanguage
                : Languages.Language.English;
        }

        /// <summary>
        /// Changes the language being shown in a Windows form.
        /// </summary>
        /// <param name="form">The form to apply the language.</param>
        /// <param name="words">The dictionary containing the words.</param>
        /// <param name="language">The selected language.</param>
        internal static void ChangeFormLanguage(Form form, Dictionary<string, List<string>> words, Language language)
        {
            foreach (Control control in GetSelfAndChildrenRecursive(form))
            {
                // If control is a toolStrip the child controls are items.
                if (control is ToolStrip toolStrip)
                {
                    foreach (ToolStripItem item in toolStrip.Items)
                    {
                        if (words.ContainsKey(item.Name))
                            item.Text = words[item.Name][(int)language];

                        // If the toolStrip contains child elements.
                        SetMenuLanguage(item, words, language);
                    }
                }
                else
                {
                    // Change the text for other controls.
                    if (words.ContainsKey(control.Name))
                        control.Text = words[control.Name][(int)language];
                }
            }
        }

        /// <summary>
        /// Gets an enumeration of the controls contained in a container including itself.
        /// </summary>
        /// <param name="parent">The parent control.</param>
        /// <returns>The enumeration of controls.</returns>
        private static IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            yield return parent;

            foreach (Control container in parent.Controls)
            {
                foreach (Control child in GetSelfAndChildrenRecursive(container))
                {
                    yield return child;
                }
            }
        }

        /// <summary>
        /// Sets the text language for a menu item recursively.
        /// </summary>
        /// <param name="item">The item to change the language.</param>
        /// <param name="words">The dictionary containing the words.</param>
        /// <param name="language">The selected language.</param>
        private static void SetMenuLanguage(ToolStripItem item, Dictionary<string, List<string>> words, Language language)
        {
            // If the toolStrip contains child elements.
            if (item is ToolStripDropDownItem downItems)
            {
                foreach (ToolStripItem downItem in downItems.DropDownItems)
                {
                    if (words.ContainsKey(downItem.Name))
                    {
                        downItem.Text = words[downItem.Name][(int)language];
                        SetMenuLanguage(downItem, words, language);
                    }
                }
            }
        }
    }
}
