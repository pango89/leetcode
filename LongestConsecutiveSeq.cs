using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LongestConsecutiveSeq
    {
        public int LongestConsecutive(int[] nums)
        {
            int longest = 0;
            HashSet<int> set = new HashSet<int>(nums);

            foreach (int n in nums)
            {
                if (set.Contains(n - 1))
                    continue;

                int len = 0;
                while (set.Contains(n + len))
                    len++;

                longest = Math.Max(longest, len);
            }

            return longest;
        }
    }
}
