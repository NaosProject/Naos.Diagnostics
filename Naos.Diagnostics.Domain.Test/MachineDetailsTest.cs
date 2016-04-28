// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineDetailsTest.cs" company="Naos">
//   Copyright 2015 Naos
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using Domain;

    using FluentAssertions;

    using Xunit;

    public class MachineDetailsTest
    {
        [Fact]
        public static void TestCreate()
        {
            // arrange

            // act
            var details = MachineDetails.Create();

            // assert
            details.Should().NotBeNull();
            details.OperatingSystem.Should().NotBeNull();
            details.Frameworks.Should().NotBeNull().And.ContainSingle();
        }
    }
}
