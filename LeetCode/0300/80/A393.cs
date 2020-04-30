using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A393 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool ValidUtf8(int[] data)
            {
                int mask = 0b11000000;
                int validData = 0b10000000;

                int length = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    int mask1 = 1 << 7;
                    while ((data[i] & mask1) != 0)
                    {
                        length++;
                        mask1 >>= 1;
                    }
                    if (length > 4 || length == 1)
                    {
                        return false;
                    }
                    if (length == 0)
                    {
                        continue;
                    }
                    length--;
                    while (length > 0)
                    {
                        length--;
                        i++;
                        if (i >= data.Length)
                        {
                            return false;
                        }
                        if ((data[i] & mask) != validData)
                        {
                            return false;
                        }
                    }

                }
                return true;
            }
        }
    }
}
