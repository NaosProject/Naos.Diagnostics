// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineDetailsTest.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using System.Linq;

    using FluentAssertions;

    using Naos.Diagnostics.Domain;

    using OBeautifulCode.Collection.Recipes;
    using OBeautifulCode.Enum.Recipes;

    using Xunit;

    public static class MachineDetailsTest
    {
        [Fact]
        public static void TestCreate()
        {
            // arrange
            var machineNameKinds = EnumExtensions.GetEnumValues<MachineNameKind>().Select(_ => _.ToString());

            // act
            var details = MachineDetails.Create();
            var availableMemory = MachineDetails.GetAvailablePhysicalMemoryInGb();

            // assert
            details.Should().NotBeNull();
            details.OperatingSystem.Should().NotBeNull();
            details.Frameworks.Should().NotBeNull().And.ContainSingle();
            availableMemory.Should().BeLessThan(details.TotalPhysicalMemoryInGb);

            details.MachineNameKindToNameMap.Keys.SymmetricDifference(machineNameKinds).Any().Should().BeFalse();
            details.MachineNameKindToNameMap.Values.Any(string.IsNullOrWhiteSpace).Should().BeFalse();
        }
    }
}
