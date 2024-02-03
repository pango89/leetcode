using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class QueueReconstructHeight
    {
        public int[][] ReconstructQueue(int[][] people)
        {
            // Array.Sort(people, (a, b) => b[0] - a[0]);
            Array.Sort(people, (a, b) => a[0] != b[0] ? b[0] - a[0] : a[1] - b[1]);

            List<int[]> res = new List<int[]>();

            foreach (int[] pair in people)
                res.Insert(pair[1], pair);

            return res.ToArray();
        }
    }
}