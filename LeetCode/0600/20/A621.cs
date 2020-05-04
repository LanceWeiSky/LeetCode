using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._0600._20
{
    class A621 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int LeastInterval(char[] tasks, int n)
            {
                if (n == 0)
                {
                    return tasks.Length;
                }
                if(tasks.Length < 2)
                {
                    return tasks.Length;
                }
                int[] counter = new int[26];
                foreach (var c in tasks)
                {
                    counter[c - 'A']++;
                }
                Array.Sort(counter);
                int maxTaskLength = counter[25] - 1;
                int slot = maxTaskLength * n;
                for (int i = 24; i >= 0; i--)
                { 
                    if(counter[i] == 0)
                    {
                        break;
                    }
                    slot -= Math.Min(maxTaskLength, counter[i]);
                    if (slot <= 0)
                    {
                        return tasks.Length;
                    }
                }
                return slot + tasks.Length;
            }
        }
    }
}
