using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class UnionSet
    {
        private readonly int[] _set;
        private readonly int[] _rank;

        public UnionSet(int capacity)
        {
            _set = new int[capacity];
            _rank = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                _set[i] = i;
            }
        }

        public int Find(int x)
        {
            int root = x;
            while (root != _set[root])
            {
                root = _set[root];
            }

            int updated = x;
            while (updated != _set[updated])
            {
                var temp = _set[updated];
                _set[updated] = root;
                updated = temp;
            }
            return root;
        }

        public void Union(int x, int y)
        {
            int xr = Find(x);
            int yr = Find(y);
            if (xr != yr)
            {
                if (_rank[xr] > _rank[yr])
                {
                    _set[yr] = xr;
                    _rank[xr] += _rank[yr] + 1;
                }
                else
                {
                    _set[xr] = yr;
                    _rank[yr] += _rank[xr] + 1;
                }
            }
        }
    }
}
