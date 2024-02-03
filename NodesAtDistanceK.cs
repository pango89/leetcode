using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class NodesAtDistanceK
    {
        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            IList<int> answer = new List<int>();
            if (root == null || K < 0)
                return answer;

            Dictionary<TreeNode, List<TreeNode>> map = new Dictionary<TreeNode, List<TreeNode>>();
            this.FillMap(root, null, map);

            if (!map.ContainsKey(target))
                return answer;

            HashSet<TreeNode> visited = new HashSet<TreeNode>();

            return BFS(visited, map, target, K);
        }

        public IList<int> BFS(HashSet<TreeNode> visited, Dictionary<TreeNode, List<TreeNode>> map, TreeNode target, int K)
        {
            IList<int> nodes = new List<int>();
            visited.Add(target);

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(target);

            while (q.Count > 0)
            {
                int count = q.Count;
                if (K == 0)
                {
                    for (int i = 0; i < count; i++)
                        nodes.Add(q.Dequeue().val);

                    return nodes;
                }

                for(int i = 0; i < count; i++)
                {
                    TreeNode dq = q.Dequeue();

                    foreach (TreeNode neighbor in map[dq])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            q.Enqueue(neighbor);
                            visited.Add(neighbor);
                        }
                    }
                }

                K--;
            }

            return nodes;
        }

        public void FillMap(TreeNode child, TreeNode parent, Dictionary<TreeNode, List<TreeNode>> map)
        {
            if (child == null)
                return;

            if (!map.ContainsKey(child))
                map.Add(child, new List<TreeNode>());

            if (parent != null)
            {
                map[child].Add(parent);
                map[parent].Add(child);
            }

            FillMap(child.left, child, map);
            FillMap(child.right, child, map);
        }
    }
}
