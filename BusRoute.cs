using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class BusRoute
    {
        public int NumBusesToDestination(int[][] routes, int source, int target)
        {
            if (source == target) return 0;
            int ans = 0;

            Dictionary<int, List<int>> map = new();

            for (int i = 0; i < routes.Length; i++)
            {
                int[] route = routes[i];
                for (int j = 0; j < route.Length; j++)
                {
                    if (!map.ContainsKey(route[j]))
                        map.Add(route[j], new List<int>());

                    map[route[j]].Add(i);
                }
            }

            HashSet<int> visited = new();
            Queue<int> q = new();

            q.Enqueue(source);

            while (q.Count > 0)
            {
                int len = q.Count;
                ans += 1;

                for (int k = 1; k <= len; k++)
                {
                    int curr = q.Dequeue();

                    foreach (int bus in map[curr])
                    {
                        if (visited.Contains(bus)) continue;
                        visited.Add(bus);

                        for (int r = 0; r < routes[bus].Length; r++)
                        {
                            if (routes[bus][r] == target) return ans;
                            q.Enqueue(routes[bus][r]);
                        }
                    }
                }
            }

            return -1;
        }
    }
}