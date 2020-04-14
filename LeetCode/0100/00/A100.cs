using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A100 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定两个二叉树，编写一个函数来检验它们是否相同。
        //如果两个树在结构上相同，并且节点具有相同的值，则认为它们是相同的。

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p != null && q != null)
            {
                return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }

            return p == null && q == null;
        }
    }
}
