using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class SlidingWindow
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int N = nums.Length;
            int[] ans = new int[N - k + 1];

            // Monotonically Decreasing Queue
            LinkedList<int> deque = new LinkedList<int>();
            int l = 0;
            int r = 0;

            while (r < N)
            {
                while (deque.Count > 0 && nums[deque.Last.Value] < nums[r])
                    deque.RemoveLast();
                deque.AddLast(r);

                if (deque.First.Value < l)
                    deque.RemoveFirst();

                if (r + 1 >= k)
                {
                    ans[l] = nums[deque.First.Value];
                    l++;
                }

                r++;
            }

            return ans;
        }

        public int[] MinSlidingWindow(int[] nums, int k)
        {
            int N = nums.Length;
            int[] ans = new int[N - k + 1];

            // Monotonically Increasing Queue
            LinkedList<int> deque = new LinkedList<int>();
            int l = 0;
            int r = 0;

            while (r < N)
            {
                while (deque.Count > 0 && nums[deque.Last.Value] > nums[r])
                    deque.RemoveLast();
                deque.AddLast(r);

                if (deque.First.Value < l)
                    deque.RemoveFirst();

                if (r + 1 >= k)
                {
                    ans[l] = nums[deque.First.Value];
                    l++;
                }

                r++;
            }

            return ans;
        }
    }
}
