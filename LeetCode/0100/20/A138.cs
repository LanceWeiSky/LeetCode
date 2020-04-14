using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A138 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个链表，每个节点包含一个额外增加的随机指针，该指针可以指向链表中的任何节点或空节点。

        //要求返回这个链表的 深拷贝。 

        //我们用一个由 n 个节点组成的链表来表示输入/输出中的链表。每个节点用一个[val, random_index] 表示：



        //    val：一个表示 Node.val 的整数。

        //    random_index：随机指针指向的节点索引（范围从 0 到 n-1）；如果不指向任何节点，则为  null 。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/copy-list-with-random-pointer
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public Node CopyRandomList(Node head)
        {
            Dictionary<Node, Node> cache = new Dictionary<Node, Node>();
            return Copy(head, cache);
        }

        private Node Copy(Node node, Dictionary<Node, Node> cache)
        {
            if (node == null)
            {
                return null;
            }
            if(cache.TryGetValue(node, out var c))
            {
                return c;
            }
            c = new Node(node.val);
            cache[node] = c;
            c.next = Copy(node.next, cache);
            c.random = Copy(node.random, cache);
            return c;
        }
    }
}
