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
    public partial class CheckDrivesReport : IHaveCheckStatus, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckDrivesReport"/> class.
        /// </summary>
        /// <param name="status">Evaluated check status.</param>
        /// <param name="driveNameToReportMap">The map of drive name to a <see cref="CheckSingleDriveReport" /> map.</param>
        /// <param name="operationUsed">The operation used to create the report.</param>
        /// <param name="sampleTimeUtc">The time report was sampled in UTC.</param>
        public CheckDrivesReport(
            CheckStatus status,
            IReadOnlyDictionary<string, CheckSingleDriveReport> driveNameToReportMap,
            CheckDrivesOp operationUsed,
            DateTime sampleTimeUtc)
        {
            status.MustForArg(nameof(status)).NotBeEqualTo(CheckStatus.Invalid);
            driveNameToReportMap.MustForArg(nameof(driveNameToReportMap)).NotBeNullNorEmptyDictionaryNorContainAnyNullValues();
            operationUsed.MustForArg(nameof(operationUsed)).NotBeNull();
            sampleTimeUtc.MustForArg(nameof(sampleTimeUtc)).BeUtcDateTime();

            this.Status = status;
            this.DriveNameToReportMap = driveNameToReportMap;
            this.OperationUsed = operationUsed;
            this.SampleTimeUtc = sampleTimeUtc;
        }

        /// <inheritdoc />
        public CheckStatus Status { get; private set; }

        /// <summary>
        /// Gets a map of drive name sampled to it's individual report.
        /// </summary>
        public IReadOnlyDictionary<string, CheckSingleDriveReport> DriveNameToReportMap { get; private set; }

        /// <summary>
        /// Gets the operation used to create the report.
        /// </summary>
        public CheckDrivesOp OperationUsed { get; private set; }

        /// <summary>
        /// Gets the time report was sampled in UTC.
        /// </summary>
        public DateTime SampleTimeUtc { get; private set; }
    }
}
