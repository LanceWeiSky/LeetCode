using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0300._40
{
    class A341 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class NestedIterator
        {
            private List<int> _items = new List<int>();
            private int _index = 0;

            public NestedIterator(IList<NestedInteger> nestedList)
            {
                Stack<NestedInteger> stack = new Stack<NestedInteger>();
                for (int i = nestedList.Count - 1; i >= 0; i--)
                {
                    stack.Push(nestedList[i]);
                }
                while (stack.Count > 0)
                {
                    var n = stack.Pop();
                    if (n.IsInteger())
                    {
                        _items.Add(n.GetInteger());
                    }
                    else
                    {
                        var l = n.GetList();
                        for (int i = l.Count - 1; i >= 0; i--)
                        {
                            stack.Push(l[i]);
                        }
                    }
                }
            }

            public bool HasNext()
            {
                return _items.Count > _index;
            }

            public int Next()
            {
                return _items[_index++];
            }
        }


        // This is the interface that allows for creating nested lists.
        // You should not implement it, or speculate about its implementation
        public interface NestedInteger
        {

            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            bool IsInteger();

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            int GetInteger();

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger> GetList();
        }

    }
}
