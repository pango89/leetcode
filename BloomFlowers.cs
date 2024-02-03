using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class BloomFlowers
    {
        public int[] FullBloomFlowers(int[][] flowers, int[] people)
        {
            SortedDictionary<int, int> blooms = new();

            foreach (int[] flower in flowers)
            {
                int start = flower[0];
                int end = flower[1] + 1;

                if (!blooms.ContainsKey(start))
                    blooms.Add(start, 0);
                blooms[start]++;

                if (!blooms.ContainsKey(end))
                    blooms.Add(end, 0);
                blooms[end]--;
            }

            // Cumulative Sum in Same Dict
            int sum = 0;
            foreach (var kvp in blooms.ToList())
            {
                sum += kvp.Value;
                blooms[kvp.Key] = sum;
            }

            int[] answer = new int[people.Length];
            int[] keys = blooms.Keys.ToArray();

            for (int i = 0; i < people.Length; i++)
            {
                int p = people[i];

                if (blooms.ContainsKey(p))
                {
                    answer[i] = blooms[p];
                    continue;
                }

                // Floor Binary Search into the Keys List and use the value of found key
                int index = BinarySearchFloor(keys, p);
                if (index == -1)
                    answer[i] = 0;
                else if (blooms.ContainsKey(keys[index]))
                    answer[i] = blooms[keys[index]];
            }

            return answer;
        }

        private int BinarySearchFloor(int[] arr, int num)
        {
            int l = 0;
            int r = arr.Length - 1;
            int index = -1;

            while (l <= r)
            {
                int m = l + (r - l) / 2;

                if (arr[m] < num)
                {
                    l = m + 1;
                    index = m;
                }
                else if (num < arr[m])
                {
                    r = m - 1;
                }
                else
                {
                    return m;
                }
            }

            return index;
        }
    }
}
