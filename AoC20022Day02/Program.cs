using AdventUtils;

var fileData = DataReader.Read("Data/input.txt", s => s.Trim());

const int X = 1; //piedra     A 
const int Y = 2; //Papel      B 
const int Z = 3; //Tijeras    C 

string[] puntuaciones = { "X", "Y", "Z" }; // i+1=> 1,2,3
string[] Empates = { "A X", "B Y", "C Z" };
string[] Perdidas = { "A Z", "B X", "C Y" };
string[] Victorias = { "A Y", "B Z", "C X" };

const int vitoria = 6;
const int empate = 3;

int puntos = 0;

int puntos2 = 0;

int getScoreFormSelection(string s)
{
    string mySelection = s.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

    return Array.IndexOf(puntuaciones, mySelection) + 1;

}

foreach (string s in fileData)
{
    if (Empates.Any(w => w == s))
    {
        puntos += 3;
    }

    if (Victorias.Any(w => w == s))
    {
        puntos += 6;

    }

    int aux= getScoreFormSelection(s);
    puntos += aux;

    int resultadoPartida= aux switch { 1 => 0 /*perdida*/, 2 => 3 /*empate*/, 3 => 6 /*win*/ };
    Console.WriteLine($"{s} {aux}  {resultadoPartida} ");

    puntos2 += aux + resultadoPartida;

}


Console.WriteLine($"Puntos {puntos}");

Console.WriteLine($"Puntos 2 {puntos2}");

Console.ReadLine();