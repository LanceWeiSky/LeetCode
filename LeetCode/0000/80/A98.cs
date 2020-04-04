using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A98 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，判断其是否是一个有效的二叉搜索树。

        //假设一个二叉搜索树具有如下特征：


        //	节点的左子树只包含小于当前节点的数。
        //	节点的右子树只包含大于当前节点的数。
        //	所有左子树和右子树自身必须也是二叉搜索树。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/validate-binary-search-tree
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public bool IsValidBST(TreeNode root)
        {
            var p = root;
            long min = long.MinValue;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Count > 0 || p != null)
            {
                while (p != null)
                {
                    stack.Push(p);
                    p = p.left;
                }

                p = stack.Pop();
                if (p.val <= min)
                {
                    return false;
                }
                min = p.val;
                p = p.right;
            }
            return true;
        }
    }
}
