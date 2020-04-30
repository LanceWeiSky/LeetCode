using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A321 : IQuestion
    {
        public void Run()
        {
            
        }

        public class Solution
        {
            public int[] MaxNumber(int[] nums1, int[] nums2, int k)
            {
                int[] ans = new int[k];
                int index = 0;
                HashSet<long> list = new HashSet<long>();
                list.Add(0);
                while (index < k)
                {
                    HashSet<long> list2 = new HashSet<long>();
                    int max = int.MinValue;
                    int rightCount = k - index - 1;
                    foreach(var temp in list)
                    {
                        int i1 = (int)temp;
                        int i2 = (int)(temp >> 32);
                        int rightCount1 = Math.Max(0, rightCount - (nums2.Length - i2));
                        int maxIdx1 = FindMaxIndex(nums1, i1, rightCount1);
                        int maxNum1 = maxIdx1 < nums1.Length ? nums1[maxIdx1] : -1;
                        if (maxNum1 > max)
                        {
                            list2.Clear();
                            max = maxNum1;
                            list2.Add((((long)i2) << 32) | (long)(maxIdx1 + 1));
                        }
                        else if (maxNum1 == max)
                        {
                            list2.Add((((long)i2) << 32) | (long)(maxIdx1 + 1));
                        }

                        int rightCount2 = Math.Max(0, rightCount - (nums1.Length - i1));
                        int maxIdx2 = FindMaxIndex(nums2, i2, rightCount2);
                        int maxNum2 = maxIdx2 < nums2.Length ? nums2[maxIdx2] : -1;
                        if (maxNum2 > max)
                        {
                            list2.Clear();
                            max = maxNum2;
                            list2.Add((long)i1 | ((long)(maxIdx2 + 1)) << 32);
                        }
                        else if (maxNum2 == max)
                        {
                            list2.Add((long)i1 | ((long)(maxIdx2 + 1)) << 32);
                        }
                    }

                    ans[index++] = max;
                    list = list2;
                }
                return ans;
            }

            private int FindMaxIndex(int[] nums, int index, int rightCount)
            {
                int idx = index;
                int max = -1;
                for (int i = index; i < nums.Length - rightCount; i++)
                {
                    if (nums[i] > max)
                    {
                        max = nums[i];
                        idx = i;
                    }
                }
                return idx;
            }
        }
    }
}
