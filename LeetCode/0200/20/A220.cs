using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A220 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (t < 0 || k <= 0)
            {
                return false;
            }

            Dictionary<int, int> buckets = new Dictionary<int, int>();
            int size = t + 1;
            for (int i = 0; i < nums.Length; i++)
            {
                var id = GetBucketId(nums[i], size);
                if (buckets.ContainsKey(id))
                {
                    return true;
                }
                if (buckets.TryGetValue(id - 1, out var temp) && nums[i] - temp < size)
                {
                    return true;
                }
                if (buckets.TryGetValue(id + 1, out temp) && temp - nums[i] < size)
                {
                    return true;
                }
                buckets[id] = nums[i];
                if (i >= k)
                {
                    buckets.Remove(GetBucketId(nums[i - k], size));
                }
            }
            return false;
        }

        private int GetBucketId(int num, int size)
        {
            var id = num / size;
            if(num < 0)
            {
                id--;
            }
            return id;
        }
    }
}
