// See https://aka.ms/new-console-template for more information

using AdventUtils;
using AoC2022Day07;

const bool useTestData = true;

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
Console.WriteLine("Part Two");
var allFiles = GetFoldersWhere(currentFolder.GetRootItem().SubItems, w => w.Type==ItemFile.ItemType.File)
    //.OrderBy(o=>o.Size)
    .ToList();

long total = allFiles.Sum(s=>s.Size);
long unUsedSpace = 70000000 - total;
long necesary = 30000000 - unUsedSpace;

Console.WriteLine($"Total Used: {total} Unused: {unUsedSpace} Necesary: {necesary}");

//foreach (ItemFile itemFile in allFolders.Where(w=>w.Size>= necesary))
//{
//    Console.WriteLine($"\nFolder: {itemFile.Name} - {itemFile.Size}");
//}

//var item = allFolders.FirstOrDefault(w => w.Size >= necesary);
//Console.WriteLine($"Folder: {item.Name} - {item.Size}");

//foreach (var l in fileData)
//{
//    var res1 = PartTwo.DoIt(l);
//    Console.WriteLine($"Result Two {l} --> {res1}");
//}

//Console.Write("\n\n");

Console.ReadLine();
