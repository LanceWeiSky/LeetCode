using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A374 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class GuessGame
        {
            public int guess(int num) { return 1; }
        }

        public class Solution : GuessGame
        {
            public int GuessNumber(int n)
            {
                int left = 1;
                int right = n;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    var r = guess(mid);
                    if (r == 0)
                    {
                        return mid;
                    }
                    else if (r < 0)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                return left;
            }
        }
    }
}
