using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF45 : IQuestion
    {
        public void Run()
        {
            
        }

        //输入一个正整数数组，把数组里所有数字拼接起来排成一个数，打印能拼接出的所有数字中最小的一个。

        public string MinNumber(int[] nums)
        {
            List<string> lists = new List<string>();
            foreach(var num in nums)
            {
                lists.Add(num.ToString());
            }
            lists.Sort((x, y) => (x + y).CompareTo(y + x));//使用字符串拼接比较，12+34=1234,34+12=3412，1234小，所以12在前，34在后
            return string.Concat(lists);
        }
    }
}
