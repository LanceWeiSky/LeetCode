using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A281 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class ZigzagIterator
        {
            private readonly IList<int>[] _values = new IList<int>[2];
            private int[] _pointers = new int[2];
            private int _index = 0;

            public ZigzagIterator(IList<int> v1, IList<int> v2)
            {
                _values[0] = v1;
                _values[1] = v2;
            }

            public bool HasNext()
            {
                for (int i = 0; i < _pointers.Length; i++)
                {
                    if (_pointers[i] < _values[i].Count)
                    {
                        return true;
                    }
                }
                return false;
            }

            public int Next()
            {
                int temp = _index;
                while (_pointers[_index] >= _values[_index].Count)
                {
                    _index = (_index + 1) % _pointers.Length;
                    if (_index == temp)
                    {
                        return -1;
                    }
                }
                var value = _values[_index][_pointers[_index]];
                _pointers[_index]++;
                _index = (_index + 1) % _pointers.Length;
                return value;
            }
        }
    }
}
