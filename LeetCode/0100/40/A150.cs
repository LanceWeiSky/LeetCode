using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A150 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //根据逆波兰表示法，求表达式的值。

        //有效的运算符包括 +, -, *, / 。每个运算对象可以是整数，也可以是另一个逆波兰表达式。

        //说明：


        //	整数除法只保留整数部分。
        //	给定逆波兰表达式总是有效的。换句话说，表达式总会得出有效数值且不存在除数为 0 的情况。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/evaluate-reverse-polish-notation
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            foreach (var t in tokens)
            {
                if (t == "+")
                {
                    var num1 = stack.Pop();
                    var num2 = stack.Pop();
                    stack.Push(num2 + num1);
                }
                else if (t == "-")
                {
                    var num1 = stack.Pop();
                    var num2 = stack.Pop();
                    stack.Push(num2 - num1);
                }
                else if (t == "*")
                {
                    var num1 = stack.Pop();
                    var num2 = stack.Pop();
                    stack.Push(num2 * num1);
                }
                else if (t == "/")
                {
                    var num1 = stack.Pop();
                    var num2 = stack.Pop();
                    stack.Push(num2 / num1);
                }
                else
                {
                    stack.Push(int.Parse(t));
                }
            }
            if (stack.Count == 0)
            {
                return 0;
            }
            return stack.Peek();
        }
    }
}
