using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A429 : IQuestion
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


        public class Solution
        {
            public IList<IList<int>> LevelOrder(Node root)
            {
                List<IList<int>> res = new List<IList<int>>();
                if (root == null)
                {
                    return res;
                }
                Queue<List<Node>> queue = new Queue<List<Node>>();
                queue.Enqueue(new List<Node> { root });
                while (queue.Count > 0)
                {
                    var nodes = queue.Dequeue();
                    List<int> temp = new List<int>();
                    List<Node> nexts = new List<Node>();
                    foreach (var n in nodes)
                    {
                        temp.Add(n.val);
                        if (n.children != null && n.children.Count > 0)
                        {
                            nexts.AddRange(n.children);
                        }
                    }
                    if (nexts.Count > 0)
                    {
                        queue.Enqueue(nexts);
                    }
                    res.Add(temp);
                }
                return res;
            }
        }
    }
}
