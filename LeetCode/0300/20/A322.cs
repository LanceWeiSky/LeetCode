using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A322 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int CoinChange(int[] coins, int amount)
            {
                if (coins.Length == 0 || amount < 0)
                {
                    return -1;
                }
                if (amount == 0)
                {
                    return 0;
                }
                Array.Sort(coins);
                HashSet<int> seen = new HashSet<int>();
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(amount);
                int count = 0;
                while (queue.Count > 0)
                {
                    count++;
                    var c = queue.Count;
                    for (int i = 0; i < c; i++)
                    {
                        var temp = queue.Dequeue();
                        for (int j = coins.Length - 1; j >= 0; j--)
                        {
                            var next = temp - coins[j];
                            if (next == 0)
                            {
                                return count;
                            }
                            else if (next > 0 && seen.Add(next))
                            {
                                queue.Enqueue(next);
                            }
                        }
                    }
                }
                return -1;
            }
        }
    }
}
