// <copyright file="ElementsSourceGenerator.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using SourceGenerator.Generator;
using SourceGenerator.Generator.CodeSections;
using SourceGenerator.Generator.Members.Methods;
using SourceGenerator.Generator.Members.Properties;
using SourceGenerator.Generator.Types;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SourceGenerator
{
    /// <summary>
    /// Generates source code from the elements found in Elements folder.
    /// </summary>
    [Generator]
    public class ElementsSourceGenerator : ISourceGenerator
    {
        /// <summary>
        /// Generates the Element class.
        /// </summary>
        /// <param name="elements">The components to add.</param>
        /// <returns>The source code text.</returns>
        public static SourceText GenerateElementClass(ICollection<string> elements)
        {
            var elementFile = new SourceFileGenerator("Element", "SimpleAnnPlayground.Graphical")
                .AddReference("SimpleAnnPlayground.Graphical.Elements")
                .AddClass(ClassAccess.Public, ClassScope.Abstract | ClassScope.Partial, "Element")
                    .AddDoc("Helper class to make operations with the Graphical Elements.")

                    // Types enumeration.
                    .AddEnum(EnumAccess.Internal, "Types")
                        .AddDoc("Enumerates the types of Graphical Elements.")
                        .AddElements(elements, element => $"{element} element class.")
                    .BackTo<ClassSource>()

                    // ElementsTypes array.
                    .AddPropertyWithValue(PropertyAccess.Internal, PropertyScope.Static, "Type[]", "ElementsTypes", "new Type[]")
                        .AddDoc("Gets an array containing the types of Elements.")
                        .AddValues(elements, element => $"typeof({element}),")
                    .BackTo<ClassSource>()

                    // AddMenuPerElement method.
                    .AddMethod(MethodAccess.Internal, MethodScope.Static, "AddMenuPerElement")
                        .AddDoc("Adds a menu item for each existing element.")
                        .AddParameter("ToolStripDropDownItem", "item", "The menu to add the elements.")
                        .AddParameter("EventHandler", "clickEventHandler", "The event handler for the click action.")
                        .GetCodeBlock(out CodeBlock addMenuMethod)
                    .BackTo<ClassSource>()

                .BackTo<SourceFileGenerator>();

            addMenuMethod.AddComment("Iterate for each element type.")
                .AddLine("foreach (Types elementType in Enum.GetValues<Types>())")
                .AddBlock()
                    .AddComment("Create its correspondig menu item.")
                    .AddLine("var mnuItem = new ToolStripMenuItem")
                    .AddBlock(true)
                        .AddLine("Name = $\"MnuAdd{elementType}\",")
                        .AddLine("Text = elementType.ToString(),")
                        .AddEmptyLine()
                        .AddComment("Store the Element type in the item Tag")
                        .AddLine("Tag = ElementsTypes[(int)elementType],")
                    .Close()
                    .AddEmptyLine()
                    .AddComment("Add the menu item to the Add button.")
                    .AddLine("_ = item.DropDownItems.Add(mnuItem);")
                    .AddEmptyLine()
                    .AddComment("Link the click event with the passed event handler.")
                    .AddLine("mnuItem.Click += clickEventHandler;")
                    .End();

            return SourceText.From(elementFile.Generate(), Encoding.UTF8);
        }

        /// <inheritdoc/>
        public void Execute(GeneratorExecutionContext context)
        {
            // Find the declared elements.
            var elements = ((ElementsFinder)context.SyntaxReceiver)?.Elements;

            // inject the created source into the users compilation
            context.AddSource("Element", GenerateElementClass(elements));
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
            context.RegisterForSyntaxNotifications(() => new ElementsFinder());
        }
    }
}
