// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperatingSystemDetails.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;

    using OBeautifulCode.Validation.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Model to hold details about an operating system.
    /// </summary>
    public class OperatingSystemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatingSystemDetails"/> class.
        /// </summary>
        /// <param name="name">Name of OS.</param>
        /// <param name="version">Version of OS.</param>
        /// <param name="servicePack">Service pack of OS.</param>
        public OperatingSystemDetails(string name, Version version, string servicePack)
        {
            new { name }.Must().NotBeNullNorWhiteSpace();

            this.Name = name;
            this.Version = version;
            this.ServicePack = servicePack;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        public Version Version { get; private set; }

        /// <summary>
        /// Gets the service pack.
        /// </summary>
        public string ServicePack { get; private set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var result = Invariant($"OS - Name: {this.Name}; Version: {this.Version?.ToString() ?? "<null>"}; Service Pack: {this.ServicePack ?? "<null>"}.");
            return result;
        }
    }
}