// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyDetailsTest.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using System;
    using System.IO;
    using System.Linq;

    using Domain;

    using FakeItEasy;

    using FluentAssertions;

    using Xunit;

    public static class AssemblyDetailsTest
    {
        [Fact]
        public static void ToString___Should_be_useful()
        {
            // Arrange
            var name = A.Dummy<string>();
            var version = new Version(1, 4);
            var filePath = A.Dummy<string>();
            var frameworkVersion = A.Dummy<string>();
            var systemUnderTest = new AssemblyDetails(name, version, filePath, frameworkVersion);

            // Act
            var actualToString = systemUnderTest.ToString();

            // Assert
            actualToString.Should().Contain(name);
            actualToString.Should().Contain(version.ToString());
            actualToString.Should().Contain(filePath);
            actualToString.Should().Contain(frameworkVersion);
        }

        [Fact]
        public static void CreateFromFile_VerifyWillUseAlreadyLoadedIfSpecified()
        {
            // NOTE: these tests have to be done serially so i'm doing both in one test, the second will pollute the AppDomain if it runs first...

            // arrange
            var codeBase = typeof(AssemblyDetails).Assembly.CodeBase;
            var assemblyFilePath = new Uri(codeBase).PathAndQuery.Replace('/', Path.DirectorySeparatorChar);

            // act
            AssemblyDetails.CreateFromFile(assemblyFilePath);

            // assert
            AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).SelectMany(
                a =>
                    {
                        try
                        {
                            return a.GetExportedTypes();
                        }
                        catch (Exception)
                        {
                            /* no-op */
                        }

                        return Enumerable.Empty<Type>();
                    }).SingleOrDefault(_ => _.Name == nameof(AssemblyDetails)).Should().NotBeNull();

            // act
            AssemblyDetails.CreateFromFile(assemblyFilePath, false);

            // assert
            AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).SelectMany(
                a =>
                {
                    try
                    {
                        return a.GetExportedTypes();
                    }
                    catch (Exception)
                    {
                        /* no-op */
                    }

                    return Enumerable.Empty<Type>();
                }).Where(_ => _.Name == nameof(AssemblyDetails)).Should().HaveCount(2);
        }
    }
}
