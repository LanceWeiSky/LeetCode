using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A135 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //老师想给孩子们分发糖果，有 N 个孩子站成了一条直线，老师会根据每个孩子的表现，预先给他们评分。

        //你需要按照以下要求，帮助老师给这些孩子分发糖果：


        //	每个孩子至少分配到 1 个糖果。
        //	相邻的孩子中，评分高的孩子必须获得更多的糖果。


        //那么这样下来，老师至少需要准备多少颗糖果呢？

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/candy
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int Candy(int[] ratings)
        {
            if (ratings.Length <= 1)
            {
                return ratings.Length;
            }

            int oldSlope = 0;
            int newSlope = 0;
            int up = 0;
            int down = 0;
            int candies = 0;
            for (int i = 1; i < ratings.Length; i++)
            {
                newSlope = ratings[i] - ratings[i - 1];
                if (oldSlope < 0 && newSlope >= 0 || oldSlope > 0 && newSlope == 0)
                {
                    candies += Count(up) + Count(down) + Math.Max(up, down);
                    up = 0;
                    down = 0;
                }
                if (newSlope > 0)
                {
                    up++;
                }
                else if (newSlope < 0)
                {
                    down++;
                }
                else
                {
                    candies++;
                }
                oldSlope = newSlope;
            }
            candies += Count(up) + Count(down) + Math.Max(up, down) + 1;
            return candies;
        }

        private int Count(int n)
        {
            return n * (n + 1) / 2;
        }
    }
}
