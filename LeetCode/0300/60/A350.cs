using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A350 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[] Intersect(int[] nums1, int[] nums2)
            {
                if (nums1.Length > nums2.Length)
                {
                    var temp = nums1;
                    nums1 = nums2;
                    nums2 = temp;
                }
                if (nums1.Length == 0)
                {
                    return new int[0];
                }
                Dictionary<int, int> counter = new Dictionary<int, int>(nums1.Length);
                foreach (var n in nums1)
                {
                    if (counter.TryGetValue(n, out var count))
                    {
                        counter[n] = count + 1;
                    }
                    else
                    {
                        counter.Add(n, 1);
                    }
                }
                List<int> ans = new List<int>();
                foreach (var n in nums2)
                {
                    if (counter.TryGetValue(n, out var count) && count > 0)
                    {
                        ans.Add(n);
                        if (--count == 0)
                        {
                            counter.Remove(n);
                            if (counter.Count == 0)
                            {
                                return ans.ToArray();
                            }
                        }
                        else
                        {
                            counter[n] = count;
                        }
                    }
                }
                return ans.ToArray();
            }
        }
    }
}
