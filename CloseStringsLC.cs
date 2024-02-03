using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class CloseStringsLC
    {
        public bool CloseStrings(string word1, string word2)
        {
            int n1 = word1.Length;
            int n2 = word2.Length;

            if (n1 != n2) return false;

            int[] f1 = new int[26];
            int[] f2 = new int[26];

            foreach (char c in word1)
                f1[c - 'a'] += 1;

            foreach (char c in word2)
            {
                if (f1[c - 'a'] == 0) return false;
                f2[c - 'a'] += 1;
            }

            Dictionary<int, int> dict = new();

            for (int i = 0; i < 26; i++)
            {
                if (!dict.ContainsKey(f1[i]))
                    dict.Add(f1[i], 0);
                dict[f1[i]] += 1;
            }

            for (int i = 0; i < 26; i++)
            {
                if (!dict.ContainsKey(f2[i]))
                    return false;
                dict[f2[i]] -= 1;
                if (dict[f2[i]] < 0)
                    return false;
            }

            foreach (var kv in dict)
                if (kv.Value != 0)
                    return false;

            return true;
        }
    }
}
