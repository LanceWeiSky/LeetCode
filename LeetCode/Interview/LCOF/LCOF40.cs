using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Leetcode.Interview.LCOF
{
    class LCOF40 : IQuestion
    {
        public void Run()
        {
            string input = "[0,0,0,2,0,5]";
            //var nums = JsonSerializer.Deserialize<int[]>(input);
            var nums = InitArray(1000000);
            Array.Sort(nums);
            var ans = GetLeastNumbers(nums, 10000);
        }

        //输入整数数组 arr ，找出其中最小的 k 个数。例如，输入4、5、1、6、2、7、3、8这8个数字，则最小的4个数字是1、2、3、4。

        //思路解析：
        //快速排序只排前k个数

        private int[] InitArray(int length)
        {
            Random r = new Random();
            int[] arr = new int[length];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(0, length + 1);
            }
            return arr;
        }

        public int[] GetLeastNumbers(int[] arr, int k)
        {
            if(k == 0)
            {
                return new int[0];
            }
            if (k > arr.Length)
            {
                k = arr.Length;
            }
            QuickSort(arr, 0, arr.Length - 1, k);
            int[] ans = new int[k];
            for (int i = 0; i < k; i++)
            {
                ans[i] = arr[i];
            }
            return ans;
        }

        private void QuickSort(int[] arr, int left, int right, int k)
        {
            var p = Partition(arr, left, right);
            while (p != k - 1)
            {
                if (p > k - 1)
                {
                    right = p - 1;
                }
                else
                {
                    left = p + 1;
                }
                p = Partition(arr, left, right);
            }
        }

        private int Partition(int[] arr, int left, int right)
        {
            int i = left;
            int j = right;
            int temp = arr[left];
            while (i < j)
            {
                while (i < j && arr[j] >= temp)
                {
                    j--;
                }
                if (i < j)
                {
                    arr[i] = arr[j];
                }
                while (i < j && arr[i] <= temp)
                {
                    i++;
                }
                if (i < j)
                {
                    arr[j] = arr[i];
                }
            }
            arr[i] = temp;
            return i;
        }

    }
}
