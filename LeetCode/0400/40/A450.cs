using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._40
{
    class A450 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public TreeNode DeleteNode(TreeNode root, int key)
            {
                if (root == null)
                {
                    return null;
                }
                if (key > root.val)
                {
                    root.right = DeleteNode(root.right, key);
                }
                else if (key < root.val)
                {
                    root.left = DeleteNode(root.left, key);
                }
                else
                {
                    if (root.left != null)
                    {
                        root.val = GetMaxValue(root.left);
                        root.left = DeleteNode(root.left, root.val);
                    }
                    else if (root.right != null)
                    {
                        root.val = GetMinValue(root.right);
                        root.right = DeleteNode(root.right, root.val);
                    }
                    else
                    {
                        root = null;
                    }
                }
                return root;
            }

            private int GetMaxValue(TreeNode node)
            {
                while (node.right != null)
                {
                    node = node.right;
                }
                return node.val;
            }

            private int GetMinValue(TreeNode node)
            {
                while (node.left != null)
                {
                    node = node.left;
                }
                return node.val;
            }
        }
    }
}
