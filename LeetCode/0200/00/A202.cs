using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A202 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public bool IsHappy(int n)
        {
            int fast = GetNext(n);
            int slow = n;
            while (fast != slow)
            {
                fast = GetNext(GetNext(fast));
                slow = GetNext(slow);
                if (fast == 1 || slow == 1)
                {
                    return true;
                }
            }
            return fast == 1 || slow == 1;
        }

        private int GetNext(int n)
        {
            int result = 0;
            while (n > 0)
            {
                var temp = n % 10;
                result += temp * temp;
                n /= 10;
            }
            return result;
        }
    }
}
