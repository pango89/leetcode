using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Permutation
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            HashSet<int> temp = new HashSet<int>();

            this.PermuteUtil(result, temp, nums);

            return result;
        }

        private void PermuteUtil(IList<IList<int>> result, HashSet<int> temp, int[] nums)
        {
            if (temp.Count == nums.Length)
            {
                result.Add(new List<int>(temp));
                Console.WriteLine("[{0}]", string.Join(", ", temp));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (temp.Contains(nums[i]))
                    continue;

                temp.Add(nums[i]);
                this.PermuteUtil(result, temp, nums);
                temp.Remove(nums[i]);
            }
        }
    }
}
