using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A379 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class PhoneDirectory
        {
            private readonly int[] _nums;
            private readonly bool[] _used;
            private int _index = 0;
            private int _maxNumber;

            /** Initialize your data structure here
                @param maxNumbers - The maximum numbers that can be stored in the phone directory. */
            public PhoneDirectory(int maxNumbers)
            {
                _maxNumber = maxNumbers - 1;
                _used = new bool[maxNumbers];
                _nums = new int[maxNumbers];
                for (int i = 0; i < maxNumbers; i++)
                {
                    _nums[i] = i;
                }
            }

            /** Provide a number which is not assigned to anyone.
                @return - Return an available number. Return -1 if none is available. */
            public int Get()
            {
                if (_index > _maxNumber)
                {
                    return -1;
                }
                var i = _nums[_index++];
                _used[i] = true;
                return i;
            }

            /** Check if a number is available or not. */
            public bool Check(int number)
            {
                if (number > _maxNumber || number < 0)
                {
                    return false;
                }
                return !_used[number];
            }

            /** Recycle or release a number. */
            public void Release(int number)
            {
                if (number > _maxNumber || number < 0)
                {
                    return;
                }
                if (_used[number])
                {
                    _nums[--_index] = number;
                    _used[number] = false;
                }
            }
        }
    }
}
