using AdventUtils;


const bool useTestData = true;
const bool debug = true;

string dataFilePath = useTestData ? "data/test.txt" : "data/input.txt";
var fileData = DataReader.Read(dataFilePath, s => s.Trim()).ToList();


//part one
Console.WriteLine("Part One");
int result = 0;

Stack<string> stack = new Stack<string>();

foreach (string s in fileData)
{
    if (debug) Console.WriteLine($"Line: {s}");

    if(string.IsNullOrEmpty(s)) break;

    stack.Push(s);
}



Console.WriteLine($"Result {result}");


//part Two
Console.WriteLine("Part Two");
result = 0;
//foreach (string s in fileData)
//{
//    if (debug) Console.WriteLine($"Line: {s}");
//}

Console.WriteLine($"Result {result}");

Console.ReadLine();