using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0200._20
{
    class A229 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public IList<int> MajorityElement(int[] nums)
        {
            Dictionary<int, int> elements = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (elements.ContainsKey(n))
                {
                    elements[n]++;
                }
                else
                {
                    if (elements.Count < 2)
                    {
                        elements[n] = 1;
                    }
                    else
                    {
                        foreach (var k in elements.Keys.ToList())
                        {
                            elements[k]--;
                            if (elements[k] == 0)
                            {
                                elements.Remove(k);
                            }
                        }
                    }
                }
            }

            foreach (var k in elements.Keys.ToList())
            {
                elements[k] = 0;
            }

            List<int> ans = new List<int>();
            var count = nums.Length / 3;
            foreach (var n in nums)
            {
                if (elements.ContainsKey(n))
                {
                    elements[n]++;
                    if (elements[n] > count)
                    {
                        ans.Add(n);
                        elements.Remove(n);
                    }
                }
            }
            return ans;
        }
    }
}
