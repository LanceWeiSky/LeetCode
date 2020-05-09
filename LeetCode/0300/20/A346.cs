using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A346 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class MovingAverage
        {

            private readonly int[] _buffer;
            private double _sum = 0;
            private int _index = 0;
            private int _count = 0;

            /** Initialize your data structure here. */
            public MovingAverage(int size)
            {
                _buffer = new int[size];
            }

            public double Next(int val)
            {
                if (_count < _buffer.Length)
                {
                    _count++;
                }
                _sum = _sum - _buffer[_index] + val;
                _buffer[_index] = val;
                _index = (_index + 1) % _buffer.Length;
                return _sum / _count;
            }
        }
    }
}
