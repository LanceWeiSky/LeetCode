using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF68_2 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。

        //百度百科中最近公共祖先的定义为：“对于有根树 T 的两个结点 p、q，最近公共祖先表示为一个结点 x，满足 x 是 p、q 的祖先且 x 的深度尽可能大（一个节点也可以是它自己的祖先）。”

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/er-cha-shu-de-zui-jin-gong-gong-zu-xian-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == root || q == root)//若p和q有和root相等的，则root是公共祖先
            {
                return root;
            }

            var left = lowestCommonAncestor(root.left, p, q);//从左子树寻找公共祖先
            var right = lowestCommonAncestor(root.right, p, q);//从右子树寻找公共祖先
            if (left == null)//若左子树没找到，则公共祖先在右子树
            {
                return right;
            }
            if (right == null)//若右子树没找到，则公共祖先在左子树
            {
                return left;
            }
            return root;//左右子树都找到了，说明找到的不是公共祖先，而是p和q节点，则root是公共祖先
        }
    }
}
