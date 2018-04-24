// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessHelpersTest.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using System;

    using FluentAssertions;

    using Naos.Diagnostics.Domain;

    using Xunit;

    public static class ProcessHelpersTest
    {
        [Fact]
        public static void GetRunningProcess___Should_not_return_null___When_called()
        {
            // arrange

            // act
            var actual = ProcessHelpers.GetRunningProcess();

            // assert
            actual.Should().NotBeNull();
        }

        [Fact]
        public static void Name___Should_throw_ArgumentNullException___When_parameter_process_is_null()
        {
            // arrange

            // act
            var actual = Record.Exception(() => ProcessHelpers.Name(null));

            // assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("process");
        }

        [Fact]
        public static void Name___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = ProcessHelpers.GetRunningProcess().Name();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public static void FilePath___Should_throw_ArgumentNullException___When_parameter_process_is_null()
        {
            // arrange

            // act
            var actual = Record.Exception(() => ProcessHelpers.FilePath(null));

            // assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("process");
        }

        [Fact]
        public static void FilePath___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = ProcessHelpers.GetRunningProcess().FilePath();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public static void FileVersion___Should_throw_ArgumentNullException___When_parameter_process_is_null()
        {
            // arrange

            // act
            var actual = Record.Exception(() => ProcessHelpers.FileVersion(null));

            // assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("process");
        }

        [Fact]
        public static void FileVersion___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = ProcessHelpers.GetRunningProcess().FileVersion();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public static void ProductVersion___Should_throw_ArgumentNullException___When_parameter_process_is_null()
        {
            // arrange

            // act
            var actual = Record.Exception(() => ProcessHelpers.ProductVersion(null));

            // assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("process");
        }

        [Fact]
        public static void ProductVersion___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = ProcessHelpers.GetRunningProcess().ProductVersion();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }
    }
}
