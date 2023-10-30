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
        /// <param name="threshold">The threshold percentage (as decimal) of free space to alert on; e.g. 0.2 will alert when free space is less than 20%.</param>
        public CheckDrivesOp(
            decimal threshold)
        {
            threshold.MustForArg(nameof(threshold)).BeInRange(0m, 1m);

            this.Threshold = threshold;
        }

        /// <summary>
        /// Gets the threshold percentage (as decimal) of free space to alert on; e.g. 0.2 will alert when free space is less than 20%..
        /// </summary>
        public decimal Threshold { get; private set; }
    }
}
