using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode
{
    public class Utility
    {
        public static TreeNode ConvertToTreeNode(string str)
        {
            if(string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            str = str.Trim();
            str = str.TrimStart('[');
            str = str.TrimEnd(']');
            var nodes = str.Split(',');
            if(nodes.Length == 0)
            {
                return null;
            }
            TreeNode root = CreateTreeNode(nodes[0]);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;
            while(i < nodes.Length)
            {
                int count = queue.Count;
                for (int j = 0; j < count; j++)
                {
                    var parent = queue.Dequeue();
                    if (i < nodes.Length)
                    {
                        parent.left = CreateTreeNode(nodes[i]);
                        if (parent.left != null)
                        {
                            queue.Enqueue(parent.left);
                        }
                        i++;
                    }
                    if (i < nodes.Length)
                    {
                        parent.right = CreateTreeNode(nodes[i]);
                        if (parent.right != null)
                        {
                            queue.Enqueue(parent.right);
                        }
                        i++;
                    }
                }

            }
            
            return root;
        }

        private static TreeNode CreateTreeNode(string value)
        {
            value = value.Trim();
            if(int.TryParse(value, out var val))
            {
                return new TreeNode(val);
            }
            return null;
        }

        public static Node ConvertToNode(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            str = str.Trim();
            str = str.TrimStart('[');
            str = str.TrimEnd(']');
            var nodes = str.Split(',');
            if (nodes.Length == 0)
            {
                return null;
            }
            Node root = CreateNode(nodes[0]);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int i = 1;
            while (i < nodes.Length)
            {
                int count = queue.Count;
                for (int j = 0; j < count; j++)
                {
                    var parent = queue.Dequeue();
                    if (i < nodes.Length)
                    {
                        parent.left = CreateNode(nodes[i]);
                        if (parent.left != null)
                        {
                            queue.Enqueue(parent.left);
                        }
                        i++;
                    }
                    if (i < nodes.Length)
                    {
                        parent.right = CreateNode(nodes[i]);
                        if (parent.right != null)
                        {
                            queue.Enqueue(parent.right);
                        }
                        i++;
                    }
                }

            }

            return root;
        }

        private static Node CreateNode(string value)
        {
            value = value.Trim();
            if (int.TryParse(value, out var val))
            {
                return new Node() { val = val };
            }
            return null;
        }

    }
}
