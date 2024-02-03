using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MinIntervalQuery
    {
        public int[] MinInterval(int[][] intervals, int[] queries)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (int[] interval in intervals)
            {
                int size = interval[1] - interval[0] + 1;
                for (int k = interval[0]; k <= interval[1]; k++)
                {
                    if (map.ContainsKey(k))
                        map[k] = Math.Min(map[k], size);
                    else
                        map.Add(k, size);
                }
            }

            int[] ans = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
                ans[i] = map.ContainsKey(queries[i]) ? map[queries[i]] : -1;

            return ans;
        }
    }
}