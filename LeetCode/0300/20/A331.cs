using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A331 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsValidSerialization(string preorder)
            {
                var order = preorder.Split(',');
                int slot = 1;
                foreach (var item in order)
                {
                    slot--;
                    if (slot < 0)
                    {
                        return false;
                    }
                    if (item != "#")
                    {
                        slot += 2;
                    }
                }
                return slot == 0;
            }
        }
    }
}
