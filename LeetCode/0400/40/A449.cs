using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._40
{
    class A449 : IQuestion
    {
        public void Run()
        {
            var instance = new Codec();
            var node = Utility.ConvertToTreeNode("[41,37,44,24,39,42,48,1,35,38,40,null,43,46,49,0,2,30,36,null,null,null,null,null,null,45,47,null,null,null,null,null,4,29,32,null,null,null,null,null,null,3,9,26,null,31,34,null,null,7,11,25,27,null,null,33,null,6,8,10,16,null,null,null,28,null,null,5,null,null,null,null,null,15,19,null,null,null,null,12,null,18,20,null,13,17,null,null,22,null,14,null,null,21,23]");
            var str = instance.serialize(node);
            var node2 = instance.deserialize(str);
        }

        public class Codec
        {

            private char[] IntToString(int value)
            {
                char[] cs = new char[2];
                for (int i = 0; i < 2; i++)
                {
                    cs[i] = (char)(value & 0xffff);
                    value >>= 16;
                }
                return cs;
            }

            private int StringToInt(string s, int index)
            {
                int value = s[index + 1];
                value <<= 16;
                value |= s[index];
                return value;
            }

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                StringBuilder builder = new StringBuilder();
                Stack<TreeNode> stack = new Stack<TreeNode>();
                TreeNode prev = null;
                while (root != null || stack.Count > 0)
                {
                    while (root != null)
                    {
                        stack.Push(root);
                        root = root.left;
                    }
                    root = stack.Peek();
                    if (root.right == null || root.right == prev)
                    {
                        prev = root;
                        stack.Pop();
                        builder.Append(IntToString(root.val));
                        root = null;
                    }
                    else
                    {
                        root = root.right;
                    }
                }
                return builder.ToString();
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                if (data.Length == 0 || (data.Length & 1) == 1)
                {
                    return null;
                }
                Stack<int> postorder = new Stack<int>(data.Length / 2);
                for (int i = 0; i < data.Length; i += 2)
                {
                    postorder.Push(StringToInt(data, i));
                }

                TreeNode root = new TreeNode(postorder.Pop());
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);
                var p = root;
                while (postorder.Count > 0)
                {
                    var value = postorder.Pop();
                    var node = new TreeNode(value);
                    if (value > stack.Peek().val)
                    {
                        stack.Peek().right = node;
                        stack.Push(node);
                    }
                    else
                    {
                        TreeNode temp = null;
                        while (stack.Count > 0 && value < stack.Peek().val)
                        {
                            temp = stack.Pop();
                        }
                        temp.left = node;
                        stack.Push(node);
                    }
                }
                return root;
            }
        }
    }
}
