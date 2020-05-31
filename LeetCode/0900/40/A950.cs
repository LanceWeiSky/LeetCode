using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0900._40
{
    class A950 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            private readonly LinkedList<int> _list = new LinkedList<int>();
            private LinkedListNode<int> _first;
            private LinkedListNode<int> _last;

            public int[] DeckRevealedIncreasing(int[] deck)
            {
                Array.Sort(deck);
                _first = _list.AddFirst(0);
                _last = _list.AddLast(0);
                for (int i = deck.Length - 1; i >= 0; i--)
                {
                    _list.AddBefore(_last, deck[i]);
                    if (i != 0)
                    {
                        var temp = _first.Next;
                        _list.Remove(temp);
                        _list.AddBefore(_last, temp);
                    }
                }
                int[] ans = new int[deck.Length];
                int index = ans.Length - 1;
                while (index >= 0)
                {
                    _first = _first.Next;
                    ans[index--] = _first.Value;
                }
                return ans;
            }
        }
    }
}
