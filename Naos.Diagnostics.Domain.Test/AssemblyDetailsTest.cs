// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyDetailsTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using System;
    using System.IO;
    using System.Linq;
    using FakeItEasy;
    using FluentAssertions;
    using Naos.Diagnostics.Domain;
    using Xunit;

    public static class AssemblyDetailsTest
    {
        [Fact]
        public static void ToString___Should_be_useful()
        {
            // Arrange
            var name = A.Dummy<string>();
            var version = A.Dummy<string>();
            var filePath = A.Dummy<string>();
            var frameworkVersion = A.Dummy<string>();
            var systemUnderTest = new AssemblyDetails(name, version, filePath, frameworkVersion);

            // Act
            var actualToString = systemUnderTest.ToString();

            // Assert
            actualToString.Should().Contain(name);
            actualToString.Should().Contain(version);
            actualToString.Should().Contain(filePath);
            actualToString.Should().Contain(frameworkVersion);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Not necessary for the test.")]
        [Fact]
        public static void CreateFromFile_VerifyWillUseAlreadyLoadedIfSpecified()
        {
            // NOTE: This test passes in AppVeyor but sometimes fails locally.

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
            var loadedAssemblyDetails = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).SelectMany(
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
                }).Where(_ => _.Name == nameof(AssemblyDetails)).ToList();

            loadedAssemblyDetails.Should().HaveCount(2);
        }
    }
}
