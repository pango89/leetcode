using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    // https://leetcode.com/discuss/interview-question/1954161/microsoft-online-assessment

    public class MinimumLetters
    {
        public string RemoveMinimumLetters(string s, int k)
        {
            char ch = s[0];
            int len = 1;

            Queue<char> q = new Queue<char>();
            q.Enqueue(ch);

            for (int i = 1; i < s.Length - 1; i++)
            {
                if (ch == s[i])
                    len++;
                else
                {
                    ch = s[i];
                    len = 1;
                }

                if (len < k)
                    q.Enqueue(s[i]);
            }

            StringBuilder sb = new StringBuilder();
            
            while (q.Count > 0)
                sb.Append(q.Dequeue());

            return sb.ToString();
        }
    }
}