using System;
namespace LeetCode
{
    public class AddTwoNumbersLL
    {
        public ListNode AddTwoNumbersLLUtil(ListNode l1, ListNode l2, int carry)
        {
            if (l1 == null && l2 == null)
            {
                if (carry == 0)
                    return null;
                else
                    return new ListNode(carry);
            }

            int sum = carry;

            if (l1 != null)
                sum += l1.val;

            if (l2 != null)
                sum += l2.val;

            ListNode head = new ListNode(sum % 10);
            ListNode l1Next = l1?.next;
            ListNode l2Next = l2?.next;

            head.next = AddTwoNumbersLLUtil(l1Next, l2Next, sum / 10);
            return head;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            int carry = 0;
            return AddTwoNumbersLLUtil(l1, l2, carry);
        }
    }
}
