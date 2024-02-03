using System;

namespace LeetCode
{
    public class MaxAreaCake
    {
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);
            int left = 0, right = w, top = 0, bottom = h;

            int maxH = 1, maxW = 1;

            for (int i = 0; i < horizontalCuts.Length; i++)
            {
                int currH = horizontalCuts[i] - top;
                maxH = Math.Max(maxH, currH);
                top = horizontalCuts[i];
            }

            maxH = Math.Max(maxH, bottom - top);

            for (int i = 0; i < verticalCuts.Length; i++)
            {
                int currW = verticalCuts[i] - left;
                maxW = Math.Max(maxW, currW);
                left = verticalCuts[i];
            }

            maxW = Math.Max(maxW, right - left);

            return (int)((long)(maxH % (1e9 + 7)) * (long)(maxW % (1e9 + 7)) % (long)(1e9 + 7));
        }
    }
}