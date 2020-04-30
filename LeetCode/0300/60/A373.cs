using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0300._60
{
    class A373 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
            {
                bool reverse = false;
                if (nums1.Length > nums2.Length)
                {
                    var temp = nums1;
                    nums1 = nums2;
                    nums2 = temp;
                    reverse = true;
                }
                SortedDictionary<int, List<int[]>> dic = new SortedDictionary<int, List<int[]>>();
                for (int i = 0; i < nums1.Length; i++)
                {
                    var sum = nums1[i] + nums2[0];
                    if (!dic.TryGetValue(sum, out var list))
                    {
                        list = new List<int[]>();
                        dic.Add(sum, list);
                    }
                    list.Add(new int[] { i, 0 });
                }
                List<IList<int>> ans = new List<IList<int>>();
                while (dic.Count > 0 && k > 0)
                {
                    k--;
                    var min = dic.First();
                    var idx = min.Value.Last();
                    if (min.Value.Count == 1)
                    {
                        dic.Remove(min.Key);
                    }
                    else
                    {
                        min.Value.RemoveAt(min.Value.Count - 1);
                    }
                    if (reverse)
                    {
                        ans.Add(new List<int> { nums2[idx[1]], nums1[idx[0]] });
                    }
                    else
                    {
                        ans.Add(new List<int> { nums1[idx[0]], nums2[idx[1]] });
                    }
                    idx[1]++;
                    if (idx[1] < nums2.Length)
                    {
                        var sum = nums1[idx[0]] + nums2[idx[1]];
                        if (!dic.TryGetValue(sum, out var list))
                        {
                            list = new List<int[]>();
                            dic.Add(sum, list);
                        }
                        list.Add(idx);
                    }
                }
                return ans;
            }
        }
    }
}
