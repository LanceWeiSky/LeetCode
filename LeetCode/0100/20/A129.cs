using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A129 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，它的每个结点都存放一个 0-9 的数字，每条从根到叶子节点的路径都代表一个数字。

        //例如，从根到叶子节点路径 1->2->3 代表数字 123。

        //计算从根到叶子节点生成的所有数字之和。

        //说明: 叶子节点是指没有子节点的节点。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/sum-root-to-leaf-numbers
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int SumNumbers(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return SumNumbers(root, 0);
        }

        private int SumNumbers(TreeNode node, int num)
        {
            num *= 10;
            num += node.val;

            if (node.left == null && node.right == null)
            {
                return num;
            }

            int sum = 0;
            if (node.left != null)
            {
                sum += SumNumbers(node.left, num);
            }
            if (node.right != null)
            {
                sum += SumNumbers(node.right, num);
            }
            return sum;
        }
    }
}
