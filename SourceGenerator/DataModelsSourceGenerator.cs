// <copyright file="DataModelsSourceGenerator.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using SourceGenerator.Generator;
using SourceGenerator.Generator.Members.Methods;
using SourceGenerator.Generator.Members.Properties;
using SourceGenerator.Generator.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SourceGenerator
{
    /// <summary>
    /// Generates source code from the activation functions found in Activation folder.
    /// </summary>
    [Generator]
    public class DataModelsSourceGenerator : ISourceGenerator
    {
        /// <summary>
        /// Generates tge ActivationFunctions enumeration.
        /// </summary>
        /// <param name="models">The list of activation functions.</param>
        /// <returns>The source code text.</returns>
        public static SourceText GenerateDataModelsCode(ICollection<string> models)
        {
            if (models == null) throw new ArgumentNullException(nameof(models));

            // Create ActivationFunction.cs
            var modelsFile = new SourceFileGenerator("DataModels", "SimpleAnnPlayground.Data")
                .AddReference("SimpleAnnPlayground.Data.Models");

            var modelsClass = modelsFile.AddClass(ClassAccess.Internal, ClassScope.Abstract | ClassScope.Partial, "DataModel")
                .AddDoc("Defines objects for the data model generators.");

            foreach (string model in models)
            {
                modelsClass
                    .AddPropertyWithValue(PropertyAccess.Public, PropertyScope.Static, model, model, $"new {model}()")
                    .AddDoc($"Gets the a reference to an <see cref=\"{model}\"/> object.")
                    .End();
            }

            return SourceText.From(modelsFile.Generate(), Encoding.UTF8);
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
            var files = Directory.EnumerateFiles(Path.Combine(projectDirectory, @"Data\Models"));
            var functions = files.ToList().FindAll(IsActivationFunctionFile).ConvertAll(cmpt => Path.GetFileNameWithoutExtension(cmpt));

            // Save the source file.
            context.AddSource("DataModels.cs", GenerateDataModelsCode(functions.ToArray()));
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

        private static bool IsActivationFunctionFile(string fileName)
        {
            return Path.GetFileName(fileName) != "ActivationFunction.cs" && Path.GetExtension(fileName) == ".cs";
        }
    }
}
