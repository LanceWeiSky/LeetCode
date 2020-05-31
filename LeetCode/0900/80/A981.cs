using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0900._80
{
    class A981 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class TimeMap
        {
            private readonly Dictionary<string, List<ValueInfo>> _map = new Dictionary<string, List<ValueInfo>>();


            /** Initialize your data structure here. */
            public TimeMap()
            {

            }

            public void Set(string key, string value, int timestamp)
            {
                if (!_map.TryGetValue(key, out var set))
                {
                    set = new List<ValueInfo>();
                    _map.Add(key, set);
                }
                set.Add(new ValueInfo { Timestamp = timestamp, Value = value });
            }

            public string Get(string key, int timestamp)
            {
                if (_map.TryGetValue(key, out var set))
                {
                    var idx = set.BinarySearch(new ValueInfo { Timestamp = timestamp }, new ValueComparer());
                    if (idx < 0)
                    {
                        idx = ~idx;
                        if (idx > 0)
                        {
                            return set[idx - 1].Value;
                        }
                    }
                    else
                    {
                        return set[idx].Value;
                    }
                }
                return string.Empty;
            }

            private class ValueInfo
            {
                public string Value { get; set; }
                public int Timestamp { get; set; }
            }

            private class ValueComparer : IComparer<ValueInfo>
            {
                public int Compare(ValueInfo x, ValueInfo y)
                {
                    return x.Timestamp.CompareTo(y.Timestamp);
                }
            }
        }
    }
}
