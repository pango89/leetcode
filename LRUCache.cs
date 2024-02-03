using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class LRUCache
    {
        private class DLLNode
        {
            public int Key;
            public int Value;
            public DLLNode Prev;
            public DLLNode Next;

            public DLLNode(int key, int value)
            {
                Key = key;
                Value = value;
                Prev = null;
                Next = null;
            }
        }

        private int capacity;
        private int count;

        private Dictionary<int, DLLNode> cache = new Dictionary<int, DLLNode>();
        private DLLNode head;
        private DLLNode tail;

        // Adding ALWAYS happens agter Head dummy node
        private void AddNode(DLLNode node)
        {
            node.Prev = head;
            node.Next = head.Next;
            head.Next = node;
            node.Next.Prev = node;
        }

        private void RemoveNode(DLLNode node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;

            node.Prev = null;
            node.Next = null;
        }

        private void MoveToHead(DLLNode node)
        {
            RemoveNode(node);
            AddNode(node);
        }

        private DLLNode RemoveLast()
        {
            DLLNode prev = this.tail.Prev;
            this.RemoveNode(prev);
            return prev;
        }

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.count = 0;

            this.head = new DLLNode(0, 0);
            this.tail = new DLLNode(0, 0);

            this.head.Next = this.tail;
            this.tail.Prev = this.head;
        }

        public int Get(int key)
        {
            if (this.cache.ContainsKey(key))
            {
                DLLNode node = cache[key];
                MoveToHead(node);
                return node.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (this.cache.ContainsKey(key))
            {
                DLLNode node = this.cache[key];
                node.Value = value;
                this.MoveToHead(node);
            }
            else
            {
                DLLNode node = new DLLNode(key, value);

                if (this.count == this.capacity)
                {
                    DLLNode removed = this.RemoveLast();
                    this.cache.Remove(removed.Key);

                    this.AddNode(node);
                }
                else
                {
                    this.AddNode(node);
                    this.count++;
                }

                this.cache.Add(key, node);
            }
        }
    }
}
