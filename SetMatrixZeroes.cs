using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class SetMatrixZeroes
    {
        public void SetZeroes(int[][] matrix)
        {
            bool rowHasZero = false;
            bool colHasZero = false;

            for (int i = 0; i < matrix[0].Length; i++)
                if (matrix[0][i] == 0)
                    rowHasZero = true;

            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i][0] == 0)
                    colHasZero = true;

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }

            for (int i = 1; i < matrix[0].Length; i++)
                if (matrix[0][i] == 0)
                    NullifyColumn(matrix, i);

            for (int i = 1; i < matrix.Length; i++)
                if (matrix[i][0] == 0)
                    NullifyRow(matrix, i);

            if (rowHasZero)
                NullifyRow(matrix, 0);

            if (colHasZero)
                NullifyColumn(matrix, 0);

        }

        public void NullifyRow(int[][] matrix, int row)
        {
            for (int i = 0; i < matrix[row].Length; i++)
                matrix[row][i] = 0;
        }

        public void NullifyColumn(int[][] matrix, int col)
        {
            for (int i = 0; i < matrix.Length; i++)
                matrix[i][col] = 0;
        }

        public void Print(int[][] matrix)
        {
            for(int i = 0; i < matrix.Length; i++)
                Console.WriteLine("[{0}]", string.Join(", ", matrix[i]));
            Console.WriteLine();
        }
    }
}
