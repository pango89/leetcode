using System;
namespace LeetCode
{
    public class Leetcode581
    {
        public int FindUnsortedSubarray(int[] nums)
        {
            int N = nums.Length;

            // End of Left Increasing Seq
            int L = 0;
            while (L < N - 1 && nums[L + 1] >= nums[L])
                L++;

            if (L == N - 1)
                return 0;

            // Start of Right Decreasing Seq
            int R = N - 1;
            while (R > 0 && nums[R - 1] <= nums[R])
                R--;


            // Find Min, Max in Middle Subsequence
            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = L; i <= R; i++)
            {
                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
            }

            // Shrink Left side using Min
            while (L > 0 && nums[L - 1] > min)
                L--;

            // Shrink Right side using Max
            while (R < N - 1 && nums[R + 1] < max)
                R++;

            return R - L + 1;
        }
    }
}
