// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineDetails.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    using Spritely.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Model to contain details about a machine.
    /// </summary>
    public class MachineDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MachineDetails"/> class.
        /// </summary>
        /// <param name="machineNameKindToNameMap">Map of the kind of machine name to the machine name.</param>
        /// <param name="processorCount">Processor count (will include virtual).</param>
        /// <param name="memoryKindToValueInGbMap">Map of the kind of memory to the value in gigabytes.</param>
        /// <param name="operatingSystemIs64Bit">A value indicating whether or not the operating system is 64bit.</param>
        /// <param name="operatingSystem">Operating system of the machine.</param>
        /// <param name="clrVersion">Common language runtime installed on machine.</param>
        public MachineDetails(
            IReadOnlyDictionary<string, string> machineNameKindToNameMap,
            int processorCount,
            IReadOnlyDictionary<string, decimal> memoryKindToValueInGbMap,
            bool operatingSystemIs64Bit,
            OperatingSystemDetails operatingSystem,
            string clrVersion)
        {
            new { machineNameKindToNameMap }.Must().NotBeNull().And().NotBeEmptyEnumerable<KeyValuePair<string, string>>().OrThrowFirstFailure();

            this.MachineNameKindToNameMap = machineNameKindToNameMap;
            this.ProcessorCount = processorCount;
            this.MemoryKindToValueInGbMap = memoryKindToValueInGbMap ?? new Dictionary<string, decimal>();
            this.OperatingSystemIs64Bit = operatingSystemIs64Bit;
            this.OperatingSystem = operatingSystem;
            this.ClrVersion = clrVersion;
        }

        /// <summary>
        /// Gets a map of the kind of machine name to the machine name.
        /// </summary>
        public IReadOnlyDictionary<string, string> MachineNameKindToNameMap { get; private set; }

        /// <summary>
        /// Gets the processor count (will include virtual).
        /// </summary>
        public int ProcessorCount { get; private set; }

        /// <summary>
        /// Gets a map of the kind of memory to the value in gigabytes.
        /// </summary>
        public IReadOnlyDictionary<string, decimal> MemoryKindToValueInGbMap { get; private set; }

        /// <summary>
        /// Gets a value indicating whether or not the operating system is 64bit.
        /// </summary>
        public bool OperatingSystemIs64Bit { get; private set; }

        /// <summary>
        /// Gets the operating system of the machine.
        /// </summary>
        public OperatingSystemDetails OperatingSystem { get; private set; }

        /// <summary>
        /// Gets the common language runtime installed on version.
        /// </summary>
        public string ClrVersion { get; private set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var result = Invariant($"{nameof(MachineDetails)} - Names: {string.Join(",", this.MachineNameKindToNameMap.Select(_ => _.Key + "=" + _.Value))}.");
            return result;
        }
    }
}
