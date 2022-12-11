namespace AoC2022Day07;

internal class ItemFile
{
    public enum ItemType
    {
        File=0,
        Directory=1
    }

    public ItemFile Parent;
    public List<ItemFile> SubItems { get; set; }
    public ItemType Type { get; set; }
    public string Name { get; set; }

    public long Size
    {
        get
        {
            if (Type == ItemType.File) return FileSize;

            return SubItems.Sum(s => s.Size);

        }
    }

    private long FileSize {  get; set; }




    public ItemFile(ItemFile parent)
    {
        Parent = parent;
        SubItems = new List<ItemFile>();
        Type = ItemType.Directory;
    }

    public ItemFile(ItemFile parent, long size)
    {
        Parent = parent;
        SubItems = new List<ItemFile>();
        FileSize= size;
        Type= ItemType.File;
    }

    public void AddSubItem(string line)
    {
        var item=new ItemFile(this);

        if (line.StartsWith("dir"))
        {
            item.Type = ItemType.Directory;
            item.Name=line.Replace("dir ",string.Empty).Trim();
        }
        else
        {
            var file = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            item.Type= ItemType.File;
            item.FileSize = Convert.ToInt64(file[0]);
            item.Name = file[1];
        }

        this.SubItems.Add(item);

    }
}