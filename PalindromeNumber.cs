using System;
namespace LeetCode
{
    public class PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            int temp = x;
            int reverse = 0;
            while (temp > 0)
            {
                reverse = 10 * reverse + temp % 10;
                temp /= 10;
            }

            return reverse == x;
        }
    }
}
