using System;
using System.Text;
namespace LeetCode
{
    public class RankTeamByVotes
    {
        public string RankTeams(string[] votes)
        {
            int len = votes[0].Length;
            int[][] matrix = new int[26][];

            for (int i = 0; i < 26; i++)
            {
                matrix[i] = new int[len + 1];
                matrix[i][len] = i;
            }

            foreach (string vote in votes)
                for (int j = 0; j < vote.Length; j++)
                    matrix[vote[j] - 'A'][j]++;

            Array.Sort(matrix, (a, b) =>
            {
                for (int i = 0; i < len; i++)
                {
                    if (a[i] < b[i]) return 1;
                    if (a[i] > b[i]) return -1;
                }
                return 0;
            });

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < len; i++)
                sb.Append((char)('A' + matrix[i][len]));

            string output = sb.ToString();
            return output;
        }
    }
}