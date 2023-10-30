// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckDrivesProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Protocol
{
    using System;
    using System.IO;
    using System.Linq;
    using Naos.Diagnostics.Domain;
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Protocol to execute <see cref="CheckDrivesOp" />.
    /// </summary>
    public class CheckDrivesProtocol : SyncSpecificReturningProtocolBase<CheckDrivesOp, CheckDrivesReport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckDrivesProtocol"/> class.
        /// </summary>
        /// <param name="getUtcNow">Function to get the sampling time; allows for a single time to be used in multiple protocols.</param>
        public CheckDrivesProtocol(
            Func<DateTime> getUtcNow)
        {
            getUtcNow.MustForArg(nameof(getUtcNow)).NotBeNull();
            this.GetUtcNow = getUtcNow;
        }

        /// <summary>
        /// Gets or sets the function to get the sampling time; allows for a single time to be used in multiple protocols.
        /// </summary>
        public Func<DateTime> GetUtcNow { get; set; }

        /// <inheritdoc />
        public override CheckDrivesReport Execute(
            CheckDrivesOp operation)
        {
            operation.MustForArg(nameof(operation)).NotBeNull();

            var utcNow = this.GetUtcNow();
            var shouldAlert = false;
            var drives = DriveInfo.GetDrives();
            var driveToReportMap = drives.Where(_ => _.IsReady)
                                         .ToDictionary(
                                              k => k.Name,
                                              v => new CheckSingleDriveReport(v.Name, v.TotalFreeSpace, v.TotalSize));

            if (driveToReportMap.Values.Any(_ => ((decimal)_.TotalFreeSpaceInBytes / (decimal)_.TotalSizeInBytes) < operation.Threshold))
            {
                shouldAlert = true;
            }

            var result = new CheckDrivesReport(shouldAlert, driveToReportMap, utcNow);
            return result;
        }
    }
}