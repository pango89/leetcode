using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class CodecStrings
    {
        // Encodes a list of strings to a single string.
        public string Encode(IList<string> strs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in strs)
            {
                sb.Append(str.Length);
                sb.Append('#');
                sb.Append(str);
            }

            return sb.ToString();
        }

        // Decodes a single string to a list of strings.
        public IList<string> Decode(string s)
        {
            IList<string> ans = new List<string>();

            int i = 0;

            while (i < s.Length)
            {
                int j = i;
                while (s[j] != '#')
                    j++;

                //int len = int.Parse(s.Substring(i, j - i));
                int len = int.Parse(s[i..j]);
                ans.Add(s.Substring(j + 1, len));
                i = j + 1 + len;
            }

            return ans;
        }
    }
}
