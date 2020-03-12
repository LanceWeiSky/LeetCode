using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF54 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一棵二叉搜索树，请找出其中第k大的节点

        //深度优先遍历，优先访问右子树，找到第k个节点
        public int KthLargest(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var p = root;
            while(p != null || stack.Count > 0)
            {
                while(p != null)
                {
                    stack.Push(p);
                    p = p.right;
                }

                p = stack.Pop();
                k--;
                if(k == 0)
                {
                    return p.val;
                }
                p = p.left;
            }
            return 0;
        }
    }
}
