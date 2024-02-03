using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LongestIncreasingPathMatrix
    {
        public int max = 0;
        public int[] nR = new int[] { 0, 0, -1, 1 };
        public int[] nC = new int[] { -1, 1, 0, 0 };

        public int LongestIncreasingPath(int[][] matrix)
        {
            int R = matrix.Length;
            int C = matrix[0].Length;

            Dictionary<(int, int), int> map = new Dictionary<(int, int), int>();

            for (int i = 0; i < R; i++)
                for (int j = 0; j < C; j++)
                    if (map.ContainsKey((i, j)))
                        this.DFS(matrix, i, j, map);

            return 1 + max;
        }

        private void DFS(int[][] matrix, int r, int c, Dictionary<(int, int), int> map)
        {
            if (map.ContainsKey((r, c)))
                return;

            int maxAtCell = 0;
            for (int i = 0; i < 4; i++)
            {
                int rr = r + nR[i];
                int cc = c + nC[i];
                if (rr < 0 || rr >= matrix.Length || cc < 0 || cc >= matrix[0].Length)
                    continue;

                if (matrix[rr][cc] <= matrix[r][c])
                    continue;

                this.DFS(matrix, rr, cc, map);
                maxAtCell = Math.Max(maxAtCell, 1 + map[(rr, cc)]);
            }

            map[(r, c)] = maxAtCell;
            max = Math.Max(max, maxAtCell);
        }
    }
}
