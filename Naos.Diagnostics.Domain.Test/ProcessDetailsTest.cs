// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessDetailsTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using FakeItEasy;

    using FluentAssertions;

    using Naos.Diagnostics.Recipes;

    using Xunit;

    public static class ProcessDetailsTest
    {
        [Fact]
        public static void ToString___Should_be_useful()
        {
            // Arrange
            var name = A.Dummy<string>();
            var filePath = A.Dummy<string>();
            var fileVersion = A.Dummy<string>();
            var productVersion = A.Dummy<string>();

            var systemUnderTest = new ProcessDetails(name, filePath, fileVersion, productVersion, true);

            // Act
            var actualToString = systemUnderTest.ToString();

            // Assert
            actualToString.Should().Contain(name);
            actualToString.Should().Contain(filePath);
            actualToString.Should().Contain(fileVersion);
            actualToString.Should().Contain(productVersion);
        }

        [Fact]
        public static void TestCreate()
        {
            // Arrange & Act
            var details = DomainFactory.CreateProcessDetails();

            // Assert
            details.Should().NotBeNull();
        }
    }
}