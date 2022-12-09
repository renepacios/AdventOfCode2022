using AdventUtils;
using AoC2022Day06;


const bool useTestData = false;

string dataFilePath = useTestData ? "data/test.txt" : "data/input.txt";
var fileData = DataReader.Read(dataFilePath, s => s).ToList();


Console.WriteLine($"Part One");
foreach (var l in fileData)
{
    var res1 = PartOne.DoIt(l);
    Console.WriteLine($"Result One {l} --> {res1}");
}

Console.Write("\n\n");

//part Two
Console.WriteLine("Part Two");
foreach (var l in fileData)
{
    var res1 = PartTwo.DoIt(l);
    Console.WriteLine($"Result Two {l} --> {res1}");
}

Console.Write("\n\n");

Console.ReadLine();