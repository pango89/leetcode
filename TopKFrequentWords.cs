using System.Collections.Generic;

namespace LeetCode
{
    public class TopKFrequentWords
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!map.ContainsKey(word))
                    map.Add(word, 0);
                map[word]++;
            }

            PriorityQueue<string, Pair> pq = new PriorityQueue<string, Pair>(new CustomComparer());

            foreach (KeyValuePair<string, int> kv in map)
            {
                (string key, int val) = kv;
                pq.Enqueue(key, new Pair(key, val));
                if (pq.Count > k)
                    pq.Dequeue();
            }

            string[] output = new string[k];

            int j = k - 1;
            while (pq.Count > 0)
                output[j--] = pq.Dequeue();

            return output;
        }

        public class CustomComparer : IComparer<Pair>
        {
            public int Compare(Pair x, Pair y)
            {
                if (x.Frequency == y.Frequency)
                    return y.Word.CompareTo(x.Word);
                return x.Frequency.CompareTo(y.Frequency);
            }
        }

        public class Pair
        {
            public string Word { get; private set; }
            public int Frequency { get; private set; }

            public Pair(string word, int frequency)
            {
                this.Word = word;
                this.Frequency = frequency;
            }
        }
    }
}