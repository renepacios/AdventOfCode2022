// See https://aka.ms/new-console-template for more information

using AdventUtils;
using AoC2022Day07;

const bool useTestData = true;

string dataFilePath = useTestData ? "data/test.txt" : "data/input.txt";
var fileData = DataReader.Read(dataFilePath, s => s).ToList();


Console.WriteLine($"Part One");
ItemFile currentFolder = new ItemFile(null); //root folder hasn't parent
                                             
PartOne.DoIt(fileData,currentFolder);

//List<ItemFile> GetFoldersWhere(List<ItemFile> folders, Func<ItemFile, bool> where)
//{
//    //if (folders.Any(w => w.SubItems.AnyNotNull()))
//    //{
//    //    List<ItemFile> subitems=new List<ItemFile>();
//    //    foreach (var itemFile in folders)
//    //    {
//    //        subitems.AddRange(GetFoldersWhere(itemFile.SubItems, where));
//    //    }
//    //    return subitems;
//    //}

//    //return folders.Where(where).ToList();
//}

//var folders = GetFoldersWhere(currentFolder.GetRootItem().SubItems,
//    s => s.Size <= 100000 && s.Type == ItemFile.ItemType.Directory);

//var folders = currentFolder.GetRootItem()
//    .SubItems.WhereFromMany(s => s.Size <= 100000 && s.Type == ItemFile.ItemType.Directory);

//var folders=currentFolder.GetRootItem().SubItems.Where(s => s.Size <= 100000 && s.Type==ItemFile.ItemType.Directory).ToList();

//var subFolders = folders.ToList();
//while (subFolders.AnyNotNull())
//{
//    subFolders = subFolders.SelectMany(s => s.SubItems).Where(s => s.Size <= 100000 && s.Type==ItemFile.ItemType.Directory).ToList();
//    folders.AddRange(subFolders);
//}

foreach (ItemFile itemFile in folders)
{
    Console.WriteLine($"Name: {itemFile.Name} Size: {itemFile.Size}");
}
Console.Write("\n\n");

Console.WriteLine($"Total Size {folders.Sum(s=>s.Size)}");

//part Two
//Console.WriteLine("Part Two");
//foreach (var l in fileData)
//{
//    var res1 = PartTwo.DoIt(l);
//    Console.WriteLine($"Result Two {l} --> {res1}");
//}

//Console.Write("\n\n");

Console.ReadLine();
