using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF7 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入某二叉树的前序遍历和中序遍历的结果，请重建该二叉树。假设输入的前序遍历和中序遍历的结果中都不含重复的数字。

        //思路解析：
        //前序遍历先访问的是根节点，然后是左子树和右子树。
        //中序遍历先访问左子树，再访问根节点，然后是右子树。
        //1.由前序遍历结果首先能知道根节点必然是preorder的第一个数字。
        //2.inorder的特性是左子树在根节点之前，右子树在根节点之后，我们可以根据这个特性确认preorder中接下来的数字是左子树还是右子树。
        //3.重复1,2的过程找到左右子树。
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null || preorder.Length == 0 || inorder.Length == 0)
            {
                return null;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>(preorder.Length);//用一个栈存储当前访问路径
            TreeNode root = new TreeNode(preorder[0]);//根节点是前序遍历的第一个元素
            stack.Push(root);
            int j = 0;
            for (int i = 1; i < preorder.Length; i++)
            {
                var preNode = stack.Peek();//前一个访问的节点，有两种情况，1.他是父节点。2.他是左叶子节点
                if (inorder[j] == preNode.val)//相等有两种情况，1.他是某一颗子二叉树的根节点。2.他是左叶子节点
                {
                    while (stack.Count > 0 && stack.Peek().val == inorder[j])//处理左叶子节点的情况，遇到第一个值不相同的节点就是根节点
                    {
                        preNode = stack.Pop();
                        j++;
                    }
                    //由于当前节点在根节点之后，所以他是一个又子节点
                    preNode.right = new TreeNode(preorder[i]);
                    stack.Push(preNode.right);
                }
                else//如果不相等，则代表当前节点是一个左子节点
                {
                    preNode.left = new TreeNode(preorder[i]);
                    stack.Push(preNode.left);
                }
            }
            return root;
        }
    }
}
