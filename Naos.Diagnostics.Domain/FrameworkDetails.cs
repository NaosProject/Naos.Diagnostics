// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameworkDetails.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    /// <summary>
    /// Model that hold details about a framework.
    /// </summary>
    public class FrameworkDetails
    {
        /// <summary>
        /// Constant to use for the name of the .NET framework.
        /// </summary>
        public const string DotNetFrameworkName = ".NET";

        /// <summary>
        /// Constant to use for the name of the CLR.
        /// </summary>
        public const string ClrFrameworkName = "CLR";

        /// <summary>
        /// Gets or sets the name of the framework.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version of the framework.
        /// </summary>
        public string Version { get; set; }
    }
}