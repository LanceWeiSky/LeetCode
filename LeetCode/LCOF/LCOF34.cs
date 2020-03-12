using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    public class LCOF34 : IQuestion
    {
        public void Run()
        {
            string input = "[5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1]";
            var node = Utility.ConvertToTreeNode(input);
            var ans = PathSum(node, 22);
        }

        //输入一棵二叉树和一个整数，打印出二叉树中节点值的和为输入整数的所有路径。从树的根节点开始往下一直到叶节点所经过的节点形成一条路径。

        //深度优先遍历的非递归形式
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            List<int> path = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var p = root;
            var prep = root;
            while (p != null || stack.Count > 0)
            {
                bool back = p == null;
                while (p != null)
                {
                    stack.Push(p);
                    path.Add(p.val);
                    sum -= p.val;
                    p = p.left;
                }

                if (stack.Count > 0)
                {
                    if (back)
                    {
                        sum += path[path.Count - 1];
                        path.RemoveAt(path.Count - 1);
                    }
                    p = stack.Peek();

                    if (p.left == null && p.right == null && sum == 0)
                    {
                        ans.Add(new List<int>(path));
                    }
                    if (p.right == null || p.right == prep)
                    {
                        prep = p;
                        p = null;
                        stack.Pop();
                    }
                    else
                    {
                        prep = p;
                        p = p.right;
                    }
                }
            }
            return ans;
        }
    }

}
