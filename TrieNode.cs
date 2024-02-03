using System;
namespace LeetCode
{
    public class TrieNode
    {
        public bool isEndOfWord;
        public TrieNode[] nodes;

        public TrieNode(int alphabetSize)
        {
            this.nodes = new TrieNode[alphabetSize];
            for (int i = 0; i < this.nodes.Length; i++)
                this.nodes[i] = null;

            isEndOfWord = false;
        }
    }
}
