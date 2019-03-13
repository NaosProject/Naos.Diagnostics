// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainFactoryTests.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using FakeItEasy;

    using FluentAssertions;

    using Naos.Diagnostics.Recipes;
    using Naos.Serialization.Domain;
    using Naos.Serialization.Json;

    using Xunit;

    public static class DomainFactoryTests
    {
        private static readonly IStringSerializeAndDeserialize Serializer = new NaosJsonSerializer();

        [Fact]
        public static void Model_Recipe_conversions___Roundtrip()
        {
            // Arrange
            var inputDescription = new PerformanceCounterDescription(A.Dummy<string>(), A.Dummy<string>(), A.Dummy<string>(), A.Dummy<float>(), A.Dummy<float>());
            var inputSample = new PerformanceCounterSample(inputDescription, A.Dummy<float>());

            // Act
            var actualDescription = inputDescription.ToRecipe().ToModel().FromModel().FromRecipe();
            var actualSample = inputSample.ToRecipe().ToModel().FromModel().FromRecipe();

            // Assert
            actualDescription.Should().BeOfType(inputDescription.GetType());
            actualSample.Should().BeOfType(inputSample.GetType());

            var inputDescriptionJson = Serializer.SerializeToString(inputDescription);
            var actualDescriptionJson = Serializer.SerializeToString(actualDescription);
            actualDescriptionJson.Should().Be(inputDescriptionJson);

            var inputSampleJson = Serializer.SerializeToString(inputSample);
            var actualSampleJson = Serializer.SerializeToString(actualSample);
            actualSampleJson.Should().Be(inputSampleJson);
        }
    }
}
