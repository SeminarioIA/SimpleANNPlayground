﻿// <copyright file="TextFileManager.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Utils.FileManagment
{
    /// <summary>
    /// File manager class to handle UI file operations with text files.
    /// </summary>
    public class TextFileManager : FileManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileManager"/> class.
        /// </summary>
        public TextFileManager()
            : base()
        {
        }

        /// <summary>
        /// Compares.
        /// </summary>
        /// <param name="currentContent">String with current json file.</param>
        /// <returns>Returns a bool value.</returns>
        public bool HadChanged(string currentContent)
        {
            if (currentContent?.Equals(FileContent) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <inheritdoc/>
        protected override object? NewOperation() => string.Empty;

        /// <inheritdoc/>
        protected override object? OpenOperation() => File.ReadAllText(FilePath);

        /// <inheritdoc/>
        protected override bool SaveOperation()
        {
#pragma warning disable CA1031 // Do not catch general exception types
            try
            {
                File.WriteAllText(FilePath, FileContent?.ToString() ?? string.Empty);
                return true;
            }
            catch (Exception)
            {
            }
#pragma warning restore CA1031 // Do not catch general exception types
            return false;
        }
    }
}
