using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF68_1 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉搜索树, 找到该树中两个指定节点的最近公共祖先。

        //百度百科中最近公共祖先的定义为：“对于有根树 T 的两个结点 p、q，最近公共祖先表示为一个结点 x，满足 x 是 p、q 的祖先且 x 的深度尽可能大（一个节点也可以是它自己的祖先）。”

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/er-cha-sou-suo-shu-de-zui-jin-gong-gong-zu-xian-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val == q.val)//如果p==q，则任何一个节点都是公共祖先
            {
                return p;
            }

            while (root != null)
            {
                if (p.val > root.val && q.val > root.val)//如果p和q都比root大，则公共祖先在root的右子树
                {
                    root = root.right;
                }
                else if (p.val < root.val && q.val < root.val)//如果p和q都比root小，则公共祖先在root的左子树
                {
                    root = root.left;
                }
                else//p和q在root的两侧，则root是公共祖先
                {
                    return root;
                }
            }
            return null;
        }
    }
}
