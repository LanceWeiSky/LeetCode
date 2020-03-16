using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A4 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定两个大小为 m 和 n 的有序数组 nums1 和 nums2。

        //请你找出这两个有序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。

        //你可以假设 nums1 和 nums2 不会同时为空。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/median-of-two-sorted-arrays
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)//让nums1的长度小于nums2的长度，方便后续处理
            {
                var temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }
            int half = (nums1.Length + nums2.Length + 1) / 2;//一半元素的数量，提取中位数使用
            int left = 0;
            int right = nums1.Length;
            while (left <= right)//二分查找较短数组
            {
                int i = (left + right) / 2;
                //由于i在较短数组中查找，所以j一定不会越界。
                //因为i>=0，所以当i=0时，j有最大值j=half=(nums1.Length + nums2.Length + 1) / 2<=(nums2.Length + nums2.Length + 1) / 2<=nums2.Length
                //当i取最大值nums1.Length时（即left=right=nums1.Length），j有最小值，j=half-nums1.Length=(nums1.Length + nums2.Length + 1) / 2-nums1.Length>=0
                int j = half - i;
                if (i < right && nums1[i] < nums2[j - 1])//i小于right，所以j一定大于0
                {
                    left = i + 1;//i右侧的值比j左侧小，说明i小了，需要向右移
                }
                else if (i > left && nums2[j] < nums1[i - 1])//i大于0，所以j一定小于nums2.Length
                {
                    right = i - 1;//i左侧的值比j右侧大，说明i大了，需要向左移
                }
                else
                {
                    //i和j右侧的值均比左侧小，说明左侧一半的值小于右侧一半的值，我们找到了合适的索引
                    int value1 = 0;
                    if(i == 0)
                    {
                        value1 = nums2[j - 1];
                    }
                    else if(j == 0)
                    {
                        value1 = nums1[i - 1];
                    }
                    else
                    {
                        value1 = Math.Max(nums1[i - 1], nums2[j - 1]);
                    }
                    if ((nums1.Length + nums2.Length) % 2 == 1)//如果是奇数，中位数一定是左侧最大值
                    {
                        return value1;
                    }
                    //如果是偶数，中位数是左侧最大值和右侧最小值的平均数
                    int value2 = 0;
                    if(i == nums1.Length)
                    {
                        value2 = nums2[j];
                    }
                    else if(j == nums2.Length)
                    {
                        value2 = nums1[i];
                    }
                    else
                    {
                        value2 = Math.Min(nums1[i], nums2[j]);
                    }
                    return (value1 + value2) / 2d;
                }
            }
            return 0;
        }

    }
}
