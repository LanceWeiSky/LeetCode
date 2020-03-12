using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF61 : IQuestion
    {
        public void Run()
        {

        }

        //从扑克牌中随机抽5张牌，判断是不是一个顺子，即这5张牌是不是连续的。2～10为数字本身，A为1，J为11，Q为12，K为13，而大、小王为 0 ，可以看成任意数字。A 不能视为 14。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/bu-ke-pai-zhong-de-shun-zi-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //除了0外，其他的数字不能重复。
        //若没有0，最大值与最小值的差+1一定等于牌的数量，例如：2,3,4,5,6是一个顺子，6-2+1=5
        //如果有0，最大值与最小值的差+1可以小于牌的数量，因为0可以替代缺少的牌

        public bool IsStraight(int[] nums)
        {
            bool[] duplicate = new bool[14];
            int kingCount = 0;
            int min = 14;
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    kingCount++;
                    continue;
                }
                if (duplicate[nums[i]])
                {
                    return false;
                }
                duplicate[nums[i]] = true;
                if (nums[i] > max)
                {
                    max = nums[i];
                }
                if (nums[i] < min)
                {
                    min = nums[i];
                }
            }
            if (max - min + 1 == nums.Length || kingCount > 0 && max - min + 1 < nums.Length)
            {
                return true;
            }
            return false;
        }
    }
}
