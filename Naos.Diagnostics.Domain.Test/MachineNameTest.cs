// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineNameTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using System.Linq;

    using FluentAssertions;

    using Naos.Diagnostics.Recipes;

    using OBeautifulCode.Collection.Recipes;
    using OBeautifulCode.Enum.Recipes;

    using Xunit;

    public static class MachineNameTest
    {
        [Fact]
        public static void GetMachineName___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = MachineName.GetMachineName();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public static void GetNetBiosName___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = MachineName.GetNetBiosName();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public static void GetFullyQualifiedDomainName___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = MachineName.GetFullyQualifiedDomainName();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public static void GetResolvedLocalhostName___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = MachineName.GetResolvedLocalhostName();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public static void GetMachineNames___Should_not_return_a_machine_name_for_all_MachineNameKind_that_is_not_null_or_white_space___When_called()
        {
            // arrange
            var machineNameKinds = EnumExtensions.GetEnumValues<MachineNameKind>();

            // act
            var actual = MachineName.GetMachineNames();

            // assert
            actual.Keys.SymmetricDifference(machineNameKinds).Any().Should().BeFalse();
            actual.Values.Any(string.IsNullOrWhiteSpace).Should().BeFalse();
        }
    }
}
