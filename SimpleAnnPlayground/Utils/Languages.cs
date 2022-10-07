// <copyright file="Languages.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Utils.Items;

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
        internal static Language GetApplicationLanguage()
        {
            return Enum.TryParse(typeof(Language), Properties.Settings.Default.DefaultLanguage, out object? objLanguage) && objLanguage is not null
                ? (Language)objLanguage
                : Language.English;
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
                        {
                            if (words[item.Name][0] == "#")
                            {
                                item.ToolTipText = words[item.Name][(int)language + 1];
                            }
                            else
                            {
                                item.Text = words[item.Name][(int)language];
                            }
                        }

                        // If the toolStrip contains child elements.
                        SetMenuLanguage(item, words, language);
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    ApplyComboBoxItemsLanguage(comboBox, words);
                }
                else
                {
                    // Change the text for other controls.
                    if (words.ContainsKey(control.Name))
                    {
                        control.Text = words[control.Name][(int)language];
                    }
                }
            }
        }

        /// <summary>
        /// Applies the current application language to the passed <see cref="ComboBox"/> items.
        /// </summary>
        /// <param name="comboBox">The ComboBox control.</param>
        /// <param name="words">The languages dictionary.</param>
        internal static void ApplyComboBoxItemsLanguage(ComboBox comboBox, Dictionary<string, List<string>> words)
        {
            Language language = GetApplicationLanguage();

            var items = new List<object>();
            foreach (object item in comboBox.Items)
            {
                items.Add(item);
                if (item is ComboBoxItem cbi && words.ContainsKey(cbi.Name))
                {
                    cbi.Text = words[cbi.Name][(int)language];
                }
            }

            int selectedIndex = comboBox.SelectedIndex;
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items.ToArray());
            comboBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Gets a string of the specified language from the passed dictionary.
        /// </summary>
        /// <param name="key">The key for the string.</param>
        /// <param name="words">The dictionary.</param>
        /// <param name="language">The languaje of the string.</param>
        /// <returns>The string of the specified language.</returns>
        internal static string GetString(string key, Dictionary<string, List<string>> words, Language language)
        {
            if (words.ContainsKey(key))
            {
                return words[key][(int)language];
            }

            return $"[{key}: {language}]";
        }

        /// <summary>
        /// Gets a string of the specified language from the passed dictionary.
        /// </summary>
        /// <param name="key">The key for the string.</param>
        /// <param name="words">The dictionary.</param>
        /// <returns>The string of the specified language.</returns>
        internal static string GetString(string key, Dictionary<string, List<string>> words)
        {
            Language language = GetApplicationLanguage();
            if (words.ContainsKey(key))
            {
                return words[key][(int)language];
            }

            return $"[{key}: {language}]";
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
