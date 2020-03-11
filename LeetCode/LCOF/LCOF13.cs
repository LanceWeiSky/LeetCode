using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF13 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }


        //地上有一个m行n列的方格，从坐标[0, 0] 到坐标[m - 1, n - 1] 。
        //一个机器人从坐标[0, 0] 的格子开始移动，它每次可以向左、右、上、下移动一格（不能移动到方格外），也不能进入行坐标和列坐标的数位之和大于k的格子。
        //例如，当k为18时，机器人能够进入方格[35, 37] ，因为3+5+3+7=18。但它不能进入方格[35, 38]，因为3+5+3+8=19。请问该机器人能够到达多少个格子？

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/ji-qi-ren-de-yun-dong-fan-wei-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


        //思路解析:
        //由于机器人从左上角开始行动，所以每次只需要考虑向右和向下两种情况即可。相当于层次遍历。
        //由于遍历过程中会存在多次访问到同一个格子的情况，所以需要加一个临时数组记录当前格子是否已经计算过。

        public class Solution
        {
            public int MovingCount(int m, int n, int k)
            {
                bool[][] temp = new bool[m][];
                for (int i = 0; i < m; i++)
                {
                    temp[i] = new bool[n];
                }
                int ans = 0;
                Queue<int[]> queues = new Queue<int[]>();
                queues.Enqueue(new int[] { 0, 0, 0 });
                while (queues.Count > 0)
                {
                    var cell = queues.Dequeue();
                    if (temp[cell[0]][cell[1]])
                    {
                        continue;
                    }
                    ans++;
                    temp[cell[0]][cell[1]] = true;
                    int col = cell[1] + 1;
                    if (col < n)
                    {
                        var sum = GetNextSum(cell[2], col);
                        if (sum <= k)
                        {
                            queues.Enqueue(new int[] { cell[0], col, sum });
                        }
                    }
                    int row = cell[0] + 1;
                    if (row < m)
                    {
                        var sum = GetNextSum(cell[2], row);
                        if (sum <= k)
                        {
                            queues.Enqueue(new int[] { row, cell[1], sum });
                        }
                    }
                }
                return ans;
            }

            //计算和的时候不需要每次重新计算，个位0-9的情况，相当于和值+1，个位进位的情况，相当于十位+1，个位-9，和值总体-8
            private int GetNextSum(int current, int nextNum)
            {
                if (nextNum % 10 == 0)
                {
                    return current - 8;
                }
                return current + 1;
            }

            private int GetSum(int num)
            {
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                return sum;
            }
        }
    }
}
