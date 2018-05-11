// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineDetailsTest.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using System.Collections.Generic;
    using System.Linq;

    using FakeItEasy;

    using FluentAssertions;

    using Naos.Diagnostics.Recipes;

    using OBeautifulCode.Collection.Recipes;
    using OBeautifulCode.Enum.Recipes;

    using Xunit;

    using static System.FormattableString;

    public static class MachineDetailsTest
    {
        [Fact]
        public static void ToString___Should_be_useful()
        {
            // Arrange
            var name = A.Dummy<string>();
            var keyOne = MachineNameKind.FullyQualifiedDomainName.ToString();
            var keyTwo = MachineNameKind.NetBiosName.ToString();
            var keyThree = MachineNameKind.ResolvedLocalhostName.ToString();
            var names = new Dictionary<string, string>
                            {
                                { keyOne, name },
                                { keyTwo, name },
                                { keyThree, name },
                            };

            var systemUnderTest = new MachineDetails(names, 10, null, true, null, null);

            // Act
            var actualToString = systemUnderTest.ToString();

            // Assert
            actualToString.Should().Contain(Invariant($"{keyOne}={name}"));
            actualToString.Should().Contain(Invariant($"{keyTwo}={name}"));
            actualToString.Should().Contain(Invariant($"{keyThree}={name}"));
        }

        [Fact]
        public static void TestCreate()
        {
            // arrange
            var machineNameKinds = EnumExtensions.GetEnumValues<MachineNameKind>().Select(_ => _.ToString());

            // act
            var details = DomainFactory.CreateMachineDetails();
            var availableMemory = MachineMemory.GetMachineMemoryInGb()[MachineMemoryKind.AvailablePhysical];

            // assert
            details.Should().NotBeNull();
            details.OperatingSystem.Should().NotBeNull();
            details.ClrVersion.Should().NotBeNullOrWhiteSpace();
            availableMemory.Should().BeLessThan(details.GetTypedMemoryKindToValueInGbMap()[MachineMemoryKind.TotalPhysical]);

            details.MachineNameKindToNameMap.Keys.SymmetricDifference(machineNameKinds).Any().Should().BeFalse();
            details.MachineNameKindToNameMap.Values.Any(string.IsNullOrWhiteSpace).Should().BeFalse();
        }
    }
}