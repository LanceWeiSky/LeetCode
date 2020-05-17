using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace LeetCode._0600._20
{
    class A635 : IQuestion
    {
        public void Run()
        {
            string[] input = File.ReadAllLines(@"C:\Users\skli\Desktop\test.txt");
            Utility.InvokeHelper<LogSystem>(input);
        }

        public class LogSystem
        {
            private static readonly Dictionary<string, int> _graMap = new Dictionary<string, int>
            {
                { "Year", 1 },
                { "Month", 2 },
                { "Day", 3 },
                { "Hour", 4 },
                { "Minute", 5 },
                { "Second", 6 },
            };
            private static readonly long _minute = 60;
            private static readonly long _hour = _minute * 60;
            private static readonly long _day = _hour * 24;
            private static readonly long _month = _day * 31;
            private static readonly long _year = _month * 12;
            private readonly SortedSet<LogEntry> _set = new SortedSet<LogEntry>(new LogEntryComparer());

            public LogSystem()
            {

            }

            public void Put(int id, string timestamp)
            {
                var timeArray = timestamp.Split(':').Select(t => int.Parse(t)).ToArray();
                var time = ConvertTime(timeArray);
                _set.Add(new LogEntry { Timestamp = time, Id = id });
            }

            public IList<int> Retrieve(string s, string e, string gra)
            {
                var start = Granularity(s, gra, false);
                var end = Granularity(e, gra, true);
                var view = _set.GetViewBetween(new LogEntry { Timestamp = start }, new LogEntry { Timestamp = end });
                return view.Select(t => t.Id).ToList();
            }

            private long Granularity(string timestamp, string gra, bool isEnd)
            {
                var temp = timestamp.Split(':');
                int[] time = new int[6];
                for (int i = 0; i < _graMap[gra]; i++)
                {
                    time[i] = int.Parse(temp[i]);
                }
                if (isEnd)
                {
                    time[_graMap[gra] - 1]++;
                    time[5]--;
                }
                return ConvertTime(time);
            }

            private long ConvertTime(int[] time)
            {
                if(time[1] > 0)
                {
                    time[1]--;
                }
                if(time[2] > 0)
                {
                    time[2]--;
                }
                return (time[0] - 2000) * _year + time[1] * _month + time[2] * _day + time[3] * _hour + time[4] * _minute + time[5];
            }

            private class LogEntry
            { 
                public int Id { get; set; }
                public long Timestamp { get; set; }
            }

            private class LogEntryComparer : IComparer<LogEntry>
            {
                public int Compare(LogEntry x, LogEntry y)
                {
                    return x.Timestamp.CompareTo(y.Timestamp);
                }
            }
        }
    }
}
