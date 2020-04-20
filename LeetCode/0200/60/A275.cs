using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._60
{
    class A275 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int HIndex(int[] citations)
            {
                int l = 0;
                int r = citations.Length - 1;
                while (l <= r)
                {
                    int mid = (l + r) / 2;
                    if (citations.Length - mid <= citations[mid])
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                return citations.Length - l;
            }
        }
    }
}
