using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF38 : IQuestion
    {
        public void Run()
        {
            string input = "abc";
            var ans = Permutation(input);
        }

        //输入一个字符串，打印出该字符串中字符的所有排列。

        public string[] Permutation(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return new string[0];
            }
            var cs = s.ToCharArray();
            List<string> results = new List<string>();
            Permutation(cs, 0, results);
            return results.ToArray();
        }

        private void Permutation(char[] chars, int offset, List<string> results)
        {
            if(offset == chars.Length - 1)
            {
                results.Add(new string(chars));
                return;
            }
            HashSet<char> set = new HashSet<char>();
            //找从offset开始的全排列
            for (int i = offset; i < chars.Length; i++)
            {
                if(!set.Add(chars[i]))
                {
                    continue;
                }
                //确定第一个字符，然后找offset+1开始的全排列
                Swap(chars, offset, i);
                Permutation(chars, offset + 1, results);
                Swap(chars, i, offset);
            }
        }

        private void Swap(char[] chars, int i, int j)
        {
            if (i != j)
            {
                var temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;
            }
        }
    }
}
