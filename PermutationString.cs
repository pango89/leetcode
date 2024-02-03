using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class PermutationString
    {
        public bool CheckInclusion(string s1, string s2)
        {
            int N1 = s1.Length;
            int N2 = s2.Length;

            int l = 0, r = 0;
            int[] map1 = new int[26];
            int[] map2 = new int[26];

            foreach (char c in s1)
                map1[c - 'a']++;

            while (r < N2)
            {
                map2[s2[r] - 'a']++;

                while ((r - l + 1) > N1)
                {
                    map2[s2[l] - 'a']--;
                    l++;
                }

                if ((r - l + 1) == N1 && IsMatching(map1, map2))
                    return true;

                r++;
            }

            return false;
        }

        private bool IsMatching(int[] nums1, int[] nums2)
        {
            for (int i = 0; i < nums1.Length; i++)
                if (nums1[i] != nums2[i])
                    return false;

            return true;
        }
    }
}
