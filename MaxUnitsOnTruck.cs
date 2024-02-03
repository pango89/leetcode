using System;

namespace LeetCode
{
    public class MaxUnitsOnTruck
    {
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            int[] count = new int[1001];
            foreach (int[] boxType in boxTypes)
                count[boxType[1]] += boxType[0];

            int max = 0;
            for (int i = 1000; i > 0; i--)
            {
                if (truckSize <= 0)
                    break;

                if (count[i] == 0)
                    continue;

                int moved = Math.Min(truckSize, count[i]);
                max += moved * i;
                truckSize -= moved;
            }

            return max;
        }

        public int MaximumUnits1(int[][] boxTypes, int truckSize)
        {
            Array.Sort(boxTypes, (a, b) => b[1] - a[1]);

            int max = 0;
            foreach (int[] boxType in boxTypes)
            {
                if (truckSize <= 0)
                    break;

                int moved = Math.Min(truckSize, boxType[0]);
                max += moved * boxType[1];
                truckSize -= moved;
            }

            return max;
        }
    }
}
