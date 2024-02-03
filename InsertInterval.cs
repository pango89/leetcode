using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class InsertInterval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0)
                return new int[][] { newInterval };

            List<int[]> result = new List<int[]>();
            foreach (int[] interval in intervals)
            {
                if (newInterval[1] < interval[0])
                {
                    result.Add(newInterval);
                    newInterval = interval;
                    continue;
                }

                if (newInterval[0] > interval[1])
                {
                    result.Add(interval);
                    continue;
                }

                newInterval[0] = Math.Min(newInterval[0], interval[0]);
                newInterval[1] = Math.Max(newInterval[1], interval[1]);
            }

            result.Add(newInterval);
            return result.ToArray();
        }
    }
}
