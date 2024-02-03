using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MergeInterval
    {
        public int[][] Merge(int[][] intervals)
        {
            int N = intervals.Length;
            if (N == 1)
                return intervals;

            // Sort by Start Time
            Array.Sort(intervals, (a, b) => a[0] - b[0]);
            List<int[]> result = new List<int[]>();

            int[] prev = intervals[0];

            for (int i = 1; i < N; i++)
            {
                int[] curr = intervals[i];

                if (prev[1] < curr[0])
                {
                    result.Add(prev);
                    prev = curr;
                    continue;
                }

                prev[1] = Math.Max(prev[1], curr[1]);
            }

            result.Add(prev);
            return result.ToArray();
        }
    }
}
