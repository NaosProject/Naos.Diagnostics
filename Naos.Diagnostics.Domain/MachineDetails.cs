// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineDetails.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Model to contain details about a machine.
    /// </summary>
    public class MachineDetails
    {
        /// <summary>
        /// Gets or sets a map of the kind of machine name to the machine name.
        /// </summary>
        public IReadOnlyDictionary<string, string> MachineNameKindToNameMap { get; set; }

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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Gb", Justification = "Spelling/name is correct.")]
        public decimal TotalPhysicalMemoryInGb { get; set; }

        /// <summary>
        /// Gets or sets the total virtual memory (in gigabytes).
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Gb", Justification = "Spelling/name is correct.")]
        public decimal TotalVirtualMemoryInGb { get; set; }
    }
}
