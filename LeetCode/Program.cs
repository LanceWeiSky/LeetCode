using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string questionId = "A673";
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var type = types.FirstOrDefault(t => t.Name.Equals($"{questionId}", StringComparison.OrdinalIgnoreCase));
            IQuestion question = Activator.CreateInstance(type) as IQuestion;
            question.Run();
        }

        public class Solution
        {
            public int NumPoints(int[][] points, int r)
            {
                int ans = 1;
                for (int i = 0; i < points.Length; i++)
                {
                    for (int j = i + 1; j < points.Length; j++)
                    {
                        var p1 = new double[] { points[i][0], points[i][1] };
                        var p2 = new double[] { points[j][0], points[j][1] };
                        var dis = Distance(p1, p2);
                        if (dis > r * 2d)
                        {
                            continue;
                        }
                        var center = GetCircleCenter(p1, p2, r);
                        int cnt = 0;
                        for (int k = 0; k < points.Length; k++)
                        {
                            var p = new double[] { points[k][0], points[k][1] };
                            if (Distance(center, p) < (double)r + 0.01)
                            {
                                cnt++;
                            }
                        }
                        ans = Math.Max(ans, cnt);
                    }
                }
                return ans;
            }

            private double Distance(double[] x, double[] y)
            {
                var dx = x[0] - y[0];
                var dy = x[1] - y[1];
                return Math.Sqrt(dx * dx + dy * dy);
            }

            private double[] GetCircleCenter(double[] p1, double[] p2, int r) 
            {
                double[] mid = new double[] { (p1[0] + p2[0]) / 2, (p1[1] + p2[1]) / 2 };
                double angle = Math.Atan2(p1[0] - p2[0], p2[1] - p1[1]); 
                double d = Math.Sqrt(r * r - Math.Pow(Distance(p1, mid), 2)); 
                return new double[] { mid[0] + d * Math.Cos(angle), mid[1] + d * Math.Sin(angle) }; 
            }

        }

    }

}
