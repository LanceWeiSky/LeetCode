using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0400._00
{
    class A401 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<string> ReadBinaryWatch(int num)
            {
                List<string> ans = new List<string>();
                if (num > 8)
                {
                    return ans;
                }
                int[] h = new int[] { 1, 2, 4, 8 };
                int[] m = new int[] { 1, 2, 4, 8, 16, 32 };
                ReadWatch(ans, h, m, num);
                return ans;
            }

            private void ReadWatch(List<string> ans, int[] h, int[] m, int num)
            {
                for (int i = 0; i < 4; i++)
                {
                    var j = num - i;
                    if (j < 0)
                    {
                        return;
                    }
                    if (j > 5)
                    {
                        continue;
                    }
                    var hs = ReadHours(h, i);
                    var ms = ReadMinutes(m, j);
                    foreach (var hh in hs)
                    {
                        foreach (var mm in ms)
                        {
                            ans.Add($"{hh}:{mm}");
                        }
                    }
                }
            }

            private List<string> ReadHours(int[] h, int count)
            {
                List<string> hs = new List<string>();
                ReadSums(hs, h, 0, count, new List<int> { 0 }, 11, "D1");
                return hs;
            }

            private void ReadSums(List<string> sums, int[] nums, int index, int count, List<int> path, int max, string format)
            {
                if (count == 0)
                {
                    sums.Add(path.Last().ToString(format));
                    return;
                }
                for (int i = index; i < nums.Length; i++)
                {
                    var sum = path.Last() + nums[i];
                    if (sum > max)
                    {
                        return;
                    }
                    path.Add(sum);
                    ReadSums(sums, nums, i + 1, count - 1, path, max, format);
                    path.RemoveAt(path.Count - 1);
                }
            }

            private List<string> ReadMinutes(int[] m, int count)
            {
                List<string> ms = new List<string>();
                ReadSums(ms, m, 0, count, new List<int> { 0 }, 59, "D2");
                return ms;
            }
        }
    }
}
