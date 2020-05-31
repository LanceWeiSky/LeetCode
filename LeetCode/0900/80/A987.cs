using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0900._80
{
    class A987 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<IList<int>> VerticalTraversal(TreeNode root)
            {
                if (root == null)
                {
                    return new List<IList<int>>();
                }
                int maxX = 1;
                int minX = 1;
                Dictionary<int, List<int[]>> xMaps = new Dictionary<int, List<int[]>>();
                Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
                queue.Enqueue(new Tuple<TreeNode, int>(root, 1));
                int y = 0;
                while (queue.Count > 0)
                {
                    var count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var temp = queue.Dequeue();
                        maxX = Math.Max(maxX, temp.Item2);
                        minX = Math.Min(minX, temp.Item2);
                        if (!xMaps.TryGetValue(temp.Item2, out var list))
                        {
                            list = new List<int[]>();
                            xMaps.Add(temp.Item2, list);
                        }
                        list.Add(new int[] { temp.Item1.val, y });
                        if (temp.Item1.left != null)
                        {
                            queue.Enqueue(new Tuple<TreeNode, int>(temp.Item1.left, temp.Item2 - 1));
                        }
                        if (temp.Item1.right != null)
                        {
                            queue.Enqueue(new Tuple<TreeNode, int>(temp.Item1.right, temp.Item2 + 1));
                        }
                    }
                    y++;
                }
                List<int>[] ans = new List<int>[maxX - minX + 1];
                foreach (var kp in xMaps)
                {
                    kp.Value.Sort((x, y) =>
                    {
                        var c = x[1].CompareTo(y[1]);
                        if(c == 0)
                        {
                            c = x[0].CompareTo(y[0]);
                        }
                        return c;
                    });
                    ans[kp.Key - minX] = kp.Value.Select(item => item[0]).ToList();
                }
                return ans.Where(list => list != null).ToArray();
            }
        }
    }
}
