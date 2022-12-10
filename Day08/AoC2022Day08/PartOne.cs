namespace AoC2022Day08
{
    internal static class PartOne
    {
        private static int[][] _matrix;
        private static int _lineLength;
        private static int _rowCount;
        const bool debug = true;

        private static bool IsVisible((int x, int y) treePoint, (int x, int y) positionToValidate,
            Func<(int x, int y), (int x, int y)> applyFunc)
        {
            if (
                positionToValidate.x <= -1
                || positionToValidate.y <= -1
                || positionToValidate.x >= _lineLength
                || positionToValidate.y >= _rowCount
                )
                return true; //llego al borde siendo mayor

            if (_matrix[treePoint.y][treePoint.x] <= _matrix[positionToValidate.y][positionToValidate.x])
            {
                return false; // found a bigger tree
            }

            return IsVisible(treePoint, applyFunc(positionToValidate), applyFunc);
        }

        private static bool IsTreeVisible(int row, int col)
        {
            return
            IsVisible((col, row), (col - 1, row), (tuple => (tuple.x - 1, tuple.y)))
            || IsVisible((col, row), (col + 1, row), (tuple => (tuple.x + 1, tuple.y)))
            || IsVisible((col, row), (col, row - 1), (tuple => (tuple.x, tuple.y - 1)))
            || IsVisible((col, row), (col, row + 1), (tuple => (tuple.x, tuple.y + 1)))


            ;
        }

        internal static int DoIt(List<string> data)
        {
            _lineLength = data.First().Length; // amount of columns 
            _rowCount = data.Count; //amount of rows

            _matrix = new int[_rowCount][];
            int i = 0, amount = 0;

            foreach (string s in data)
            {
                _matrix[i] = s.ToCharArray().Select(c=>Convert.ToInt32(c.ToString())).ToArray();
                i++;

            }

            //first and last line are visible trees
            //first and last column are visible tress except four corners (count on first and last line)
            amount += _lineLength * 2;
            amount += _rowCount * 2 - 4;
            int r = 0;

            for (i = 1; i < _rowCount - 1; i++)
            {
                for (int j = 1; j < _lineLength - 1; j++)
                {
                    if (IsTreeVisible(i, j))
                    {
                        amount ++;
                    }

                    r++;
                }
            }

            if (debug) Console.WriteLine($"Nums recorridos {r}");
            return amount;
        }
    }
}
