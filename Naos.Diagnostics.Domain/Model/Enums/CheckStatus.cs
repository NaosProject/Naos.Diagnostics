// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckStatus.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    /// <summary>
    /// Enumeration of statues for a check result.
    /// </summary>
    public enum CheckStatus
    {
        /// <summary>
        /// Invalid default state.
        /// </summary>
        Invalid,

        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// Success status.
        /// </summary>
        Success,

        /// <summary>
        /// Warning status.
        /// </summary>
        Warning,

        /// <summary>
        /// Failure status.
        /// </summary>
        Failure,
    }
}
