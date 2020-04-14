using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A134 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //在一条环路上有 N 个加油站，其中第 i 个加油站有汽油 gas[i] 升。

        //你有一辆油箱容量无限的的汽车，从第 i 个加油站开往第 i+1 个加油站需要消耗汽油 cost[i] 升。你从其中的一个加油站出发，开始时油箱为空。

        //如果你可以绕环路行驶一周，则返回出发时加油站的编号，否则返回 -1。

        //说明: 


        //	如果题目有解，该答案即为唯一答案。
        //	输入数组均为非空数组，且长度相同。
        //	输入数组中的元素均为非负数。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/gas-station
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int total = 0;
            int current = 0;
            int start = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                var temp = gas[i] - cost[i];
                current += temp;
                total += temp;
                if (current < 0)
                {
                    start = i + 1;
                    current = 0;
                }
            }
            return total < 0 ? -1 : start;
        }
    }
}
