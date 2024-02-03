using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class ValidSudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            int R = board.Length;
            int C = board[0].Length;

            // Check Rows
            for (int i = 0; i < R; i++)
                if (this.IsValid(board, i, 0, 1, 9) == false)
                    return false;

            // Check Columns
            //         for (int i = 0; i < C; i++)
            //             if(this.IsValid(board, 0, i, 9, 1) == false)
            //                 return false;

            //         // Check 3 x 3 
            //         for (int i = 0; i < R; i = i + 3) {
            //             for(int j = 0; j < C; j = j + 3) {
            //                 if(this.IsValid(board, i, j, 3, 3) == false)
            //                     return false;
            //             }
            //         }

            return true;
        }

        private bool IsValid(char[][] box, int r, int c, int rowLen, int colLen)
        {
            HashSet<int> set = new HashSet<int>();
            int R = r + rowLen;
            int C = c + colLen;

            for (int i = r; i < R; i++)
            {
                for (int j = c; j < C; j++)
                {
                    if (box[i][j] == '.') continue;
                    int n = box[i][j] - '0';

                    if (n < 1 || n > 9) return false;
                    if (set.Contains(n)) return false;

                    set.Add(n);
                }
            }

            return true;
        }
    }
}
