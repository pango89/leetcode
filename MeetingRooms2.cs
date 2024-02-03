using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MeetingRooms2
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            List<(int, int)> timings = new List<(int, int)>();

            foreach (int[] interval in intervals)
            {
                // 0 for Start, 1 for End
                timings.Add((interval[0], 0));
                timings.Add((interval[1], 1));
            }

            timings.Sort((x, y) => x.Item1 != y.Item1 ? x.Item1 - y.Item1 : y.Item2 - x.Item2);

            int max = 0;
            int curr = 0;

            for (int i = 0; i < timings.Count; i++)
            {
                if (timings[i].Item2 == 0)
                {
                    curr++;
                    max = Math.Max(max, curr);
                }
                else
                    curr--;
            }

            return max;
        }

        public int MinMeetingRooms1(int[][] intervals)
        {
            int[] starts = new int[intervals.Length];
            int[] ends = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                starts[i] = intervals[i][0];
                ends[i] = intervals[i][1];
            }

            Array.Sort(starts);
            Array.Sort(ends);

            int s = 0, e = 0, ans = 0, count = 0;

            while (s < intervals.Length)
            {
                if (starts[s] < ends[e])
                {
                    s++;
                    count++;
                }
                else
                {
                    e++;
                    count--;
                }

                ans = Math.Max(ans, count);
            }

            return ans;
        }
    }
}
