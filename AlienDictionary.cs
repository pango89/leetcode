using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class AlienDictionary
    {
        public Dictionary<char, HashSet<char>> adj;
        public Dictionary<char, int> inDegree;

        public string AlienOrder(string[] words)
        {
            this.adj = new Dictionary<char, HashSet<char>>();
            this.inDegree = new Dictionary<char, int>();

            foreach (string w in words)
            {
                foreach (char c in w)
                {
                    if (!this.adj.ContainsKey(c))
                        this.adj.Add(c, new HashSet<char>());

                    if (!this.inDegree.ContainsKey(c))
                        this.inDegree.Add(c, 0);
                }
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                string w1 = words[i];
                string w2 = words[i + 1];

                int minLen = Math.Min(w1.Length, w2.Length);
                if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0, minLen))
                    return "";

                for (int j = 0; j < minLen; j++)
                {
                    if (w1[j] != w2[j])
                    {
                        if (!this.adj[w1[j]].Contains(w2[j]))
                        {
                            this.adj[w1[j]].Add(w2[j]);
                            this.inDegree[w2[j]]++;
                        }
                        break;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            Queue<char> queue = new Queue<char>();

            foreach (KeyValuePair<char, int> item in this.inDegree)
                if (item.Value == 0)
                    queue.Enqueue(item.Key);


            int count = 0;
            while (queue.Count > 0)
            {
                char node = queue.Dequeue();
                sb.Append(node);

                foreach (char child in this.adj[node])
                {
                    this.inDegree[child]--;
                    if (this.inDegree[child] == 0)
                        queue.Enqueue(child);
                }

                count++;
            }

            if (count != this.inDegree.Keys.Count)
                return "";

            return sb.ToString();
        }
    }
}
