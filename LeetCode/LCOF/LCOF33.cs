using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF33 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入一个整数数组，判断该数组是不是某二叉搜索树的后序遍历结果。如果是则返回 true，否则返回 false。假设输入的数组的任意两个数字都互不相同。

        public class Solution
        {
            public bool VerifyPostorder(int[] postorder)
            {
                if (postorder.Length <= 2)
                {
                    return true;
                }
                return Verify(postorder, 0, postorder.Length - 1);
            }

            private bool Verify(int[] postorder, int start, int end)
            {
                if (start >= end)
                {
                    return true;
                }
                //end为根节点，比根节点小的是左子树，比根节点大的是右子树
                int i = 0;
                for (i = start; i < end; i++)
                {
                    if (postorder[i] > postorder[end])
                    {
                        break;
                    }
                }
                for (int j = i; j < end; j++)
                {
                    if (postorder[j] < postorder[end])
                    {
                        return false;
                    }
                }
                //递归判断左子树和右子树
                return Verify(postorder, start, i - 1) && Verify(postorder, i, end - 1);
            }
        }
    }
}
