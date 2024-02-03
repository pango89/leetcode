using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class SubstrConcatWord
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            Dictionary<string, int> counts = new();

            foreach (string word in words)
            {
                if (!counts.ContainsKey(word))
                    counts.Add(word, 0);
                counts[word]++;
            }

            IList<int> ans = new List<int>();

            int sLen = s.Length;
            int wLen = words[0].Length;
            int wCount = words.Length;
            int wChars = wLen * wCount;

            for (int i = 0; i < sLen - wChars + 1; i++)
            {
                string sub = s.Substring(i, wChars);
                if (IsConcat(sub, counts, wLen))
                    ans.Add(i);
            }

            return ans;
        }

        private bool IsConcat(string sub, Dictionary<string, int> counts, int wLen)
        {
            Dictionary<string, int> seen = new();

            for (int i = 0; i < sub.Length; i += wLen)
            {
                string w = sub.Substring(i, wLen);
                if (!seen.ContainsKey(w))
                    seen.Add(w, 0);
                seen[w]++;
            }

            return seen.Count == counts.Count && !seen.Except(counts).Any();
        }
    }
}