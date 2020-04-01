using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A22 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给出 n 代表生成括号的对数，请你写出一个函数，使其能够生成所有可能的并且有效的括号组合。

        //例如，给出 n = 3，生成结果为：

        //[
        //  "((()))",
        //  "(()())",
        //  "(())()",
        //  "()(())",
        //  "()()()"
        //]

        //        来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/generate-parentheses
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public IList<string> GenerateParenthesis(int n)
        {
            if (n == 0)
            {
                return new List<string>();
            }
            List<string> ans = new List<string>();
            GenerateParenthesis(ans, "", 0, 0, n);
            return ans;
        }

        private void GenerateParenthesis(List<string> results, string cur, int open, int close, int n)
        {
            if(cur.Length == n * 2)
            {
                results.Add(cur);
                return;
            }

            if(open < n)
            {
                GenerateParenthesis(results, cur + "(", open + 1, close, n);
            }
            if(close < open)
            {
                GenerateParenthesis(results, cur + ")", open, close + 1, n);
            }
        }
    }
}
