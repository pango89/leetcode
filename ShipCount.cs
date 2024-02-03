// https://www.chegg.com/homework-help/questions-and-answers/battleships-game-played-rectangular-board-given-representation-board-size-n-height-x-m-wid-q97030738
using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class ShipCount
    {
        public int[] GetShipCount(char[][] matrix)
        {
            int[] ans = new int[3];

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    if (matrix[r][c] == '#')
                    {
                        int count = this.GetShipSize(matrix, r, c);
                        if (count <= 3)
                            ans[count - 1]++;
                    }
                }
            }

            return ans;
        }

        private int GetShipSize(char[][] matrix, int r, int c)
        {
            matrix[r][c] = '.'; // Mark as Visited
            int[][] dirs = new int[][] { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };

            Queue<(int, int)> queue = new();
            queue.Enqueue((r, c));
            int count = 1;

            while (queue.Count > 0)
            {
                int qCount = queue.Count;

                for (int i = 1; i <= qCount; i++)
                {
                    (int ro, int co) = queue.Dequeue();
                    foreach (int[] dir in dirs)
                    {
                        int nr = ro + dir[0];
                        int nc = co + dir[1];

                        if (nr < 0 || nr >= matrix.Length || nc < 0 || nc >= matrix[0].Length || matrix[nr][nc] != '#')
                            continue;

                        matrix[nr][nc] = '.';
                        count++;
                        queue.Enqueue((nr, nc));
                    }
                }
            }

            return count;
        }
    }
}