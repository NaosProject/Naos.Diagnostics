// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyDetails.cs" company="Naos">
//   Copyright 2015 Naos
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

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
        public static AssemblyDetails CreateFromFile(string assemblyFilePath, bool useAssemblyIfAlreadyInAppDomain = true)
        {
            Assembly assembly = null;

            if (useAssemblyIfAlreadyInAppDomain)
            {
                assembly =
                    AppDomain.CurrentDomain.GetAssemblies().Where(_ => !_.IsDynamic).SingleOrDefault(_ => _.CodeBase == new Uri(assemblyFilePath).ToString());
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
            var codeBasesToIgnore = new List<string>(new[] { "Microsoft.GeneratedCode", "Anonymously Hosted DynamicMethods Assembly" });

            var asmName = assembly.GetName();

            var frameworkVersionNumber = assembly.ImageRuntimeVersion.Substring(1, 3);
            var framework = new FrameworkDetails { Name = FrameworkDetails.DotNetFrameworkName, Version = Version.Parse(frameworkVersionNumber) };

            var version = asmName.Version;
            var name = asmName.Name;

            string codeBase = codeBasesToIgnore.Contains(name) ? name : assembly.CodeBase;

            // strip off 'file://'
            Uri uri;
            var uriCodebase = Uri.TryCreate(codeBase, UriKind.Absolute, out uri);
            if (uriCodebase)
            {
                codeBase = uri.LocalPath;
            }

            return new AssemblyDetails { Name = name, Version = version, Framework = framework, FilePath = codeBase };
        }

        /// <summary>
        /// Gets or sets the version of the assembly.
        /// </summary>
        public Version Version { get; set; }

        /// <summary>
        /// Gets or sets the name of the assembly.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the file path the assembly was observed at.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the .NET framework the assembly was build for.
        /// </summary>
        public FrameworkDetails Framework { get; set; }
    }
}