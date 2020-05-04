using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._40
{
    class A251 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Vector2D
        {
            private IEnumerator<int> _iterator;
            private bool _hasNext;

            public Vector2D(int[][] v)
            {
                List<int> temp = new List<int>();
                foreach (var vv in v)
                {
                    foreach (var vvv in vv)
                    {
                        temp.Add(vvv);
                    }
                }
                _iterator = temp.GetEnumerator();
                _hasNext = _iterator.MoveNext();
            }

            public int Next()
            {
                if (_hasNext)
                {
                    var value = _iterator.Current;
                    _hasNext = _iterator.MoveNext();
                    return value;
                }
                return -1;
            }

            public bool HasNext()
            {
                return _hasNext;
            }
        }
    }
}
