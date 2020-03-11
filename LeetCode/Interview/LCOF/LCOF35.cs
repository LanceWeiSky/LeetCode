using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF35 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node() { }
            public Node(int _val, Node _next, Node _random)
            {
                val = _val;
                next = _next;
                random = _random;
            }
        }

        //请实现 copyRandomList 函数，复制一个复杂链表。
        //在复杂链表中，每个节点除了有一个 next 指针指向下一个节点，还有一个 random 指针指向链表中的任意节点或者 null。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/fu-za-lian-biao-de-fu-zhi-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public class Solution
        {
            public Node CopyRandomList(Node head)
            {
                if (head == null)
                {
                    return null;
                }
                Dictionary<Node, Node> cache = new Dictionary<Node, Node>();
                return CloneNode(head, cache);
            }

            private Node CloneNode(Node node, Dictionary<Node, Node> cache)
            {
                if (cache.TryGetValue(node, out var value))
                {
                    return value;
                }
                value = new Node();
                cache[node] = value;
                value.val = node.val;
                value.next = CloneNode(node.next, cache);
                value.random = CloneNode(node.random, cache);
                return value;
            }
        }
    }
}
