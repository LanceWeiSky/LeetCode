using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    public class LCOF36 : IQuestion
    {
        public void Run()
        {
            string input = "[4,2,5,1,3]";
            var node = Utility.ConvertToNode(input);
            var ans = TreeToDoublyList(node);
        }


        //输入一棵二叉搜索树，将该二叉搜索树转换成一个排序的循环双向链表。要求不能创建任何新的节点，只能调整树中节点指针的指向。


        public Node TreeToDoublyList(Node root)
        {
            if (root == null)
            {
                return root;
            }
            Node head = null;
            Stack<Node> stack = new Stack<Node>();
            var p = root;
            Node prev = null;
            while (p != null || stack.Count > 0)
            {
                while(p != null)
                {
                    stack.Push(p);
                    p = p.left;
                }

                p = stack.Pop();
                var right = p.right;

                if(prev != null)
                {
                    prev.left = p;
                }
                p.right = prev;
                prev = p;
                if(head == null)
                {
                    head = p;
                }

                p = right;
            }
            if(prev != null && head != null)
            {
                prev.left = head;
                head.right = prev;
            }
            return head;

        }
    }
}
