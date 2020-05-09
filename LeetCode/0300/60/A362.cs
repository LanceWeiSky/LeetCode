using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A362 : IQuestion
    {
        public void Run()
        {
            var counter = new HitCounter();
            counter.Hit(100);
            counter.Hit(282);
            counter.Hit(411);
            counter.Hit(609);
            counter.Hit(620);
            counter.Hit(744);
            counter.GetHits(879);
        }

        public class HitCounter
        {

            private readonly long[] _counter = new long[300];
            private int _lastTimestamp = 0;
            private long _sum;

            /** Initialize your data structure here. */
            public HitCounter()
            {

            }

            /** Record a hit.
                @param timestamp - The current timestamp (in seconds granularity). */
            public void Hit(int timestamp)
            {
                var index = timestamp % 300;
                if (timestamp == _lastTimestamp)
                {
                    _sum++;
                    _counter[index]++;
                }
                else
                {

                    MoveTo(timestamp);
                    _sum += 1;
                    _counter[index] = 1;
                }
                _lastTimestamp = timestamp;
            }

            private void MoveTo(int timestamp)
            {
                var temp = timestamp - _lastTimestamp;
                if (temp >= 300)
                {
                    Array.Fill(_counter, 0);
                    _sum = 0;
                }
                else
                {
                    for (int i = _lastTimestamp + 1; i <= timestamp; i++)
                    {
                        var index = i % 300;
                        _sum -= _counter[index];
                        _counter[index] = 0;
                    }
                }
            }

            /** Return the number of hits in the past 5 minutes.
                @param timestamp - The current timestamp (in seconds granularity). */
            public int GetHits(int timestamp)
            {
                if (timestamp != _lastTimestamp)
                {
                    MoveTo(timestamp);
                }
                return (int)_sum;
            }
        }
    }
}
