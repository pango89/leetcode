using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MergeKSortedLists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode head = null, tail = null;

            PriorityQueue<ListNode, int> pq = new PriorityQueue<ListNode, int>();

            for (int i = 0; i < lists.Length; i++)
                if (lists[i] != null)
                    pq.Enqueue(lists[i], lists[i].val);


            while (pq.Count > 0)
            {
                ListNode dqed = pq.Dequeue();

                if (head == null)
                {
                    head = dqed;
                    tail = dqed;
                }
                else
                {
                    tail.next = dqed;
                    tail = tail.next;
                }

                if (dqed.next != null)
                    pq.Enqueue(dqed.next, dqed.next.val);
            }

            return head;
        }
    }
}

