using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class InfixEval
    {
        public int Calculate(string s)
        {
            int n = s.Length;
            int l = 0;

            Stack<int> operands = new();
            Stack<char> operators = new();

            while (l < n)
            {
                if (Char.IsDigit(s[l]))
                {
                    int num = 0;
                    while (l < n && Char.IsDigit(s[l]))
                    {
                        num = num * 10 + (s[l] - '0');
                        l += 1;
                    }

                    operands.Push(num);
                }

                if (l == n) break;

                char c = s[l];
                if (IsOperator(c))
                {
                    while (operators.Count > 0 && (Precedence(c) <= Precedence(operators.Peek())))
                    {
                        int o1 = operands.Pop();
                        int o2 = operands.Pop();
                        char op = operators.Pop();

                        if (op == '+') operands.Push(o2 + o1);
                        else if (op == '-') operands.Push(o2 - o1);
                        else if (op == '*') operands.Push(o2 * o1);
                        else if (op == '/') operands.Push(o2 / o1);
                    }

                    operators.Push(c);
                }

                l += 1;
            }

            while (operators.Count > 0)
            {
                int o1 = operands.Pop();
                int o2 = operands.Pop();
                char op = operators.Pop();

                if (op == '+') operands.Push(o2 + o1);
                else if (op == '-') operands.Push(o2 - o1);
                else if (op == '*') operands.Push(o2 * o1);
                else if (op == '/') operands.Push(o2 / o1);
            }

            int ans = operands.Pop();
            return ans;
        }

        private int Precedence(char c)
        {
            if (c == '+') return 1;
            if (c == '-') return 2;
            if (c == '*') return 3;
            if (c == '/') return 3;
            return 0;
        }

        private bool IsOperator(char c)
        {
            if (c == '*' || c == '/' || c == '+' || c == '-')
                return true;

            return false;
        }
    }
}