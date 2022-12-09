using AdventUtils;

namespace AoC2022Day05
{
    internal static class PartTwo
    {
        internal static Stack<char>[] DoIt()
        {
            const bool useTestData = false;
            const bool debug = true;

            string dataFilePath = useTestData ? "data/test.txt" : "data/input.txt";
            var fileData = DataReader.Read(dataFilePath, s => s).ToList();


            void MoveStack(string s1, Stack<char>[] stacks)
            {
                var (a, s, t) = Utils.GetMove(s1);

                List<char> items= new List<char>();

                for (int i = 0; i < a; i++)
                {
                    items.Add(stacks[s].Pop());
                }

                items.Reverse();
                items.ForEach(item=>stacks[t].Push(item));
                //stacks[t].Push(item);

            }

            bool areMoves = false;
            Stack<string> stack = new Stack<string>();
            Stack<char>[] pilas = new Stack<char>[] { };

            //read file
            foreach (string s in fileData)
            {
                // if (debug) Console.WriteLine($"Line: {s}");

                if (string.IsNullOrEmpty(s))
                {
                    areMoves = true;
                    pilas = Utils.GetStacks(stack);
                    continue;
                }
                if (!areMoves)
                {
                    stack.Push(s);
                    continue;
                }

                MoveStack(s, pilas);

            }

            return pilas;
        }

    }
}
