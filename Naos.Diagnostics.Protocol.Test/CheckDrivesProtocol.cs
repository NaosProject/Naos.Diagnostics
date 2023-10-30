// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckDrivesProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Protocol.Test
{
    using System;
    using Naos.Diagnostics.Domain;
    using OBeautifulCode.Assertion.Recipes;

    using Xunit;

    /// <summary>
    /// Test <see cref="CheckDrivesProtocol" />.
    /// </summary>
    public static partial class CheckDrivesProtocolTest
    {
        [Fact]
        public static void Execute___Creates_correct_report_with_alert___When_threshold_set_high()
        {
            // Arrange
            var operation = new CheckDrivesOp(.99999m);
            var protocol = new CheckDrivesProtocol(() => DateTime.UtcNow);

            // Act
            var report = protocol.Execute(operation);

            // Assert
            report.ShouldAlert.MustForTest().BeTrue();
        }

        [Fact]
        public static void Execute___Creates_correct_report_without_alert___When_threshold_set_low()
        {
            // Arrange
            var operation = new CheckDrivesOp(.00001m);
            var protocol = new CheckDrivesProtocol(() => DateTime.UtcNow);

            // Act
            var report = protocol.Execute(operation);

            // Assert
            report.ShouldAlert.MustForTest().BeFalse();
        }
    }
}