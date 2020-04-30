using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class DuplicatedSortedTree<T> : IEnumerable<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly IHashGenerator<T> _hashGenerator;
        private readonly SortedSet<T> _set;
        private readonly Dictionary<T, List<T>> _counter;

        private bool _minHasValue;
        private T _min;
        public T Min
        {
            get
            {
                if (_minHasValue)
                {
                    return _min;
                }
                if (_set.Count > 0)
                {
                    _minHasValue = true;
                }
                _min = _set.Min;
                if (_counter.TryGetValue(_min, out var list))
                {
                    _min = list.Last();
                }
                return _min;

            }
        }

        private bool _maxHasValue;
        private T _max;
        public T Max
        {
            get
            {
                if (_maxHasValue)
                {
                    return _max;
                }
                if (_set.Count > 0)
                {
                    _maxHasValue = true;
                }
                _max = _set.Max;
                if (_counter.TryGetValue(_max, out var list))
                {
                    _max = list.Last();
                }
                return _max;
            }
        }

        private int _count;
        public int Count => _count;
        public int UniqueCount => _set.Count;

        public DuplicatedSortedTree(IHashGenerator<T> hashGenerator = null)
            : this(Comparer<T>.Default, hashGenerator)
        {
        }

        public DuplicatedSortedTree(IComparer<T> comparer, IHashGenerator<T> hashGenerator = null)
        {
            _comparer = comparer;
            _set = new SortedSet<T>(_comparer);
            _hashGenerator = hashGenerator;
            _counter = new Dictionary<T, List<T>>(new EqualityComparer(_comparer, hashGenerator));
        }

        public bool TryGetValue(T equalValue, out T actualValue)
        {
            return _set.TryGetValue(equalValue, out actualValue);
        }

        public T GetKThValue(int k)
        {
            if (k == 0)
            {
                return Min;
            }
            return this.Skip(k).First();
        }

        public int Add(T item)
        {
            _count++;
            if (_counter.TryGetValue(item, out var list))
            {
                AddMaxMinValue(item);
                list.Add(item);
                return list.Count + 1;
            }
            else
            {
                if (_set.Add(item))
                {
                    AddMaxMinValue(item);
                    return 1;
                }
                _counter.Add(item, new List<T> { item });
                return 2;
            }
        }

        public int Remove(T item)
        {
            if (_counter.TryGetValue(item, out var list))
            {
                _count--; 
                RemoveMaxMinValue(item);
                if (list.Last().Equals(item))
                {
                    list.RemoveAt(list.Count - 1);
                }
                else
                {
                    list.Remove(item);
                }
                if (list.Count == 0)
                {
                    _counter.Remove(item);
                }
                return list.Count + 1;
            }
            else
            {
                if (_set.Remove(item))
                {
                    _count--;
                    RemoveMaxMinValue(item);
                    return 0;
                }
                return -1;
            }
        }

        public DuplicatedSortedTreeView GetViewBetween(T lowerValue, T upperValue)
        {
            var view = _set.GetViewBetween(lowerValue, upperValue);
            return new DuplicatedSortedTreeView(view, _counter, _comparer);
        }

        private void AddMaxMinValue(T item)
        {
            if (_count == 1 || _comparer.Compare(item, _min) <= 0)
            {
                _min = item;
                _minHasValue = true;
            }
            if (_count == 1 || _comparer.Compare(item, _max) >= 0)
            {
                _max = item;
                _maxHasValue = true;
            }
        }

        private void RemoveMaxMinValue(T item)
        {
            if (_minHasValue && _comparer.Compare(item, _min) == 0)
            {
                _minHasValue = false;
            }
            if (_maxHasValue && _comparer.Compare(item, _max) == 0)
            {
                _maxHasValue = false;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_set, _counter);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class DuplicatedSortedTreeView : IEnumerable<T>
        {
            private readonly SortedSet<T> _set;
            private readonly Dictionary<T, List<T>> _counter;
            private readonly IComparer<T> _comparer;

            public T Min => _set.Min;
            public T Max => _set.Max;
            public int Count
            {
                get
                {
                    var count = _set.Count;
                    if (_counter.Count > 0)
                    {
                        var min = Min;
                        var max = Max;
                        foreach (var counter in _counter)
                        {
                            if (_comparer.Compare(counter.Key, min) >= 0 && _comparer.Compare(counter.Key, max) <= 0)
                            {
                                count += counter.Value.Count;
                            }
                        }
                    }
                    return count;
                }
            }
            public int UniqueCount => _set.Count;

            internal DuplicatedSortedTreeView(SortedSet<T> set, Dictionary<T, List<T>> counter, IComparer<T> comparer)
            {
                _set = set;
                _counter = counter;
                _comparer = comparer;
            }

            public bool TryGetValue(T equalValue, out T actualValue)
            {
                return _set.TryGetValue(equalValue, out actualValue);
            }

            public T GetKThValue(int k)
            {
                if (k == 0)
                {
                    return Min;
                }
                return this.Skip(k).First();
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new Enumerator(_set, _counter);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class Enumerator : IEnumerator<T>
        {
            private readonly SortedSet<T> _set;
            private readonly Dictionary<T, List<T>> _counter;
            private IEnumerator<T> _iterator;
            private int _currentCount;

            public T Current => _iterator.Current;

            object IEnumerator.Current => Current;

            internal Enumerator(SortedSet<T> set, Dictionary<T, List<T>> counter)
            {
                _set = set;
                _counter = counter;
                Reset();
            }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if (_currentCount > 0)
                {
                    _currentCount--;
                    return true;
                }
                if (_iterator.MoveNext())
                {
                    if (_counter.TryGetValue(_iterator.Current, out var list))
                    {
                        _currentCount = list.Count;
                    }
                }
                return false;
            }

            public void Reset()
            {
                _iterator = _set.GetEnumerator();
                _currentCount = 0;
            }
        }

        private class EqualityComparer : IEqualityComparer<T>
        {
            private readonly IComparer<T> _comparer;
            private readonly IHashGenerator<T> _hash;

            internal EqualityComparer(IComparer<T> comparer, IHashGenerator<T> hash = null)
            {
                _comparer = comparer;
                _hash = hash;
            }

            public bool Equals(T x, T y)
            {
                return _comparer.Compare(x, y) == 0;
            }

            public int GetHashCode(T obj)
            {
                if (_hash != null)
                {
                    return _hash.GetHashCode(obj);
                }
                return obj.GetHashCode();
            }
        }
    }

    public interface IHashGenerator<T>
    {
        int GetHashCode(T obj);
    }

}
