// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperatingSystemDetails.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;

    using static System.FormattableString;

    /// <summary>
    /// Model to hold details about an operating system.
    /// </summary>
    public class OperatingSystemDetails
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public Version Version { get; set; }

        /// <summary>
        /// Gets or sets the service pack.
        /// </summary>
        public string ServicePack { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var ret = Invariant($"OS; Name: {this.Name}, Version: {this.Version}, Service Pack: {this.ServicePack}");
            return ret;
        }
    }
}