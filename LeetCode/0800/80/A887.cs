using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0800._80
{
    class A887 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //你将获得 K 个鸡蛋，并可以使用一栋从 1 到 N  共有 N 层楼的建筑。

        //每个蛋的功能都是一样的，如果一个蛋碎了，你就不能再把它掉下去。

        //你知道存在楼层 F ，满足 0 <= F <= N 任何从高于 F 的楼层落下的鸡蛋都会碎，从 F 楼层或比它低的楼层落下的鸡蛋都不会破。

        //每次移动，你可以取一个鸡蛋（如果你有完整的鸡蛋）并把它从任一楼层 X 扔下（满足 1 <= X <= N）。

        //你的目标是确切地知道 F 的值是多少。

        //无论 F 的初始值如何，你确定 F 的值的最小移动次数是多少？

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/super-egg-drop
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int SuperEggDrop(int K, int N)
        {
            if (K == 0)
            {
                return 0;
            }
            if (N == 1)
            {
                return 1;
            }
            int[,] dp = new int[N + 1, K + 1];
            for (int i = 1; i <= K; i++)
            {
                dp[1, i] = 1;
            }

            for (int i = 2; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    dp[i, j] = 1 + dp[i - 1, j - 1] + dp[i - 1, j];
                    if (dp[i, j] >= N)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
