using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class GraphValidTree
    {
        public Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

        public bool ValidTree(int n, int[][] edges)
        {
            if (n == 1)
                return true;

            for (int i = 0; i < n; i++)
                adj.Add(i, new List<int>());

            foreach (int[] edge in edges)
            {
                adj[edge[0]].Add(edge[1]);
                adj[edge[1]].Add(edge[0]);
            }

            HashSet<int> visited = new HashSet<int>();

            // There should not be any cycle && All the nodes should be connected
            return this.DFS(0, visited, -1) && visited.Count == n;
        }

        public bool DFS(int node, HashSet<int> visited, int parent)
        {
            if (visited.Contains(node))
                return false;

            visited.Add(node);

            foreach (int child in this.adj[node])
            {
                if (child == parent)
                    continue;

                if (this.DFS(child, visited, node) == false)
                    return false;
            }

            return true;
        }
    }
}
