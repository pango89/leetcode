using System;
namespace LeetCode
{
    public class BuySellStock
    {
        public int MaxProfit(int[] prices)
        {
            int N = prices.Length;

            if (N <= 1)
                return 0;

            int min = prices[0];
            int maxDiff = 0;

            for (int i = 1; i < N; i++)
            {
                min = Math.Min(min, prices[i]);
                maxDiff = Math.Max(maxDiff, prices[i] - min);
            }

            return maxDiff;
        }
    }
}
