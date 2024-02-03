using System.Collections.Generic;

namespace LeetCode
{
    public class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            int R = board.Length;
            int C = board[0].Length;

            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            for (int i = 0; i < R; i++)
                for (int j = 0; j < C; j++)
                    if (this.DFS(board, i, j, visited, word, 0)) return true;

            return false;
        }

        private bool DFS(char[][] board, int r, int c, HashSet<(int, int)> visited, string word, int i)
        {
            if (i == word.Length)
                return true;

            if (r < 0 || r > board.Length - 1 || c < 0 || c > board[0].Length - 1 || visited.Contains((r, c)) || word[i] != board[r][c])
                return false;

            visited.Add((r, c));

            bool found =
                this.DFS(board, r + 1, c, visited, word, i + 1)
                || this.DFS(board, r - 1, c, visited, word, i + 1)
                || this.DFS(board, r, c + 1, visited, word, i + 1)
                || this.DFS(board, r, c - 1, visited, word, i + 1);

            if (found)
                return true;

            visited.Remove((r, c));
            return false;
        }
    }
}
