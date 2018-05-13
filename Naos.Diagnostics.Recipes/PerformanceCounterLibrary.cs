// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceCounterLibrary.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Recipes
{
    using System.Collections.Generic;

    /// <summary>
    /// Various common <see cref="System.Diagnostics.PerformanceCounter" />'s sometimes with standard ranges.
    /// </summary>
#if NaosDiagnosticsRecipes
    public
#else
    [System.CodeDom.Compiler.GeneratedCode("Naos.Diagnostics", "See package version number")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal
#endif
    static class PerformanceCounterLibrary
    {
        /// <summary>
        /// Gets disk idle time.
        /// </summary>
        public static RecipePerformanceCounterDescription DiskPercentageIdleTime => new RecipePerformanceCounterDescription(
            Category.PhysicalDisk,
            "%idle time",
            instanceName: null,
            expectedMinValue: 60,
            expectedMaxValue: 100);

        /// <summary>
        /// Common categories.
        /// </summary>
        public static class Category
        {
            /// <summary>
            /// Physical disk.
            /// </summary>
            public const string PhysicalDisk = "PhysicalDisk";
        }

        /// <summary>
        /// Gets common counters.
        /// </summary>
        public static IReadOnlyCollection<RecipePerformanceCounterDescription> CommonCounters => new[]
                                                                                           {
                                                                                               DiskPercentageIdleTime,
                                                                                           };
    }
}
