using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LeetCode._0100._00
{
    class A117 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树

        //struct Node
        //        {
        //            int val;
        //            Node* left;
        //            Node* right;
        //            Node* next;
        //        }

        //        填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。

        //初始状态下，所有 next 指针都被设置为 NULL。




        //进阶：


        //	你只能使用常量级额外空间。
        //	使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node-ii
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

        private Node _prev;
        private Node _leftHead;

        public Node Connect(Node root)
        {
            _leftHead = root;

            while (_leftHead != null)
            {
                var cur = _leftHead;
                _leftHead = null;
                _prev = null;

                while (cur != null)
                {
                    ProcessChild(cur.left);
                    ProcessChild(cur.right);
                    cur = cur.next;
                }
            }
            return root;
        }

        private void ProcessChild(Node child)
        {
            if (child == null)
            {
                return;
            }
            if (_prev == null)
            {
                _leftHead = child;
            }
            else
            {
                _prev.next = child;
            }
            _prev = child;
        }
    }
}
