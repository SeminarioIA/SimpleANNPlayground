using SourceGenerator;

string[] components = new string[] { "InputNeuron", "InternalNeuron", "OutputNeuron" };

var componentsCode = ComponentsSourceGenerator.GenerateComponentClass(components);

File.WriteAllText("Component.cs", componentsCode.ToString());
