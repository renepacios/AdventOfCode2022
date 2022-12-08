using AdventUtils;

var fileData = DataReader.Read("Data/input.txt", s => s.Trim());

const int X = 1; //piedra     A 
const int Y = 2; //Papel      B 
const int Z = 3; //Tijeras    C 

string[] puntuacionesOrigen = { "A", "B", "C" }; // i+1=> 1,2,3 //pierdo empato gano
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

string GetMoveFromOrigin(string s)
{
    var move = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string oponentSelection = move[0];
    string mySelection = move[1];
    string myNewSelection = string.Empty;
    int indexMoveOponent = Array.IndexOf(puntuacionesOrigen, oponentSelection);
    if (mySelection == "Y")
    {
        myNewSelection = puntuaciones[indexMoveOponent];
    }
    else if (mySelection == "X") //must lost
    {

        myNewSelection = indexMoveOponent switch
        {
            0 => puntuaciones[2],
            _ => puntuaciones[(indexMoveOponent - 1)]

        };
    }
    else if (mySelection == "Z") //must win
    {
        myNewSelection = puntuaciones[(indexMoveOponent + 1) % puntuaciones.Length];
    }

    string dev = $"{oponentSelection} {myNewSelection}";

    Console.WriteLine($"Era {s} --> {dev}");

    return dev;


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

    string two = GetMoveFromOrigin(s);
    if (Empates.Any(w => w == two))
    {
        puntos2 += 3;

    }

    if (Victorias.Any(w => w == two))
    {
        puntos += 6;

    }

    int aux = getScoreFormSelection(s);
    puntos += aux;
    puntos2 += getScoreFormSelection(two); ;


    // Console.WriteLine($"{s} {aux}  {getScoreFormSelection(two)} ");



}


Console.WriteLine($"Puntos {puntos}");

Console.WriteLine($"Puntos 2 {puntos2}");

Console.ReadLine();