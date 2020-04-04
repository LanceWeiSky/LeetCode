using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A88 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给你两个有序整数数组 nums1 和 nums2，请你将 nums2 合并到 nums1 中，使 num1 成为一个有序数组。



        //说明:


        //	初始化 nums1 和 nums2 的元素数量分别为 m 和 n 。

        //    你可以假设 nums1 有足够的空间（空间大小大于或等于 m + n）来保存 nums2 中的元素。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/merge-sorted-array
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int k = m + n - 1;
            int j = n - 1;
            while (j >= 0)
            {
                if (i >= 0 && nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i--];
                }
                else
                {
                    nums1[k] = nums2[j--];
                }
                k--;
            }
        }
    }
}
