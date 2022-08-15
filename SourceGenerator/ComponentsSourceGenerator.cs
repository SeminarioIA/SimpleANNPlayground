// <copyright file="ComponentsSourceGenerator.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using SourceGenerator.Generator;
using SourceGenerator.Generator.Members.Methods;
using SourceGenerator.Generator.Members.Properties;
using SourceGenerator.Generator.Types;
using System.Collections.Generic;
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

            GenerateComponentClass(context, components);
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

        private static void GenerateComponentClass(GeneratorExecutionContext context, List<string> components)
        {
            // Create Component.cs
            var main = new SourceFileGenerator("Component", "SimpleAnnPlayground.Graphical");
            var mainClass = main.AddClass(ClassAccess.Public, ClassScope.Partial, main.Name);

            // Add a property for each component.
            foreach (string component in components)
            {
                mainClass.AddAutoProperty(PropertyAccess.Internal, PropertyScope.Static, component)
                    .SetDescription($"Gets the graphical object that represents an {component}.");
            }

            // Add ReloadComponents method.
            var reloadMethod = mainClass.AddMethod(MethodAccess.Internal, MethodScope.Static, "ReloadComponents", "Load the components from their respective files.")
                .AddParameter("string", "path", "The path where the components are located.");

            // Add the code to reload each component.
            foreach (string component in components)
            {
                reloadMethod.Code
                    .AddLine($"{component}.Deserialize(File.ReadAllText(Path.Combine(path, @\"{component}.cmpt\")))")
                    .End();
            }

            // Save the source file.
            context.AddSource(main.Name, SourceText.From(main.Generate(), Encoding.UTF8));
        }
    }
}
