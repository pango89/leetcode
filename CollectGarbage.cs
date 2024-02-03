namespace LeetCode
{
    public class CollectGarbage
    {
        public int GarbageCollection(string[] garbage, int[] travel)
        {
            int n = garbage.Length;
            int sum = 0;

            int index_g = 0;
            int index_p = 0;
            int index_m = 0;

            for (int i = 0; i < n; i++)
            {
                string s = garbage[i];
                foreach (char c in s)
                {
                    if (c == 'G')
                    {
                        if (index_g < i)
                        {
                            while (index_g < i)
                            {
                                sum += travel[index_g];
                                index_g += 1;
                            }
                        }
                        sum += 1;
                    }
                    else if (c == 'M')
                    {
                        if (index_m < i)
                        {
                            while (index_m < i)
                            {
                                sum += travel[index_m];
                                index_m += 1;
                            }
                        }
                        sum += 1;
                    }
                    else if (c == 'P')
                    {
                        if (index_p < i)
                        {
                            while (index_p < i)
                            {
                                sum += travel[index_p];
                                index_p += 1;
                            }
                        }
                        sum += 1;
                    }
                }
            }

            return sum;
        }
    }
}