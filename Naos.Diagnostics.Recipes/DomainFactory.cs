// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainFactory.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;
    using System.Linq;

    using Microsoft.VisualBasic.Devices;

    /// <summary>
    /// Factory methods for domain objects.
    /// </summary>
#if !NaosDiagnosticsRecipes
    [System.CodeDom.Compiler.GeneratedCode("Naos.Diagnostics", "See package version number")]
#endif
    internal class DomainFactory
    {
        /// <summary>
        /// Creates a new <see cref="OperatingSystemDetails"/> from executing context.
        /// </summary>
        /// <returns>New <see cref="OperatingSystemDetails"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "The caller will be the consumer of this recipe.")]
        public static OperatingSystemDetails CreateOperatingSystemDetails()
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
        /// Creates a new <see cref="MachineDetails"/> from executing context.
        /// </summary>
        /// <returns>New <see cref="MachineDetails"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "The caller will be the consumer of this recipe.")]
        public static MachineDetails CreateMachineDetails()
        {
            var operatingSystemDetails = CreateOperatingSystemDetails();

            var frameworks = new[] { new FrameworkDetails { Name = FrameworkDetails.ClrFrameworkName, Version = Environment.Version.ToString() } };

            var memoryInGb = MachineMemory.GetMachineMemoryInGb();

            var report = new MachineDetails
                             {
                                 MachineNameKindToNameMap = MachineName.GetMachineNames().ToDictionary(_ => _.Key.ToString(), _ => _.Value),
                                 IsOperatingSystem64Bit = Environment.Is64BitOperatingSystem,
                                 OperatingSystem = operatingSystemDetails,
                                 ProcessorCount = Environment.ProcessorCount,
                                 Frameworks = frameworks,
                                 TotalPhysicalMemoryInGb = memoryInGb[MachineMemoryKind.TotalPhysical],
                                 TotalVirtualMemoryInGb = memoryInGb[MachineMemoryKind.TotalVirtual],
                             };

            return report;
        }
    }
}