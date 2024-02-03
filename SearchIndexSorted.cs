namespace LeetCode
{
    public class SearchIndexSorted
    {
        // public int[] SearchRange(int[] nums, int target)
        // {
        //     return this.SearchRangeUtil(nums, 0, nums.Length - 1, target);
        // }

        // private int[] SearchRangeUtil(int[] arr, int left, int right, int x)
        // {
        //     if (left < 0 || right > arr.Length - 1 || left > right)
        //         return new int[] { -1, -1 };

        //     int mid = left + (right - left) / 2;
        //     int first;
        //     int last;
        //     if (arr[mid] == x)
        //     {
        //         first = mid;
        //         last = mid;

        //         if (left <= mid - 1 && arr[mid - 1] == x)
        //             first = SearchRangeUtil(arr, left, mid - 1, x)[0];
        //         if (mid + 1 <= right && arr[mid + 1] == x)
        //             last = SearchRangeUtil(arr, mid + 1, right, x)[1];
        //     }
        //     else
        //     {
        //         if (arr[mid] > x)
        //             return SearchRangeUtil(arr, left, mid - 1, x);
        //         else
        //             return SearchRangeUtil(arr, mid + 1, right, x);

        //     }

        //     return new int[] { first, last };
        // }

        public int[] SearchRange(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;

            int[] ans = new int[2] { -1, -1 };

            while (l <= r)
            {
                int m = l + (r - l) / 2;

                if (nums[m] < target)
                    l = m + 1;
                else if (nums[m] > target)
                    r = m - 1;
                else
                {
                    int i = m;
                    while (i >= l && nums[i] == target)
                        i--;
                    ans[0] = i + 1;

                    i = m;
                    while (i <= r && nums[i] == target)
                        i++;
                    ans[1] = i - 1;
                    break;
                }
            }

            return ans;
        }
    }
}
