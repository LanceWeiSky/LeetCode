using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0000._00
{
    class A17 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。
        //给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。

        private Dictionary<char, string> _map = new Dictionary<char, string>
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" },
        };

        public IList<string> LetterCombinations(string digits)
        {
            if(string.IsNullOrEmpty(digits))
            {
                return new List<string>();
            }
            return LetterCombinations(digits, 0);
        }

        private List<string> LetterCombinations(string digits, int i)
        {
            var chars = _map[digits[i]];
            if(digits.Length - 1 == i)
            {
                return chars.Select(c => c.ToString()).ToList();
            }
            List<string> ans = new List<string>();
            foreach(var c in chars)
            {
                var r = LetterCombinations(digits, i + 1);
                foreach(var s in r)
                {
                    ans.Add(c + s);
                }
            }
            return ans;
        }
    }
}
