using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode._1200._40
{
    class A1244 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Leaderboard
        {
            private readonly Dictionary<int, PlayerInfo> _players = new Dictionary<int, PlayerInfo>();
            private readonly SortedSet<PlayerInfo> _sortedSet = new SortedSet<PlayerInfo>(new PlayerComparer());

            public Leaderboard()
            {

            }

            public void AddScore(int playerId, int score)
            {
                if (_players.TryGetValue(playerId, out var info))
                {
                    _sortedSet.Remove(info);
                    info.Score += score;
                    _sortedSet.Add(info);
                }
                else
                {
                    info = new PlayerInfo { Id = playerId, Score = score };
                    _players.Add(playerId, info);
                    _sortedSet.Add(info);
                }
            }

            public int Top(int K)
            {
                return _sortedSet.Take(K).Sum(p => p.Score);
            }

            public void Reset(int playerId)
            {
                if (_players.TryGetValue(playerId, out var info))
                {
                    _sortedSet.Remove(info);
                    info.Score = 0;
                    _sortedSet.Add(info);
                }
            }
        }

        public class PlayerInfo
        { 
            public int Id { get; set; }
            public int Score { get; set; }
        }

        public class PlayerComparer : IComparer<PlayerInfo>
        {
            public int Compare(PlayerInfo x, PlayerInfo y)
            {
                var ret = y.Score.CompareTo(x.Score);
                if (ret == 0)
                {
                    ret = x.Id.CompareTo(y.Id);
                }
                return ret;
            }
        }
    }
}
