// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckSingleDriveReportTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using FakeItEasy;

    using OBeautifulCode.AutoFakeItEasy;
    using OBeautifulCode.CodeAnalysis.Recipes;
    using OBeautifulCode.CodeGen.ModelObject.Recipes;
    using OBeautifulCode.Equality.Recipes;
    using OBeautifulCode.Math.Recipes;

    using Xunit;

    using static System.FormattableString;

    [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
    public static partial class CheckSingleDriveReportTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static CheckSingleDriveReportTest()
        {
            ConstructorArgumentValidationTestScenarios
               .AddScenario(
                    () =>
                        new ConstructorArgumentValidationTestScenario<CheckSingleDriveReport>
                        {
                            Name =
                                "constructor should throw ArgumentOutOfRangeException when parameter 'totalFreeSpaceInBytes' is bigger than 'totalSizeInBytes' scenario",
                            ConstructionFunc = () =>
                                               {
                                                   var referenceObject = A.Dummy<CheckSingleDriveReport>();

                                                   var result = new CheckSingleDriveReport(
                                                       referenceObject.Name,
                                                       referenceObject.TotalSizeInBytes + 1,
                                                       referenceObject.TotalSizeInBytes);

                                                   return result;
                                               },
                            ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                            ExpectedExceptionMessageContains = new[]
                                                               {
                                                                   "totalFreeSpaceInBytes",
                                                               },
                        })
               .AddScenario(
                    () =>
                        new ConstructorArgumentValidationTestScenario<CheckSingleDriveReport>
                        {
                            Name =
                                "constructor should throw ArgumentOutOfRangeException when parameter 'totalFreeSpaceInBytes' is less than zero scenario",
                            ConstructionFunc = () =>
                                               {
                                                   var referenceObject = A.Dummy<CheckSingleDriveReport>();

                                                   var result = new CheckSingleDriveReport(
                                                       referenceObject.Name,
                                                       -1,
                                                       referenceObject.TotalSizeInBytes);

                                                   return result;
                                               },
                            ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                            ExpectedExceptionMessageContains = new[]
                                                               {
                                                                   "totalFreeSpaceInBytes",
                                                               },
                        })
               .AddScenario(
                    () =>
                        new ConstructorArgumentValidationTestScenario<CheckSingleDriveReport>
                        {
                            Name =
                                "constructor should throw ArgumentOutOfRangeException when parameter 'totalSizeInBytes' is less than zero scenario",
                            ConstructionFunc = () =>
                                               {
                                                   var referenceObject = A.Dummy<CheckSingleDriveReport>();

                                                   var result = new CheckSingleDriveReport(
                                                       referenceObject.Name,
                                                       referenceObject.TotalFreeSpaceInBytes,
                                                       -1);

                                                   return result;
                                               },
                            ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                            ExpectedExceptionMessageContains = new[]
                                                               {
                                                                   "totalSizeInBytes",
                                                               },
                        });

            DeepCloneWithTestScenarios
               .RemoveAllScenarios()
               .AddScenario(
                    () =>
                        new DeepCloneWithTestScenario<CheckSingleDriveReport>
                        {
                            Name = "DeepCloneWithName should deep clone object and replace Name with the provided name",
                            WithPropertyName = "Name",
                            SystemUnderTestDeepCloneWithValueFunc = () =>
                                                                    {
                                                                        var systemUnderTest = A.Dummy<CheckSingleDriveReport>();

                                                                        var referenceObject =
                                                                            A.Dummy<CheckSingleDriveReport>()
                                                                             .ThatIs(_ => !systemUnderTest.Name.IsEqualTo(_.Name));

                                                                        var result = new SystemUnderTestDeepCloneWithValue<CheckSingleDriveReport>
                                                                                     {
                                                                                         SystemUnderTest = systemUnderTest,
                                                                                         DeepCloneWithValue = referenceObject.Name,
                                                                                     };

                                                                        return result;
                                                                    },
                        })
               .AddScenario(
                    () =>
                        new DeepCloneWithTestScenario<CheckSingleDriveReport>
                        {
                            Name =
                                "DeepCloneWithTotalFreeSpaceInBytes should deep clone object and replace TotalFreeSpaceInBytes with the provided totalFreeSpaceInBytes",
                            WithPropertyName = "TotalFreeSpaceInBytes",
                            SystemUnderTestDeepCloneWithValueFunc = () =>
                                                                    {
                                                                        var systemUnderTest = A.Dummy<CheckSingleDriveReport>();

                                                                        var result = new SystemUnderTestDeepCloneWithValue<CheckSingleDriveReport>
                                                                                     {
                                                                                         SystemUnderTest = systemUnderTest,
                                                                                         DeepCloneWithValue = systemUnderTest.TotalFreeSpaceInBytes - 1,
                                                                                     };

                                                                        return result;
                                                                    },
                        })
               .AddScenario(
                    () =>
                        new DeepCloneWithTestScenario<CheckSingleDriveReport>
                        {
                            Name =
                                "DeepCloneWithTotalSizeInBytes should deep clone object and replace TotalSizeInBytes with the provided totalSizeInBytes",
                            WithPropertyName = "TotalSizeInBytes",
                            SystemUnderTestDeepCloneWithValueFunc = () =>
                                                                    {
                                                                        var systemUnderTest = A.Dummy<CheckSingleDriveReport>();

                                                                        var result = new SystemUnderTestDeepCloneWithValue<CheckSingleDriveReport>
                                                                                     {
                                                                                         SystemUnderTest = systemUnderTest,
                                                                                         DeepCloneWithValue = systemUnderTest.TotalSizeInBytes + 1,
                                                                                     };

                                                                        return result;
                                                                    },
                        });
        }
    }
}