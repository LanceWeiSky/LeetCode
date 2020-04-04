using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string questionId = "A95";
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var type = types.FirstOrDefault(t => t.Name.Equals($"{questionId}", StringComparison.OrdinalIgnoreCase));
            IQuestion question = Activator.CreateInstance(type) as IQuestion;
            question.Run();
        }

    }



}
