// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyDetails.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using OBeautifulCode.Reflection.Recipes;
    using OBeautifulCode.Validation.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Model that holds details about an assembly.
    /// </summary>
    public class AssemblyDetails
    {
        /// <summary>
        /// Reads the assembly from file path to create a <see cref="AssemblyDetails"/>.
        /// </summary>
        /// <param name="assemblyFilePath">The file path the assembly is at.</param>
        /// <param name="useAssemblyIfAlreadyInAppDomain">If the assembly file is already loaded in the AppDomain will use the existing Assembly. Default is true, false will force the file to be loaded...</param>
        /// <returns>Details about an assembly.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFile", Justification = "Need to be able to do this from a file also.")]
        public static AssemblyDetails CreateFromFile(string assemblyFilePath, bool useAssemblyIfAlreadyInAppDomain = true)
        {
            new { assemblyFilePath }.Must().NotBeNullNorWhiteSpace();

            Assembly assembly = null;

            if (useAssemblyIfAlreadyInAppDomain)
            {
                assembly =
                    AppDomain.CurrentDomain.GetAssemblies()
                        .Where(_ => !_.IsDynamic)
                        .SingleOrDefault(_ => _.CodeBase.ToUpperInvariant() == new Uri(assemblyFilePath).ToString().ToUpperInvariant());
            }

            if (assembly == null)
            {
                assembly = Assembly.LoadFile(assemblyFilePath);
            }

            return CreateFromAssembly(assembly);
        }

        /// <summary>
        /// Reads the assembly to create a new <see cref="AssemblyDetails"/>.
        /// </summary>
        /// <param name="assembly">The assembly object to interrogate.</param>
        /// <returns>Details about an assembly.</returns>
        public static AssemblyDetails CreateFromAssembly(Assembly assembly)
        {
            new { assembly }.Must().NotBeNull();

            var codeBasesToIgnore = new List<string>(new[] { "Microsoft.GeneratedCode", "Anonymously Hosted DynamicMethods Assembly" });

            var asmName = assembly.GetName();

            var frameworkVersionNumber = assembly.ImageRuntimeVersion.Substring(1, 3);

            var version = asmName.Version;
            var name = asmName.Name;

            var codeBase = codeBasesToIgnore.Contains(name) ? name : assembly.GetCodeBaseAsPathInsteadOfUri();

            return new AssemblyDetails(name, version, codeBase, frameworkVersionNumber);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyDetails"/> class.
        /// </summary>
        /// <param name="name">Name of the assembly.</param>
        /// <param name="version">Version of the assembly.</param>
        /// <param name="filePath">File path of the assembly observed.</param>
        /// <param name="frameworkVersion">Framework of assembly.</param>
        public AssemblyDetails(string name, Version version, string filePath, string frameworkVersion)
        {
            new { name }.Must().NotBeNullNorWhiteSpace();

            this.Name = name;
            this.Version = version;
            this.FilePath = filePath;
            this.FrameworkVersion = frameworkVersion;
        }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the version of the assembly.
        /// </summary>
        public Version Version { get; private set; }

        /// <summary>
        /// Gets the file path the assembly was observed at.
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Gets the .NET framework the assembly was build for.
        /// </summary>
        public string FrameworkVersion { get; private set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var result = Invariant($"{nameof(AssemblyDetails)} - {nameof(this.Name)}: {this.Name}; {nameof(this.Version)}: {this.Version?.ToString() ?? "<null>"}; {nameof(this.FilePath)}: {this.FilePath ?? "<null>"}; {nameof(this.FrameworkVersion)}: {this.FrameworkVersion ?? "<null>"}.");
            return result;
        }
    }
}