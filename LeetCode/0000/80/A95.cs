using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A95 : IQuestion
    {
        public void Run()
        {
            var ans = GenerateTrees(3);
        }

        //给定一个整数 n，生成所有由 1 ... n 为节点所组成的二叉搜索树。

        public IList<TreeNode> GenerateTrees(int n)
        {
            return GenerateTree(1, n);
        }

        private List<TreeNode> GenerateTree(int start, int end)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            for (int i = start; i <= end; i++)
            {
                var left = GenerateTree(start, i - 1);
                var right = GenerateTree(i + 1, end);
                if (left.Count == 0 && right.Count == 0)
                {
                    nodes.Add(new TreeNode(i));
                }
                else if (left.Count == 0)
                {
                    foreach (var r in right)
                    {
                        TreeNode node = new TreeNode(i);
                        node.right = r;
                        nodes.Add(node);
                    }
                }
                else if (right.Count == 0)
                {
                    foreach (var l in left)
                    {
                        TreeNode node = new TreeNode(i);
                        node.left = l;
                        nodes.Add(node);
                    }
                }
                else
                {
                    foreach (var r in right)
                    {
                        foreach (var l in left)
                        {
                            TreeNode node = new TreeNode(i);
                            node.left = l;
                            node.right = r;
                            nodes.Add(node);
                        }
                    }
                }
            }
            return nodes;
        }
    }
}
