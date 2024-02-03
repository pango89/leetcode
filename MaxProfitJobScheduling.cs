using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MaxProfitJobScheduling
    {
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            int n = profit.Length;
            int max = 0;
            int[] dp = new int[n];

            List<Job> jobs = new();

            for (int i = 0; i < n; i++)
            {
                jobs.Add(new Job()
                {
                    StartTime = startTime[i],
                    EndTime = endTime[i],
                    Profit = profit[i]
                });
            }

            jobs.Sort((job1, job2) => job1.EndTime - job2.EndTime);

            for (int i = 0; i < n; i++) {
                dp[i] = jobs[i].Profit;
                max = Math.Max(max, dp[i]);
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    bool hasNoOverlap = IsNonOverlapping(jobs[i].StartTime, jobs[i].EndTime, jobs[j].StartTime, jobs[j].EndTime);
                    if (hasNoOverlap)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + jobs[i].Profit);
                        max = Math.Max(max, dp[i]);
                    }
                }
            }

            return max;
        }

        private bool IsNonOverlapping(int s1, int e1, int s2, int e2)
        {
            if ((s2 <= s1) && (e2 <= s1)) return true;
            if ((s2 >= e1) && (e2 >= s1)) return true;

            return false;
        }

        public class Job
        {
            public int StartTime { get; set; }
            public int EndTime { get; set; }
            public int Profit { get; set; }
        }
    }
}
