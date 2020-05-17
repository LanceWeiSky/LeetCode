using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LeetCode._0900._60
{
    class A973 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[][] KClosest(int[][] points, int K)
            {
                if (K == 0)
                {
                    return new int[0][];
                }
                if (K >= points.Length)
                {
                    return points;
                }
                return QuickSelect(points.Select(p => new DistanceInfo(p)).ToArray(), K);
            }

            private int[][] QuickSelect(DistanceInfo[] points, int k)
            {
                Random rnd = new Random();
                int low = 0, high = points.Length;
                while (true)
                {
                    int temp = rnd.Next(low, high);
                    int value = points[temp].Distance;
                    Swap(points, temp, high - 1);
                    int i = low, j = low;
                    while (j < high)
                    {
                        if (points[j].Distance <= value)
                        {
                            Swap(points, i++, j);
                        }
                        j++;
                    }
                    if (i == k)
                    {
                        break;
                    }
                    if (i > k)
                    {
                        high = i - 1;
                    }
                    else
                    {
                        low = i;
                    }
                }
                return points.Take(k).Select(p => p.Points).ToArray();
            }

            private void Swap(DistanceInfo[] points, int i, int j)
            {
                var temp = points[i];
                points[i] = points[j];
                points[j] = temp;
            }

            private class DistanceInfo
            { 
                public int[] Points { get; }
                public int Distance { get; }

                internal DistanceInfo(int[] points)
                {
                    Points = points;
                    Distance = points[0] * points[0] + points[1] * points[1];
                }
            }
        }
    }
}
