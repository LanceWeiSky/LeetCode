using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._60
{
    class A278 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class VersionControl
        {
            public bool IsBadVersion(int version) { return false; }
        }

        public class Solution : VersionControl
        {
            public int FirstBadVersion(int n)
            {
                int left = 1;
                int right = n;
                while (left <= right)
                {
                    int pivot = left + (right - left) / 2;
                    if (IsBadVersion(pivot))
                    {
                        right = pivot - 1;
                    }
                    else
                    {
                        left = pivot + 1;
                    }
                }
                return left;
            }
        }
    }
}
