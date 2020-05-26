// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializationConfigurationTypes.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using Naos.Diagnostics.Serialization.Bson;
    using Naos.Diagnostics.Serialization.Json;
    using OBeautifulCode.Serialization.Bson;
    using OBeautifulCode.Serialization.Json;

    public static class SerializationConfigurationTypes
    {
        public static BsonSerializationConfigurationType BsonConfigurationType => typeof(DiagnosticsBsonSerializationConfiguration).ToBsonSerializationConfigurationType();

        public static JsonSerializationConfigurationType JsonConfigurationType => typeof(DiagnosticsJsonSerializationConfiguration).ToJsonSerializationConfigurationType();
    }
}
