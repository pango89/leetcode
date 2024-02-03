using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LongestSubstringWithoutRepeat
    {
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int i = 0;
            int j = 0;
            int max = 0;

            HashSet<char> hs = new HashSet<char>();

            while (i < n && j < n)
            {
                if (!hs.Contains(s[j]))
                {
                    max = Math.Max(max, j - i + 1);
                    hs.Add(s[i]);
                    j++;
                }
                else
                {
                    hs.Remove(s[j]);
                    i++;
                }
            }

            return max;
        }
    }
}
