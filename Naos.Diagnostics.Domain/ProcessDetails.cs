// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessDetails.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;
    using OBeautifulCode.Math.Recipes;
    using OBeautifulCode.Validation.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Model that hold details about a process.
    /// </summary>
    public class ProcessDetails : IEquatable<ProcessDetails>
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

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="first">First parameter.</param>
        /// <param name="second">Second parameter.</param>
        /// <returns>A value indicating whether or not the two items are equal.</returns>
        public static bool operator ==(ProcessDetails first, ProcessDetails second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }

            var result = string.Equals(first.Name, second.Name, StringComparison.OrdinalIgnoreCase) &&
                         string.Equals(first.FilePath, second.FilePath, StringComparison.OrdinalIgnoreCase) &&
                         string.Equals(first.FileVersion, second.FileVersion, StringComparison.OrdinalIgnoreCase) &&
                         string.Equals(first.ProductVersion, second.ProductVersion, StringComparison.OrdinalIgnoreCase) &&
                         first.RunningAsAdmin == second.RunningAsAdmin;

            return result;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="first">First parameter.</param>
        /// <param name="second">Second parameter.</param>
        /// <returns>A value indicating whether or not the two items are inequal.</returns>
        public static bool operator !=(ProcessDetails first, ProcessDetails second) => !(first == second);

        /// <inheritdoc />
        public bool Equals(ProcessDetails other) => this == other;

        /// <inheritdoc />
        public override bool Equals(object obj) => this == (obj as ProcessDetails);

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeHelper.Initialize()
            .Hash(this.Name)
            .Hash(this.FilePath)
            .Hash(this.FileVersion)
            .Hash(this.ProductVersion)
            .Hash(this.RunningAsAdmin)
            .Value;
    }
}