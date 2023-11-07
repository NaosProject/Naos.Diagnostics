// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckDrivesOpTest.cs" company="Naos Project">
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
    using OBeautifulCode.Math.Recipes;

    using Xunit;

    using static System.FormattableString;

    [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
    public static partial class CheckDrivesOpTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static CheckDrivesOpTest()
        {
            ConstructorArgumentValidationTestScenarios
               .AddScenario(
                    () =>
                        new ConstructorArgumentValidationTestScenario<CheckDrivesOp>
                        {
                            Name =
                                "constructor should throw ArgumentOutOfRangeException when parameter 'failureThreshold' is less than 0 scenario",
                            ConstructionFunc = () =>
                                               {
                                                   var result = new CheckDrivesOp(-1);

                                                   return result;
                                               },
                            ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                            ExpectedExceptionMessageContains = new[]
                                                               {
                                                                   "failureThreshold",
                                                               },
                        })
               .AddScenario(
                    () =>
                        new ConstructorArgumentValidationTestScenario<CheckDrivesOp>
                        {
                            Name =
                                "constructor should throw ArgumentOutOfRangeException when parameter 'failureThreshold' is greater than 1 scenario",
                            ConstructionFunc = () =>
                                               {
                                                   var result = new CheckDrivesOp(2);

                                                   return result;
                                               },
                            ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                            ExpectedExceptionMessageContains = new[]
                                                               {
                                                                   "failureThreshold",
                                                               },
                        })
               .AddScenario(
                    () =>
                        new ConstructorArgumentValidationTestScenario<CheckDrivesOp>
                        {
                            Name =
                                "constructor should throw ArgumentOutOfRangeException when parameter 'warningThreshold' is less than 0 scenario",
                            ConstructionFunc = () =>
                                               {
                                                   var result = new CheckDrivesOp(0.5m, -1);

                                                   return result;
                                               },
                            ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                            ExpectedExceptionMessageContains = new[]
                                                               {
                                                                   "warningThreshold",
                                                               },
                        })
               .AddScenario(
                    () =>
                        new ConstructorArgumentValidationTestScenario<CheckDrivesOp>
                        {
                            Name =
                                "constructor should throw ArgumentOutOfRangeException when parameter 'warningThreshold' is greater than 1 scenario",
                            ConstructionFunc = () =>
                                               {
                                                   var result = new CheckDrivesOp(0.5m, 2);

                                                   return result;
                                               },
                            ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                            ExpectedExceptionMessageContains = new[]
                                                               {
                                                                   "warningThreshold",
                                                               },
                        });
        }
    }
}