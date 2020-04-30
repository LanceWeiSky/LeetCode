using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0300._80
{
    class A381 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class RandomizedCollection
        {

            private readonly Dictionary<int, HashSet<int>> _idx = new Dictionary<int, HashSet<int>>();
            private readonly List<int> _values = new List<int>();
            private readonly Random _rnd = new Random();

            /** Initialize your data structure here. */
            public RandomizedCollection()
            {

            }

            /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (!_idx.TryGetValue(val, out var set))
                {
                    set = new HashSet<int>();
                    _idx.Add(val, set);
                }
                set.Add(_values.Count);
                _values.Add(val);
                return set.Count == 1;
            }

            /** Removes a value from the collection. Returns true if the collection contained the specified element. */
            public bool Remove(int val)
            {
                if (_idx.TryGetValue(val, out var set) && set.Count > 0)
                {
                    var id = set.First();
                    set.Remove(id);
                    if (id != _values.Count - 1)
                    {
                        var value = _values.Last();
                        _values[id] = value;
                        if (_idx.TryGetValue(value, out var set2))
                        {
                            set2.Remove(_values.Count - 1);
                            set2.Add(id);
                        }
                    }
                    _values.RemoveAt(_values.Count - 1);
                    return true;
                }
                return false;
            }

            /** Get a random element from the collection. */
            public int GetRandom()
            {
                if (_values.Count > 0)
                {
                    return _values[_rnd.Next(_values.Count)];
                }
                return -1;
            }
        }
    }
}
