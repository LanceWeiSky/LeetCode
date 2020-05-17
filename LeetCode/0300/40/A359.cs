using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._40
{
    class A359 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Logger
        {

            private readonly Dictionary<string, int> _messages = new Dictionary<string, int>();

            /** Initialize your data structure here. */
            public Logger()
            {

            }

            /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
                If this method returns false, the message will not be printed.
                The timestamp is in seconds granularity. */
            public bool ShouldPrintMessage(int timestamp, string message)
            {
                if (!_messages.TryGetValue(message, out var time))
                {
                    _messages.Add(message, timestamp);
                    return true;
                }
                if (timestamp - time >= 10)
                {
                    _messages[message] = 10;
                    return true;
                }
                return false;
            }
        }
    }
}
