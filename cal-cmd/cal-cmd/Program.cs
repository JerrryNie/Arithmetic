using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cal_cmd
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Problem
    {
        private string expression;
        public string Get() { return expression; }
        public void Set(string content) { expression = content; }
        public Problem() { expression = ""; }
        public Problem(string res_exp) { expression = res_exp; }
    }
    class ProblemSet
    {
        private List<Problem> problem_set;
        public ProblemSet() { problem_set = new List<Problem>(); }
        public void Generate(int n) { }
        public List<Problem> Get() { return problem_set; }
    }
    class Solve
    {
        public class UniType
        {
            public int type = 0;
            public char op = '+';
            public int numerator = 0;
            public int denominator = 1;
        }
        private Queue<UniType> postfix_exp;
        private UniType res;
        private char[] exp;
        static Dictionary<char, int> dic_pri;
        public Solve()
        {
            postfix_exp = new Queue<UniType>();
            dic_pri = new Dictionary<char, int>();
            exp = new char[100];

            dic_pri.Add('(', 0);
            dic_pri.Add('+', 1);
            dic_pri.Add('-', 1);
            dic_pri.Add('*', 2);
            dic_pri.Add('/', 2);
            dic_pri.Add('^', 3);
            dic_pri.Add('p', 3);
            dic_pri.Add('m', 4);
            dic_pri.Add(')', 5);
        }
        public void Cal(string tosolve)
        {
            PreTreat(tosolve);
        }
        public void PreTreat(string init_exp)
        {
            int idx_exp = 0;
            for (int i = 0; i < init_exp.Length; i++)
            {
                if (init_exp[i] == ' ')
                {
                    continue;
                }
                if (init_exp[i] == '-')
                {
                    if (i == 0 || exp[i - 1] == '(')
                    {
                        exp[idx_exp++] = 'm';
                    }
                }
                else
                {
                    exp[idx_exp++] = '-';
                }
                if (init_exp[i] == '*')
                {
                    if (init_exp[i + 1] == '*')
                    {
                        exp[idx_exp++] = '^';
                    }
                    else
                    {
                        exp[idx_exp++] = '*';
                    }
                }
            }
        }
        public void InfixToPostfix()
        {
            int idx = 0;
            Stack<UniType> op_sign = new Stack<UniType>();
            while (idx < exp.Length)
            {
                if (exp[idx] > '9' || exp[idx] < '0')
                {
                    UniType cur = new UniType();
                    cur.type = 1;
                    cur.op = exp[idx];

                    while (true)
                    {
                        if (op_sign.Count != 0 || exp[idx] == '^' && exp[idx + 1] == '^')
                        {
                            op_sign.Push(cur);
                            break;
                        }
                        if (exp[idx] == ')')
                        {
                            while (op_sign.Peek().op != '(')
                            {
                                postfix_exp.Enqueue(op_sign.Peek());
                                op_sign.Pop();
                            }
                            break;
                        }
                        if (op_sign.Count == 0 ||
                           dic_pri[exp[idx]] > dic_pri[op_sign.Peek().op] ||
                           op_sign.Peek().op == '(' ||
                           exp[idx] == '(')
                        {
                            op_sign.Push(cur);
                            break;
                        }
                        else
                        {
                            postfix_exp.Enqueue(op_sign.Peek());
                            op_sign.Pop();
                            continue;
                        }
                    }
                    idx++;
                }
                else
                {
                    int sum = exp[idx++] - '0';
                    while (exp[idx] <= '9' && exp[idx] >= '0')
                    {
                        sum = sum * 10 + exp[idx++] - '0';
                    }
                    UniType cur = new UniType();
                    cur.type = 0;
                    cur.denominator = 1;
                    cur.numerator = sum;
                    postfix_exp.Enqueue(cur);
                }
            }
            while (op_sign.Count != 0)
            {
                postfix_exp.Enqueue(op_sign.Peek());
                op_sign.Pop();
            }
        }
        public int gcd(int x, int y)
        {
            if (y == 0) return x;
            if (x < y) return gcd(y, x);
            else return gcd(y, x % y);
        }
        public void CalPost()
        {
            Stack<UniType> st_cal = new Stack<UniType>();
            while (postfix_exp.Count != 0)
            {
                if (postfix_exp.Peek().type == 0)
                {
                    st_cal.Push(postfix_exp.Peek());
                    postfix_exp.Dequeue();
                }
                else if (postfix_exp.Peek().type == 1 && postfix_exp.Peek().op == 'm')
                {
                    UniType num1 = st_cal.Peek();
                    st_cal.Pop();
                    st_cal.Push(Minus(num1));
                }
                else
                {
                    UniType num2 = st_cal.Peek();
                    st_cal.Pop();
                    UniType num1 = st_cal.Peek();
                    st_cal.Pop();
                    switch (postfix_exp.Peek().op)
                    {
                        case '+': st_cal.Push(Add(num1, num2)); break;
                        case '-': st_cal.Push(Sub(num1, num2)); break;
                        case '*': st_cal.Push(Mul(num1, num2)); break;
                        case '/': st_cal.Push(Div(num1, num2)); break;
                        case '^': st_cal.Push(Pow(num1, num2)); break;
                    }
                }
            }
        }
        public UniType Add(UniType num1, UniType num2)
        {
            int sum_numerator;
            int sum_denominator;
            sum_denominator = num1.denominator * num2.denominator;
            sum_numerator = num1.numerator * num2.denominator + num2.numerator * num1.denominator;
            int max_gcd = gcd(Math.Max(Math.Abs(sum_denominator), Math.Abs(sum_numerator)),
                              Math.Min(Math.Abs(sum_denominator), Math.Abs(sum_numerator)));
            if (max_gcd != 1)
            {
                sum_numerator /= max_gcd;
                sum_denominator /= max_gcd;
            }
            UniType cur = new UniType();
            cur.type = 0;
            cur.numerator = sum_numerator;
            cur.denominator = sum_denominator;
            return cur;
        }
        public UniType Sub(UniType num1, UniType num2)
        {
            int sum_numerator;
            int sum_denominator;
            sum_denominator = num1.denominator * num2.denominator;
            sum_numerator = num1.numerator * num2.denominator - num2.numerator * num1.denominator;
            int max_gcd = gcd(Math.Max(Math.Abs(sum_denominator), Math.Abs(sum_numerator)),
                              Math.Min(Math.Abs(sum_denominator), Math.Abs(sum_numerator)));
            if (max_gcd != 1)
            {
                sum_numerator /= max_gcd;
                sum_denominator /= max_gcd;
            }
            UniType cur = new UniType();
            cur.type = 0;
            cur.numerator = sum_numerator;
            cur.denominator = sum_denominator;
            return cur;
        }
        public UniType Mul(UniType num1, UniType num2)
        {
            int sum_numerator;
            int sum_denominator;
            sum_numerator = num1.numerator * num2.numerator;
            sum_denominator = num1.denominator * num2.denominator;
            int max_gcd = gcd(Math.Max(Math.Abs(sum_denominator), Math.Abs(sum_numerator)),
                              Math.Min(Math.Abs(sum_denominator), Math.Abs(sum_numerator)));
            if (max_gcd != 1)
            {
                sum_numerator /= max_gcd;
                sum_denominator /= max_gcd;
            }
            UniType cur = new UniType();
            cur.type = 0;
            cur.numerator = sum_numerator;
            cur.denominator = sum_denominator;
            return cur;

        }
    }
}
