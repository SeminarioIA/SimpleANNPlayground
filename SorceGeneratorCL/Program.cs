using SourceGenerator;

// Generate components
string[] components = new string[] { "InputNeuron", "InternalNeuron", "OutputNeuron" };

var componentsCode = ComponentsSourceGenerator.GenerateComponentClass(components);
File.WriteAllText("Component.cs", componentsCode.ToString());

// Generate elements
string[] elements = new string[] { "Triangle", "Ellipse", "Box", "Line" };

var elementsCode = ElementsSourceGenerator.GenerateElementClass(elements);
File.WriteAllText("Element.cs", elementsCode.ToString());

// Generate activation functions
string[] functions = new string[] { "Sigmoid" };

var functionsCode = ActivationFunctionsSourceGenerator.GenerateActivationFunctionsCode(functions);
File.WriteAllText("ActivationFunctions.cs", functionsCode.ToString());

// Generate activation functions
string[] models = new string[] { "CircleDataModel", "PlaneDataModel", "TwoGroupsDataModel" };

var modelsCode = DataModelsSourceGenerator.GenerateDataModelsCode(models);
File.WriteAllText("DataModels.cs", modelsCode.ToString());
