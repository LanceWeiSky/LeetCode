using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A113 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树和一个目标和，找到所有从根节点到叶子节点路径总和等于给定目标和的路径。
        //说明: 叶子节点是指没有子节点的节点。

        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            List<IList<int>> ans = new List<IList<int>>();
            PathSum(ans, root, new List<int>(), sum);
            return ans;
        }

        private void PathSum(List<IList<int>> ans, TreeNode node, List<int> path, int sum)
        {
            if (node == null)
            {
                return;
            }
            if (node.val == sum && node.left == null && node.right == null)
            {
                var temp = new List<int>(path);
                temp.Add(node.val);
                ans.Add(temp);
                return;
            }

            path.Add(node.val);
            PathSum(ans, node.left, path, sum - node.val);
            PathSum(ans, node.right, path, sum - node.val);
            path.RemoveAt(path.Count - 1);
        }
    }
}
