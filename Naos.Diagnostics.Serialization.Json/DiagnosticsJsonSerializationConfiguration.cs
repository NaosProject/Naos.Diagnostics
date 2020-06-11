// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticsJsonSerializationConfiguration.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Serialization.Json
{
    using System.Collections.Generic;
    using Naos.Diagnostics.Domain;
    using OBeautifulCode.Serialization.Json;

    /// <summary>
    /// Implementation for the <see cref="Diagnostics" /> domain.
    /// </summary>
    public class DiagnosticsJsonSerializationConfiguration : JsonSerializationConfigurationBase
    {
        /// <inheritdoc />
        protected override IReadOnlyCollection<string> TypeToRegisterNamespacePrefixFilters => new[]
                                                                                               {
                                                                                                   typeof(AssemblyDetails).Namespace,
                                                                                               };

        /// <inheritdoc />
        protected override IReadOnlyCollection<TypeToRegisterForJson> TypesToRegisterForJson => new[]
        {
            typeof(AssemblyDetails).ToTypeToRegisterForJson(),
            typeof(MachineDetails).ToTypeToRegisterForJson(),
            typeof(OperatingSystemDetails).ToTypeToRegisterForJson(),
            typeof(PerformanceCounterDescription).ToTypeToRegisterForJson(),
            typeof(PerformanceCounterSample).ToTypeToRegisterForJson(),
            typeof(ProcessDetails).ToTypeToRegisterForJson(),
        };
    }
}
