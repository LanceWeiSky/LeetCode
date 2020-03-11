using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    public class LCOF37 : IQuestion
    {
        public void Run()
        {
            string input = "[5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1]";
            var node = Utility.ConvertToTreeNode(input);
            var ans = Codec(node);
        }

        //请实现两个函数，分别用来序列化和反序列化二叉树。

        public string Codec(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            StringBuilder builder = new StringBuilder("[");
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int count = 0;
            while (queue.Count > 0)
            {
                count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    if (node == null)
                    {
                        builder.Append("null,");
                    }
                    else
                    {
                        builder.Append($"{node.val},");
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                    }
                }
            }
            int lastNullLength = count * 5;
            builder.Remove(builder.Length - lastNullLength - 1, lastNullLength + 1);
            builder.Append("]");
            return builder.ToString();
        }
    }
}
