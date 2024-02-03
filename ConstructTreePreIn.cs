using System.Collections.Generic;

namespace LeetCode
{
    public class ConstructTreePreIn
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0)
                return null;

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
                map.Add(inorder[i], i);

            return BuildTreeUtil(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1, map);
        }

        public TreeNode BuildTreeUtil(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd, Dictionary<int, int> map)
        {
            if (preStart > preEnd)
                return null;

            TreeNode root = new TreeNode(preorder[preStart]);

            if (preStart == preEnd)
                return root;

            int index = map[preorder[preStart]];

            int inStartUpdatedLeft = inStart;
            int inEndUpdatedLeft = index - 1;
            int inStartUpdatedRight = index + 1;
            int inEndUpdatedRight = inEnd;

            int countLeftInorder = index - inStart + 1;

            int preStartUpdatedLeft = preStart + 1;
            int preEndUpdatedLeft = preStart + countLeftInorder - 1;
            int preStartUpdatedRight = preStart + countLeftInorder;
            int preEndUpdatedRight = preEnd;

            root.left = BuildTreeUtil(preorder, preStartUpdatedLeft, preEndUpdatedLeft, inorder, inStartUpdatedLeft, inEndUpdatedLeft, map);
            root.right = BuildTreeUtil(preorder, preStartUpdatedRight, preEndUpdatedRight, inorder, inStartUpdatedRight, inEndUpdatedRight, map);

            return root;
        }
    }
}
