// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessDetails.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using OBeautifulCode.Validation.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Model that hold details about a process.
    /// </summary>
    public class ProcessDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessDetails"/> class.
        /// </summary>
        /// <param name="name">Name of the process.</param>
        /// <param name="filePath">File path of the executing file.</param>
        /// <param name="fileVersion">File version of the executing file.</param>
        /// <param name="productVersion">Product version of the executing file.</param>
        /// <param name="runningAsAdmin">A value indicating whether or not the process is running as administrator.</param>
        public ProcessDetails(string name, string filePath, string fileVersion, string productVersion, bool runningAsAdmin)
        {
            new { name }.Must().NotBeNullNorWhiteSpace();

            this.Name = name;
            this.FilePath = filePath;
            this.FileVersion = fileVersion;
            this.ProductVersion = productVersion;
            this.RunningAsAdmin = runningAsAdmin;
        }

        /// <summary>
        /// Gets the name of the process.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the file path of the executing file.
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Gets the file version of the executing file.
        /// </summary>
        public string FileVersion { get; private set; }

        /// <summary>
        /// Gets the product version of the executing file.
        /// </summary>
        public string ProductVersion { get; private set; }

        /// <summary>
        /// Gets a value indicating whether or not the process is running as administrator.
        /// </summary>
        public bool RunningAsAdmin { get; private set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var result = Invariant($"Process - Name: {this.Name}; File Path: {this.FilePath ?? "<null>"}; File Version: {this.FileVersion ?? "<null>"}; Product Version: {this.ProductVersion ?? "<null>"}; Running as Admin: {this.RunningAsAdmin}.");
            return result;
        }
    }
}