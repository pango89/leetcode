using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LongestStringChain
    {
        public int LongestStrChain(string[] words)
        {
            Array.Sort(words, (a, b) => a.Length.CompareTo(b.Length));
            Dictionary<string, int> map = new Dictionary<string, int>();

            int ans = 0;

            foreach (string word in words)
            {
                int cnt = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    string prev = word.Substring(0, i) + word.Substring(i + 1);
                    cnt = Math.Max(cnt, 1 + (map.ContainsKey(prev) ? map[prev] : 0));
                }
                map[word] = cnt;
                ans = Math.Max(ans, cnt);
            }

            return ans;
        }
    }
}