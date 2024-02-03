using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class OpenLockProblem
    {
        public int OpenLock(string[] deadends, string target)
        {
            HashSet<string> deadSet = new HashSet<string>(deadends);

            if (deadSet.Contains(target) || deadSet.Contains("0000"))
                return -1;

            HashSet<string> visited = new HashSet<string>();

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("0000");

            int level = 0;

            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    string str = queue.Dequeue();

                    if (target.Equals(str))
                        return level;

                    IList<string> children = this.GetChildren(str);

                    foreach (string child in children)
                    {
                        if (!deadSet.Contains(child) && !visited.Contains(child))
                        {
                            visited.Add(child);
                            queue.Enqueue(child);
                        }
                    }
                }

                level++;
            }

            return -1;
        }

        private IList<string> GetChildren(string str)
        {
            IList<string> children = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                int digit = (str[i] - '0' + 1) % 10;
                string child = str.Substring(0, i) + digit + str.Substring(i + 1);
                children.Add(child);

                digit = (str[i] - '0' - 1 + 10) % 10;
                child = str.Substring(0, i) + digit + str.Substring(i + 1);
                children.Add(child);
            }

            return children;
        }
    }
}
