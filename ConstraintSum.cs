using System;

namespace LeetCode
{
    public class ConstraintSubsequenceSum
    {
        public int ConstrainedSubsetSum(int[] nums, int k)
        {
            int n = nums.Length;
            int[] dp = new int[n];

            int max = nums[0];
            dp[0] = nums[0];

            for (int j = 0; j < n; j++)
            {
                for (int i = j - 1; j - i <= k && i >= 0; i--)
                {
                    dp[j] = Math.Max(dp[j], nums[j] + dp[i]);
                    max = Math.Max(max, dp[j]);
                }
            }

            return max;
        }
    }
}
