using System.Collections.Generic;

namespace LeetCode
{
    public class HandOfStraights
    {
        public bool IsNStraightHand(int[] hand, int groupSize)
        {
            int N = hand.Length;
            if (N % groupSize != 0) return false;

            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            Dictionary<int, int> countMap = new Dictionary<int, int>();
            foreach (int card in hand)
            {
                if (!countMap.ContainsKey(card))
                {
                    countMap.Add(card, 0);
                    minHeap.Enqueue(card, card);
                }
                countMap[card]++;
            }

            while (minHeap.Count > 0)
            {
                int first = minHeap.Dequeue();
                int num = countMap[first];
                if (num > 0)
                {
                    for (int i = 1; i < groupSize; i++)
                    {
                        if (!countMap.ContainsKey(first + i) || countMap[first + i] < num)
                            return false;
                        else
                            countMap[first + i] = countMap[first + i] - num;
                    }
                }
            }

            return true;
        }
    }
}
