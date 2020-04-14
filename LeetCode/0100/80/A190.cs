using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._80
{
    class A190 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public uint reverseBits(uint n)
        {
            n = (n >> 16) | (n << 16);
            n = ((n & 0xff00ff00) >> 8) | ((n & 0x00ff00ff) << 8);
            n = ((n & 0xf0f0f0f0) >> 4) | ((n & 0x0f0f0f0f) << 4);
            n = ((n & 0xcccccccc) >> 2) | ((n & 0x33333333) << 2);
            n = ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);
            return n;
        }
    }
}
