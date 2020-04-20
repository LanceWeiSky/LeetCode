using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A295 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class MedianFinder
        {
            private Heap<int> _min = new Heap<int>(false);
            private Heap<int> _max = new Heap<int>(true);

            /** initialize your data structure here. */
            public MedianFinder()
            {

            }

            public void AddNum(int num)
            {
                _min.Push(num);
                _max.Push(_min.Pop());
                if (_max.Count > _min.Count)
                {
                    _min.Push(_max.Pop());
                }
            }

            public double FindMedian()
            {
                if (_min.Count == 0)
                {
                    return 0;
                }
                if (_min.Count > _max.Count)
                {
                    return _min.Peek();
                }
                return (_min.Peek() + _max.Peek()) / 2d;
            }
        }
    }
}
