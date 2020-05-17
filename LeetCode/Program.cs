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

    }

}
