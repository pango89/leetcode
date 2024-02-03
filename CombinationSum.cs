using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class CombinationSum
    {
        public IList<IList<int>> GetCombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> final = new List<IList<int>>();
            IList<int> current = new List<int>();

            Array.Sort(candidates);
            Util(final, current, candidates, 0, target);


            return final;
        }

        public void Util(IList<IList<int>> final, IList<int> current, int[] nums, int start, int target)
        {
            if (target < 0)
                return;

            if (target == 0)
            {
                final.Add(new List<int>(current));
                Console.WriteLine("[{0}]", string.Join(", ", current));
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                if (nums[i] <= target)
                {
                    current.Add(nums[i]);
                    Util(final, current, nums, i, target - nums[i]);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
    }
}
