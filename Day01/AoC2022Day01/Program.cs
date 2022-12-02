// See https://aka.ms/new-console-template for more information

using AdventUtils;

Console.WriteLine("Hello, World!");

var fileData = DataReader.Read("Data/input.txt", s => s);

int elfCount = 0;
int maxElf = -1;
int maxAmount = 0;
int amount = 0;

int[] threeElfs = { 0, 0, 0 };


foreach (var s in fileData)
{
    if (int.TryParse(s, out int n))
    {
        amount += n;
    }
    else
    {
        elfCount++;

        if (amount > maxAmount)
        {
            maxAmount = amount;
            maxElf = elfCount;

            Console.WriteLine($"Elf {maxElf} Calories {maxAmount}");
        }
        //part two
        if (amount > threeElfs.Min() )
        {
            var i=Array.FindIndex(threeElfs, f => f == threeElfs.Min());
            Console.WriteLine($"{amount} is > {threeElfs[i]}");
            threeElfs[i]=amount;
        }
        amount = 0;
    }
}

Console.WriteLine($"Elf {maxElf} Calories {maxAmount}");

Console.WriteLine($"Three Elfs sum {threeElfs.Sum()} Calories");

Console.ReadLine();
