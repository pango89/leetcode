namespace LeetCode
{
    public class WordDictionaryTrie
    {
        public WordDictionaryTrie[] Nodes { get; set; }

        public bool IsEndOfWord { get; set; }

        private const int ALPHABET_SIZE = 26;

        public WordDictionaryTrie()
        {
            this.Nodes = new WordDictionaryTrie[ALPHABET_SIZE];
            this.IsEndOfWord = false;
        }

        public void AddWord(string word)
        {
            if (word.Length == 0)
                return;

            WordDictionaryTrie begin = this;

            foreach (char c in word)
            {
                if (begin.Nodes[c - 'a'] == null)
                    begin.Nodes[c - 'a'] = new WordDictionaryTrie();

                begin = begin.Nodes[c - 'a'];
            }

            begin.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            if (word.Length == 0)
                return false;

            WordDictionaryTrie begin = this;

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];

                if (c == '.')
                {
                    foreach (WordDictionaryTrie node in begin.Nodes)
                    {
                        if (node != null && node.Search(word.Substring(i + 1)))
                            return true;
                    }

                    return false;
                }

                if (begin.Nodes[c - 'a'] == null)
                    return false;

                begin = begin.Nodes[c - 'a'];
            }

            return begin.IsEndOfWord;
        }

    }
}