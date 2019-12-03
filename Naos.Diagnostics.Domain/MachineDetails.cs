// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineDetails.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Collection.Recipes;
    using OBeautifulCode.Equality.Recipes;
    using static System.FormattableString;

    /// <summary>
    /// Model to contain details about a machine.
    /// </summary>
    public class MachineDetails : IEquatable<MachineDetails>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Gb", Justification = "Name/spelling is correct.")]
        public MachineDetails(
            IReadOnlyDictionary<string, string> machineNameKindToNameMap,
            int processorCount,
            IReadOnlyDictionary<string, decimal> memoryKindToValueInGbMap,
            bool operatingSystemIs64Bit,
            OperatingSystemDetails operatingSystem,
            string clrVersion)
        {
            new { machineNameKindToNameMap }.AsArg().Must().NotBeNull().And().NotBeEmptyEnumerable();

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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Gb", Justification = "Name/spelling is correct.")]
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

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="first">First parameter.</param>
        /// <param name="second">Second parameter.</param>
        /// <returns>A value indicating whether or not the two items are equal.</returns>
        public static bool operator ==(MachineDetails first, MachineDetails second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }

            var result = first.MachineNameKindToNameMap.IsEqualTo(second.MachineNameKindToNameMap) &&
                             first.ProcessorCount == second.ProcessorCount &&
                             first.MemoryKindToValueInGbMap.IsEqualTo(second.MemoryKindToValueInGbMap) &&
                             first.OperatingSystemIs64Bit == second.OperatingSystemIs64Bit &&
                             first.OperatingSystem == second.OperatingSystem &&
                             string.Equals(first.ClrVersion, second.ClrVersion, StringComparison.OrdinalIgnoreCase);

            return result;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="first">First parameter.</param>
        /// <param name="second">Second parameter.</param>
        /// <returns>A value indicating whether or not the two items are inequal.</returns>
        public static bool operator !=(MachineDetails first, MachineDetails second) => !(first == second);

        /// <inheritdoc />
        public bool Equals(MachineDetails other) => this == other;

        /// <inheritdoc />
        public override bool Equals(object obj) => this == (obj as MachineDetails);

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeHelper.Initialize()
            .Hash(this.MachineNameKindToNameMap)
            .Hash(this.ProcessorCount)
            .Hash(this.MemoryKindToValueInGbMap)
            .Hash(this.OperatingSystemIs64Bit)
            .Hash(this.OperatingSystem)
            .Hash(this.ClrVersion)
            .Value;
    }
}
