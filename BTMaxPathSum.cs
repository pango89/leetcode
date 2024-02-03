using System;

namespace LeetCode
{
    public class BTMaxPathSum
    {
        private int maxSum;

        public int MaxPathSum(TreeNode root)
        {
            maxSum = int.MinValue;
            MaxPathSumUtil(root);
            return maxSum;
        }

        private int MaxPathSumUtil(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftMax = MaxPathSumUtil(root.left);
            int rightMax = MaxPathSumUtil(root.right);

            int maxLeftRight = Math.Max(leftMax, rightMax);
            int maxLeftRightOneRoot = Math.Max(root.val, root.val + maxLeftRight);
            int maxAll = Math.Max(maxLeftRightOneRoot, root.val + leftMax + rightMax);

            maxSum = Math.Max(maxSum, maxAll);

            return maxLeftRightOneRoot;

        }
    }
}
