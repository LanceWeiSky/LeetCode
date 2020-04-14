using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A105 : IQuestion
    {
        public void Run()
        {
            var ans = BuildTree(new int[] { 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 });
        }

        //根据一棵树的前序遍历与中序遍历构造二叉树。
        //注意:
        //你可以假设树中没有重复的元素。

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0)
            {
                return null;
            }
            TreeNode root = new TreeNode(preorder[0]);
            var node = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            int j = 0;
            for (int i = 1; i < preorder.Length; i++)
            {
                if (node.val == inorder[j])
                {
                    while (stack.Count > 0 && inorder[j] == stack.Peek().val)
                    {
                        j++;
                        node = stack.Pop();
                    }
                    node.right = new TreeNode(preorder[i]);
                    node = node.right;
                    stack.Push(node);
                }
                else
                {
                    node.left = new TreeNode(preorder[i]);
                    node = node.left;
                    stack.Push(node);
                }

            }
            return root;
        }
    }
}
