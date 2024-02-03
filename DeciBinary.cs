using System;
namespace LeetCode
{
    public class DeciBinary
    {
        public int MinPartitions(string n)
        {
            int max = 1;
            foreach (char c in n)
            {
                int digit = Convert.ToInt32(c - '0');
                max = Math.Max(max, digit);
            }

            return max;
        }
    }
}