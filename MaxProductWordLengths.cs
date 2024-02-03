using System;
namespace LeetCode
{
    public class MaxProductWordLengths
    {
        public int MaxProduct(string[] words)
        {
            int N = words.Length;
            bool[][] mat = new bool[N][];
            for (int i = 0; i < N; i++)
                mat[i] = new bool[26];

            int ans = 0;

            for (int i = 0; i < N; i++)
            {
                foreach (char c in words[i])
                    mat[i][c - 'a'] = true;

                for (int j = 0; j < i; j++)
                    if (!DoShareCommonLetter(mat[i], mat[j]))
                        ans = Math.Max(ans, words[i].Length * words[j].Length);
            }

            return ans;
        }

        private bool DoShareCommonLetter(bool[] word1, bool[] word2)
        {
            for (int i = 0; i < 26; i++)
                if (word1[i] && word2[i])
                    return true;

            return false;
        }
    }
}
