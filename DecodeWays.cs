using System;
namespace LeetCode
{
    public class DecodeWays
    {
        public int NumDecodings(string s)
        {
            int N = s.Length;

            int[] dp = new int[N + 1];
            dp[N] = 1;

            for (int i = N - 1; i >= 0; i--)
            {
                dp[i] = s[i] == '0' ? 0 : dp[i + 1];

                if (i + 1 < N)
                {
                    if (s[i] == '1' || (s[i] == '2' && s[i + 1] < '7'))
                        dp[i] += dp[i + 2];
                }
            }

            return dp[0];
        }
    }
}
