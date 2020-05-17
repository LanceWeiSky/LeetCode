using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1300._40
{
    class A1348 : IQuestion
    {
        public void Run()
        {
            var instance = new TweetCounts();
            instance.RecordTweet("tweet3", 0);
            instance.RecordTweet("tweet3", 60);
            instance.RecordTweet("tweet3", 10);
            var ans = instance.GetTweetCountsPerFrequency("minute", "tweet3", 0, 59);
            ans = instance.GetTweetCountsPerFrequency("minute", "tweet3", 0, 60);
        }

        public class TweetCounts
        {
            private readonly Dictionary<string, SortedSet<int>> _tweets = new Dictionary<string, SortedSet<int>>();

            public TweetCounts()
            {

            }

            public void RecordTweet(string tweetName, int time)
            {
                if (!_tweets.TryGetValue(tweetName, out var set))
                {
                    set = new SortedSet<int>();
                    _tweets.Add(tweetName, set);
                }
                set.Add(time);
            }

            public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime)
            {
                if (!_tweets.TryGetValue(tweetName, out var set))
                {
                    return new List<int>();
                }
                int delta = 60;
                if (freq == "minute")
                {
                    delta = 60;
                }
                else if (freq == "hour")
                {
                    delta = 3600;
                }
                else if (freq == "day")
                {
                    delta = 86400;
                }
                int freqEndTime = startTime + delta;
                int count = 0;
                List<int> counts = new List<int>();
                var view = set.GetViewBetween(startTime, endTime);
                foreach (var time in view)
                {
                    while (time >= freqEndTime)
                    {
                        counts.Add(count);
                        count = 0;
                        freqEndTime += delta;
                    }
                    count++;
                }
                int listCount = (endTime - startTime) / delta + 1;
                while (counts.Count < listCount)
                {
                    counts.Add(count);
                    count = 0;
                }
                return counts;
            }
        }
    }
}
