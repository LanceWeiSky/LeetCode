using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LeetCode._1100._00
{
    class A1116 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class ZeroEvenOdd
        {
            private int n;
            private readonly AutoResetEvent _zero = new AutoResetEvent(true);
            private readonly AutoResetEvent _even = new AutoResetEvent(false);
            private readonly AutoResetEvent _odd = new AutoResetEvent(false);

            public ZeroEvenOdd(int n)
            {
                this.n = n;
            }

            // printNumber(x) outputs "x", where x is an integer.
            public void Zero(Action<int> printNumber)
            {
                for (int i = 1; i <= n; i++)
                {
                    _zero.WaitOne();
                    printNumber(0);
                    if ((i & 1) == 1)
                    {
                        _odd.Set();
                    }
                    else
                    {
                        _even.Set();
                    }
                }
            }

            public void Even(Action<int> printNumber)
            {
                for (int i = 2; i <= n; i += 2)
                {
                    _even.WaitOne();
                    printNumber(i);
                    _zero.Set();
                }
            }

            public void Odd(Action<int> printNumber)
            {
                for (int i = 1; i <= n; i += 2)
                {
                    _odd.WaitOne();
                    printNumber(i);
                    _zero.Set();
                }
            }
        }
    }
}
