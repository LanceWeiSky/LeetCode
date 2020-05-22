using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._40
{
    class A652 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            private int _index = 0;
            private readonly List<TreeNode> _ans = new List<TreeNode>();
            private readonly Dictionary<string, int> _hash = new Dictionary<string, int>();
            private readonly Dictionary<int, int> _counter = new Dictionary<int, int>();

            public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
            {
                if (root != null)
                {
                    ComputeSeries(root);
                }
                return _ans;
            }

            private int ComputeSeries(TreeNode node)
            {
                if (node == null)
                {
                    return 0;
                }
                var series = $"{node.val}_{ComputeSeries(node.left)}_{ComputeSeries(node.right)}";
                if (!_hash.TryGetValue(series, out var hash))
                {
                    hash = ++_index;
                    _hash.Add(series, hash);
                }
                if (_counter.TryGetValue(hash, out var count))
                {
                    count++;
                    _counter[hash] = count;
                }
                else
                {
                    count = 1;
                    _counter.Add(hash, count);
                }
                if(count == 2)
                {
                    _ans.Add(node);
                }
                return hash;
            }
        }
    }
}
