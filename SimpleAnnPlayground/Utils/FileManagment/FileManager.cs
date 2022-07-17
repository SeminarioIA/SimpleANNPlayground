// <copyright file="FileManager.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Utils.FileManagment
{
    /// <summary>
    /// File manager class to handle UI file operations.
    /// </summary>
    public abstract class FileManager : IDisposable
    {
        /// <summary>
        /// File dialog used to save the file.
        /// </summary>
        private readonly SaveFileDialog _saveFileDialog;

        /// <summary>
        /// File dialog used to open a file.
        /// </summary>
        private readonly OpenFileDialog _openFileDialog;

        /// <summary>
        /// The file path value.
        /// </summary>
        private string _filePath;

        /// <summary>
        /// Stores if the instance is disposed.
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileManager"/> class.
        /// </summary>
        protected FileManager()
        {
            _filePath = string.Empty;
            _saveFileDialog = new SaveFileDialog();
            _openFileDialog = new OpenFileDialog();
        }

        /// <summary>
        /// Ocurs when the name of the file path had changed.
        /// </summary>
        public event EventHandler<EventArgs>? FilePathChanged;

        /// <summary>
        /// Gets the file content object.
        /// </summary>
        public object? FileContent { get; private set; }

        /// <summary>
        /// Gets the current file path.
        /// </summary>
        public string FilePath
        {
            get => _filePath;
            private set
            {
                _filePath = value;
                FilePathChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets the current file name including the extension.
        /// </summary>
        public string FileName => Path.GetFileName(FilePath);

        /// <summary>
        /// Gets the current file extension including the dot.
        /// </summary>
        public string FileExtension => Path.GetExtension(FilePath);

        /// <summary>
        /// Adds a new supported file format.
        /// </summary>
        /// <param name="extension">The extension of the file format without the dot.</param>
        /// <param name="description">The file format description to show in the file dialogs.</param>
        public void AddFileFormat(string extension, string description)
        {
            _saveFileDialog.Filter += $"{description} (*.{extension})|*.{extension}";
            _openFileDialog.Filter += $"{description} (*.{extension})|*.{extension}";
        }

        /// <summary>
        /// Saves the passed file content in the current file, if there is no file the Save file dialog will be shown.
        /// </summary>
        /// <param name="fileContent">The content to save in the file.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool Save(object fileContent) => string.IsNullOrEmpty(FilePath) ? SaveAs(fileContent) : (fileContent?.Equals(FileContent) ?? false) || SaveOperation();

        /// <summary>
        /// Saves the passed file content with a new file name.
        /// </summary>
        /// <param name="fileContent">The content to save in the file.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool SaveAs(object fileContent)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = _saveFileDialog.FileName;
                FileContent = fileContent;
                return SaveOperation();
            }

            return false;
        }

        /// <summary>
        /// Performs the open opeation showing the file open dialog.
        /// </summary>
        /// <returns>True if the operation is successful.</returns>
        public bool Open()
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = _openFileDialog.FileName;
                FileContent = OpenOperation();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Clears the file parameters for a new file.
        /// </summary>
        public void New()
        {
            FilePath = string.Empty;
            FileContent = null;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="filePath">The new file path.</param>
        protected void SetFileName(string filePath) => FilePath = filePath;

        /// <summary>
        /// Executes the 'Save' operation for the specific file format.
        /// </summary>
        /// <returns>True if the operation was successful.</returns>
        protected abstract bool SaveOperation();

        /// <summary>
        /// Executes the 'Open' operation for the specific file format.
        /// </summary>
        /// <returns>The file contents, or null if the operation fails.</returns>
        protected abstract object? OpenOperation();

        /// <summary>
        /// Executes the 'Save' operation for the specific file format.
        /// </summary>
        /// <returns>The file contents, or null if the operation fails.</returns>
        protected abstract object? NewOperation();

        /// <summary>
        /// The bulk of the clean-up code is implemented in Dispose(bool).
        /// </summary>
        /// <param name="disposing">Indicates if contained resources are disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                // Free managed resources
                _saveFileDialog.Dispose();
                _openFileDialog.Dispose();
            }

            _isDisposed = true;
        }
    }
}
