using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class TopKFrequent
    {
        public int[] TopKFrequent1(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            LinkedList<int>[] buckets = new LinkedList<int>[nums.Length + 1];

            int[] output = new int[k];

            for (int i = 0; i < nums.Length; i++)
            {
                int key = nums[i];
                if (!dict.ContainsKey(key))
                    dict[key] = 1;
                else
                    dict[key]++;
            }

            foreach (KeyValuePair<int, int> item in dict)
            {
                if (buckets[item.Value] == null)
                    buckets[item.Value] = new LinkedList<int>();
                buckets[item.Value].AddLast(item.Key);
            }

            int c = 0;
            for (int i = buckets.Length - 1; i > 0; i--)
            {
                if (c >= k)
                    break;

                if (buckets[i] != null)
                {
                    while (buckets[i].Count > 0)
                    {
                        if (c >= k)
                            break;

                        output[c++] = buckets[i].First();
                        buckets[i].RemoveFirst();
                    }
                }
            }

            return output;
        }

        public class IntMaxCompare : IComparer<int>
        {
            public int Compare(int x, int y) => y.CompareTo(x);
        }

        public int[] TopKFrequent2(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int[] output = new int[k];

            for (int i = 0; i < nums.Length; i++)
            {
                int key = nums[i];
                if (!dict.ContainsKey(key))
                    dict[key] = 1;
                else
                    dict[key]++;
            }

            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            foreach (KeyValuePair<int, int> kv in dict)
            {
                (int key, int val) = kv;

                minHeap.Enqueue(key, val);
                if (minHeap.Count > k)
                    minHeap.Dequeue();
            }

            int j = 0;
            while (minHeap.Count > 0)
                output[j++] = minHeap.Dequeue();

            return output;
        }

        public int[] TopKFrequent3(int[] nums, int k)
        {
            int[] output = new int[k];
            Dictionary<int, int> map = new();

            foreach (int num in nums)
            {
                if (!map.ContainsKey(num))
                    map.Add(num, 0);
                map[num]++;
            }

            LinkedList<int>[] buckets = new LinkedList<int>[nums.Length + 1];

            foreach (KeyValuePair<int, int> kv in map)
            {
                if (buckets[kv.Value] == null)
                    buckets[kv.Value] = new LinkedList<int>();

                buckets[kv.Value].AddLast(kv.Key);
            }

            int i = buckets.Length - 1;
            int j = 0;

            while (i >= 0)
            {
                while (buckets[i] != null && buckets[i].Count > 0 && j < k)
                {
                    output[j++] = buckets[i].Last.Value;
                    buckets[i].RemoveLast();
                }

                i--;
            }

            return output;
        }
    }
}
