using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LongestRepeatCharReplacement
    {
        public int CharacterReplacement(string s, int k)
        {
            int l = 0;
            int r = 0;
            int maxOccurenceInMap = 0;
            int maxLength = 0;

            int[] map = new int[26];

            while (l <= r && r < s.Length)
            {
                map[s[r] - 'A']++;
                maxOccurenceInMap = Math.Max(maxOccurenceInMap, map[s[r] - 'A']);

                int currentWindowLength = r - l + 1;
                if (currentWindowLength - maxOccurenceInMap > k)
                {
                    // Slide the left corner of window to the right by one step
                    map[s[l] - 'A']--;
                    l++;
                    currentWindowLength--;
                }

                maxLength = Math.Max(maxLength, currentWindowLength);
                r++;
            }


            return maxLength;
        }

        public string MinWindow(string s, string t)
        {
            Dictionary<char, int> freqT = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                char ch = t[i];
                if (!freqT.ContainsKey(ch))
                    freqT.Add(ch, 0);
                freqT[ch]++;
            }

            int required = freqT.Keys.Count;


            int l = 0;

            while (l < s.Length)
            {
                char c = s[l];
                if (!freqT.ContainsKey(c))
                    l++;
                else
                    break;
            }

            int r = l;
            int formed = 0;

            // ans list of the form (min window length, left, right)
            int[] ans = { int.MaxValue, 0, 0 };

            Dictionary<char, int> freqS = new Dictionary<char, int>();
            while (r < s.Length)
            {
                char ch = s[r];
                if (freqT.ContainsKey(ch))
                {
                    if (!freqS.ContainsKey(ch))
                        freqS.Add(ch, 0);
                    freqS[ch]++;

                    if (freqS[ch] == freqT[ch])
                        formed++;
                }

                while (l <= r && formed == required)
                {
                    if (r - l + 1 < ans[0])
                    {
                        ans[0] = r - l + 1;
                        ans[1] = l;
                        ans[2] = r;
                    }

                    char cLeft = s[l];

                    if (freqS.ContainsKey(cLeft))
                        freqS[cLeft]--;

                    if (freqT.ContainsKey(cLeft) && freqS[cLeft] < freqT[cLeft])
                        formed--;

                    l++;
                }

                r++;
            }

            return ans[0] == int.MaxValue ? "" : s.Substring(ans[1], ans[0]);
        }
    }
}
