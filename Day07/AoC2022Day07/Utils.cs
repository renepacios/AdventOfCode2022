namespace AoC2022Day07
{
    internal static class Utils
    {
        public static ItemFile ExecuteCommand(this ItemFile currentItemFile, string command)
        {
            var cmd = command.Replace("$", string.Empty);

            //only cd
            if (cmd.Trim().StartsWith("cd"))
            {
                currentItemFile = currentItemFile.ChangeFolder(cmd);
            }
            return currentItemFile;

        }

        private static ItemFile ChangeFolder(this ItemFile currentItemFile, string cmd)
        {
            var dirName = cmd.Replace("cd ", string.Empty).Trim();
            return dirName switch
            {
                "/" => currentItemFile.GetRootItem(),
                ".." => currentItemFile.GetParent(),
                _ => currentItemFile.GetChild(dirName)
            };
        }
    }

    internal static class Extensions
    {
        public static ItemFile GetRootItem(this ItemFile itemFile)
        {
            if (itemFile.Parent == null) return itemFile;

            return GetRootItem(itemFile.Parent);
        }
        public static ItemFile GetParent(this ItemFile itemFile)
        {
            return itemFile.Parent;
        }
        public static ItemFile GetChild(this ItemFile itemFile, string childName)
        {
            return itemFile.SubItems.First(w => w.Name == childName);
        }
        public static long GetSize(this ItemFile itemFile)
        {
            if (itemFile.Type == ItemFile.ItemType.File)
            {
                return itemFile.Size;
            }

            return itemFile.SubItems.Sum(GetSize);
        }

    }

}
