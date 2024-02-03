using System.Collections.Generic;

namespace LeetCode
{
    public class LastStoneWeight
    {
        public int GetLastStoneWeight(int[] stones)
        {
            // Max Heap
            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));

            foreach (int stone in stones)
                maxHeap.Enqueue(stone, stone);

            while (maxHeap.Count > 1)
            {
                int y = maxHeap.Dequeue();
                int x = maxHeap.Dequeue();

                if (x < y)
                    maxHeap.Enqueue(y - x, y - x);
            }

            return maxHeap.Count == 0 ? 0 : maxHeap.Peek();
        }
    }
}