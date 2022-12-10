namespace AoC2022Day08
{
    internal static class PartTwo
    {
        private static int[][] _matrix;
        private static int _lineLength;
        private static int _rowCount;
        const bool debug = true;

        private static int GetVisibles((int x, int y) treePoint, (int x, int y) positionToValidate,
            Func<(int x, int y), (int x, int y)> applyFunc)
        {
            if (
                positionToValidate.x <= -1
                || positionToValidate.y <= -1
                || positionToValidate.x >= _lineLength
                || positionToValidate.y >= _rowCount
                )
                return 0; //llego al borde siendo mayor

            if (_matrix[treePoint.y][treePoint.x] > _matrix[positionToValidate.y][positionToValidate.x])
            {
                return 1 + GetVisibles(treePoint, applyFunc(positionToValidate), applyFunc);
            }

            if (_matrix[treePoint.y][treePoint.x] <= _matrix[positionToValidate.y][positionToValidate.x])
            {
                return 1;
            }

            return 0;
        }

        private static long GetBeetterTreeVisible(int row, int col)
        {

            var a = GetVisibles((col, row), (col - 1, row), (tuple => (tuple.x - 1, tuple.y)));
            var b = GetVisibles((col, row), (col + 1, row), (tuple => (tuple.x + 1, tuple.y)));
            var c = GetVisibles((col, row), (col, row - 1), (tuple => (tuple.x, tuple.y - 1)));
            var d = GetVisibles((col, row), (col, row + 1), (tuple => (tuple.x, tuple.y + 1)));

            return a * b * c * d;
            ;
        }

        internal static long DoIt(List<string> data)
        {
            _lineLength = data.First().Length; // amount of columns 
            _rowCount = data.Count; //amount of rows

            _matrix = new int[_rowCount][];
            int i = 0;
            long bestAmount = 0;

            foreach (string s in data)
            {
                _matrix[i] = s.ToCharArray().Select(c => Convert.ToInt32(c.ToString())).ToArray();
                i++;

            }

            int r = 0;

            for (i = 1; i < _rowCount - 1; i++)
            {
                for (int j = 1; j < _lineLength - 1; j++)
                {
                    var currentAmount = GetBeetterTreeVisible(i, j);
                    if (currentAmount > bestAmount)
                    {
                        bestAmount = currentAmount;
                    }

                    r++;
                }
            }

            if (debug) Console.WriteLine($"Nums recorridos {r}");
            return bestAmount;
        }
    }

}

