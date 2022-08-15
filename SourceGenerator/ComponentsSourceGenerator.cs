// <copyright file="ComponentsSourceGenerator.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using SourceGenerator.Generator;
using SourceGenerator.Generator.Members.Methods;
using SourceGenerator.Generator.Members.Properties;
using SourceGenerator.Generator.Types;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SourceGenerator
{
    /// <summary>
    /// Generates source code from the elements found in Elements folder.
    /// </summary>
    [Generator]
    public class ComponentsSourceGenerator : ISourceGenerator
    {
        /// <summary>
        /// Generates the Component class.
        /// </summary>
        /// <param name="components">The components to add.</param>
        /// <returns>The source code text.</returns>
        public static SourceText GenerateComponentClass(string[] components)
        {
            if (components == null) throw new ArgumentNullException(nameof(components));

            // Create Component.cs
            var main = new SourceFileGenerator("Component", "SimpleAnnPlayground.Graphical");
            var mainClass = main.AddClass(ClassAccess.Public, ClassScope.Partial, main.Name);
            mainClass.SetDescription("Helper class to make operations with the Graphical Components.");

            // Add a property for each component.
            foreach (string component in components)
            {
                mainClass.AddAutoProperty(PropertyAccess.Internal, PropertyScope.Static, "Component", component, PropertyAccess.Private, "new Component()")
                    .AddDoc($"Gets the graphical object that represents an {component}.")
                    .End();
            }

            // Add ReloadComponents method.
            var reloadMethod = mainClass.AddMethod(MethodAccess.Internal, MethodScope.Static, "ReloadComponents")
                .AddParameter("string", "path", "The path where the components are located.");
            reloadMethod.SetDescription("Load the components from their respective files.");

            // Add the code to reload each component.
            foreach (string component in components)
            {
                reloadMethod.Code
                    .AddLine($"{component}.Deserialize(File.ReadAllText(Path.Combine(path, @\"{component}.cmpt\")))")
                    .End();
            }

            return SourceText.From(main.Generate(), Encoding.UTF8);
        }

        /// <inheritdoc/>
        public void Execute(GeneratorExecutionContext context)
        {
            if (!context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.projectdir", out string projectDirectory))
            {
#pragma warning disable CA2201 // Do not raise reserved exception types
                throw new System.Exception("Invalid build property.");
#pragma warning restore CA2201 // Do not raise reserved exception types
            }

            // Find the declared elements.
            var files = Directory.EnumerateFiles(Path.Combine(projectDirectory, @"Graphical\Components"));
            var components = files.ToList().FindAll(file => Path.GetExtension(file) == ".cmpt").ConvertAll(cmpt => Path.GetFileNameWithoutExtension(cmpt));

            // Save the source file.
            context.AddSource("Component.cs", GenerateComponentClass(components.ToArray()));
        }

        /// <inheritdoc/>
        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                // Debugger.Launch();
            }
#endif
        }
    }
}
