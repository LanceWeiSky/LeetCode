using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A437 : IQuestion
    {
        public void Run()
        {
            var node = Utility.ConvertToTreeNode("[1,0,1,1,2,0,-1,0,1,-1,0,-1,0,1,0]");
            new Solution().PathSum(node, 2);
        }

        public class Solution
        {
            public int PathSum(TreeNode root, int sum)
            {
                if (root == null)
                {
                    return 0;
                }
                int prefixSum = 0;
                int count = 0;
                TreeNode prev = null;
                Dictionary<int, int> set = new Dictionary<int, int>();
                Stack<TreeNode> stack = new Stack<TreeNode>();
                while (stack.Count > 0 || root != null)
                {
                    while (root != null)
                    {
                        prefixSum += root.val;
                        if (sum == prefixSum)
                        {
                            count++;
                        }
                        if (set.TryGetValue(prefixSum - sum, out var vc))
                        {
                            count += vc;
                        }
                        set.TryGetValue(prefixSum, out var c);
                        c++;
                        set[prefixSum] = c;
                        stack.Push(root);
                        root = root.left;
                    }

                    root = stack.Peek();
                    if (root.right == null || root.right == prev)
                    {
                        var c = set[prefixSum];
                        c--;
                        if (c == 0)
                        {
                            set.Remove(prefixSum);
                        }
                        else
                        {
                            set[prefixSum] = c;
                        }
                        prefixSum -= root.val;
                        stack.Pop();
                        prev = root;
                        root = null;
                    }
                    else
                    {
                        root = root.right;
                    }
                }
                return count;
            }
        }
    }
}
