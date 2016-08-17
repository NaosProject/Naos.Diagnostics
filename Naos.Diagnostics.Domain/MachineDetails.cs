// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineDetails.cs" company="Naos">
//   Copyright 2015 Naos
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualBasic.Devices;

    /// <summary>
    /// Model to contain details about a machine.
    /// </summary>
    public class MachineDetails
    {
        private const decimal DivideByToGetGb = 1024m / 1024m / 1024m;

        /// <summary>
        /// Interrogates machine for available physical memory in gigabytes.
        /// </summary>
        /// <returns>Number of gigabytes of available physical memory.</returns>
        public static decimal GetAvailablePhysicalMemoryInGb()
        {
            // this is only in VisualBasic...
            var computerInfo = new ComputerInfo();

            return computerInfo.AvailablePhysicalMemory / DivideByToGetGb;
        }

        /// <summary>
        /// Creates a new <see cref="MachineDetails"/> from executing context.
        /// </summary>
        /// <returns>New <see cref="MachineDetails"/>.</returns>
        public static MachineDetails Create()
        {
            // this is only in VisualBasic...
            var computerInfo = new ComputerInfo();

            var operatingSystemDetails = OperatingSystemDetails.Create();

            var frameworks = new[] { new FrameworkDetails { Name = FrameworkDetails.ClrFrameworkName, Version = Environment.Version.ToString() } };

            var machineName = Environment.MachineName; // this could be truncated to be compliant with old networks
            var hostName = System.Net.Dns.GetHostName(); // this should be the full 'machine name'

            var report = new MachineDetails
            {
                MachineName = machineName,
                HostName = hostName,
                IsOperatingSystem64Bit = Environment.Is64BitOperatingSystem,
                OperatingSystem = operatingSystemDetails,
                ProcessorCount = Environment.ProcessorCount,
                Frameworks = frameworks,
                TotalPhysicalMemoryInGb = computerInfo.TotalPhysicalMemory / DivideByToGetGb,
            };

            return report;
        }

        /// <summary>
        /// Gets or sets the host name (System.Net.Dns.GetHostName() - should be the full 'machine name').
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the machine name (Environment.MachineName - could be truncated to be compliant with old networks).
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the operating system is 64bit.
        /// </summary>
        public bool IsOperatingSystem64Bit { get; set; }

        /// <summary>
        /// Gets or sets the processor count (will include virtual).
        /// </summary>
        public int ProcessorCount { get; set; }

        /// <summary>
        /// Gets or sets the frameworks installed on machine.
        /// </summary>
        public IReadOnlyCollection<FrameworkDetails> Frameworks { get; set; } 

        /// <summary>
        /// Gets or sets the operation system of the machine.
        /// </summary>
        public OperatingSystemDetails OperatingSystem { get; set; }

        /// <summary>
        /// Gets or sets the total physical memory (in gigabytes).
        /// </summary>
        public decimal TotalPhysicalMemoryInGb { get; set; }
    }
}
