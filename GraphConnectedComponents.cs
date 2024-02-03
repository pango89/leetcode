using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class GraphConnectedComponents
    {
        public Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
        public int CountComponents(int n, int[][] edges)
        {
            if (n == 1)
                return 1;

            for (int i = 0; i < n; i++)
                adj.Add(i, new List<int>());

            foreach (int[] edge in edges)
            {
                adj[edge[0]].Add(edge[1]);
                adj[edge[1]].Add(edge[0]);
            }

            HashSet<int> visited = new HashSet<int>();
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (visited.Contains(i))
                    continue;

                this.DFS(i, visited);
                count++;
            }

            return count;
        }

        private void DFS(int node, HashSet<int> visited)
        {
            if (visited.Contains(node))
                return;

            visited.Add(node);

            foreach (int neighbour in this.adj[node])
                this.DFS(neighbour, visited);
        }
    }
}
