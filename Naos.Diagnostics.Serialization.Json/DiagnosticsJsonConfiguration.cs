// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticsJsonConfiguration.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Serialization.Json
{
    using System;
    using System.Collections.Generic;
    using Naos.Diagnostics;
    using Naos.Diagnostics.Domain;
    using Naos.Serialization.Json;

    /// <summary>
    /// Implementation for the <see cref="Diagnostics" /> domain.
    /// </summary>
    public class DiagnosticsJsonConfiguration : JsonConfigurationBase
    {
        /// <inheritdoc />
        protected override IReadOnlyCollection<Type> TypesToAutoRegister => new[]
        {
            typeof(AssemblyDetails),
            typeof(MachineDetails),
            typeof(OperatingSystemDetails),
            typeof(PerformanceCounterDescription),
            typeof(PerformanceCounterSample),
            typeof(ProcessDetails),
        };
    }
}
