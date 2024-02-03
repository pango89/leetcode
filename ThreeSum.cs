using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class ThreeSumProblem
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            int N = nums.Length;
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(nums);

            if (N < 3)
                return ans;

            for (int i = 0; i < N - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int a = nums[i];

                int l = i + 1;
                int r = N - 1;

                while (l < r)
                {
                    int b = nums[l];
                    int c = nums[r];

                    if (a + b + c == 0)
                    {
                        ans.Add(new List<int>() { a, b, c });

                        while (l < r && nums[l + 1] == b)
                            l++;

                        while (l < r && nums[r - 1] == c)
                            r--;

                        l++;
                        r--;
                    }
                    else if (a + b + c < 0) l++;
                    else r--;
                }
            }

            return ans;
        }
    }
}
