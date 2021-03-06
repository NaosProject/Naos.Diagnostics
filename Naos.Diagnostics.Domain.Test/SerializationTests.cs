﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializationTests.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using System;
    using System.Collections.Generic;
    using FakeItEasy;
    using FluentAssertions;
    using Naos.Diagnostics.Recipes;
    using Naos.Diagnostics.Serialization.Bson;
    using Naos.Diagnostics.Serialization.Json;
    using OBeautifulCode.Serialization;
    using OBeautifulCode.Serialization.Bson;
    using OBeautifulCode.Serialization.Json;
    using Xunit;

    public static class SerializationTests
    {
        private static readonly ObcBsonSerializer BsonSerializer = new ObcBsonSerializer(typeof(DiagnosticsBsonSerializationConfiguration).ToBsonSerializationConfigurationType());
        private static readonly ObcJsonSerializer JsonSerializer = new ObcJsonSerializer(typeof(DiagnosticsJsonSerializationConfiguration).ToJsonSerializationConfigurationType());

        [Fact]
        public static void AssemblyDetails_Roundtrips()
        {
            // Arrange
            var expected = A.Dummy<AssemblyDetails>();

            // Act
            var actualBsonString = BsonSerializer.SerializeToString(expected);
            var actualBson = BsonSerializer.Deserialize<AssemblyDetails>(actualBsonString);
            
            var actualJsonString = JsonSerializer.SerializeToString(expected);
            var actualJson = JsonSerializer.Deserialize<AssemblyDetails>(actualJsonString);

            // Assert
            actualBson.Should().Be(expected);
            actualJson.Should().Be(expected);
        }

        [Fact]
        public static void MachineDetails_Roundtrips()
        {
            // Arrange
            var expected = A.Dummy<MachineDetails>();
            var bsonSerializer = new ObcBsonSerializer(typeof(DiagnosticsBsonSerializationConfiguration).ToBsonSerializationConfigurationType());
            var jsonSerializer = new ObcJsonSerializer(typeof(DiagnosticsJsonSerializationConfiguration).ToJsonSerializationConfigurationType());

            // Act
            var actualBsonString = bsonSerializer.SerializeToString(expected);
            var actualBson = bsonSerializer.Deserialize<MachineDetails>(actualBsonString);
            
            var actualJsonString = jsonSerializer.SerializeToString(expected);
            var actualJson = jsonSerializer.Deserialize<MachineDetails>(actualJsonString);

            // Assert
            actualBson.Should().Be(expected);
            actualJson.Should().Be(expected);
        }

        [Fact]
        public static void OperatingSystemDetails_Roundtrips()
        {
            // Arrange
            var expected = A.Dummy<OperatingSystemDetails>();
            var bsonSerializer = new ObcBsonSerializer(typeof(DiagnosticsBsonSerializationConfiguration).ToBsonSerializationConfigurationType());
            var jsonSerializer = new ObcJsonSerializer(typeof(DiagnosticsJsonSerializationConfiguration).ToJsonSerializationConfigurationType());

            // Act
            var actualBsonString = bsonSerializer.SerializeToString(expected);
            var actualBson = bsonSerializer.Deserialize<OperatingSystemDetails>(actualBsonString);
            
            var actualJsonString = jsonSerializer.SerializeToString(expected);
            var actualJson = jsonSerializer.Deserialize<OperatingSystemDetails>(actualJsonString);

            // Assert
            actualBson.Should().Be(expected);
            actualJson.Should().Be(expected);
        }

        [Fact]
        public static void ProcessDetails_Roundtrips()
        {
            // Arrange
            var expected = A.Dummy<ProcessDetails>();
            var bsonSerializer = new ObcBsonSerializer(typeof(DiagnosticsBsonSerializationConfiguration).ToBsonSerializationConfigurationType());
            var jsonSerializer = new ObcJsonSerializer(typeof(DiagnosticsJsonSerializationConfiguration).ToJsonSerializationConfigurationType());

            // Act
            var actualBsonString = bsonSerializer.SerializeToString(expected);
            var actualBson = bsonSerializer.Deserialize<ProcessDetails>(actualBsonString);
            
            var actualJsonString = jsonSerializer.SerializeToString(expected);
            var actualJson = jsonSerializer.Deserialize<ProcessDetails>(actualJsonString);

            // Assert
            actualBson.Should().Be(expected);
            actualJson.Should().Be(expected);
        }

        [Fact]
        public static void PerformanceCounterDescription_Roundtrips()
        {
            // Arrange
            var expected = A.Dummy<PerformanceCounterDescription>();
            var bsonSerializer = new ObcBsonSerializer(typeof(DiagnosticsBsonSerializationConfiguration).ToBsonSerializationConfigurationType());
            var jsonSerializer = new ObcJsonSerializer(typeof(DiagnosticsJsonSerializationConfiguration).ToJsonSerializationConfigurationType());

            // Act
            var actualBsonString = bsonSerializer.SerializeToString(expected);
            var actualBson = bsonSerializer.Deserialize<PerformanceCounterDescription>(actualBsonString);
            
            var actualJsonString = jsonSerializer.SerializeToString(expected);
            var actualJson = jsonSerializer.Deserialize<PerformanceCounterDescription>(actualJsonString);

            // Assert
            actualBson.Should().Be(expected);
            actualJson.Should().Be(expected);
        }

        [Fact]
        public static void PerformanceCounterSample_Roundtrips()
        {
            // Arrange
            var expected = A.Dummy<PerformanceCounterSample>();
            var bsonSerializer = new ObcBsonSerializer(typeof(DiagnosticsBsonSerializationConfiguration).ToBsonSerializationConfigurationType());
            var jsonSerializer = new ObcJsonSerializer(typeof(DiagnosticsJsonSerializationConfiguration).ToJsonSerializationConfigurationType());

            // Act
            var actualBsonString = bsonSerializer.SerializeToString(expected);
            var actualBson = bsonSerializer.Deserialize<PerformanceCounterSample>(actualBsonString);
            
            var actualJsonString = jsonSerializer.SerializeToString(expected);
            var actualJson = jsonSerializer.Deserialize<PerformanceCounterSample>(actualJsonString);

            // Assert
            actualBson.Should().Be(expected);
            actualJson.Should().Be(expected);
        }
    }
}
