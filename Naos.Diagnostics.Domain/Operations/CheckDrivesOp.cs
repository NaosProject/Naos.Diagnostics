// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckDrivesOp.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Operation to evaluate drives on a machine.
    /// </summary>
    public partial class CheckDrivesOp : ReturningOperationBase<CheckDrivesReport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckDrivesOp"/> class.
        /// </summary>
        /// <param name="failureThreshold">The threshold percentage (as decimal) of free space to consider a failure; e.g. 0.2 will alert when free space is less than 20%.</param>
        /// <param name="warningThreshold">The optional threshold percentage (as decimal) of free space to consider a warning; e.g. 0.2 will alert when free space is less than 20%; DEFAULT is 0.</param>
        public CheckDrivesOp(
            decimal failureThreshold,
            decimal warningThreshold = 0)
        {
            failureThreshold.MustForArg(nameof(failureThreshold)).BeInRange(0m, 1m);
            warningThreshold.MustForArg(nameof(warningThreshold)).BeInRange(0m, 1m);

            this.FailureThreshold = failureThreshold;
            this.WarningThreshold = warningThreshold;
        }

        /// <summary>
        /// Gets the threshold percentage (as decimal) of free space to consider a failure; e.g. 0.2 will alert when free space is less than 20%..
        /// </summary>
        public decimal FailureThreshold { get; private set; }

        /// <summary>
        /// Gets the threshold percentage (as decimal) of free space to consider a warning; e.g. 0.2 will alert when free space is less than 20%..
        /// </summary>
        public decimal WarningThreshold { get; private set; }
    }
}
