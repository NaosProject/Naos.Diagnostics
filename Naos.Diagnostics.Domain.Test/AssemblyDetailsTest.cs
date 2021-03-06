﻿// --------------------------------------------------------------------------------------------------------------------
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
    using OBeautifulCode.Reflection.Recipes;
    using Xunit;

    public static partial class AssemblyDetailsTest
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
            // NOTE: this is just running the scenario in a separate appdomain to prove it does not get polluted with any additional types when working directly from a file.

            // arrange
            var codeBase = typeof(AssemblyDetails).Assembly.CodeBase;
            var assemblyFilePath = new Uri(codeBase).PathAndQuery.Replace('/', Path.DirectorySeparatorChar);

            // act
            var firstFromCurrentAppDomainLoadedTypes = AssemblyDetails.CreateFromFile(assemblyFilePath);

            // assert
            firstFromCurrentAppDomainLoadedTypes.Should().NotBeNull();
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
            Action<string> action = localAssemblyFilePath => AssemblyDetails.CreateFromFile(localAssemblyFilePath, false);

            // using a dedicated AppDomain so if there are issues it will not pollute the existing AppDomain which is used for serialization et al. in other tests.
            using (var domain = AppDomainHelper.CreateDisposableAppDomain())
            {
                action.ExecuteInAppDomain(assemblyFilePath, domain);
                action.ExecuteInAppDomain(assemblyFilePath, domain);

                // assert
                var loadedAssemblyDetails = domain.AppDomain.GetAssemblies()
                                                     .Where(a => !a.IsDynamic)
                                                     .SelectMany(
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
                                                          })
                                                     .Where(_ => _.Name == nameof(AssemblyDetails))
                                                     .ToList();

                loadedAssemblyDetails.Should().HaveCount(1);
            }
        }
    }
}
