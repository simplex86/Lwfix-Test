// See https://aka.ms/new-console-template for more information

Console.WriteLine("Lwfix-Test");

Console.WriteLine(double.MaxValue + 1);

for (int i = 0; i < 5; i++)
{
    var u = System.Random.Shared.NextDouble() + System.Random.Shared.Next(int.MaxValue / 2, int.MaxValue);
    Console.WriteLine($"{u}");
}

Console.WriteLine();

for (int i = 0; i < 5; i++)
{
    var u = System.Random.Shared.NextDouble() + System.Random.Shared.Next(int.MinValue, int.MaxValue);
    Console.WriteLine($"{u}");
}

Console.WriteLine();

for (int i = 0; i < 5; i++)
{
    var u = System.Random.Shared.NextDouble() + System.Random.Shared.Next(-100, 100);
    var v = System.Random.Shared.NextDouble() + System.Random.Shared.Next(-100, 100);
    Console.WriteLine($"[{u}, {v}]");
}

Console.WriteLine();

for (int i = 0; i < 5; i++)
{
    var u = System.Random.Shared.NextDouble() + System.Random.Shared.Next(-1000000, 1000000);
    var v = System.Random.Shared.NextDouble() + System.Random.Shared.Next(-1000000, 1000000);
    Console.WriteLine($"[{u}, {v}]");
}