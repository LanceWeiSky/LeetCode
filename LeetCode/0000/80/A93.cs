using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A93 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个只包含数字的字符串，复原它并返回所有可能的 IP 地址格式。

        //示例:

        //输入: "25525511135"
        //输出: ["255.255.11.135", "255.255.111.35"]

        //        来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/restore-ip-addresses
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> ans = new List<string>();
            RestoreIpAddresses(ans, s, 0, new List<string>());
            return ans;
        }

        private void RestoreIpAddresses(List<string> ans, string s, int index, List<string> path)
        {
            if (path.Count == 4 && index == s.Length)
            {
                ans.Add(string.Join('.', path));
                return;
            }
            if (s.Length - index > (4 - path.Count) * 3)
            {
                return;
            }
            var l = Math.Min(3, s.Length - index);
            for (int i = 1; i <= l; i++)
            {
                if (i > 1 && s[index] == '0')
                {
                    return;
                }
                string num = s.Substring(index, i);
                if (int.TryParse(num, out var n) && n <= 255)
                {
                    path.Add(num);
                    RestoreIpAddresses(ans, s, index + i, path);
                    path.RemoveAt(path.Count - 1);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
