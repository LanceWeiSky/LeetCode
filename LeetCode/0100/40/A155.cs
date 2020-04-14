using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A155 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //设计一个支持 push ，pop ，top 操作，并能在常数时间内检索到最小元素的栈。


        //	push(x) —— 将元素 x 推入栈中。
        //	pop() —— 删除栈顶的元素。
        //	top() —— 获取栈顶元素。
        //	getMin() —— 检索栈中的最小元素。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/min-stack
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public class MinStack
        {
            private Stack<int> _stack = new Stack<int>();
            private Stack<int> _min = new Stack<int>();


            /** initialize your data structure here. */
            public MinStack()
            {

            }

            public void Push(int x)
            {
                _stack.Push(x);
                if (_min.Count == 0 || _min.Peek() >= x)
                {
                    _min.Push(x);
                }
            }

            public void Pop()
            {
                var value = _stack.Pop();
                if (value == _min.Peek())
                {
                    _min.Pop();
                }
            }

            public int Top()
            {
                if (_stack.Count > 0)
                {
                    return _stack.Peek();
                }
                return 0;
            }

            public int GetMin()
            {
                if (_min.Count > 0)
                {
                    return _min.Peek();
                }
                return 0;
            }
        }
    }
}
