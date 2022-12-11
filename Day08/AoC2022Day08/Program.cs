using AdventUtils;
using AoC2022Day08;


const bool useTestData = false;

string dataFilePath = useTestData ? "data/test.txt" : "data/input.txt";
var fileData = DataReader.Read(dataFilePath, s => s).ToList();


Console.WriteLine($"Part One");
var res1 = PartOne.DoIt(fileData);
Console.WriteLine($"Result One  --> {res1}");


Console.Write("\n\n");


Console.WriteLine($"Part Two");
var res2 = PartTwo.DoIt(fileData);
Console.WriteLine($"Result   --> {res2}");



Console.ReadLine();