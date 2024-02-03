using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MinimumMeetingRoom
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            int N = intervals.Length;
            List<Timing> timings = new List<Timing>();

            foreach (int[] interval in intervals)
            {
                timings.Add(new Timing(interval[0], 0));
                timings.Add(new Timing(interval[1], 1));
            }

            // timings.Sort((x, y) => x.value.CompareTo(y.value));
            timings.Sort();

            int maxRooms = 0;
            int currRooms = 0;

            for (int i = 0; i < timings.Count; i++)
            {
                if (timings[i].type == 0)
                {
                    currRooms++;
                    maxRooms = Math.Max(maxRooms, currRooms);
                }
                else
                {
                    currRooms--;
                }
            }

            return maxRooms;
        }

        public class Timing : IComparable<Timing>
        {
            public int value;
            public int type; // 0 for Start, 1 for End

            public Timing(int value, int type)
            {
                this.value = value;
                this.type = type;
            }

            public int CompareTo(Timing y)
            {
                if (this.value == y.value)
                {
                    return y.type.CompareTo(this.type);
                }
                else
                {
                    return this.value.CompareTo(y.value);
                }
            }
        }
    }
}
