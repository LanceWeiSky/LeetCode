using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._20
{
    class A630 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int ScheduleCourse(int[][] courses)
            {
                if (courses.Length == 0)
                {
                    return 0;
                }
                Array.Sort(courses, (x, y) => x[1].CompareTo(y[1]));
                SortedSet<CourseInfo> set = new SortedSet<CourseInfo>(new CourseComparer());
                int time = 0;
                for (int i = 0; i < courses.Length; i++)
                {
                    if (time + courses[i][0] <= courses[i][1])
                    {
                        set.Add(new CourseInfo { Index = i, T = courses[i][0] });
                        time += courses[i][0];
                    }
                    else if (set.Count > 0)
                    {
                        var max = set.Max;
                        if (max.T > courses[i][0])
                        {
                            set.Remove(max);
                            set.Add(new CourseInfo { Index = i, T = courses[i][0] });
                            time += courses[i][0] - max.T;
                        }
                    }
                }
                return set.Count;
            }

            private class CourseInfo
            { 
                public int T { get; set; }
                public int Index { get; set; }
            }

            private class CourseComparer : IComparer<CourseInfo>
            {
                public int Compare(CourseInfo x, CourseInfo y)
                {
                    var c = x.T.CompareTo(y.T);
                    if(c == 0)
                    {
                        c = x.Index.CompareTo(y.Index);
                    }
                    return c;
                }
            }
        }
    }
}
