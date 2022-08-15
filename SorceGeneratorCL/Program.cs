using SourceGenerator.Generator;
using SourceGenerator.Generator.Members.Methods;
using SourceGenerator.Generator.Members.Properties;
using SourceGenerator.Generator.Types;

string[] components = new string[] { "InputNeuron", "InternalNeuron", "OutputNeuron" };

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

File.WriteAllText("Component.cs", main.Generate());
