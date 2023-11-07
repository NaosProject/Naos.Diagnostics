// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckStatusExtensions.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Logic for use with <see cref="CheckStatus" />.
    /// </summary>
    public static class CheckStatusExtensions
    {
        /// <summary>
        /// Reduces a set of <see cref="CheckStatus" /> to single status.
        /// </summary>
        /// <param name="statusesToReduce">The statuses to reduce.</param>
        /// <returns>Reduced CheckStatus.</returns>
        public static CheckStatus ReduceToSingleStatus(
            this IReadOnlyCollection<CheckStatus> statusesToReduce)
        {
            if (statusesToReduce.Any(_ => _ == CheckStatus.Invalid))
            {
                return CheckStatus.Invalid;
            }

            if (statusesToReduce.Any(_ => _ == CheckStatus.Failure))
            {
                return CheckStatus.Failure;
            }

            if (statusesToReduce.Any(_ => _ == CheckStatus.Warning))
            {
                return CheckStatus.Warning;
            }

            if (statusesToReduce.Any(_ => _ == CheckStatus.Unknown))
            {
                return CheckStatus.Unknown;
            }

            if (statusesToReduce.All(_ => _ == CheckStatus.Success))
            {
                return CheckStatus.Success;
            }

            return CheckStatus.Invalid;
        }
    }
}
