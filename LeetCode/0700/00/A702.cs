using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._00
{
    class A702 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        class ArrayReader
        {
            public int get(int index) { return 0; }
        }

        class Solution
        {
            public int Search(ArrayReader reader, int target)
            {
                int left = 0;
                int right = 1;
                while(reader.get(right) < target)
                {
                    left = right;
                    right <<= 1;
                }
                while(left <= right)
                {
                    var mid = left + ((right - left) >> 1);
                    var temp = reader.get(mid);
                    if (temp == target)
                    {
                        return mid;
                    }
                    else if (temp < target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                return -1;
            }
        }
    }
}
