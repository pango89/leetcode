using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Interval
    {
        public int start, end;

        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }

    public class MeetingRooms
    {
        public bool CanAttendMeetings(List<Interval> intervals)
        {
            if (intervals.Count <= 1)
                return true;

            Interval prev = intervals[0];

            for (int i = 1; i < intervals.Count; i++)
            {
                Interval curr = intervals[i];

                if (prev.end > curr.start)
                    return false;
            }

            return true;
        }
    }
}
