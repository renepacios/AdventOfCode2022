// See https://aka.ms/new-console-template for more information

using AdventUtils;
using AoC2022Day07;

const bool useTestData = false;

string dataFilePath = useTestData ? "data/test.txt" : "data/input.txt";
var fileData = DataReader.Read(dataFilePath, s => s).ToList();


Console.WriteLine($"Part One");
ItemFile currentFolder = new ItemFile(null); //root folder hasn't parent

PartOne.DoIt(fileData, currentFolder);


IEnumerable<ItemFile> GetFoldersWhere(List<ItemFile> fols, Func<ItemFile, bool> whereFunc)
{
    if (fols.Any(w => w.SubItems.AnyNotNull(w => w.IsDirectory)))
    {

        var subfolders = fols.SelectMany(s => s.SubItems.Where(w => w.IsDirectory)).ToList();

        var foldersWhere = GetFoldersWhere(subfolders, whereFunc);
        foreach (var itemFile in foldersWhere)
        {
            yield return itemFile;
        }
    }

    var foldersToDev = fols.Where(whereFunc);
    foreach (var itemFile in foldersToDev)
    {
        yield return itemFile;
    }
}


var folders = GetFoldersWhere(currentFolder.GetRootItem().SubItems, w => w.IsDirectory && w.Size <= 100000).ToList();

foreach (ItemFile itemFile in folders)
{
    Console.WriteLine($"Name: {itemFile.Name} Size: {itemFile.Size}");
}
Console.Write("\n\n");

Console.WriteLine($"Total Size {folders.Sum(s => s.Size)}");

//part Two
//Console.WriteLine("Part Two");
//foreach (var l in fileData)
//{
//    var res1 = PartTwo.DoIt(l);
//    Console.WriteLine($"Result Two {l} --> {res1}");
//}

//Console.Write("\n\n");

Console.ReadLine();
