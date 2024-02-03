using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Subset
    {
        public void SubsetsOfSet(int[] set)
        {
            List<List<int>> powerSet = new List<List<int>>();
            List<int> temp = new List<int>();

            Util(powerSet, temp, set, 0);
            PrintPowerSet(powerSet);
        }

        private void Util(List<List<int>> powerSet, List<int> temp, int[] set, int start)
        {
            powerSet.Add(new List<int>(temp));
            for (int i = start; i < set.Length; i++)
            {
                temp.Add(set[i]);
                Util(powerSet, temp, set, i + 1);
                temp.RemoveAt(temp.Count - 1);
            }
        }

        private void PrintPowerSet(List<List<int>> powerSet)
        {
            for (int i = 0; i < powerSet.Count; i++)
            {
                Console.WriteLine("[{0}]", string.Join(", ", powerSet[i]));
            }
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            return SubsetUtil(nums, nums.Length - 1);
        }

        public IList<IList<int>> SubsetUtil(int[] nums, int idx)
        {
            IList<IList<int>> final = new List<IList<int>>();
            if (idx == 0)
            {
                final.Add(new List<int>());
                final.Add(new List<int>() { nums[idx] });
                return final;
            }

            IList<IList<int>> rem = SubsetUtil(nums, idx - 1);

            for (int i = 0; i < rem.Count; i++)
            {
                final.Add(rem[i]);
                IList<int> newList = new List<int>(rem[i]);
                newList.Add(nums[idx]);
                final.Add(newList);
            }

            return final;
        }
    }
}
