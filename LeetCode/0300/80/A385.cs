using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A385 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class NestedInteger
        {

            // Constructor initializes an empty nested list.
            public NestedInteger() { }

            // Constructor initializes a single integer.
            public NestedInteger(int value) { }

            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            bool IsInteger() { return false; }

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            int GetInteger() { return 0; }

            // Set this NestedInteger to hold a single integer.
            public void SetInteger(int value) { }

            // Set this NestedInteger to hold a nested list and adds a nested integer to it.
            public void Add(NestedInteger ni) { }

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger> GetList() { return null; }
        }

        public class Solution
        {
            public NestedInteger Deserialize(string s)
            {
                NestedInteger root = new NestedInteger();
                if (s[0] != '[')
                {
                    root.SetInteger(int.Parse(s));
                    return root;
                }
                Stack<NestedInteger> stack = new Stack<NestedInteger>();
                stack.Push(root);
                int num = 0;
                bool negative = false;
                bool hasNum = false;
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] == '[')
                    {
                        var temp = new NestedInteger();
                        stack.Peek().Add(temp);
                        stack.Push(temp);
                    }
                    else if (s[i] == '-')
                    {
                        negative = true;
                    }
                    else if (s[i] >= '0' && s[i] <= '9')
                    {
                        num = num * 10 + s[i] - '0';
                        hasNum = true;
                    }
                    else if (s[i] == ',')
                    {
                        if (hasNum)
                        {
                            if (negative)
                            {
                                num = -num;
                            }
                            stack.Peek().Add(new NestedInteger(num));
                        }
                        negative = false;
                        hasNum = false;
                        num = 0;
                    }
                    else if (s[i] == ']')
                    {
                        if (hasNum)
                        {
                            if (negative)
                            {
                                num = -num;
                            }
                            stack.Pop().Add(new NestedInteger(num));
                        }
                        else
                        {
                            stack.Pop();
                        }
                        negative = false;
                        hasNum = false;
                        num = 0;
                    }
                }
                return root;
            }

        }
    }
}
