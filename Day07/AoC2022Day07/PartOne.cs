namespace AoC2022Day07
{
    internal static class PartOne
    {
        const bool debug = true;

        internal static ItemFile DoIt(List<string> data, ItemFile currentFolder)
        {
            ArgumentNullException.ThrowIfNull(currentFolder);

            foreach (string s in data)
            {
                if (s.StartsWith("$"))
                {
                 currentFolder=  currentFolder.ExecuteCommand(s);
                }
                else
                {
                    currentFolder.AddSubItem(s);
                }
            }

            return currentFolder.GetRootItem();
        }
    }
}
