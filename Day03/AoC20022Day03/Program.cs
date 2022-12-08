using AdventUtils;
using Rene.Utils.Core.CommonSources;

var fileData = DataReader.Read("Data/input.txt", s => s.Trim()).ToList();
//var fileData = DataReader.Read("Data/test.txt", s => s.Trim()).ToList();

Dictionary<char, int> ponderaciones = new Dictionary<char, int>();

foreach (char c in Constants.LETRAS_MINUSCULAS)
{
    int codigo = (((int)c) - 96); //a=1, b=2, ...
    ponderaciones.Add(c, codigo);
    //    Console.WriteLine($"Letra: {c} --> ASCII: {codigo}");
}

foreach (char c in Constants.LETRAS_MAYUSCULAS)
{
    int codigo = ((int)c) - 38; // A=27, B= 28, ...
    ponderaciones.Add(c, codigo);
    //  Console.WriteLine($"Letra: {c} --> ASCII: {codigo}");
}

//part one
Console.WriteLine("Part One");
int result = 0;
foreach (string s in fileData)
{
    var m = s.Length / 2;
    var p1 = s.Substring(0, m);
    var p2 = s.Substring(m, s.Length - m);

    var match=p1.ToCharArray().Intersect(p2.ToCharArray()).FirstOrDefault();

    var puntuacion = ponderaciones[match];

    result += puntuacion;
    //Console.WriteLine($"Cad=>{s}  Long=>{s.Length}  Med=>{m}  part1=>{p1}  part2=>{p2} match=> {match} puntuacion=> {puntuacion}");
}

Console.WriteLine($"Result {result}");


//part Two
Console.WriteLine("Part Two");
result = 0;
for (var i = 0; i < fileData.Count; i+=3)
{


    var s0 = fileData[i].ToCharArray();
    var s1 = fileData[i+1].ToCharArray();
    var s2 = fileData[i+2].ToCharArray();

    IEnumerable<char> m=s0.Intersect(s1).Intersect(s2);

    var match = m.FirstOrDefault();
    var puntuacion = ponderaciones[match];

    result += puntuacion;
    //Console.WriteLine($"Cad=>{s}  Long=>{s.Length}  Med=>{m}  part1=>{p1}  part2=>{p2} match=> {match} puntuacion=> {puntuacion}");
}

Console.WriteLine($"Result {result}");

Console.ReadLine();
