// See https://aka.ms/new-console-template for more information

using Lwkit.Fixed;
using Test;

var tests = new List<BaseTest<Fixed32>>()
{
    new ConstTest32(),
};

foreach (var test in tests)
{
    test.Run();
}
