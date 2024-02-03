using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class BottomToTopDfs
    {
        public bool IsReachable(int[][] matrix)
        {
            int R = matrix.Length;
            int C = matrix[0].Length;

            for (int i = 0; i < C; i++)
                if (this.Dfs(matrix, R - 1, i, new HashSet<(int, int)>()))
                    return true;

            return false;
        }

        private bool Dfs(int[][] matrix, int r, int c, HashSet<(int, int)> visited)
        {
            if (r < 0 || r > matrix.Length - 1 || c < 0 || c > matrix[0].Length - 1)
                return false;

            if (visited.Contains((r, c)))
                return false;

            if (matrix[r][c] == 1)
                return false;

            if (r == 0)
                return true;

            visited.Add((r, c));
            // Console.WriteLine("Visited r = {0} and c = {1} and element = {2}", r, c, matrix[r][c]);

            return this.Dfs(matrix, r - 1, c - 1, visited) || this.Dfs(matrix, r - 1, c, visited) || this.Dfs(matrix, r - 1, c + 1, visited);
        }
    }
}