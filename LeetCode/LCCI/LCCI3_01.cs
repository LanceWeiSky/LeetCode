using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.LCCI
{
    class LCCI3_01 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class TripleInOne
        {
            private readonly int[] _stack;
            private readonly int[] _indexes = new int[3];
            private readonly int _size;

            public TripleInOne(int stackSize)
            {
                _size = stackSize;
                _stack = new int[stackSize * 3];
                _indexes[1] = stackSize;
                _indexes[2] = stackSize * 2;
            }

            public void Push(int stackNum, int value)
            {
                if (_indexes[stackNum] >= (stackNum + 1) * _size)
                {
                    return;
                }
                _stack[_indexes[stackNum]++] = value;
            }

            public int Pop(int stackNum)
            {
                if (IsEmpty(stackNum))
                {
                    return -1;
                }
                return _stack[--_indexes[stackNum]];
            }

            public int Peek(int stackNum)
            {
                if (IsEmpty(stackNum))
                {
                    return -1;
                }
                return _stack[_indexes[stackNum] - 1];
            }

            public bool IsEmpty(int stackNum)
            {
                return _indexes[stackNum] <= stackNum * _size;
            }
        }
    }
}
