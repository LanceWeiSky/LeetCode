using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._00
{
    class A303 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class NumArray
        {
            private readonly int[] _cache;

            public NumArray(int[] nums)
            {
                _cache = new int[nums.Length + 1];
                for (int i = 0; i < nums.Length; i++)
                {
                    _cache[i + 1] = _cache[i] + nums[i];
                }
            }

            public int SumRange(int i, int j)
            {
                return _cache[j + 1] - _cache[i];
            }
        }
    }
}
