using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1000._80
{
    class A1095 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        class Solution
        {
            public int FindInMountainArray(int target, MountainArray mountainArr)
            {
                int length = mountainArr.Length();
                int left = 0;
                int right = length - 1;
                while (left <= right)
                {
                    var mid = left + (right - left) / 2;
                    if (mountainArr.Get(mid) < mountainArr.Get(mid + 1))
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                var peak = left;
                var index = BinarySearch(target, mountainArr, 0, peak, true);
                if(index < 0)
                {
                    index = BinarySearch(target, mountainArr, peak + 1, length - 1, false);
                }
                return index;
            }

            private int BinarySearch(int target, MountainArray mountainArr, int left, int right, bool inc)
            {
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    var v = mountainArr.Get(mid);
                    if (v == target)
                    {
                        return mid;
                    }
                    else if (v > target)
                    {
                        if (inc)
                        {
                            right = mid - 1;
                        }
                        else
                        {
                            left = mid + 1;
                        }
                    }
                    else
                    {
                        if (inc)
                        {
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                }
                return -1;
            }
        }

        class MountainArray
        {
            public int Get(int index) { return index; }
            public int Length() { return 0; }
        }
    }
}
