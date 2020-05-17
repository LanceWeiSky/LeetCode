using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0300._00
{
    class A314 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<IList<int>> VerticalOrder(TreeNode root)
            {
                if (root == null)
                {
                    return new List<IList<int>>();
                }
                Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
                int min = 0;
                int max = 0;
                Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
                queue.Enqueue(new Tuple<TreeNode, int>(root, 0));
                while (queue.Count > 0)
                {
                    var temp = queue.Dequeue();
                    if (temp.Item2 < min)
                    {
                        min = temp.Item2;
                    }
                    if (temp.Item2 > max)
                    {
                        max = temp.Item2;
                    }
                    if (map.TryGetValue(temp.Item2, out var list))
                    {
                        list.Add(temp.Item1.val);
                    }
                    else
                    {
                        list = new List<int> { temp.Item1.val };
                        map.Add(temp.Item2, list);
                    }
                    if (temp.Item1.left != null)
                    {
                        queue.Enqueue(new Tuple<TreeNode, int>(temp.Item1.left, temp.Item2 - 1));
                    }
                    if (temp.Item1.right != null)
                    {
                        queue.Enqueue(new Tuple<TreeNode, int>(temp.Item1.right, temp.Item2 + 1));
                    }
                }
                IList<int>[] bucket = new List<int>[max - min + 1];
                foreach (var kp in map)
                {
                    bucket[kp.Key - min] = kp.Value;
                }
                return bucket.ToList();
            }
        }
    }
}
