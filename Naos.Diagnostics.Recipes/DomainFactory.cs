// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainFactory.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualBasic.Devices;

    using Naos.Diagnostics.Domain;

    /// <summary>
    /// Factory methods for domain objects.
    /// </summary>
#if NaosDiagnosticsRecipes
    public
#else
    [System.CodeDom.Compiler.GeneratedCode("Naos.Diagnostics", "See package version number")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal
#endif
    static class DomainFactory
    {
        /// <summary>
        /// Creates a new <see cref="OperatingSystemDetails"/> from executing context.
        /// </summary>
        /// <returns>New <see cref="OperatingSystemDetails"/>.</returns>
        public static OperatingSystemDetails CreateOperatingSystemDetails()
        {
            // this is only in VisualBasic...
            var computerInfo = new ComputerInfo();
            var servicePack =
                (string.IsNullOrEmpty(Environment.OSVersion.ServicePack) ? "(No Service Packs)" : Environment.OSVersion.ServicePack).Replace(
                    Environment.NewLine,
                    string.Empty);

            return new OperatingSystemDetails(computerInfo.OSFullName, Environment.OSVersion.Version, servicePack);
        }

        /// <summary>
        /// Creates a new <see cref="MachineDetails"/> from executing context.
        /// </summary>
        /// <returns>New <see cref="MachineDetails"/>.</returns>
        public static MachineDetails CreateMachineDetails()
        {
            var operatingSystemDetails = CreateOperatingSystemDetails();

            var memoryInGb = MachineMemory.GetMachineMemoryInGb();

            var report = new MachineDetails(
                MachineName.GetMachineNames().ToDictionary(_ => _.Key.ToString(), _ => _.Value),
                Environment.ProcessorCount,
                memoryInGb.ToDictionary(_ => _.Key.ToString(), _ => _.Value),
                Environment.Is64BitOperatingSystem,
                operatingSystemDetails,
                Environment.Version.ToString());

            return report;
        }

        /// <summary>
        /// Creates a new <see cref="ProcessDetails" /> from the executing context.
        /// </summary>
        /// <returns>New <see cref="ProcessDetails" />.</returns>
        public static ProcessDetails CreateProcessDetails()
        {
            var process = ProcessHelpers.GetRunningProcess();
            var result = new ProcessDetails(
                process.GetName(),
                process.GetFilePath(),
                process.GetFileVersion(),
                process.GetProductVersion(),
                ProcessHelpers.IsCurrentlyRunningAsAdmin());

            return result;
        }

        /// <summary>
        /// Extracts the correctly typed dictionary using the <see cref="MachineNameKind" /> key from <see cref="MachineDetails" />.
        /// </summary>
        /// <param name="machineDetails">Machine details to use.</param>
        /// <returns>Typed dictionary.</returns>
        public static IReadOnlyDictionary<MachineNameKind, string> GetTypedMachineNameKindToNameMap(this MachineDetails machineDetails)
        {
            var result = machineDetails.MachineNameKindToNameMap.ToDictionary(
                k => (MachineNameKind)Enum.Parse(typeof(MachineNameKind), k.Key),
                v => v.Value);

            return result;
        }

        /// <summary>
        /// Extracts the correctly typed dictionary using the <see cref="MachineMemoryKind" /> key from <see cref="MachineDetails" />.
        /// </summary>
        /// <param name="machineDetails">Machine details to use.</param>
        /// <returns>Typed dictionary.</returns>
        public static IReadOnlyDictionary<MachineMemoryKind, decimal> GetTypedMemoryKindToValueInGbMap(this MachineDetails machineDetails)
        {
            var result = machineDetails.MemoryKindToValueInGbMap.ToDictionary(
                k => (MachineMemoryKind)Enum.Parse(typeof(MachineMemoryKind), k.Key),
                v => v.Value);

            return result;
        }
    }
}