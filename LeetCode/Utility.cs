using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace LeetCode
{
    public class Utility
    {
        public static TreeNode ConvertToTreeNode(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            str = str.Trim();
            str = str.TrimStart('[');
            str = str.TrimEnd(']');
            var nodes = str.Split(',');
            if (nodes.Length == 0)
            {
                return null;
            }
            TreeNode root = CreateTreeNode(nodes[0]);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;
            while (i < nodes.Length)
            {
                int count = queue.Count;
                for (int j = 0; j < count; j++)
                {
                    var parent = queue.Dequeue();
                    if (i < nodes.Length)
                    {
                        parent.left = CreateTreeNode(nodes[i]);
                        if (parent.left != null)
                        {
                            queue.Enqueue(parent.left);
                        }
                        i++;
                    }
                    if (i < nodes.Length)
                    {
                        parent.right = CreateTreeNode(nodes[i]);
                        if (parent.right != null)
                        {
                            queue.Enqueue(parent.right);
                        }
                        i++;
                    }
                }

            }

            return root;
        }

        private static TreeNode CreateTreeNode(string value)
        {
            value = value.Trim();
            if (int.TryParse(value, out var val))
            {
                return new TreeNode(val);
            }
            return null;
        }

        public static Node ConvertToNode(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            str = str.Trim();
            str = str.TrimStart('[');
            str = str.TrimEnd(']');
            var nodes = str.Split(',');
            if (nodes.Length == 0)
            {
                return null;
            }
            Node root = CreateNode(nodes[0]);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int i = 1;
            while (i < nodes.Length)
            {
                int count = queue.Count;
                for (int j = 0; j < count; j++)
                {
                    var parent = queue.Dequeue();
                    if (i < nodes.Length)
                    {
                        parent.left = CreateNode(nodes[i]);
                        if (parent.left != null)
                        {
                            queue.Enqueue(parent.left);
                        }
                        i++;
                    }
                    if (i < nodes.Length)
                    {
                        parent.right = CreateNode(nodes[i]);
                        if (parent.right != null)
                        {
                            queue.Enqueue(parent.right);
                        }
                        i++;
                    }
                }

            }

            return root;
        }

        private static Node CreateNode(string value)
        {
            value = value.Trim();
            if (int.TryParse(value, out var val))
            {
                return new Node() { val = val };
            }
            return null;
        }

        public static ListNode ConvertToListNode(string str)
        {
            var nums = JsonSerializer.Deserialize<int[]>(str);
            ListNode dummy = new ListNode(0);
            var temp = dummy;
            foreach (var num in nums)
            {
                temp.next = new ListNode(num);
                temp = temp.next;
            }
            return dummy.next;
        }

        public static void InvokeHelper<T>(string[] str)
        {
            var type = typeof(T);
            var ctors = type.GetConstructors();
            var methods = type.GetMethods().ToDictionary(m => m.Name, StringComparer.OrdinalIgnoreCase);
            var invokes = JsonSerializer.Deserialize<string[]>(str[0]);
            var args = JsonSerializer.Deserialize<object[]>(str[1]);
            T instance = (T)ctors.First().Invoke(null);
            var jType = typeof(JsonElement);
            var jMethods = new Dictionary<string, MethodInfo>(StringComparer.OrdinalIgnoreCase);
            foreach (var m in jType.GetMethods())
            {
                if (m.GetParameters().Length == 0)
                {
                    jMethods[m.Name] = m;
                }
            }
            for (int i = 1; i < invokes.Length; i++)
            {
                var m = methods[invokes[i]];
                var ps = m.GetParameters();
                var arg = (JsonElement)args[i];
                if (ps.Length == 0)
                {
                    m.Invoke(instance, null);
                }
                else
                {
                    object[] parameters = new object[ps.Length];
                    int index = 0;
                    foreach (var a in arg.EnumerateArray())
                    {
                        var name = ps[index].ParameterType.Name;
                        parameters[index++] = jMethods[$"Get{name}"].Invoke(a, null);
                    }
                    m.Invoke(instance, parameters);
                }
            }
        }

    }
}
