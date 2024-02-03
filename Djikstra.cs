using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Djikstra
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            HashSet<int> visited = new HashSet<int>();
            List<(int, int)>[] adj = new List<(int, int)>[n + 1];

            for (int i = 1; i <= n; i++)
                adj[i] = new List<(int, int)>();

            foreach (int[] tt in times)
                adj[tt[0]].Add((tt[1], tt[2]));

            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();

            pq.Enqueue((k, 0), 0);

            int ans = 0;

            while (pq.Count > 0)
            {
                (int node, int dist) = pq.Dequeue();

                if (visited.Contains(node))
                    continue;

                visited.Add(node);
                ans = dist;

                foreach (var neighbor in adj[node])
                {
                    int newDist = dist + neighbor.Item2;
                    pq.Enqueue((neighbor.Item1, newDist), newDist);
                }
            }

            return visited.Count == n ? ans : -1;
        }
    }
}
