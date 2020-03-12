using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF41 : IQuestion
    {
        public void Run()
        {

        }

        //如何得到一个数据流中的中位数？如果从数据流中读出奇数个数值，那么中位数就是所有数值排序之后位于中间的数值。
        //如果从数据流中读出偶数个数值，那么中位数就是所有数值排序之后中间两个数的平均值。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/shu-ju-liu-zhong-de-zhong-wei-shu-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //大顶堆存储所有比中位数小的数，小顶堆中存储所有比中位数大的数。
        //两个堆中存储相同数量或者相差一个元素，保证大顶堆中所有元素小于小顶堆中所有元素。
        //如果两个堆元素相同，则中位数是大顶堆最大值和小顶堆最小值的平均数。否则中位数是元素多的堆的根节点。

        public class MedianFinder
        {
            private readonly Heap<int> _max = new Heap<int>(true);
            private readonly Heap<int> _min = new Heap<int>(false);
            /** initialize your data structure here. */
            public MedianFinder()
            {

            }

            public void AddNum(int num)
            {
                if (_max.Count == _min.Count)
                {
                    _max.Push(num);
                    _min.Push(_max.Pop());
                }
                else
                {
                    _min.Push(num);
                    _max.Push(_min.Pop());
                }
            }

            public double FindMedian()
            {
                if (_max.Count == _min.Count)
                {
                    return (_max.Peek() + _min.Peek()) / 2d;
                }
                return _min.Peek();
            }
        }
    }
}
