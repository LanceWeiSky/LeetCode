using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A106 : IQuestion
    {
        public void Run()
        {
            var ans = BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });
        }

        //根据一棵树的中序遍历与后序遍历构造二叉树。
        //注意:
        //你可以假设树中没有重复的元素。

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (postorder.Length == 0)
            {
                return null;
            }

            TreeNode root = new TreeNode(postorder[postorder.Length - 1]);
            var node = root;
            int j = inorder.Length - 1;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            for (int i = postorder.Length - 2; i >= 0; i--)
            {
                if (node.val == inorder[j])
                {
                    while (stack.Count > 0 && stack.Peek().val == inorder[j])
                    {
                        j--;
                        node = stack.Pop();
                    }
                    node.left = new TreeNode(postorder[i]);
                    node = node.left;
                    stack.Push(node);
                }
                else
                {
                    node.right = new TreeNode(postorder[i]);
                    node = node.right;
                    stack.Push(node);
                }
            }
            return root;
        }
    }
}
