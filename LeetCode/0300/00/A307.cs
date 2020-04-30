using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._00
{
    class A307 : IQuestion
    {
        public void Run()
        {
            var n = new NumArray(new int[] { -1 });
            n.SumRange(0, 0);
            n.Update(0, 1);
            n.SumRange(0, 0);
        }

        public class NumArray
        {

            private readonly int[] _tree;
            private readonly int _length;

            public NumArray(int[] nums)
            {
                _length = nums.Length;
                _tree = new int[_length * 2];
                Array.Copy(nums, 0, _tree, _length, _length);
                BuildTree();
            }

            private void BuildTree()
            {
                for (int i = _length - 1; i > 0; i--)
                {
                    _tree[i] = _tree[i * 2] + _tree[i * 2 + 1];
                }
            }

            public void Update(int i, int val)
            {
                i += _length;
                val -= _tree[i];
                while (i > 0)
                {
                    _tree[i] += val;
                    i /= 2;
                }
            }

            public int SumRange(int i, int j)
            {
                i += _length;
                j += _length;
                int sum = 0;
                while (i <= j)
                {
                    if ((i & 1) == 1)
                    {
                        sum += _tree[i];
                        i++;
                    }
                    if ((j & 1) == 0)
                    {
                        sum += _tree[j];
                        j--;
                    }
                    i /= 2;
                    j /= 2;
                }
                return sum;
            }
        }
    }
}
