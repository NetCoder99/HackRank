using System;
using System.Collections.Generic;
using System.Numerics;

namespace HackRank.LeetCode
{

//  Input: l1 = [2,4,3], l2 = [5,6,4]
//  Output: [7,0,8]
//  Explanation: 342 + 465 = 807.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class LinkListSum
    {
        //ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        //ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));


        //[9]
        //[1,9,9,9,9,9,9,9,9,9]
        public void Execute()
        {
            Stack<int> stck1 = GetStackFromNumber(243);
            Stack<int> stck2 = GetStackFromNumber(564);
            //Stack<int> stck1 = GetStackFromNumber(9);
            //Stack<int> stck2 = GetStackFromNumber(1999999999);

            ListNode l1 = GetLinkedList(stck1);
            ListNode l2 = GetLinkedList(stck2);

            AddTwoNumbers(l1, l2);
        }

        //----------------------------------------------------------------------------
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            BigInteger int1 = GetNumberFromLinkList(l1);
            BigInteger int2 = GetNumberFromLinkList(l2);
            BigInteger sumx = int1 + int2;
            Console.WriteLine("int1:int2 {0}:{1} :: {2}", int1, int2, sumx);
            Stack<int> stck3 = GetStackFromNumber(sumx);
            ListNode rtnList = GetLinkedList(stck3);
            return rtnList;
        }

        //----------------------------------------------------------------------------
        private ListNode GetLinkedList(Stack<int> stck1)
        {
            if (stck1.Count == 0) { return null; }
            return new ListNode(stck1.Pop(), GetLinkedList(stck1));
        }

        //----------------------------------------------------------------------------
        private BigInteger GetNumberFromLinkList(ListNode listNode) {
            Stack<int> stck1 = new Stack<int>();
            ListNode tmpNode = listNode;
            while (tmpNode != null)
            {
                stck1.Push(tmpNode.val);
                tmpNode = tmpNode.next;
            }
            string str1 = "";
            while (stck1.Count > 0)
            { str1 += stck1.Pop(); }
            Console.WriteLine("str1: {0}", str1);
            return BigInteger.Parse(str1);
        }

        //----------------------------------------------------------------------------
        private Stack<int> GetStackFromNumber(BigInteger inpVal)
        {
            Stack<int> stck1 = new Stack<int>();
            foreach (char c in inpVal.ToString()) {
                stck1.Push(int.Parse(c.ToString()));
            }
            return stck1;
        }

    }
}
