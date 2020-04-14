using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0100._60
{
    class A164 : IQuestion
    {
        public void Run()
        {
            var ans = MaximumGap(new int[] { 3, 6, 9, 1 });
        }

        public int MaximumGap(int[] nums)
        {
            if (nums.Length < 2)
            {
                return 0;
            }
            int max = int.MinValue;
            int min = int.MaxValue;
            foreach (var n in nums)
            {
                if (n > max)
                {
                    max = n;
                }
                if (n < min)
                {
                    min = n;
                }
            }

            int size = Math.Max(1, (max - min) / (nums.Length - 1));
            int length = (max - min) / size + 1;
            Bucket[] buckets = new Bucket[length];
            for (int i = 0; i < length; i++)
            {
                buckets[i] = new Bucket();
            }
            foreach (var n in nums)
            {
                int index = (n - min) / size;
                buckets[index].Used = true;
                buckets[index].Min = Math.Min(buckets[index].Min, n);
                buckets[index].Max = Math.Max(buckets[index].Max, n);
            }

            int gap = 0;
            int prevMax = min;
            foreach (var b in buckets)
            {
                if (b.Used)
                {
                    gap = Math.Max(gap, b.Min - prevMax);
                    prevMax = b.Max;
                }
            }
            return gap;
        }

        public class Bucket
        {
            public bool Used { get; set; }
            public int Min { get; set; } = int.MaxValue;
            public int Max { get; set; } = int.MinValue;
        }
    }
}
