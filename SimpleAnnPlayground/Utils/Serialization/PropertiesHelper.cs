// <copyright file="PropertiesHelper.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using System.Globalization;

namespace SimpleAnnPlayground.Utils.Serialization
{
    /// <summary>
    /// Helper class to set or get an object properties.
    /// </summary>
    internal static class PropertiesHelper
    {
        /// <summary>
        /// Gets a list of properties and values from an object.
        /// </summary>
        /// <param name="obj">The object to get the properties values.</param>
        /// <returns>The list of properties and values.</returns>
        public static List<KeyValuePair<string, string>> GetProperties(object obj)
        {
            var properties = new List<KeyValuePair<string, string>>();
            var objType = obj.GetType();

            foreach (var property in objType.GetProperties())
            {
                string name = property.Name;
                object? value = property.GetValue(obj);

                if (value is ITextSerializable serializable)
                {
                    properties.Add(new KeyValuePair<string, string>(name, serializable.Serialize()));
                }
                else if (value is Color color)
                {
                    properties.Add(new KeyValuePair<string, string>(name, color.Name));
                }
                else
                {
                    properties.Add(new KeyValuePair<string, string>(name, value?.ToString() ?? string.Empty));
                }
            }

            return properties;
        }

        /// <summary>
        /// Sets the properties of an object.
        /// </summary>
        /// <param name="obj">The object reference.</param>
        /// <param name="properties">The list of properties and values to set the object.</param>
        public static void SetProperties(object obj, List<KeyValuePair<string, string>> properties)
        {
            var objType = obj.GetType();

            foreach (var prop in properties)
            {
                var property = objType.GetProperty(prop.Key);
                if (property != null)
                {
                    if (property.PropertyType == typeof(ITextSerializable))
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                    else if (property.PropertyType == typeof(float))
                    {
                        property.SetValue(obj, float.Parse(prop.Value, CultureInfo.CurrentCulture));
                    }
                    else if (property.PropertyType == typeof(Color?))
                    {
                        if (string.IsNullOrEmpty(prop.Value))
                        {
                            property.SetValue(obj, null);
                        }
                        else
                        {
                            property.SetValue(obj, Color.FromName(prop.Value));
                        }
                    }
                    else if (property.PropertyType == typeof(Color))
                    {
                        property.SetValue(obj, Color.FromName(prop.Value));
                    }
                }
            }
        }
    }
}
