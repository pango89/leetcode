using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class DecodeString
    {
        public string Decode(string s)
        {
            Stack<string> stack = new();

            string currStr = "", currNum = "";
            foreach (char c in s)
            {
                if (c == '[')
                {
                    stack.Push(currStr);
                    stack.Push(currNum);
                    currStr = "";
                    currNum = "";
                }
                else if (c == ']')
                {
                    currNum = stack.Peek(); stack.Pop();
                    string prev = stack.Peek(); stack.Pop();

                    currStr = prev + nTimesString(currStr, Stoi(currNum));
                    currNum = "";
                }
                else if (Char.IsDigit(c))
                    currNum += c;
                else
                    currStr += c;
            }

            return currStr;
        }

        private string nTimesString(string s, int n)
        {
            string ans = "";
            for (int i = 0; i < n; i++) ans += s;
            return ans;
        }

        private int Stoi(string s)
        {
            int n = 0;

            foreach (char c in s)
                n = n * 10 + (c - '0');

            return n;
        }
    }
}
