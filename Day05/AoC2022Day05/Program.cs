using AdventUtils;
using AoC2022Day05;


//PrintStacks(dev);
Console.WriteLine($"Result One");
var pilas=PartOne.DoIt();

for (int i = 0; i < pilas.Length; i++)
{
    if (pilas[i].TryPop(out var result))
        Console.Write($"{result}");
}
Console.Write("\n\n");

//part Two
Console.WriteLine("Part Two");

pilas = PartTwo.DoIt();

for (int i = 0; i < pilas.Length; i++)
{
    if (pilas[i].TryPop(out var result))
        Console.Write($"{result}");
}
Console.Write("\n\n");


Console.ReadLine();