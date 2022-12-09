using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022Day05
{
    internal static class Utils
    {


        internal static Stack<char>[] GetStacks(Stack<string> stackLines)
        {
            //top line is number of columns 
            var nums = stackLines.Pop();
            var tope = nums.Split(" ", StringSplitOptions.RemoveEmptyEntries).Max(Convert.ToInt32);
            Stack<char>[] pilas = Enumerable
                .Range(1, tope + 1)
                .Select(i => new Stack<char>())
                .ToArray();

            foreach (string line in stackLines)
            {
                // if (debug) Console.WriteLine($"Line: {line}");

                for (int i = 0; i < nums.Length; i++)
                {
                    if (i >= line.Length) break;

                    char n = nums[i];
                    if (n == ' ' || !char.IsDigit(n)) continue;
                    
                    //  Console.WriteLine($"Is Digit {n}");
                    int k = ((int)n - 48);
                    char toPush = line[i];
                    if (toPush != ' ') pilas[k].Push(toPush);
                }
            }

            return pilas;
        }


        internal static (int amount, int source, int target) GetMove(string s)
        {
            s = s.Replace("move ", string.Empty).Replace(" from ", "_").Replace(" to ", "_");
            var numbs = s.Split("_", StringSplitOptions.RemoveEmptyEntries)
                .Select(o => Convert.ToInt32(o))
                .ToArray();

            return (numbs[0], numbs[1], numbs[2]);
        }

    }
}
