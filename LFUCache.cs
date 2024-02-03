using System.Collections.Generic;

namespace LeetCode
{
    public class LFUCache
    {
        private class Node
        {
            public int Key;
            public int Value;
            public int frequency;

            public Node Prev;
            public Node Next;

            public Node(int key, int value)
            {
                Key = key;
                Value = value;
                frequency = 1;

                Prev = null;
                Next = null;
            }
        }

        private class DoublyLinkedList
        {
            private readonly Node head;
            private readonly Node tail;
            public int Count = 0;

            public DoublyLinkedList()
            {
                this.head = new Node(0, 0);
                this.tail = new Node(0, 0);

                this.head.Next = this.tail;
                this.tail.Prev = this.head;
            }

            // Adding ALWAYS happens after Head dummy node
            public void AddNode(Node node)
            {
                node.Prev = head;
                node.Next = head.Next;
                head.Next = node;
                node.Next.Prev = node;
                this.Count++;
            }

            public void RemoveNode(Node node)
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;

                node.Prev = null;
                node.Next = null;
                this.Count--;
            }

            public Node RemoveLast()
            {
                if (this.Count == 0)
                    return null;

                Node prev = this.tail.Prev;
                this.RemoveNode(prev);
                return prev;
            }
        }

        private readonly int capacity;
        private int count;
        private int minFrequency;

        private readonly Dictionary<int, Node> cache;
        private readonly Dictionary<int, DoublyLinkedList> frequencyMap;

        public LFUCache(int capacity)
        {
            this.capacity = capacity;
            this.count = 0;

            this.cache = new Dictionary<int, Node>();
            this.frequencyMap = new Dictionary<int, DoublyLinkedList>();
        }

        public int Get(int key)
        {
            if (!this.cache.ContainsKey(key))
                return -1;

            Node node = this.cache[key];
            this.UpdateFrequency(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (this.capacity == 0)
                return;

            if (this.cache.ContainsKey(key))
            {
                Node node = this.cache[key];
                node.Value = value;
                this.UpdateFrequency(node);
            }
            else
            {
                Node node = new Node(key, value);

                if (this.count == this.capacity)
                {
                    Node nodeRemoved = this.frequencyMap[this.minFrequency].RemoveLast();
                    this.cache.Remove(nodeRemoved.Key);
                    this.count--;
                }

                this.minFrequency = 1;

                if (!this.frequencyMap.ContainsKey(node.frequency))
                    this.frequencyMap[node.frequency] = new DoublyLinkedList();
                this.frequencyMap[node.frequency].AddNode(node);

                this.cache.Add(key, node);
                this.count++;
            }
        }

        private void UpdateFrequency(Node node)
        {
            DoublyLinkedList list = this.frequencyMap[node.frequency];
            list.RemoveNode(node);

            if (list.Count == 0 && node.frequency == this.minFrequency)
                this.minFrequency++;

            node.frequency++;

            if (!this.frequencyMap.ContainsKey(node.frequency))
                this.frequencyMap[node.frequency] = new DoublyLinkedList();
            this.frequencyMap[node.frequency].AddNode(node);
        }
    }
}
