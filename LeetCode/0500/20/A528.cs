using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._20
{
    class A528 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {

            private readonly int[] _sum;
            private readonly int _max;
            private readonly Random _rnd = new Random();

            public Solution(int[] w)
            {
                _sum = new int[w.Length];
                for(int i = 0; i < w.Length; i++)
                {
                    _max += w[i];
                    _sum[i] = _max;
                }
                _max++;
            }

            public int PickIndex()
            {
                var pick = _rnd.Next(1, _max);
                var index = Array.BinarySearch(_sum, pick);
                if(index < 0)
                {
                    index = ~index;
                }
                return index;
            }
        }
    }
}
