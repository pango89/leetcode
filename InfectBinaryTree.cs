using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class InfectBinaryTree
    {
        private Dictionary<int, List<int>> adj = new();
        public int AmountOfTime(TreeNode root, int start)
        {
            PreOrder(root);
            return BFS(start);
        }

        private int BFS(int start)
        {
            Queue<int> q = new();
            q.Enqueue(start);

            HashSet<int> visited = new();
            int ans = -1;

            while (q.Count > 0)
            {
                ans++;
                int count = q.Count;

                for (int i = 1; i <= count; i++)
                {
                    int dqed = q.Dequeue();
                    visited.Add(dqed);

                    foreach (int nbr in adj[dqed])
                    {
                        if (visited.Contains(nbr)) continue;
                        q.Enqueue(nbr);
                    }
                }
            }

            return ans;
        }

        private void PreOrder(TreeNode root)
        {
            if (root == null) return;

            if (!adj.ContainsKey(root.val))
                adj.Add(root.val, new List<int>());

            if (root.left != null)
            {
                if (!adj.ContainsKey(root.left.val))
                    adj.Add(root.left.val, new List<int>());

                adj[root.val].Add(root.left.val);
                adj[root.left.val].Add(root.val);
            }

            if (root.right != null)
            {
                if (!adj.ContainsKey(root.right.val))
                    adj.Add(root.right.val, new List<int>());

                adj[root.val].Add(root.right.val);
                adj[root.right.val].Add(root.val);
            }

            PreOrder(root.left);
            PreOrder(root.right);
        }
    }
}
