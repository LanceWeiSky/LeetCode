using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF31 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入两个整数序列，第一个序列表示栈的压入顺序，请判断第二个序列是否为该栈的弹出顺序。假设压入栈的所有数字均不相等。
        //例如，序列 {1,2,3,4,5} 是某栈的压栈序列，序列 {4,5,3,2,1}
        //是该压栈序列对应的一个弹出序列，但 {4,3,5,1,2} 就不可能是该压栈序列的弹出序列。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/zhan-de-ya-ru-dan-chu-xu-lie-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //模拟栈，遍历压栈序列，如果值与弹出序列当前值相同：则弹出，否则：压栈。遍历完成后若模拟栈中没有元素代表有可能是一个弹出序列

        public class Solution
        {
            public bool ValidateStackSequences(int[] pushed, int[] popped)
            {
                Stack<int> stack = new Stack<int>();
                int j = 0;
                for (int i = 0; i < pushed.Length; i++)
                {
                    if (pushed[i] == popped[j])
                    {
                        j++;
                        while (stack.Count > 0 && stack.Peek() == popped[j])
                        {
                            stack.Pop();
                            j++;
                        }
                    }
                    else
                    {
                        stack.Push(pushed[i]);
                    }
                }
                return stack.Count == 0;
            }
        }
    }
}
