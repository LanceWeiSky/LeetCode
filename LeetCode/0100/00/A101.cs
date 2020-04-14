using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A101 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，检查它是否是镜像对称的。

        public bool IsSymmetric(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var n1 = queue.Dequeue();
                var n2 = queue.Dequeue();

                if (n1 == null && n2 == null)
                {
                    continue;
                }
                else if (n1 == null || n2 == null)
                {
                    return false;
                }
                else if (n1.val != n2.val)
                {
                    return false;
                }
                queue.Enqueue(n1.left);
                queue.Enqueue(n2.right);
                queue.Enqueue(n1.right);
                queue.Enqueue(n2.left);
            }
            return true;
        }
    }
}
