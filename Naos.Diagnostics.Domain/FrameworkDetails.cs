// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameworkDetails.cs" company="Naos">
//   Copyright 2015 Naos
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;

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
        public Version Version { get; set; }
    }
}