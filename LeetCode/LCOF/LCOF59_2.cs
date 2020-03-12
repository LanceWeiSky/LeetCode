using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF59_2 : IQuestion
    {
        public void Run()
        {

        }

        //请定义一个队列并实现函数 max_value 得到队列里的最大值，要求函数max_value、push_back 和 pop_front 的均摊时间复杂度都是O(1)。

        //若队列为空，pop_front 和 max_value 需要返回 -1

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/dui-lie-de-zui-da-zhi-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public class MaxQueue
        {
            private Queue<int> _queue = new Queue<int>();
            private List<int> _maxList = new List<int>();
            public MaxQueue()
            {

            }

            public int Max_value()
            {
                if (_maxList.Count == 0)
                {
                    return -1;
                }
                return _maxList[0];
            }

            public void Push_back(int value)
            {
                _queue.Enqueue(value);
                //_maxList是一个单调递减序列，要保证左侧的元素一定都比当前元素大
                if (_maxList.Count > 0)
                {
                    for (int i = _maxList.Count - 1; i >= 0; i--)
                    {
                        if (_maxList[i] < value)
                        {
                            _maxList.RemoveAt(i);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                _maxList.Add(value);
            }

            public int Pop_front()
            {
                if (_queue.Count == 0)
                {
                    return -1;
                }
                var value = _queue.Dequeue();
                if (value == _maxList[0])//若Pop的值就是最大值，_maxList移除第一个值
                {
                    _maxList.RemoveAt(0);
                }
                return value;
            }
        }
    }
}
