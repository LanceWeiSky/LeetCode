using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A428 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }


        public class Codec
        {
            private char[] IntToChars(int value)
            {
                char[] cs = new char[2];
                cs[0] = (char)(value & 0xffff);
                value >>= 16;
                cs[1] = (char)(value & 0xffff);
                return cs;
            }

            private int CharsToInt(string s, int index)
            {
                int value = s[index + 1];
                value <<= 16;
                value |= s[index];
                return value;
            }

            // Encodes a tree to a single string.
            public string serialize(Node root)
            {
                if (root == null)
                {
                    return string.Empty;
                }
                StringBuilder builder = new StringBuilder();
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    builder.Append(IntToChars(node.val));
                    if (node.children == null)
                    {
                        builder.Append((char)0);
                    }
                    else
                    {
                        builder.Append((char)node.children.Count);
                        foreach (var child in node.children)
                        {
                            queue.Enqueue(child);
                        }
                    }
                }
                return builder.ToString();
            }

            // Decodes your encoded data to tree.
            public Node deserialize(string data)
            {
                if (string.IsNullOrEmpty(data))
                {
                    return null;
                }
                int index = 0;
                var value = CharsToInt(data, index);
                index += 2;
                Node root = new Node(value, new List<Node>());
                int childrenCount = data[index++];

                Queue<Tuple<Node, int>> queue = new Queue<Tuple<Node, int>>();
                queue.Enqueue(new Tuple<Node, int>(root, childrenCount));
                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    for (int i = 0; i < node.Item2; i++)
                    {
                        var child = new Node(CharsToInt(data, index), new List<Node>());
                        index += 2;
                        childrenCount = data[index++];
                        queue.Enqueue(new Tuple<Node, int>(child, childrenCount));
                        node.Item1.children.Add(child);
                    }
                }

                return root;
            }
        }
    }
}
