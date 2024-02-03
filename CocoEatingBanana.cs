using System;
using System.Linq;

namespace LeetCode
{
    public class CocoEatingBanana
    {
        public int MinEatingSpeed(int[] piles, int h)
        {
            int l = 1;
            int r = piles.Max();

            while (l < r)
            {
                int k = l + (r - l) / 2;

                int hrs = this.GetHoursForK(piles, k);

                if (hrs <= h)
                    r = k;
                else
                    l = k + 1;
            }

            return r;
        }

        private int GetHoursForK(int[] piles, int k)
        {
            int total = 0;
            foreach (int p in piles)
            {
                if (p % k == 0) total += p / k;
                else
                    total += (1 + p / k);
            }

            return total;
        }
    }
}