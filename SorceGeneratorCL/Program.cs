using SourceGenerator;

// Generate components
string[] components = new string[] { "InputNeuron", "InternalNeuron", "OutputNeuron" };

var componentsCode = ComponentsSourceGenerator.GenerateComponentClass(components);
File.WriteAllText("Component.cs", componentsCode.ToString());

// Generate elements
string[] elements = new string[] { "Triangle", "Ellipse", "Box", "Line" };

var elementsCode = ElementsSourceGenerator.GenerateElementClass(elements);
File.WriteAllText("Element.cs", elementsCode.ToString());
