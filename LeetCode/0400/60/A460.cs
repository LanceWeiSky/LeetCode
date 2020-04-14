using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LeetCode._0400._60
{
    class A460 : IQuestion
    {
        public void Run()
        {
            LFUCache cache = new LFUCache(2 /* capacity (缓存容量) */ );

            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);       // 返回 1
            cache.Put(3, 3);    // 去除 key 2
            cache.Get(2);       // 返回 -1 (未找到key 2)
            cache.Get(3);       // 返回 3
            cache.Put(4, 4);    // 去除 key 1
            cache.Get(1);       // 返回 -1 (未找到 key 1)
            cache.Get(3);       // 返回 3
            cache.Get(4);       // 返回 4

        }

        //设计并实现最不经常使用（LFU）缓存的数据结构。它应该支持以下操作：get 和 put。

        //get(key) - 如果键存在于缓存中，则获取键的值（总是正数），否则返回 -1。
        //put(key, value) - 如果键不存在，请设置或插入值。当缓存达到其容量时，它应该在插入新项目之前，使最不经常使用的项目无效。在此问题中，当存在平局（即两个或更多个键具有相同使用频率）时，最近最少使用的键将被去除。

        //进阶：
        //你是否可以在 O(1) 时间复杂度内执行两项操作？

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/lfu-cache
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public class LFUCache
        {
            private Dictionary<int, LFUItem> _keyCache = new Dictionary<int, LFUItem>();
            private Dictionary<int, List<LFUItem>> _freCache = new Dictionary<int, List<LFUItem>>();
            private int _minFreq = 1;
            private int _capacity = 0;

            public LFUCache(int capacity)
            {
                _capacity = capacity;
            }

            public int Get(int key)
            {
                if (_keyCache.TryGetValue(key, out var v))
                {
                    SetFreq(v, true);
                    return v.Value;
                }
                return -1;
            }

            private void SetFreq(LFUItem v, bool removeOld)
            {
                if (removeOld)
                {
                    var oldList = _freCache[v.Freq];
                    oldList.Remove(v);
                    if (v.Freq == _minFreq && oldList.Count == 0)
                    {
                        _minFreq++;
                    }
                    v.Freq++;
                }
                if (!_freCache.TryGetValue(v.Freq, out var newList))
                {
                    newList = new List<LFUItem>();
                    _freCache[v.Freq] = newList;
                }
                newList.Add(v);
            }

            public void Put(int key, int value)
            {
                if (_capacity < 1)
                {
                    return;
                }
                if (_keyCache.TryGetValue(key, out var v))
                {
                    v.Value = value;
                    SetFreq(v, true);
                }
                else
                {
                    if (_capacity == _keyCache.Count)
                    {
                        var list = _freCache[_minFreq];
                        var r = list[0];
                        list.RemoveAt(0);
                        _keyCache.Remove(r.Key);
                    }
                    var item = new LFUItem { Freq = 1, Key = key, Value = value };
                    _keyCache[key] = item;
                    SetFreq(item, false);
                    _minFreq = 1;
                }
            }
        }

        public class LFUItem
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public int Freq { get; set; }
        }
    }
}
