using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class JumpGameVI
    {
        public int MaxResult(int[] nums, int k)
        {
            int N = nums.Length;
            int[] dp = new int[N];
            LinkedList<int> dq = new LinkedList<int>();

            for (int i = 0; i < N; i++)
            {
                int prevMax = dq.Count == 0 ? 0 : dp[dq.First.Value];
                dp[i] = prevMax + nums[i];

                while (dq.Count > 0 && dp[i] >= dp[dq.Last.Value])
                    dq.RemoveLast();

                dq.AddLast(i);

                while (dq.Count > 0 && i - dq.First.Value >= k)
                    dq.RemoveFirst();
            }

            return dp[N - 1];
        }
    }
}