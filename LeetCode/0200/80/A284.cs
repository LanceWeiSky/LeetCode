using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A284 : IQuestion
    {
        public void Run()
        {
            var iterator = new PeekingIterator(new List<int> { 1, 2, 3 }.GetEnumerator());
            iterator.Peek();

        }

        class PeekingIterator
        {
            private readonly IEnumerator<int> _iterator;
            private bool _hasNext = false;
            private int _next = 0;

            // iterators refers to the first element of the array.
            public PeekingIterator(IEnumerator<int> iterator)
            {
                // initialize any member here.
                _iterator = iterator;
                iterator.Reset();
                _hasNext = iterator.MoveNext();
                _next = iterator.Current;
            }

            // Returns the next element in the iteration without advancing the iterator.
            public int Peek()
            {
                return _next;
            }

            // Returns the next element in the iteration and advances the iterator.
            public int Next()
            {
                var v = _next;
                _hasNext = _iterator.MoveNext();
                _next = _iterator.Current;
                return v;
            }

            // Returns false if the iterator is refering to the end of the array of true otherwise.
            public bool HasNext()
            {
                return _hasNext;
            }
        }
    }
}
