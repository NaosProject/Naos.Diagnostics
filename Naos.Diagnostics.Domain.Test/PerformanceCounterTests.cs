﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceCounterTests.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using System.Linq;
    using FakeItEasy;
    using FluentAssertions;
    using FluentAssertions.Common;
    using Naos.Diagnostics.Recipes;
    using OBeautifulCode.Reflection.Recipes;
    using OBeautifulCode.Serialization;
    using OBeautifulCode.Serialization.Json;
    using Xunit;

    public static class PerformanceCounterTests
    {
        private static readonly IStringSerializeAndDeserialize Serializer = new ObcJsonSerializer();

        [Fact]
        public static void CommonCounters___Includes_all_declared()
        {
            // Arrange & Act
            var common = PerformanceCounterLibrary.CommonCounters;
            var type = typeof(PerformanceCounterLibrary);
            var publics = type.GetPropertiesFiltered(MemberRelationships.DeclaredInType)
                              .Where(_ => _.Name != nameof(PerformanceCounterLibrary.CommonCounters))
                              .Select(_ => _.GetValue(null))
                              .ToList();

            // Assert
            var actualCommon = Serializer.SerializeToString(common);
            var actualPublics = Serializer.SerializeToString(publics);
            actualPublics.Should().Be(actualCommon);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "andin", Justification = "Name is correct.")]
        [Fact]
        public static void IsInRange___When_range_provided_and_in_range___Gets_true_serialized_to_json()
        {
            // Arrange
            var description = new PerformanceCounterDescription(A.Dummy<string>(), A.Dummy<string>(), A.Dummy<string>(), 5, 15);
            var sample = new PerformanceCounterSample(description, 10);

            // Act
            var json = Serializer.SerializeToString(sample);

            // Assert
            json.Should().Contain("\"inRange\": true");
        }

        [Fact]
        public static void IsInRange___When_range_provided_and_not_in_range___Gets_false_serialized_to_json()
        {
            // Arrange
            var description = new PerformanceCounterDescription(A.Dummy<string>(), A.Dummy<string>(), A.Dummy<string>(), 20, 30);
            var sample = new PerformanceCounterSample(description, 10);

            // Act
            var json = Serializer.SerializeToString(sample);

            // Assert
            json.Should().Contain("\"inRange\": false");
        }

        [Fact]
        public static void IsInRange___When_range_not_provided___Gets_null_serialized_to_json()
        {
            // Arrange
            var description = new PerformanceCounterDescription(A.Dummy<string>(), A.Dummy<string>(), A.Dummy<string>());
            var sample = new PerformanceCounterSample(description, 10);

            // Act
            var json = Serializer.SerializeToString(sample);

            // Assert
            json.Should().Contain("\"inRange\": null");
        }
    }
}
