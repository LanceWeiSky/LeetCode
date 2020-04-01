using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A23 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //合并 k 个排序链表，返回合并后的排序链表。请分析和描述算法的复杂度。

        //示例:

        //输入:
        //[
        //  1->4->5,
        //  1->3->4,
        //  2->6
        //]
        //        输出: 1->1->2->3->4->4->5->6

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/merge-k-sorted-lists
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode dummy = new ListNode(0);
            var temp = dummy;
            List<ComparableNode> nodes = new List<ComparableNode>();
            foreach (var list in lists)
            {
                if (list != null)
                {
                    nodes.Add(new ComparableNode(list));
                }
            }
            Heap<ComparableNode> heap = new Heap<ComparableNode>(nodes, false);
            while(heap.Count > 0)//利用最小堆选出最小值
            {
                temp.next = heap.Pop().Node;
                temp = temp.next;
                if(temp.next != null)
                {
                    heap.Push(new ComparableNode(temp.next));
                }
            }
            return dummy.next;
        }

        internal class ComparableNode : IComparable
        {
            internal ListNode Node { get; }

            internal ComparableNode(ListNode node)
            {
                Node = node;
            }

            public int CompareTo(object obj)
            {
                return Node.val.CompareTo((obj as ComparableNode).Node.val);
            }
        }
    }
}
