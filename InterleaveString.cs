namespace LeetCode
{
    public class InterleaveString
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            int M = s1.Length;
            int N = s2.Length;

            if (M + N != s3.Length)
                return false;

            bool[,] dp = new bool[M + 1, N + 1];
            dp[M, N] = true;

            for (int i = M - 1; i >= 0; i--)
                dp[i, N] = s3[i + N] == s1[i] && dp[i + 1, N];
            
            for (int i = N - 1; i >= 0; i--)
                dp[M, i] = s3[M + i] == s2[i] && dp[M, i + 1];

            for (int i = M - 1; i >= 0; i--)
            {
                for (int j = N - 1; j >= 0; j--)
                {
                    int k = i + j;

                    if (s1[i] == s3[k] && s2[j] == s3[k])
                        dp[i, j] = dp[i + 1, j] || dp[i, j + 1];
                    else if (s1[i] == s3[k])
                        dp[i, j] = dp[i + 1, j];
                    else if (s2[j] == s3[k])
                        dp[i, j] = dp[i, j + 1];
                }
            }

            return dp[0, 0];
        }
    }
}