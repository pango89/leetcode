using System.Collections.Generic;
namespace LeetCode
{
    public class FurthestBuildingReach
    {
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < heights.Length - 1; i++)
            {
                int diff = heights[i + 1] - heights[i];

                if (diff > 0)
                    pq.Enqueue(diff, diff);

                if (pq.Count > ladders)
                    bricks -= pq.Dequeue();

                if (bricks < 0)
                    return i;
            }

            return heights.Length - 1;
        }
    }
}