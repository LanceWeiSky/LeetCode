using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A365 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool CanMeasureWater(int x, int y, int z)
            {
                if (x + y < z)
                {
                    return false;
                }
                Queue<long> queue = new Queue<long>();
                queue.Enqueue(0);
                HashSet<long> seen = new HashSet<long>();
                while (queue.Count > 0)
                {
                    var state = queue.Dequeue();
                    int currentX = (int)state;
                    int currentY = (int)(state >> 32);

                    if (currentX == z || currentY == z || currentX + currentY == z)
                    {
                        return true;
                    }

                    if (currentX > 0)
                    {
                        var s = GetState(0, currentY);
                        if (seen.Add(s))
                        {
                            queue.Enqueue(s);
                        }
                    }

                    if (currentY > 0)
                    {
                        var s = GetState(currentX, 0);
                        if (seen.Add(s))
                        {
                            queue.Enqueue(s);
                        }
                    }

                    if (currentX < x)
                    {
                        var s = GetState(x, currentY);
                        if (seen.Add(s))
                        {
                            queue.Enqueue(s);
                        }
                    }

                    if (currentY < y)
                    {
                        var s = GetState(currentX, y);
                        if (seen.Add(s))
                        {
                            queue.Enqueue(s);
                        }
                    }

                    if (currentY < x - currentX)
                    {
                        var s = GetState(currentX + currentY, 0);
                        if (seen.Add(s))
                        {
                            queue.Enqueue(s);
                        }
                    }
                    else
                    {
                        var s = GetState(x, currentY - (x - currentX));
                        if (seen.Add(s))
                        {
                            queue.Enqueue(s);
                        }
                    }

                    if (currentX < y - currentY)
                    {
                        var s = GetState(0, currentY + currentX);
                        if (seen.Add(s))
                        {
                            queue.Enqueue(s);
                        }
                    }
                    else
                    {
                        var s = GetState(currentX - (y - currentY), x);
                        if (seen.Add(s))
                        {
                            queue.Enqueue(s);
                        }
                    }
                }
                return false;
            }

            private long GetState(int x, int y)
            {
                long s = y;
                return (s << 32) + x;
            }
        }

    }
}
