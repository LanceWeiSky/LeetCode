using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A20 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。

        //有效字符串需满足：


        //	左括号必须用相同类型的右括号闭合。
        //	左括号必须以正确的顺序闭合。


        //注意空字符串可被认为是有效字符串。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/valid-parentheses
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public bool IsValid(string s)
        {
            Dictionary<char, char> d = new Dictionary<char, char>{
                {'(', ')'},
                {'{', '}'},
                {'[', ']'},
            };
            Stack<char> st = new Stack<char>();
            foreach (var c in s)
            {
                if (d.ContainsKey(c))
                {
                    st.Push(c);
                }
                else
                {
                    if (st.Count == 0)
                    {
                        return false;
                    }
                    var temp = st.Pop();
                    if (d[temp] != c)
                    {
                        return false;
                    }
                }
            }
            return st.Count == 0;
        }
    }
}
