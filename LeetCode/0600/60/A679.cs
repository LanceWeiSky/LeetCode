using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0600._60
{
    class A679 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool JudgePoint24(int[] nums)
            {
                var nums2 = nums.Select(n => (double)n).ToList();
                return JudgePoint24Internal(nums2);
            }

            private bool JudgePoint24Internal(List<double> nums)
            {
                if (nums.Count == 1)
                {
                    return Math.Abs(nums[0] - 24) < 1e-6;
                }
                for (int i = 0; i < nums.Count; i++)
                {
                    for (int j = 0; j < nums.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        List<double> nums2 = new List<double>();
                        for (int k = 0; k < nums.Count; k++)
                        { 
                            if(k != i && k != j)
                            {
                                nums2.Add(nums[k]);
                            }
                        }
                        nums2.Add(0);
                        for (int k = 0; k < 4; k++)
                        { 
                            if(i > j && k < 2)
                            {
                                continue;
                            }
                            if(k == 0)
                            {
                                nums2[nums2.Count - 1] = nums[i] + nums[j];
                            }
                            else if (k == 1)
                            {
                                nums2[nums2.Count - 1] = nums[i] * nums[j];
                            }
                            else if (k == 2)
                            {
                                nums2[nums2.Count - 1] = nums[i] - nums[j];
                            }
                            else if (k == 3)
                            {
                                if(nums[j] == 0)
                                {
                                    continue;
                                }
                                nums2[nums2.Count - 1] = nums[i] / nums[j];
                            }
                            if(JudgePoint24Internal(nums2))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }
    }
}
