using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LargestRectangleHistogram
    {
        public int LargestRectangleArea(int[] heights)
        {
            Stack<Pair> stack = new Stack<Pair>();
            int max = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                int start = i;
                int height = heights[i];

                while (stack.Count > 0 && stack.Peek().Height > heights[i])
                {
                    Pair pair = stack.Pop();
                    max = Math.Max(max, pair.Height * (i - pair.Index));
                    start = pair.Index;
                }

                stack.Push(new Pair(start, height));
            }

            while (stack.Count > 0)
            {
                Pair pair = stack.Pop();
                max = Math.Max(max, pair.Height * (heights.Length - pair.Index));
            }

            return max;
        }

        public class Pair
        {
            public int Index { get; set; }
            public int Height { get; set; }

            public Pair(int i, int h)
            {
                this.Index = i;
                this.Height = h;
            }
        }
    }
}
