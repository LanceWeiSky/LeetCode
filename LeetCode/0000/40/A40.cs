using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A40 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。

        //candidates 中的每个数字在每个组合中只能使用一次。

        //说明：


        //	所有数字（包括目标数）都是正整数。
        //	解集不能包含重复的组合。 

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/combination-sum-ii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<IList<int>> ans = new List<IList<int>>();
            CombinationSum(candidates, target, 0, new List<int>(), ans);
            return ans;
        }

        private void CombinationSum(int[] candidates, int target, int index, List<int> path, List<IList<int>> ans)
        {
            if (target == 0)
            {
                ans.Add(new List<int>(path));
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                if (i > index && candidates[i - 1] == candidates[i])
                {
                    continue;
                }
                var t = target - candidates[i];
                if (t < 0)
                {
                    break;
                }
                else
                {
                    path.Add(candidates[i]);
                    CombinationSum(candidates, t, i + 1, path, ans);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}
