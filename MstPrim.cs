using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MstPrim
    {
        private int GetDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        public int MinCostConnectPoints(int[][] points)
        {
            int N = points.Length;

            Dictionary<int, List<(int, int)>> adj = new Dictionary<int, List<(int, int)>>();

            for (int i = 0; i < N; i++)
                adj[i] = new List<(int, int)>();

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    int cost = this.GetDistance(points[i][0], points[i][1], points[j][0], points[j][1]);
                    adj[i].Add((j, cost));
                    adj[j].Add((i, cost));
                }
            }

            PriorityQueue<(int, int), int> minHeap = new PriorityQueue<(int, int), int>();
            minHeap.Enqueue((0, 0), 0);

            HashSet<int> visited = new HashSet<int>();
            int minCost = 0;

            while (visited.Count < N)
            {
                (int node, int cost) = minHeap.Dequeue();
                if (visited.Contains(node))
                    continue;

                minCost += cost;
                visited.Add(node);
                foreach ((int neiNode, int neiCost) in adj[node])
                {
                    if (!visited.Contains(neiNode))
                        minHeap.Enqueue((neiNode, neiCost), neiCost);
                }
            }

            return minCost;
        }
    }
}
