using SourceGenerator.Generator;
using SourceGenerator.Generator.Members.Methods;
using SourceGenerator.Generator.Types;

var test = new SourceFileGenerator("Test", "MyProgram");
test.AddReference("System");
test.AddReference("System.Text");

var myClass = test.AddClass(ClassAccess.Public, "MyClass");
myClass.SetDescription("Example class to test the SourceGenerator library project.");

myClass.AddConstructor(MethodAccess.Public).Code
    .AddLine("Console.WriteLine(\"Hola mundo!\");")
    .AddEmptyLine()
    .AddLine("Console.WriteLine(\"Program end.\");")
    ;

myClass.AddFunction(MethodAccess.Public, MethodScope.Override, "ToString")
    .SetReturnValue("string")
    .SetExpressionBody("\"hola\"")
    ;

myClass.AddMethod(MethodAccess.Internal, MethodScope.None, "MyMethod", "Executes an operation.")
    .AddParameter("int", "length", "The length.")
    .AddParameter("int", "count", "The count.")
    .Code
    .AddLine("if (count > length)")
    .AddBlock()
        .AddLine("count = length - 1;")
    .Close()
    .AddLine("else")
    .AddBlock()
        .AddLine("length = count + 1;")
    .Close();

File.WriteAllText("test.cs", test.Generate());
