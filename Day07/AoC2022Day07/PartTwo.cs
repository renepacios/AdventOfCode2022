namespace AoC2022Day07
{
    internal static class PartTwo
    {
        const bool debug = true;


        internal static int DoIt(string data)
        {

            for (int i = 14; i < data.Length; i++)
            {
                var d = Enumerable.Range(i - 14, 14)
                    .Select(j => data[j])
                    .Distinct()
                    .Count();
                if (d < 14) continue; 

                if (debug) Console.WriteLine(string.Join("", Enumerable.Range(i - 14, 14).Select(j => data[j])));

                return i;

            }

            return -1;
        }

    }
}
