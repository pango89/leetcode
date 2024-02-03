using System;
using System.Collections.Generic;
namespace LeetCode
{
    public class TwoSum
    {
        public int[] GetTwoSum(int[] nums, int target)
        {
            int[] ans = new int[2];
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (!map.ContainsKey(num))
                    map.Add(num, new List<int>());

                map[num].
                    Add(i);
            }

            for (int indexA = 0; indexA < nums.Length; indexA++)
            {
                int diff = target - nums[indexA];
                if (map.ContainsKey(diff))
                {
                    List<int> indexesB = map[diff];
                    for (int j = 0; j < indexesB.Count; j++)
                    {
                        int indexB = indexesB[j];
                        if (indexA != indexB)
                        {
                            ans[0] = indexA;
                            ans[1] = indexB;
                            return ans;
                        }
                    }
                }
            }

            return ans;
        }
    }
}
