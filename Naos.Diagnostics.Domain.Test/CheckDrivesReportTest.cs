// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckDrivesReportTest.cs" company="Naos Project">
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
    using OBeautifulCode.DateTime.Recipes;
    using OBeautifulCode.Math.Recipes;

    using Xunit;

    using static System.FormattableString;

    [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
    public static partial class CheckDrivesReportTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static CheckDrivesReportTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<CheckDrivesReport>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'driveNameToReportMap' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<CheckDrivesReport>();

                            var result = new CheckDrivesReport(
                                                 referenceObject.Status,
                                                 null,
                                                 referenceObject.OperationUsed,
                                                 referenceObject.SampleTimeUtc);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "driveNameToReportMap", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<CheckDrivesReport>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'driveNameToReportMap' is an empty dictionary scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<CheckDrivesReport>();

                            var result = new CheckDrivesReport(
                                                 referenceObject.Status,
                                                 new Dictionary<string, CheckSingleDriveReport>(),
                                                 referenceObject.OperationUsed,
                                                 referenceObject.SampleTimeUtc);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "driveNameToReportMap", "is an empty dictionary", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<CheckDrivesReport>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'driveNameToReportMap' contains a key-value pair with a null value scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<CheckDrivesReport>();

                            var dictionaryWithNullValue = referenceObject.DriveNameToReportMap.ToDictionary(_ => _.Key, _ => _.Value);

                            var randomKey = dictionaryWithNullValue.Keys.ElementAt(ThreadSafeRandom.Next(0, dictionaryWithNullValue.Count));

                            dictionaryWithNullValue[randomKey] = null;

                            var result = new CheckDrivesReport(
                                                 referenceObject.Status,
                                                 dictionaryWithNullValue,
                                                 referenceObject.OperationUsed,
                                                 referenceObject.SampleTimeUtc);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "driveNameToReportMap", "contains at least one key-value pair with a null value", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<CheckDrivesReport>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'operationUsed' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<CheckDrivesReport>();

                            var result = new CheckDrivesReport(
                                                 referenceObject.Status,
                                                 referenceObject.DriveNameToReportMap,
                                                 null,
                                                 referenceObject.SampleTimeUtc);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "operationUsed", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<CheckDrivesReport>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'sampleTimeUtc' is not a UTC DateTime (it's Local)",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<CheckDrivesReport>();

                            var result = new CheckDrivesReport(
                                                 referenceObject.Status,
                                                 referenceObject.DriveNameToReportMap,
                                                 referenceObject.OperationUsed,
                                                 DateTime.Now);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "sampleTimeUtc", "Kind that is not DateTimeKind.Utc", "DateTimeKind.Local" },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<CheckDrivesReport>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'sampleTimeUtc' is not a UTC DateTime (it's Unspecified)",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<CheckDrivesReport>();

                            var result = new CheckDrivesReport(
                                                 referenceObject.Status,
                                                 referenceObject.DriveNameToReportMap,
                                                 referenceObject.OperationUsed,
                                                 DateTime.UtcNow.ToUnspecified());

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "sampleTimeUtc", "Kind that is not DateTimeKind.Utc", "DateTimeKind.Unspecified" },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<CheckDrivesReport>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when parameter 'status' is 'Invalid' scenario",
                        ConstructionFunc = () =>
                                            {
                                                var referenceObject = A.Dummy<CheckDrivesReport>();

                                                var result = new CheckDrivesReport(
                                                    CheckStatus.Invalid,
                                                    referenceObject.DriveNameToReportMap,
                                                    referenceObject.OperationUsed,
                                                    referenceObject.SampleTimeUtc);

                                                return result;
                                            },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[]
                                                            {
                                                                "status",
                                                            },
                    });
        }
    }
}