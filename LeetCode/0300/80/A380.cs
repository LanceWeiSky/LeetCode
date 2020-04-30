using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LeetCode._0300._80
{
    class A380 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class RandomizedSet
        {
            private readonly Dictionary<int, int> _map = new Dictionary<int, int>();
            private readonly List<int> _values = new List<int>();
            private readonly Random _rnd = new Random();

            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (_map.ContainsKey(val))
                {
                    return false;
                }
                _map[val] = _values.Count;
                _values.Add(val);
                return true;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (_map.TryGetValue(val, out var idx))
                {
                    var last = _values.Last();
                    _values[idx] = last;
                    _map[last] = idx;
                    _map.Remove(val);
                    _values.RemoveAt(_values.Count - 1);
                    return true;
                }
                return false;
            }

            /** Get a random element from the set. */
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
