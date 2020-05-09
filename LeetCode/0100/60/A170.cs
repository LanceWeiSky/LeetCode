using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A170 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class TwoSum
        {

            private readonly Dictionary<int, int> _counter = new Dictionary<int, int>();

            /** Initialize your data structure here. */
            public TwoSum()
            {

            }

            /** Add the number to an internal data structure.. */
            public void Add(int number)
            {
                if (_counter.TryGetValue(number, out var count))
                {
                    _counter[number] = count + 1;
                }
                else
                {
                    _counter.Add(number, 1);
                }
            }

            /** Find if there exists any pair of numbers which sum is equal to the value. */
            public bool Find(int value)
            {
                foreach (var num in _counter)
                {
                    var target = value - num.Key;
                    if (_counter.TryGetValue(target, out var count))
                    {
                        if (target != num.Key || count > 1)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
