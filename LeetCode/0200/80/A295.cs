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
            private DuplicatedSortedSet _min = new DuplicatedSortedSet();
            private DuplicatedSortedSet _max = new DuplicatedSortedSet();

            /** initialize your data structure here. */
            public MedianFinder()
            {

            }

            public void AddNum(int num)
            {
                _min.Push(num);
                _max.Push(_min.PopMax());
                if (_max.Count > _min.Count)
                {
                    _min.Push(_max.PopMin());
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
                    return _min.PeekMax();
                }
                return (_min.PeekMax() + _max.PeekMin()) / 2d;
            }

            private class DuplicatedSortedSet
            {
                private readonly Dictionary<int, NumInfo> _cache = new Dictionary<int, NumInfo>();
                private readonly SortedSet<NumInfo> _set = new SortedSet<NumInfo>(new NumComparer());
                private NumInfo _maxValue;
                private NumInfo _minValue;
                private int _count = 0;
                public int Count => _count;

                public int PopMax()
                {
                    _count--;
                    var max = PeekMaxInternal();
                    max.Count--;
                    if (max.Count == 0)
                    {
                        _cache.Remove(max.Value);
                        _set.Remove(max);
                        _maxValue = _set.Max;
                    }
                    return max.Value;
                }

                public int PopMin()
                {
                    _count--;
                    var min = PeekMinInternal();
                    min.Count--;
                    if (min.Count == 0)
                    {
                        _cache.Remove(min.Value);
                        _set.Remove(min);
                        _minValue = _set.Min;
                    }
                    return min.Value;
                }

                public int PeekMax()
                {
                    return PeekMaxInternal().Value;
                }

                private NumInfo PeekMaxInternal()
                {
                    if(_maxValue == null)
                    {
                        _maxValue = _set.Max;
                    }
                    return _maxValue;
                }

                public int PeekMin()
                {
                    return PeekMinInternal().Value;
                }

                private NumInfo PeekMinInternal()
                {
                    if(_minValue == null)
                    {
                        _minValue = _set.Min;
                    }
                    return _minValue;
                }

                public void Push(int value)
                {
                    if (!_cache.TryGetValue(value, out var info))
                    {
                        info = new NumInfo { Value = value };
                        _cache.Add(value, info);
                        _set.Add(info);
                        if (_maxValue == null || value > _maxValue.Value)
                        {
                            _maxValue = info;
                        }
                        if (_minValue == null || value < _minValue.Value)
                        {
                            _minValue = info;
                        }
                    }
                    info.Count++;
                    _count++;
                }
            }

            private class NumInfo
            {
                public int Value { get; set; }
                public int Count { get; set; }
            }

            private class NumComparer : IComparer<NumInfo>
            {
                public int Compare(NumInfo x, NumInfo y)
                {
                    return x.Value.CompareTo(y.Value);
                }
            }
        }
    }
}
