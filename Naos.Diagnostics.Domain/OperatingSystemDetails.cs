// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperatingSystemDetails.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;
    using OBeautifulCode.Math.Recipes;
    using OBeautifulCode.Validation.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Model to hold details about an operating system.
    /// </summary>
    public class OperatingSystemDetails : IEquatable<OperatingSystemDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatingSystemDetails"/> class.
        /// </summary>
        /// <param name="name">Name of OS.</param>
        /// <param name="version">Version of OS.</param>
        /// <param name="servicePack">Service pack of OS.</param>
        public OperatingSystemDetails(string name, string version, string servicePack)
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
        public string Version { get; private set; }

        /// <summary>
        /// Gets the service pack.
        /// </summary>
        public string ServicePack { get; private set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var result = Invariant($"OS - Name: {this.Name}; Version: {this.Version ?? "<null>"}; Service Pack: {this.ServicePack ?? "<null>"}.");
            return result;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="first">First parameter.</param>
        /// <param name="second">Second parameter.</param>
        /// <returns>A value indicating whether or not the two items are equal.</returns>
        public static bool operator ==(OperatingSystemDetails first, OperatingSystemDetails second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }

            var result = string.Equals(first.Name, second.Name, StringComparison.OrdinalIgnoreCase) &&
                         string.Equals(first.Version, second.Version, StringComparison.OrdinalIgnoreCase) &&
                         string.Equals(first.ServicePack, second.ServicePack, StringComparison.OrdinalIgnoreCase);

            return result;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="first">First parameter.</param>
        /// <param name="second">Second parameter.</param>
        /// <returns>A value indicating whether or not the two items are inequal.</returns>
        public static bool operator !=(OperatingSystemDetails first, OperatingSystemDetails second) => !(first == second);

        /// <inheritdoc />
        public bool Equals(OperatingSystemDetails other) => this == other;

        /// <inheritdoc />
        public override bool Equals(object obj) => this == (obj as OperatingSystemDetails);

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeHelper.Initialize()
            .Hash(this.Name)
            .Hash(this.Version)
            .Hash(this.ServicePack)
            .Value;
    }
}