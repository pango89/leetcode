using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class RotateImage
    {
        public void Rotate(int[][] matrix)
        {
            Print(matrix);
            int N = matrix.Length;

            int rowTop = 0, rowBottom = N - 1, colLeft = 0, colRight = N - 1;

            while (rowTop <= rowBottom)
            {
                for (int i = 0; i < colRight - colLeft; i++)
                {
                    int temp = matrix[rowTop][colLeft + i];
                    matrix[rowTop][colLeft + i] = matrix[rowBottom - i][colLeft];
                    matrix[rowBottom - i][colLeft] = matrix[rowBottom][colRight - i];
                    matrix[rowBottom][colRight - i] = matrix[rowTop + i][colRight];
                    matrix[rowTop + i][colRight] = temp;

                    //Print(matrix);
                    //Console.WriteLine("For Loop ended where i  = {0}, colLeft = {1}, colRight = {2}", i, colLeft, colRight);
                }

                rowTop++;
                rowBottom--;
                colLeft++;
                colRight--;
                //Console.WriteLine("While Loop ended");

            }

            Print(matrix);
        }

        public void Print(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
                Console.WriteLine("[{0}]", string.Join(", ", matrix[i]));
            Console.WriteLine();
        }
    }
}
