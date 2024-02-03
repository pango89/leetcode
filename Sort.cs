using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Sort
    {
        public int[] SortArray(int[] nums)
        {
            QuickSort(nums, 0, nums.Length - 1);
            return nums;
        }

        public void QuickSort(int[] nums, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(nums, low, high);
                QuickSort(nums, low, pivot - 1);
                QuickSort(nums, pivot + 1, high);
            }
        }

        public int Partition(int[] nums, int low, int high)
        {
            int pivotItem = nums[low];
            int left = low;
            int right = high;

            while (left < right)
            {
                while (left <= right && pivotItem >= nums[left])
                    left++;
                while (left <= right && pivotItem < nums[right])
                    right--;

                if (left < right)
                {
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                }
            }

            nums[low] = nums[right];
            nums[right] = pivotItem;
            return right;
        }
    }
}
