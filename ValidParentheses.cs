using System;
using System.Collections.Generic;
namespace LeetCode
{
    public class ValidParentheses
    {
        public bool IsValid(string s)
        {
            if (s.Length == 1) return false;
            char[] sa = s.ToCharArray();

            Stack<char> stk = new Stack<char>();

            for (int i = 0; i < sa.Length; i++)
            {
                char c = sa[i];
                if (this.IsOpeningBracket(c))
                {
                    stk.Push(c);
                    continue;
                }

                char openC = this.GetOpeningBracket(c);
                if (stk.Count > 0 && stk.Peek() == openC)
                {
                    stk.Pop();
                    continue;
                }

                return false;
            }

            return stk.Count == 0;
        }

        private bool IsOpeningBracket(char c)
        {
            return c == '(' || c == '{' || c == '[';
        }

        private char GetOpeningBracket(char c)
        {
            if (c == ')')
                return '(';
            else if (c == '}')
                return '{';
            else
                return '[';
        }
    }
}
