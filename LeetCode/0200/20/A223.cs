using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A223 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            var w1 = (long)C - A;
            var h1 = (long)D - B;
            var w2 = (long)G - E;
            var h2 = (long)H - F;
            var maxX = Math.Max((long)C, G);
            var minX = Math.Min((long)A, E);
            var maxY = Math.Max((long)D, H);
            var minY = Math.Min((long)B, F);
            var tempW = w1 + w2 - maxX + minX;
            var tempH = h1 + h2 - maxY + minY;
            var ans = w1 * h1 + w2 * h2;
            if (tempW > 0 && tempH > 0)
            {
                ans -= tempW * tempH;
            }
            return (int)ans;
        }
    }
}
