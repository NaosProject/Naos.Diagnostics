// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineDetailsTest.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using Domain;

    using FluentAssertions;

    using Xunit;

    public static class MachineDetailsTest
    {
        [Fact]
        public static void TestCreate()
        {
            // arrange

            // act
            var details = MachineDetails.Create();
            var availableMemory = MachineDetails.GetAvailablePhysicalMemoryInGb();

            // assert
            details.Should().NotBeNull();
            details.OperatingSystem.Should().NotBeNull();
            details.Frameworks.Should().NotBeNull().And.ContainSingle();
            availableMemory.Should().BeLessThan(details.TotalPhysicalMemoryInGb);
        }
    }
}
