using AdventUtils;


const bool useTestData = false;
const bool debug = true;

string dataFilePath = useTestData ? "data/test.txt" : "data/input.txt";
var fileData = DataReader.Read(dataFilePath, s => s.Trim()).ToList();


//part one
Console.WriteLine("Part One");
int result = 0;
int result2=0;
foreach (string s in fileData)
{
    if (debug) Console.WriteLine($"Line: {s}");

    var pares = s.Split(",");
    var p1 = pares[0].Split("-").Select(o=>Convert.ToInt32(o)).ToArray();
    var p2 =pares[1].Split("-").Select(o=>Convert.ToInt32(o)).ToArray();

    //contains
    if ((p1[0] <= p2[0] && p1[1] >= p2[1])
        || (p1[0] >= p2[0] && p1[1] <= p2[1]))
    {
        result++;
    }


    //overlaps
    if ((p1[0] >= p2[0] && p1[0] <= p2[1]) 
        || (p1[1] >= p2[0] && p1[1] <= p2[1])
        || (p2[0] >= p1[0] && p2[0] <= p1[1]) 
        || (p2[1] >= p1[0] && p2[1] <= p1[1])
        )
    {
        result2++;
    }

}

Console.WriteLine($"Result {result}");
Console.WriteLine($"Result2 {result2}");

Console.ReadLine();