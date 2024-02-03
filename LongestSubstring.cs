using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            char[] sentence = s.ToCharArray();

            if (sentence.Length == 0)
                return 0;

            if (sentence.Length == 1)
                return 1;

            int maxLen = 1;

            int maxStartIndex = 0;
            int maxEndIndex = 1;

            char prev = sentence[0];
            map.Add(prev, 0);
            int currLen = 1;

            for (int i = 1; i < sentence.Length; i++)
            {
                Console.WriteLine("i = {0}", i);
                char c = sentence[i];
                if (map.ContainsKey(c))
                {
                    if (maxLen < currLen)
                    {
                        maxLen = currLen;
                        maxStartIndex = i - maxLen;
                        maxEndIndex = i;
                        Console.WriteLine("MaxLen = {0}, CurrLen = {1}, Map[c] = {2}", maxLen, currLen, map[c]);
                    }
                    i = map[c];
                    map.Clear();
                    currLen = 0;
                }
                else
                {
                    map.Add(c, i);
                    currLen++;
                    Console.WriteLine("Char = {0} CurrLen = {1}", c, currLen);
                }
            }

            Console.WriteLine("MaxLen = {0}, CurrLen = {1}", maxLen, currLen);

            if (maxLen < currLen)
            {
                maxLen = currLen;
                maxStartIndex = sentence.Length - maxLen;
                maxEndIndex = sentence.Length;
            }

            Console.WriteLine("[{0}]", string.Join(", ", sentence[maxStartIndex..maxEndIndex]));

            return maxLen;
        }
    }
}
