using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class CountConnectedCompo
    {
        public Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
        HashSet<int> visited = new HashSet<int>();

        public int CountComponents(int n, int[][] edges)
        {
            for (int i = 0; i < n; i++)
                adj.Add(i, new List<int>());

            foreach (int[] edge in edges)
            {
                adj[edge[0]].Add(edge[1]);
                adj[edge[1]].Add(edge[0]);
            }

            int res = 0;

            for (int i = 0; i < n; i++)
                if (this.DFS(i))
                    res++;

            return res;
        }

        private bool DFS(int node)
        {
            if (this.visited.Contains(node))
                return false;

            this.visited.Add(node);

            foreach (int child in this.adj[node])
                this.DFS(child);

            return true;
        }
    }
}
