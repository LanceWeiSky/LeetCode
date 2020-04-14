using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0300._40
{
    class A355 : IQuestion
    {
        public void Run()
        {
            Twitter t = new Twitter();
            //["Twitter","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","getNewsFeed"]
            //[[],[1,5],[1,3],[1,101],[1,13],[1,10],[1,2],[1,94],[1,505],[1,333],[1,22],[1,11],[1]]
            t.PostTweet(1, 5);
            t.PostTweet(1, 3);
            t.PostTweet(1, 101);
            t.PostTweet(1, 13);
            t.PostTweet(1, 10);
            t.PostTweet(1, 2);
            t.PostTweet(1, 94);
            t.PostTweet(1, 505);
            t.PostTweet(1, 333);
            t.PostTweet(1, 22);
            t.PostTweet(1, 11);
            var ans = t.GetNewsFeed(1);
        }

        public class MessageInfo
        { 
            public int Id { get; set; }
            public int Time { get; set; }
        }

        public class Twitter
        {
            private const int MaxMessageCount = 10;
            private int _lastTime = 0;
            private Dictionary<int, HashSet<int>> _followers = new Dictionary<int, HashSet<int>>();
            private Dictionary<int, List<MessageInfo>> _userMessages = new Dictionary<int, List<MessageInfo>>();


            /** Initialize your data structure here. */
            public Twitter()
            {

            }

            /** Compose a new tweet. */
            public void PostTweet(int userId, int tweetId)
            {
                if (!_userMessages.TryGetValue(userId, out var messages))
                {
                    messages = new List<MessageInfo>();
                    _userMessages[userId] = messages;
                }
                messages.Add(new MessageInfo { Id = tweetId, Time = _lastTime++ });
            }

            /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
            public IList<int> GetNewsFeed(int userId)
            {
                List<MessageInfo> messages = new List<MessageInfo>();
                if (_userMessages.TryGetValue(userId, out var um))
                {
                    for (int i = um.Count - 1; i >= 0; i--)
                    {
                        messages.Add(um[i]);
                    }
                }
                if (_followers.TryGetValue(userId, out var uf))
                {
                    foreach (var u in uf)
                    {
                        if (u == userId)
                        {
                            continue;
                        }
                        if (_userMessages.TryGetValue(u, out um))
                        {
                            for (int i = um.Count - 1; i >= 0; i--)
                            {
                                messages.Add(um[i]);
                            }
                        }
                    }
                }
                messages.Sort((x, y) => y.Time.CompareTo(x.Time));
                return messages.Take(MaxMessageCount).Select(m => m.Id).ToList();
            }

            /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
            public void Follow(int followerId, int followeeId)
            {
                if (!_followers.TryGetValue(followerId, out var followers))
                {
                    followers = new HashSet<int>();
                    _followers[followerId] = followers;
                }
                followers.Add(followeeId);
            }

            /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
            public void Unfollow(int followerId, int followeeId)
            {
                if (!_followers.TryGetValue(followerId, out var followers))
                {
                    followers = new HashSet<int>();
                    _followers[followerId] = followers;
                }
                followers.Remove(followeeId);
            }
        }
    }
}
