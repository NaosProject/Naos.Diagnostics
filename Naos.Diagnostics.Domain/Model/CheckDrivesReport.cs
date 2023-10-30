// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckDrivesReport.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;
    using System.Collections.Generic;
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Report returned from <see cref="CheckDrivesOp" />.
    /// </summary>
    public partial class CheckDrivesReport : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckDrivesReport"/> class.
        /// </summary>
        /// <param name="shouldAlert">A value indicating whether the the results of the checks should be alerted.</param>
        /// <param name="driveNameToReportMap">The map of drive name to a <see cref="CheckSingleDriveReport" /> map.</param>
        /// <param name="sampleTimeUtc">The time report was sampled in UTC.</param>
        public CheckDrivesReport(
            bool shouldAlert,
            IReadOnlyDictionary<string, CheckSingleDriveReport> driveNameToReportMap,
            DateTime sampleTimeUtc)
        {
            driveNameToReportMap.MustForArg(nameof(driveNameToReportMap)).NotBeNullNorEmptyDictionaryNorContainAnyNullValues();
            sampleTimeUtc.MustForArg(nameof(sampleTimeUtc)).BeUtcDateTime();

            this.ShouldAlert = shouldAlert;
            this.DriveNameToReportMap = driveNameToReportMap;
            this.SampleTimeUtc = sampleTimeUtc;
        }

        /// <summary>
        /// Gets a value indicating whether the the results of the checks should be alerted.
        /// </summary>
        public bool ShouldAlert { get; private set; }

        /// <summary>
        /// Gets a map of drive name sampled to it's individual report.
        /// </summary>
        public IReadOnlyDictionary<string, CheckSingleDriveReport> DriveNameToReportMap { get; private set; }

        /// <summary>
        /// Gets the time report was sampled in UTC.
        /// </summary>
        public DateTime SampleTimeUtc { get; private set; }
    }
}
