using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022Day05
{
    internal static class PartOne
    {
        internal static Stack<char>[] DoIt()
        {
            const bool useTestData = false;
            const bool debug = true;

            string dataFilePath = useTestData ? "data/test.txt" : "data/input.txt";
            var fileData = DataReader.Read(dataFilePath, s => s).ToList();


            //part one
            Console.WriteLine("Part One");




            void moveStack(string s1, Stack<char>[] stacks)
            {
                var (a, s, t) = Utils.GetMove(s1);

                for (int i = 0; i < a; i++)
                {
                    char item = stacks[s].Pop();
                    stacks[t].Push(item);
                }
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

                moveStack(s, pilas);

            }

            return pilas;
        }
    }
}
