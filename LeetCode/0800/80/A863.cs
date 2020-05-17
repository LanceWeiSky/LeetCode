using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0800._80
{
    class A863 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
            {
                List<int> ans = new List<int>();
                var map = GetParentMapping(root);
                HashSet<TreeNode> seen = new HashSet<TreeNode>();
                seen.Add(target);
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(target);
                while (queue.Count > 0)
                {
                    if (K == 0)
                    {
                        foreach (var p in queue)
                        {
                            ans.Add(p.val);
                        }
                        break;
                    }
                    K--;
                    var c = queue.Count;
                    for (int i = 0; i < c; i++)
                    {
                        var p = queue.Dequeue();
                        if (p.left != null && seen.Add(p.left))
                        {
                            queue.Enqueue(p.left);
                        }
                        if (p.right != null && seen.Add(p.right))
                        {
                            queue.Enqueue(p.right);
                        }
                        if (map.TryGetValue(p, out var parent) && seen.Add(parent))
                        {
                            queue.Enqueue(parent);
                        }
                    }
                }
                return ans;
            }

            private Dictionary<TreeNode, TreeNode> GetParentMapping(TreeNode node)
            {
                Dictionary<TreeNode, TreeNode> map = new Dictionary<TreeNode, TreeNode>();
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(node);
                while (queue.Count > 0)
                {
                    var p = queue.Dequeue();
                    if(p.left != null)
                    {
                        map[p.left] = p;
                        queue.Enqueue(p.left);
                    }
                    if (p.right != null)
                    {
                        map[p.right] = p;
                        queue.Enqueue(p.right);
                    }
                }
                return map;
            }
        }
    }
}
