using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class RottenOranges
    {
        public int OrangesRotting(int[][] grid)
        {
            int R = grid.Length;
            int C = grid[0].Length;

            int fresh = 0;
            int time = 0;

            Queue<(int, int)> rottenIndexesQueue = new Queue<(int, int)>();

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (grid[i][j] == 1)
                        fresh++;

                    if (grid[i][j] == 2)
                        rottenIndexesQueue.Enqueue((i, j));
                }
            }

            int[][] neighbors = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            while (rottenIndexesQueue.Count > 0 && fresh > 0)
            {
                int currLen = rottenIndexesQueue.Count;

                for (int i = 0; i < currLen; i++)
                {
                    (int, int) rc = rottenIndexesQueue.Dequeue();
                    // var (r, c) = rottenIndexesQueue.Dequeue();
                    int r = rc.Item1;
                    int c = rc.Item2;

                    foreach (int[] neighbor in neighbors)
                    {
                        int nR = r + neighbor[0];
                        int nC = c + neighbor[1];

                        if (nR < 0 || nC < 0 || nR >= R || nC >= C || grid[nR][nC] != 1)
                            continue;

                        grid[nR][nC] = 2;
                        rottenIndexesQueue.Enqueue((nR, nC));
                        fresh--;
                    }
                }
                time++;
            }

            return fresh > 0 ? -1 : time;
        }
    }
}
