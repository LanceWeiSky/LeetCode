using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF27 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //请完成一个函数，输入一个二叉树，该函数输出它的镜像。

        public TreeNode MirrorTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            var temp = root.left;
            root.left = root.right;
            root.right = temp;
            MirrorTree(root.left);
            MirrorTree(root.right);
            return root;
        }
    }
}
