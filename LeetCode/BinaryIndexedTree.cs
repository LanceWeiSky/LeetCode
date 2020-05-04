using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class BinaryIndexedTree<T>
    {
        private readonly T[] _c;
        private readonly int _size;
        private readonly Func<T, T, T> _merger;

        public BinaryIndexedTree(int size, Func<T, T, T> merger)
        {
            _size = size + 1;
            _c = new T[_size];
            _merger = merger;
        }

        public void Update(int index, T value)
        {
            index++;
            while (index <= _size)
            {
                _c[index] = _merger(value, _c[index]);
                index += index & -index;
            }
        }

        public T GetSum(int index)
        {
            index++;
            T sum = default;
            while (index > 0)
            {
                sum = _merger(sum, _c[index]);
                index -= index & -index;
            }
            return sum;
        }
    }
}
