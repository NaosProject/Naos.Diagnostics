// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessHelpersTest.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using System;

    using FluentAssertions;

    using Naos.Diagnostics.Recipes;

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
            var actual = Record.Exception(() => ProcessHelpers.GetName(null));

            // assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("process");
        }

        [Fact]
        public static void Name___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = ProcessHelpers.GetRunningProcess().GetName();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public static void FilePath___Should_throw_ArgumentNullException___When_parameter_process_is_null()
        {
            // arrange

            // act
            var actual = Record.Exception(() => ProcessHelpers.GetFilePath(null));

            // assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("process");
        }

        [Fact]
        public static void FilePath___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = ProcessHelpers.GetRunningProcess().GetFilePath();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public static void FileVersion___Should_throw_ArgumentNullException___When_parameter_process_is_null()
        {
            // arrange

            // act
            var actual = Record.Exception(() => ProcessHelpers.GetFileVersion(null));

            // assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("process");
        }

        [Fact]
        public static void FileVersion___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = ProcessHelpers.GetRunningProcess().GetFileVersion();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public static void ProductVersion___Should_throw_ArgumentNullException___When_parameter_process_is_null()
        {
            // arrange

            // act
            var actual = Record.Exception(() => ProcessHelpers.GetProductVersion(null));

            // assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("process");
        }

        [Fact]
        public static void ProductVersion___Should_not_return_null_or_white_space___When_called()
        {
            // arrange

            // act
            var actual = ProcessHelpers.GetRunningProcess().GetProductVersion();

            // assert
            actual.Should().NotBeNullOrWhiteSpace();
        }
    }
}
