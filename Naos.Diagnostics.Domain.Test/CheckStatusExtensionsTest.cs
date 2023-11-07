// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckStatusExtensionsTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using OBeautifulCode.Assertion.Recipes;
    using Xunit;

    public static class CheckStatusExtensionsTest
    {
        [Fact]
        public static void ReduceToSingleStatus___Called_with_one_Invalid___Returns_Invalid()
        {
            // Arrange
            var input = new[]
                        {
                            CheckStatus.Invalid,
                            CheckStatus.Unknown,
                            CheckStatus.Unknown,
                            CheckStatus.Success,
                            CheckStatus.Success,
                            CheckStatus.Warning,
                            CheckStatus.Warning,
                            CheckStatus.Failure,
                            CheckStatus.Failure,
                        };

            var expected = CheckStatus.Invalid;

            // Act
            var actual = input.ReduceToSingleStatus();

            // Assert
            actual.MustForTest().BeEqualTo(expected);
        }

        [Fact]
        public static void ReduceToSingleStatus___Called_with_one_Failure_and_no_Invalid___Returns_Failure()
        {
            // Arrange
            var input = new[]
                        {
                            CheckStatus.Success,
                            CheckStatus.Success,
                            CheckStatus.Unknown,
                            CheckStatus.Unknown,
                            CheckStatus.Warning,
                            CheckStatus.Warning,
                            CheckStatus.Failure,
                        };

            var expected = CheckStatus.Failure;

            // Act
            var actual = input.ReduceToSingleStatus();

            // Assert
            actual.MustForTest().BeEqualTo(expected);
        }

        [Fact]
        public static void ReduceToSingleStatus___Called_with_one_Warning_and_no_Invalid_or_Failure___Returns_Warning()
        {
            // Arrange
            var input = new[]
                        {
                            CheckStatus.Success,
                            CheckStatus.Success,
                            CheckStatus.Unknown,
                            CheckStatus.Unknown,
                            CheckStatus.Warning,
                        };

            var expected = CheckStatus.Warning;

            // Act
            var actual = input.ReduceToSingleStatus();

            // Assert
            actual.MustForTest().BeEqualTo(expected);
        }

        [Fact]
        public static void ReduceToSingleStatus___Called_with_one_Unknown_and_no_Invalid_or_Failure_or_Warning___Returns_Unknown()
        {
            // Arrange
            var input = new[]
                        {
                            CheckStatus.Success,
                            CheckStatus.Success,
                            CheckStatus.Unknown,
                        };

            var expected = CheckStatus.Unknown;

            // Act
            var actual = input.ReduceToSingleStatus();

            // Assert
            actual.MustForTest().BeEqualTo(expected);
        }

        [Fact]
        public static void ReduceToSingleStatus___Called_with_all_Success___Returns_Success()
        {
            // Arrange
            var input = new[]
                        {
                            CheckStatus.Success,
                            CheckStatus.Success,
                        };

            var expected = CheckStatus.Success;

            // Act
            var actual = input.ReduceToSingleStatus();

            // Assert
            actual.MustForTest().BeEqualTo(expected);
        }
    }
}