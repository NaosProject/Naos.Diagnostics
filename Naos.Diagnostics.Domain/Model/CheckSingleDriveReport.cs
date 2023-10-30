// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckSingleDriveReport.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Report of a specific drive.
    /// </summary>
    public partial class CheckSingleDriveReport : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckSingleDriveReport"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="totalFreeSpaceInBytes">The total free space in bytes.</param>
        /// <param name="totalSizeInBytes">The total size in bytes.</param>
        public CheckSingleDriveReport(string name, long totalFreeSpaceInBytes, long totalSizeInBytes)
        {
            name.MustForArg(nameof(name)).NotBeNullNorWhiteSpace();
            totalFreeSpaceInBytes.MustForArg(nameof(totalFreeSpaceInBytes)).BeGreaterThanOrEqualTo(0L);
            totalSizeInBytes.MustForArg(nameof(totalSizeInBytes)).BeGreaterThanOrEqualTo(0L);
            totalFreeSpaceInBytes.MustForArg(nameof(totalFreeSpaceInBytes)).BeLessThanOrEqualTo(totalSizeInBytes);

            this.Name = name;
            this.TotalFreeSpaceInBytes = totalFreeSpaceInBytes;
            this.TotalSizeInBytes = totalSizeInBytes;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the total free space in bytes.
        /// </summary>
        public long TotalFreeSpaceInBytes { get; private set; }

        /// <summary>
        /// Gets the total size in bytes.
        /// </summary>
        public long TotalSizeInBytes { get; private set; }
    }
}
