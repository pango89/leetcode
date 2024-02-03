using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Islands
    {
        public int NumIslands(char[][] grid)
        {
            int R = grid.Length;
            int C = grid[0].Length;

            int ans = 0;
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (grid[i][j] == '1' && !visited.Contains((i, j)))
                    {
                        ans++;
                        this.DFS(grid, i, j, visited);
                    }
                }
            }

            return ans;
        }

        private void DFS(char[][] grid, int r, int c, HashSet<(int, int)> visited)
        {
            if (r < 0 || r > grid.Length - 1 || c < 0 || c > grid[0].Length - 1 || visited.Contains((r, c)))
                return;

            if (grid[r][c] != '1')
                return;

            visited.Add((r, c));

            this.DFS(grid, r - 1, c, visited);
            this.DFS(grid, r + 1, c, visited);
            this.DFS(grid, r, c - 1, visited);
            this.DFS(grid, r, c + 1, visited);
        }
    }
}
