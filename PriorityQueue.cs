using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class PriorityQueue
    {
        public List<int> arr;

        public PriorityQueue()
        {
            this.arr = new List<int>();
        }

        public void Add(int x)
        {
            this.arr.Add(x);
            if (this.arr.Count == 1)
                return;

            int lastParentIndex = (this.arr.Count / 2) - 1;

            for (int i = lastParentIndex; i >= 0; i--)
                this.Heapify(i);

            Console.WriteLine("[{0}]", string.Join(", ", this.arr));
        }

        public void Heapify(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            int largest = index;

            if (leftChildIndex < this.arr.Count && arr[leftChildIndex] > arr[largest])
                largest = leftChildIndex;

            if (rightChildIndex < this.arr.Count && arr[rightChildIndex] > arr[largest])
                largest = rightChildIndex;

            if (largest != index)
            {
                int temp = arr[largest];
                arr[largest] = arr[index];
                arr[index] = temp;

                this.Heapify(largest);
            }
        }

        public int Peek()
        {
            return this.arr.Count > 0 ? this.arr[0] : int.MinValue;
        }

        public int Poll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int x)
        {
            throw new NotImplementedException();
        }

        public bool Contains(int x)
        {
            throw new NotImplementedException();
        }
    }
}
