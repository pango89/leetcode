using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class PartitionLabelString
    {
        public IList<int> PartitionLabels(string s)
        {
            int[] lastIndex = new int[26];

            for (int i = 0; i < 26; i++)
                lastIndex[i] = -1;

            for (int i = 0; i < s.Length; i++)
                lastIndex[s[i] - 'a'] = i;

            int end = 0;
            int size = 0;
            IList<int> ans = new List<int>();
            
            for (int i = 0; i < s.Length; i++) {
                size++;
                end = Math.Max(end, lastIndex[s[i] - 'a']);

                if (i == end) {
                    ans.Add(size);
                    size = 0;
                }
            }

            return ans;
        }
    }
}