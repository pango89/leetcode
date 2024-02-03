using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int R = matrix.Length;
            int C = matrix[0].Length;

            IList<int> ans = new List<int>();

            int rowTop = 0, rowBottom = R - 1, colLeft = 0, colRight = C - 1;

            while (rowTop <= rowBottom && colLeft <= colRight)
            {
                for (int i = colLeft; i <= colRight; i++)
                    ans.Add(matrix[rowTop][i]);
                rowTop++;

                for (int i = rowTop; i <= rowBottom; i++)
                    ans.Add(matrix[i][colRight]);
                colRight--;

                if (rowTop <= rowBottom)
                    for (int i = colRight; i >= colLeft; i--)
                        ans.Add(matrix[rowBottom][i]);
                rowBottom--;

                if (colLeft <= colRight)
                    for (int i = rowBottom; i >= rowTop; i--)
                        ans.Add(matrix[i][colLeft]);
                colLeft++;
            }
            return ans;
        }

        public void Print(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
                Console.WriteLine("[{0}]", string.Join(", ", matrix[i]));
            Console.WriteLine();
        }
    }
}
