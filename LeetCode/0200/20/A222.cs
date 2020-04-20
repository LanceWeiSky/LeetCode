using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A222 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int CountNodes(TreeNode root)
        {
            var h = GetHeight(root);
            if (h < 2)
            {
                return h;
            }

            int left = 0;
            int right = (int)Math.Pow(2, h - 1) - 1;
            int right2 = right;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (Exist(mid, h, right2, root))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return right2 + left;
        }

        private bool Exist(int id, int h, int right, TreeNode node)
        {
            int left = 0;
            for (int i = 1; i < h; i++)
            {
                int mid = (left + right) / 2;
                if (id > mid)
                {
                    node = node.right;
                    left = mid + 1;
                }
                else
                {
                    node = node.left;
                    right = mid;
                }
            }
            return node != null;
        }

        private int GetHeight(TreeNode node)
        {
            int h = 0;
            while (node != null)
            {
                h++;
                node = node.left;
            }
            return h;
        }
    }
}
