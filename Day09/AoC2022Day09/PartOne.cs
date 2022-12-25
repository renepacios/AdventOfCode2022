namespace AoC2022Day09
{
    internal static class PartOne
    {
        private static (int x, int y) _currentHeadPosition = (0, 0);
        private static (int x, int y) _currentTailPosition=(0, 0);
        private static Dictionary<(int x, int y), int> _hLocations = new Dictionary<(int x, int y), int>();
        private static Dictionary<(int x, int y), int> _tLocations = new Dictionary<(int x, int y), int>();

        private static void MoveHead(Func<(int x, int y), (int x, int y)> move)
        {

        }

        private static void GenerateMove(string move)
        {
            var items = move.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int m = Convert.ToInt32(items[1]);


            Func<(int x, int y), (int, int)> movFunc = items[0] switch
            {
                "U" => tuple => (tuple.x, tuple.y - m),
                "R" => tuple => (tuple.x + m, tuple.y),
                "D" => tuple => (tuple.x, tuple.y + m),
                "L" => tuple => (tuple.x - m, tuple.y),

                _ => throw new ArgumentOutOfRangeException()
            };



        }


        internal static int DoIt(List<string> data)
        {
            foreach (string s in data)
            {
                GenerateMove(s);
            }

            return -1;
        }
    }
}
