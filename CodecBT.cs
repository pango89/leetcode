using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Codec
    {
        public Codec()
        {
        }

        public string Serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            this.SerializeHelper(root, sb);
            return sb.ToString();
        }

        private void SerializeHelper(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append('#').Append(',');
                return;
            }

            sb.Append(root.val).Append(',');
            SerializeHelper(root.left, sb);
            SerializeHelper(root.right, sb);
        }

        public TreeNode Deserialize(string data)
        {
            string[] nodes = data.Split(',');
            TreeNode root = this.DeserializeHelper(new Queue<string>(nodes));
            return root;
        }

        private TreeNode DeserializeHelper(Queue<string> nodes)
        {
            if (nodes.Count == 0)
                return null;

            string front = nodes.Dequeue();

            if (front.Equals("#"))
                return null;

            TreeNode n = new TreeNode(int.Parse(front));
            n.left = DeserializeHelper(nodes);
            n.right = DeserializeHelper(nodes);
            return n;
        }

    }
}
