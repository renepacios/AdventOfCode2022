namespace AoC2022Day06
{
    using System.Linq;

    internal static class PartOne
    {
        const bool debug = true;

        internal static int DoIt(string data)
        {
            
            for (int i = 4; i < data.Length; i++)
            {
                var d = Enumerable.Range(i - 4, 4)
                    .Select(j => data[j])
                    .Distinct()
                    .Count();

                
                    if (d < 4) continue;

                    if(debug) Console.WriteLine(string.Join("", Enumerable.Range(i - 4, 4).Select(j => data[j])));

                return i;

            }

            return -1;
        }
    }
}
