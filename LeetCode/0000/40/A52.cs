using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A52 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //n 皇后问题研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。
        //给定一个整数 n，返回 n 皇后不同的解决方案的数量。

        public int TotalNQueens(int n)
        {
            int count = 0;
            TotalQueens(0, 0, 0, 0, n, ref count);
            return count;
        }

        private void TotalQueens(int row, int col, int ld, int rd, int n, ref int count)
        {
            //ld代表左斜线，rd代表右斜线，col代表列使用的情况
            if (row == n)
            {
                count++;
                return;
            }
            int bit = ~(col | ld | rd) & ((1 << n) - 1);//去掉所有被使用过的格子
            while (bit != 0)
            {
                var pick = bit & -bit;//获取最低位1，也就是最低位可以使用的格子
                //col | pick 代表新一行列的使用情况
                //(ld | pick) << 1 代表新一行左斜线的使用情况，因为加了一行，所以需要向左移动一位
                //(rd | pick) >> 1 代表新一行右斜线的使用情况，因为加了一行，所以需要向右移动一位
                TotalQueens(row + 1, col | pick, (ld | pick) << 1, (rd | pick) >> 1, n, ref count);
                bit = bit & (bit - 1);//消掉最低位的1
            }
        }
    }
}
