using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{
    public class Trie
    {
        public static int ALPHABET_SIZE = 26;
        public TrieNode root;

        public Trie()
        {
            this.root = new TrieNode(ALPHABET_SIZE);
        }

        public void Insert(string word)
        {
            if (word.Length == 0)
                return;

            TrieNode ws = this.root;

            for (int i = 0; i < word.Length; i++)
            {
                int index = word[i] - 'a';
                if (ws.nodes[index] == null)
                    ws.nodes[index] = new TrieNode(ALPHABET_SIZE);

                ws = ws.nodes[index];
            }

            ws.isEndOfWord = true;
        }

        public bool Search(string word)
        {
            if (word.Length == 0)
                return true;

            TrieNode ws = this.root;

            for (int i = 0; i < word.Length; i++)
            {
                int index = word[i] - 'a';

                if (ws.nodes[index] == null)
                    return false;

                ws = ws.nodes[index];
            }

            return ws.isEndOfWord;
        }

        // https://leetcode.com/problems/design-add-and-search-words-data-structure/
        public bool SearchSpecial(string word)
        {
            return this.SearchSpecialUtil(word.ToCharArray(), 0, this.root);
        }

        private bool SearchSpecialUtil(char[] word, int i, TrieNode node)
        {
            if (word.Length == i)
                return node.isEndOfWord;

            if (word[i] == '.')
            {
                for (int x = 0; x < ALPHABET_SIZE; x++)
                {
                    if (node.nodes[x] != null && SearchSpecialUtil(word, i + 1, node.nodes[x]))
                        return true;
                }
            }
            else
            {
                int currIndex = word[i] - 'a';
                TrieNode currNode = node.nodes[currIndex];
                if (currNode != null && SearchSpecialUtil(word, i + 1, currNode))
                    return true;
            }

            return false;
        }

        public bool StartsWith(string prefix)
        {
            if (prefix.Length == 0)
                return true;

            TrieNode ws = this.root;

            for (int i = 0; i < prefix.Length; i++)
            {
                int index = prefix[i] - 'a';

                if (ws.nodes[index] == null)
                    return false;

                ws = ws.nodes[index];
            }

            return true;
        }

        public TrieNode Delete(string word)
        {
            return this.DeleteUtil(this.root, word, 0);
        }

        private TrieNode DeleteUtil(TrieNode root, string word, int depth)
        {
            if (root == null)
                return null;

            if (depth == word.Length)
            {
                if (root.isEndOfWord)
                    root.isEndOfWord = false;

                if (root.nodes.All(x => x == null))
                    root = null;

                return root;
            }

            char c = word[depth];
            root.nodes[c - 'a'] = this.DeleteUtil(root.nodes[c - 'a'], word, depth + 1);

            if (root.nodes.All(x => x == null) && root.isEndOfWord == false)
                root = null;

            return root;
        }
    }
}
