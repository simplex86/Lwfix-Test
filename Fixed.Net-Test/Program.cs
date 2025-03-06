// See https://aka.ms/new-console-template for more information

using Test;

var testList = new List<ITest>();
var baseType = typeof(ITest);
var attrType = typeof(TestAttribute);

var assemblies = AppDomain.CurrentDomain.GetAssemblies();
foreach (var assembly in assemblies)
{
    var types = assembly.GetTypes();
    foreach (var type in types)
    {
        if (type.IsAbstract || type.IsInterface || type.IsEnum) continue;
        // 不是从TBase继承
        if (!baseType.IsAssignableFrom(type)) continue;

        var objects = type.GetCustomAttributes(attrType, false);
        if (objects.Length == 0) continue;

        var test = Activator.CreateInstance(type) as ITest;
        if (test != null) testList.Add(test);
    }
}

foreach (var test in testList)
{
    test.Run();
}