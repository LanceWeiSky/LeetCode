using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A116 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个完美二叉树，其所有叶子节点都在同一层，每个父节点都有两个子节点。二叉树定义如下：

        //struct Node
        //        {
        //            int val;
        //            Node* left;
        //            Node* right;
        //            Node* next;
        //        }

        //        填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。

        //初始状态下，所有 next 指针都被设置为 NULL。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        public Node Connect(Node root)
        {
            if (root == null)
            {
                return null;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var c = queue.Count;
                Node p = null;
                for (int i = 0; i < c; i++)
                {
                    if (p == null)
                    {
                        p = queue.Dequeue();
                    }
                    else
                    {
                        p.next = queue.Dequeue();
                        p = p.next;
                    }
                    if (p.left != null)
                    {
                        queue.Enqueue(p.left);
                    }
                    if (p.right != null)
                    {
                        queue.Enqueue(p.right);
                    }
                }
            }
            return root;
        }
    }
}
