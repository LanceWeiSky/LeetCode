using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF30 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //定义栈的数据结构，请在该类型中实现一个能够得到栈的最小元素的 min 函数在该栈中，调用 min、push 及 pop 的时间复杂度都是 O(1)。

        //思路解析：
        //两个栈，一个普通栈，一个记录最小值的栈min，如果push的值比最小值小，则min需要push这个值，如果Pop的值是最小值，min也同时Pop

        public class MinStack
        {
            private Stack<int> _min = new Stack<int>();
            private Stack<int> _stack = new Stack<int>();

            /** initialize your data structure here. */
            public MinStack()
            {

            }

            public void Push(int x)
            {
                _stack.Push(x);
                if (_min.Count == 0 || x <= _min.Peek())
                {
                    _min.Push(x);
                }
            }

            public void Pop()
            {
                var v = _stack.Pop();
                if (v == _min.Peek())
                {
                    _min.Pop();
                }
            }

            public int Top()
            {
                return _stack.Peek();
            }

            public int Min()
            {
                return _min.Peek();
            }
        }

        /**
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(x);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.Min();
         */
    }
}
