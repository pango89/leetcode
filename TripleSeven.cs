using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class TripleSeven
    {
        public string LargestGoodInteger(string num)
        {
            int n = num.Length;
            List<int>[] buckets = new List<int>[10];

            for (int i = 0; i < 10; ++i)
                buckets[i] = new();

            for (int i = 0; i < n; ++i)
                buckets[num[i] - '0'].Add(i);

            int j = 9;

            while (j >= 0)
            {
                var arr = buckets[j];
                int l = arr.Count;

                if (l < 3)
                {
                    --j;
                    continue;
                }

                int last = arr[0];
                int len = 1;

                for (int i = 1; i < l; i++)
                {
                    if (1 + last == arr[i])
                    {
                        len += 1;
                        if (len == 3)
                        {
                            StringBuilder sb = new();
                            sb.Append(num[last]);
                            sb.Append(num[last]);
                            sb.Append(num[last]);
                            return sb.ToString();
                        }
                    }
                    else
                    {
                        len = 1;
                    }

                    last = arr[i];
                }
                --j;
            }

            return String.Empty;
        }
    }
}