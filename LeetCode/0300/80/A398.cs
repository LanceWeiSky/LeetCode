using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A398 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            private readonly Dictionary<int, List<int>> _idxes;
            private readonly Random _rnd = new Random();

            public Solution(int[] nums)
            {
                _idxes = new Dictionary<int, List<int>>(nums.Length);
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!_idxes.TryGetValue(nums[i], out var list))
                    {
                        list = new List<int>();
                        _idxes.Add(nums[i], list);
                    }
                    list.Add(i);
                }
            }

            public int Pick(int target)
            {
                if (_idxes.TryGetValue(target, out var list))
                {
                    return list[_rnd.Next(list.Count)];
                }
                return -1;
            }
        }
    }
}
