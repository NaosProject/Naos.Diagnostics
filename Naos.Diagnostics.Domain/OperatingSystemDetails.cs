// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperatingSystemDetails.cs" company="Naos">
//   Copyright 2015 Naos
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;

    using Microsoft.VisualBasic.Devices;

    /// <summary>
    /// Model to hold details about an operating system.
    /// </summary>
    public class OperatingSystemDetails
    {
        /// <summary>
        /// Creates a new <see cref="OperatingSystemDetails"/> from executing context.
        /// </summary>
        /// <returns>New <see cref="OperatingSystemDetails"/>.</returns>
        public static OperatingSystemDetails Create()
        {
            // this is only in VisualBasic...
            var computerInfo = new ComputerInfo();
            var servicePack =
                (string.IsNullOrEmpty(Environment.OSVersion.ServicePack) ? "(No Service Packs)" : Environment.OSVersion.ServicePack).Replace(
                    Environment.NewLine,
                    string.Empty);

            return new OperatingSystemDetails { Name = computerInfo.OSFullName, Version = Environment.OSVersion.Version, ServicePack = servicePack };
        }

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
            var ret = string.Format("OS; Name: {0}, Version: {1}, Service Pack: {2}", this.Name, this.Version, this.ServicePack);
            return ret;
        }
    }
}