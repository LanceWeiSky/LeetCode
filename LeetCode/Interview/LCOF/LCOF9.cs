using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF9 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }


        //用两个栈实现一个队列。队列的声明如下，请实现它的两个函数 appendTail 和 deleteHead ，分别完成在队列尾部插入整数和在队列头部删除整数的功能。(若队列中没有元素，deleteHead 操作返回 -1 )

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/yong-liang-ge-zhan-shi-xian-dui-lie-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


        //思路解析：
        //两个栈，一个存储从头到尾，一个存储从尾到头

        public class CQueue
        {

            private Stack<int> _s1 = new Stack<int>();//存储从头到尾
            private Stack<int> _s2 = new Stack<int>();//存储从尾到头

            public CQueue()
            {

            }

            public void AppendTail(int value)
            {
                //若s2中有数据，说明s1的数据不完整，则先将数据放进s1中，再将当前数据放入s1的尾部
                if (_s2.Count == 0)
                {
                    _s1.Push(value);
                }
                else
                {
                    while (_s2.Count > 0)
                    {
                        _s1.Push(_s2.Pop());
                    }
                    _s1.Push(value);
                }
            }

            public int DeleteHead()
            {
                //若s1中有数据，说明s2的Pop不是头，需要先将s1的数据放入s2中，再Pop
                while (_s1.Count != 0)
                {
                    _s2.Push(_s1.Pop());
                }

                if (_s2.Count == 0)
                {
                    return -1;
                }
                return _s2.Pop();
            }
        }
    }
}
