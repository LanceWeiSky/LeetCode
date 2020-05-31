using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0600._40
{
    class A658 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<int> FindClosestElements(int[] arr, int k, int x)
            {
                if (x <= arr[0])
                {
                    return arr.Take(k).ToList();
                }
                if (x >= arr[arr.Length - 1])
                {
                    return arr.Skip(arr.Length - k).ToList();
                }
                int left = 0;
                int right = arr.Length - 1 - k;
                while (left <= right)
                {
                    int mid = left + ((right - left) >> 1);
                    if (x - arr[mid] > arr[mid + k] - x)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                List<int> ans = new List<int>(k);
                for (int i = left; i < left + k; i++)
                {
                    ans.Add(arr[i]);
                }
                return ans;
            }
        }
    }
}
