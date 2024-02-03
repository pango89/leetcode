using System;

namespace LeetCode
{
    public class DestroyMonster
    {
        public int EliminateMaximum(int[] dist, int[] speed)
        {
            int n = dist.Length;
            double[] time = new double[n];

            for (int i = 0; i < n; ++i)
                time[i] = (double)dist[i] / speed[i];

            Array.Sort(time);

            int count = 0;
            double currTime = 0.0;

            for (int i = 0; i < n; ++i)
            {
                if (time[i] > currTime)
                    ++count;
                else
                    return count;

                currTime++;
            }

            return count;
        }
    }
}