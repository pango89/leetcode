using System.Collections.Generic;

namespace LeetCode
{
    public class OceanFlow
    {
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            int R = heights.Length;
            int C = heights[0].Length;

            IList<IList<int>> ans = new List<IList<int>>();
            HashSet<(int, int)> atl = new HashSet<(int, int)>();
            HashSet<(int, int)> pac = new HashSet<(int, int)>();

            for (int i = 0; i < R; i++)
            {
                this.DFS(heights, i, 0, pac, heights[i][0]);
                this.DFS(heights, i, C - 1, atl, heights[i][C - 1]);
            }

            for (int i = 0; i < C; i++)
            {
                this.DFS(heights, 0, i, pac, heights[0][i]);
                this.DFS(heights, R - 1, i, atl, heights[R - 1][i]);
            }

            for (int i = 0; i < R; i++)
                for (int j = 0; j < C; j++)
                    if (atl.Contains((i, j)) && pac.Contains((i, j)))
                        ans.Add(new List<int>() { i, j });

            return ans;
        }

        private void DFS(int[][] heights, int r, int c, HashSet<(int, int)> visited, int prevHeight)
        {
            if (r < 0 || r > heights.Length - 1 || c < 0 || c > heights[0].Length - 1 || visited.Contains((r, c)))
                return;

            if (heights[r][c] < prevHeight)
                return;

            visited.Add((r, c));

            this.DFS(heights, r - 1, c, visited, heights[r][c]);
            this.DFS(heights, r + 1, c, visited, heights[r][c]);
            this.DFS(heights, r, c - 1, visited, heights[r][c]);
            this.DFS(heights, r, c + 1, visited, heights[r][c]);
        }
    }
}
