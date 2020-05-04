using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A410 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int SplitArray(int[] nums, int m)
            {
                long h = 0;
                long l = 0;
                foreach (var n in nums)
                {
                    if (n > l)
                    {
                        l = n;
                    }
                    h += n;
                }

                while (l <= h)
                {
                    var mid = (l + h) / 2;

                    int cnt = 1;
                    int temp = 0;
                    foreach (var n in nums)
                    {
                        temp += n;
                        if (temp > mid)
                        {
                            cnt++;
                            temp = n;
                        }
                    }
                    if (cnt > m)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        h = mid - 1;
                    }
                }
                return (int)l;
            }
        }
    }
}
