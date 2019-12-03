// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticsBsonConfiguration.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Serialization.Bson
{
    using System;
    using System.Collections.Generic;
    using Naos.Diagnostics.Domain;
    using OBeautifulCode.Serialization.Bson;

    /// <summary>
    /// Implementation for the <see cref="Diagnostics" /> domain.
    /// </summary>
    public class DiagnosticsBsonConfiguration : BsonConfigurationBase
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
