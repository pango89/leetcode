using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class LargestBSTinBT
    {
        public int LargestBSTSubtree(TreeNode root)
        {
            if (root == null)
                return 0;
            return PostOrder(root).Size;
        }

        public Information PostOrder(TreeNode root)
        {
            Console.WriteLine(root.val);
            if (root.left == null && root.right == null)
                return new Information(true, 1, root.val, root.val);

            Information fromLeft = null;
            Information fromRight = null;
            if (root.left != null)
                fromLeft = PostOrder(root.left);

            if (root.right != null)
                fromRight = PostOrder(root.right);           

            if (fromLeft != null && fromRight != null)
            {
                bool isBST = fromLeft.IsBST && fromRight.IsBST && fromLeft.Max <= root.val && root.val < fromRight.Min;
                int size = isBST ? fromLeft.Size + 1 + fromRight.Size : Math.Max(fromLeft.Size, fromRight.Size);
                int min = isBST ? fromLeft.Min : 0;
                int max = isBST ? fromRight.Max : 0;
                return new Information(isBST, size, min, max);
            }
            if (fromLeft != null)
            {
                bool isBST = fromLeft.IsBST && fromLeft.Max <= root.val;
                int size = isBST ? fromLeft.Size + 1 : fromLeft.Size;
                int min = isBST ? fromLeft.Min : 0;
                int max = isBST ? root.val : 0;
                return new Information(isBST, size, min, max);
            }
            if (fromRight != null)
            {
                bool isBST = fromRight.IsBST && root.val < fromRight.Min;
                int size = isBST ? 1 + fromRight.Size : fromRight.Size;
                int min = isBST ? root.val : 0;
                int max = isBST ? fromRight.Max : 0;
                return new Information(isBST, size, min, max);
            }

            return new Information(false, 0, 0, 0);
        }

        public class Information
        {
            public bool IsBST;
            public int Size;
            public int Min;
            public int Max;

            public Information(bool isBST, int size, int min, int max)
            {
                IsBST = isBST;
                Size = size;
                Min = min;
                Max = max;
            }
        }
    }


}
