namespace LeetCode
{
    public class SearchRotatedSorted
    {
        public int Search(int[] nums, int target)
        {
            return SearchUtil(nums, 0, nums.Length - 1, target);
        }

        private int SearchUtil(int[] arr, int left, int right, int x)
        {
            if (left < 0 || right > arr.Length - 1 || left > right)
                return -1;

            int mid = left + (right - left) / 2;

            if (arr[mid] == x)
                return mid;

            // Left Side Sorted Increasing
            if (arr[left] < arr[mid])
            {
                if (arr[left] <= x && x <= arr[mid])
                    return SearchUtil(arr, left, mid - 1, x);
                else
                    return SearchUtil(arr, mid + 1, right, x);
            }
            // Right Side sorted increasing
            else if (arr[mid] < arr[left])
            {
                if (arr[mid] <= x && x <= arr[right])
                    return SearchUtil(arr, mid + 1, right, x);
                else
                    return SearchUtil(arr, left, mid - 1, x);
            }
            // Left to Mid is all repeated
            else
            {
                // Check if right is different or not
                if (arr[mid] != arr[right])
                    return SearchUtil(arr, mid + 1, right, x);
                else
                {
                    // Need to search both left and right sides
                    int result = SearchUtil(arr, left, mid - 1, x);
                    if (result != -1)
                        return result;
                    // Not found in left hence Serach right also
                    return SearchUtil(arr, mid + 1, right, x);
                }
            }
        }
    }
}
