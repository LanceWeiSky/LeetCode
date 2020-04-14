﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A133 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给你无向 连通 图中一个节点的引用，请你返回该图的 深拷贝（克隆）。

        //图中的每个节点都包含它的值 val（int） 和其邻居的列表（list[Node]）。

        //class Node
        //        {
        //            public int val;
        //            public List<Node> neighbors;
        //        }



        //        测试用例格式：

        //简单起见，每个节点的值都和它的索引相同。例如，第一个节点值为 1（val = 1），第二个节点值为 2（val = 2），以此类推。该图在测试用例中使用邻接列表表示。

        //邻接列表 是用于表示有限图的无序列表的集合。每个列表都描述了图中节点的邻居集。

        //给定节点将始终是图中的第一个节点（值为 1）。你必须将 给定节点的拷贝 作为对克隆图的引用返回。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/clone-graph
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        public class Solution
        {
            public Node CloneGraph(Node node)
            {
                if (node == null)
                {
                    return null;
                }
                Dictionary<Node, Node> cache = new Dictionary<Node, Node>();
                return Clone(node, cache);
            }

            private Node Clone(Node node, Dictionary<Node, Node> cache)
            {
                if (cache.TryGetValue(node, out var temp))
                {
                    return temp;
                }
                var node2 = new Node(node.val);
                cache[node] = node2;
                foreach (var n in node.neighbors)
                {
                    node2.neighbors.Add(Clone(n, cache));
                }
                return node2;
            }
        }
    }
}
