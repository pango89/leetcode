using System;
namespace LeetCode
{
    public class MedianSortedArray
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int lenA = nums1.Length;
            int lenB = nums2.Length;

            if (lenA > lenB)
                return FindMedianSortedArrays(nums2, nums1);

            int total = lenA + lenB;
            // Real Half Index in Merged array
            int half = total / 2;

            int l = 0;
            int r = lenA;

            while (true)
            {
                int mid1 = (l + r) / 2;
                int mid2 = half - mid1;

                int leftA = mid1 == 0 ? int.MinValue : nums1[mid1 - 1];
                int rightA = mid1 == lenA ? int.MaxValue : nums1[mid1];
                int leftB = mid2 == 0 ? int.MinValue : nums2[mid2 - 1];
                int rightB = mid2 == lenB ? int.MaxValue : nums2[mid2];

                if (leftA <= rightB && leftB <= rightA)
                {
                    if (total % 2 == 0)
                        return (Math.Max(leftA, leftB) + Math.Min(rightA, rightB)) / 2.0;
                    return Math.Min(rightA, rightB);
                }

                else if (leftA > rightB)
                    r = mid1 - 1;
                else
                    l = mid1 + 1;
            }
        }
    }
}
