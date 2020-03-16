using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A14 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //编写一个函数来查找字符串数组中的最长公共前缀。
        //如果不存在公共前缀，返回空字符串 ""。

        public string LongestCommonPrefix(string[] strs)
        {
            if(strs == null || strs.Length == 0)
            {
                return string.Empty;
            }
            if(strs.Length == 1)
            {
                return strs[0];
            }
            var s = strs[0];
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < s.Length; i++)
            {
                for(int j = 1; j < strs.Length; j++)
                {
                    if(i >= strs[j].Length || strs[j][i] != s[i])
                    {
                        return builder.ToString();
                    }
                }
                builder.Append(s[i]);
            }
            return builder.ToString();
        }
    }
}
