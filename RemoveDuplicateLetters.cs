using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class DuplicateLetters
    {
        public string RemoveDuplicateLetters(string s)
        {
            int[] count = new int[26];
            bool[] inQueue = new bool[26];

            foreach (char c in s)
                count[c - 'a']++;

            LinkedList<char> deque = new LinkedList<char>();

            foreach (char c in s)
            {
                count[c - 'a']--;

                if (inQueue[c - 'a'])
                    continue;

                while (deque.Count > 0 && deque.Last.Value > c && count[deque.Last.Value - 'a'] > 0)
                {
                    char popped = deque.Last.Value;
                    deque.RemoveLast();
                    inQueue[popped - 'a'] = false;
                }

                inQueue[c - 'a'] = true;
                deque.AddLast(c);
            }

            StringBuilder sb = new StringBuilder();

            while (deque.Count > 0)
            {
                sb.Append(deque.First.Value);
                deque.RemoveFirst();
            }

            return sb.ToString();
        }
    }
}