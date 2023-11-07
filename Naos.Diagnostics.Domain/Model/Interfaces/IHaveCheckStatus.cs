// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHaveCheckStatus.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    /// <summary>
    /// Interface to expose <see cref="CheckStatus" /> property.
    /// </summary>
    public interface IHaveCheckStatus
    {
        /// <summary>
        /// Gets the evaluated check status.
        /// </summary>
        CheckStatus Status { get; }
    }
}
