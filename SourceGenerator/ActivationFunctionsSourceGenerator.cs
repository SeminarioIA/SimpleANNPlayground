// <copyright file="ActivationFunctionsSourceGenerator.cs" company="SeminarioIA">
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
    public class ActivationFunctionsSourceGenerator : ISourceGenerator
    {
        /// <summary>
        /// Generates tge ActivationFunctions enumeration.
        /// </summary>
        /// <param name="functions">The list of activation functions.</param>
        /// <returns>The source code text.</returns>
        public static SourceText GenerateActivationFunctionsCode(ICollection<string> functions)
        {
            if (functions == null) throw new ArgumentNullException(nameof(functions));

            // Create ActivationFunction.cs
            var activationFile = new SourceFileGenerator("ActivationFunctions", "SimpleAnnPlayground.Ann.Activation");
            var activationEnum = activationFile.AddEnum(EnumAccess.Public, "Functions");
            activationEnum.SetDescription("Enumerates all the activation functions.");

            // Add a property for each component.
            foreach (string function in functions)
            {
                activationEnum.AddElement(function, $"The {function} activation function.")
                    .End();
            }

            var activationClass = activationFile.AddClass(ClassAccess.Public, ClassScope.Static, "ActivationFunctions")
                .AddDoc("Implements static operations with activation functions.");

            foreach (string function in functions)
            {
                activationClass
                    .AddAutoProperty(PropertyAccess.Public, PropertyScope.Static, function, function, PropertyAccess.Private, $"new {function}()")
                    .AddDoc($"Gets the {function} activation function.")
                    .End();
            }

            activationClass
                .AddFunction(MethodAccess.Public, MethodScope.Static, "GetActivationFunction")
                    .SetReturnValue("ActivationFunction", "The activation function object.")
                    .AddParameter("this Functions", "function", "The activation function name.")
                    .AddDoc("Gets the activation function from its name.")
                    .Code
                        .AddLine("return function switch")
                        .AddBlock(semiColon: true)
                            .AddLines(functions, item => $"Functions.{item} => {item},")
                            .AddLine("_ => throw new ArgumentException(\"Invalid value.\", nameof(function)),")
                        .End();

            return SourceText.From(activationFile.Generate(), Encoding.UTF8);
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
            var files = Directory.EnumerateFiles(Path.Combine(projectDirectory, @"Ann\Activation"));
            var functions = files.ToList().FindAll(IsActivationFunctionFile).ConvertAll(cmpt => Path.GetFileNameWithoutExtension(cmpt));

            // Save the source file.
            context.AddSource("ActivationFunctions.cs", GenerateActivationFunctionsCode(functions.ToArray()));
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
