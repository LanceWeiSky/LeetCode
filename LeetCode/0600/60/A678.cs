using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._60
{
    class A678 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool CheckValidString(string s)
            {
                int min = 0;
                int max = 0;
                foreach (var c in s)
                {
                    if (c == '(')
                    {
                        min++;
                        max++;
                    }
                    else if (c == ')')
                    {
                        if (min > 0)
                        {
                            min--;
                        }
                        if (max > 0)
                        {
                            max--;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (min > 0)
                        {
                            min--;
                        }
                        max++;
                    }
                }
                return min == 0;
            }
        }
    }
}
