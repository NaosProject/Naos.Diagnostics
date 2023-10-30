// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticsBsonSerializationConfiguration.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Serialization.Bson
{
    using System.Collections.Generic;
    using Naos.Diagnostics.Domain;
    using OBeautifulCode.Serialization.Bson;

    /// <summary>
    /// Implementation for the <see cref="Diagnostics" /> domain.
    /// </summary>
    public class DiagnosticsBsonSerializationConfiguration : BsonSerializationConfigurationBase
    {
        /// <inheritdoc />
        protected override IReadOnlyCollection<string> TypeToRegisterNamespacePrefixFilters => new[]
                                                                                               {
                                                                                                   typeof(AssemblyDetails).Namespace,
                                                                                               };

        /// <inheritdoc />
        protected override IReadOnlyCollection<TypeToRegisterForBson> TypesToRegisterForBson => new[]
        {
            typeof(AssemblyDetails).ToTypeToRegisterForBson(),
            typeof(CheckDrivesOp).ToTypeToRegisterForBson(),
            typeof(CheckDrivesReport).ToTypeToRegisterForBson(),
            typeof(CheckSingleDriveReport).ToTypeToRegisterForBson(),
            typeof(MachineDetails).ToTypeToRegisterForBson(),
            typeof(OperatingSystemDetails).ToTypeToRegisterForBson(),
            typeof(PerformDefaultDiagnosticChecksOp).ToTypeToRegisterForBson(),
            typeof(PerformanceCounterDescription).ToTypeToRegisterForBson(),
            typeof(PerformanceCounterSample).ToTypeToRegisterForBson(),
            typeof(ProcessDetails).ToTypeToRegisterForBson(),
        };
    }
}
