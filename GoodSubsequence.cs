using System;

namespace LeetCode
{
    public class GoodSubsequence
    {
        public int MaximumScore(int[] nums, int k)
        {
            int n = nums.Length;
            int[] min = new int[n];

            min[k] = nums[k];

            for (int i = k - 1; i >= 0; i--)
                min[i] = Math.Min(nums[i], min[i + 1]);

            for (int i = k + 1; i < n; i++)
                min[i] = Math.Min(nums[i], min[i - 1]);

            int max = min[k];
            int l = k, r = k;

            while (true)
            {
                if (l - 1 >= 0)
                    l -= 1;
                if (r + 1 < n)
                    r += 1;

                // check (l, k), (k, r), (l, r)
                int maxOf3 = MaxOf3(min[l] * (k - l + 1), min[r] * (r - k + 1), Math.Min(min[l], min[r]) * (r - l + 1));
                max = Math.Max(max, maxOf3);

                if (l == 0 && r == n)
                    break;
            }

            return max;
        }

        private int MaxOf3(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }
    }
}
