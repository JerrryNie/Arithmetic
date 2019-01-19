using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cal_cmd
{
    class Cmd
    {
        Cmd(string[] args)
        {//命令行程序的入口，由原来的Program类改写
            Control control = new Control();
            control.ControlCore(args);
            /*Solve solve = new Solve();
            solve.CalCore("((25+(46)*86))");
            System.Console.WriteLine(solve.GetRes());
            System.Console.WriteLine(solve.Check("3981"));*/
        }
        Cmd()
        {//GUI程序的入口
            Control control = new Control();

        }
    }
    class Control
    {
        private int num = 0;
        public void ControlCore(string[] args)
        {
            if (args.Length == 3 && args[0] == "-g")
            {
                if (CheckNum(args[1]))
                {
                    num = int.Parse(args[1]);
                }
                else
                {
                    System.Console.WriteLine("Please input a positive integer");
                    return;
                }
                FileStream output = new FileStream(args[2], FileMode.Create);
                StreamWriter write = new StreamWriter(output);
                ProblemSet problem_set = new ProblemSet();
                problem_set.Generate(num);
                foreach (Problem cur in problem_set.Get())
                {
                    write.Write(cur.Get());
                    write.Write("\n");
                    write.Flush();
                }
                write.Close();
                output.Close();
            }
            else if (args.Length == 2 && args[0] == "-s")
            {
                int right_cnt = 0;
                if (CheckNum(args[1]))
                {
                    num = int.Parse(args[1]);
                }
                else
                {
                    System.Console.WriteLine("Please input a positive integer");
                    return;
                }
                ProblemSet problem_set = new ProblemSet();
                problem_set.Generate(num);
                Solve solve = new Solve();
                foreach (Problem cur in problem_set.Get())
                {
                    System.Console.WriteLine(cur.Get());
                    string res = System.Console.ReadLine();
                    solve.CalCore(cur.Get());
                    System.Console.WriteLine("my answer " + res);
                    if (solve.Check(res))
                    {
                        System.Console.WriteLine("正确");
                        right_cnt++;
                    }
                    else
                    {
                        System.Console.WriteLine("错误");
                        System.Console.WriteLine(solve.GetRes());

                    }
                }
                System.Console.WriteLine("您的成绩为:" + right_cnt.ToString());
            }
        }
        public bool CheckNum(string num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] > '9' || num[i] < '0')
                {
                    return false;
                }
            }
            return true;
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
        private class BracketPos
        {
            public int left = 0;
            public int right = 0;
        }
        private BracketPos[] bracket_pos = new BracketPos[10];
        static Dictionary<int, char> dic_op = new Dictionary<int, char>();
        Random rd = new Random();
        public ProblemSet()
        {
            problem_set = new List<Problem>();

            dic_op.Add(1, '+');
            dic_op.Add(2, '-');
            dic_op.Add(3, '*');
            dic_op.Add(4, '/');
            dic_op.Add(5, '^');

            for (int i = 0; i < 10; i++)
            {
                bracket_pos[i] = new BracketPos();
            }
        }
        public void Generate(int n)
        {
            for (int i = 0; i < n; i++)
            {
                GenerateSingle();
            }
        }
        public List<Problem> Get() { return problem_set; }
        public void GenerateSingle()
        {
            int cnt_num = rd.Next(2, 10);
            int cnt_bracket = rd.Next(1, 4);
            for (int i = 0; i < cnt_bracket; i++)
            {
                bracket_pos[i].left = rd.Next(0, cnt_num - 1);
                bracket_pos[i].right = rd.Next(bracket_pos[i].left, cnt_num);
            }
            StringBuilder exp = new StringBuilder();
            for (int i = 0; i < cnt_num; i++)
            {
                for (int j = 0; j < cnt_bracket; j++)
                {
                    if (bracket_pos[j].left == i)
                    {
                        exp.Append("(");
                    }
                }
                int cur_num = rd.Next(1, 101);
                int op_num = rd.Next(1, 6);
                exp.Append(cur_num.ToString());
                for (int j = 0; j < cnt_bracket; j++)
                {
                    if (bracket_pos[j].right == i)
                    {
                        exp.Append(")");
                    }
                }
                if (i == cnt_num - 1) break;
                if (op_num == 5)
                {
                    if (rd.Next(0, 2) == 0)
                    {
                        exp.Append("**");
                    }
                    else
                    {
                        exp.Append("^");
                    }
                }
                else
                {
                    exp.Append(dic_op[op_num]);
                }
            }
            Problem new_proble = new Problem(exp.ToString());
            problem_set.Add(new_proble);
        }
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
        private string res;
        private char[] exp;
        private int length;
        static Dictionary<char, int> dic_pri;
        public Solve()
        {
            postfix_exp = new Queue<UniType>();
            dic_pri = new Dictionary<char, int>();
            exp = new char[100];
            length = 0;
            res = "";

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
        public string GetRes()
        {
            return res;
        }
        public void CalCore(string tosolve)
        {
            PreTreat(tosolve);
            InfixToPostfix();
            CalPost();
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
                    else
                    {
                        exp[idx_exp++] = '-';
                    }
                    continue;
                }
                if (init_exp[i] == '*')
                {
                    if (init_exp[i + 1] == '*')
                    {
                        exp[idx_exp++] = '^';
                        i++;
                    }
                    else
                    {
                        exp[idx_exp++] = '*';
                    }
                    continue;
                }
                exp[idx_exp++] = init_exp[i];
            }
            length = idx_exp;
        }
        public void InfixToPostfix()
        {
            int idx = 0;
            Stack<UniType> op_sign = new Stack<UniType>();
            while (idx < length)
            {
                if (exp[idx] > '9' || exp[idx] < '0')
                {
                    UniType cur = new UniType();
                    cur.type = 1;
                    cur.op = exp[idx];

                    while (true)
                    {
                        if (exp[idx] == '^')
                        {
                            if (op_sign.Count == 0 || dic_pri[exp[idx]] >= dic_pri[op_sign.Peek().op])
                            {
                                op_sign.Push(cur);
                                break;
                            }
                        }
                        if (exp[idx] == ')')
                        {
                            while (op_sign.Peek().op != '(')
                            {
                                postfix_exp.Enqueue(op_sign.Peek());
                                op_sign.Pop();
                            }
                            op_sign.Pop();
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
                }
                else if (postfix_exp.Peek().type == 1 && postfix_exp.Peek().op == 'm')
                {
                    st_cal.Peek().numerator *= -1;
                }
                else
                {
                    UniType num2 = st_cal.Peek();
                    st_cal.Pop();
                    UniType num1 = st_cal.Peek();
                    st_cal.Pop();
                    st_cal.Push(Cal(num1, num2, postfix_exp.Peek().op));
                }
                postfix_exp.Dequeue();
            }
            if (st_cal.Peek().denominator == 1)
            {
                res = st_cal.Peek().numerator.ToString();
            }
            else
            {
                res = st_cal.Peek().numerator.ToString() + "/" + st_cal.Peek().denominator.ToString();
            }
            st_cal.Pop();
        }
        public UniType Cal(UniType num1, UniType num2, char op)
        {
            int sum_numerator = 1;
            int sum_denominator = 1;
            switch (op)
            {
                case '+':
                    sum_denominator = num1.denominator * num2.denominator;
                    sum_numerator = num1.numerator * num2.denominator + num2.numerator * num1.denominator;
                    break;
                case '-':
                    sum_denominator = num1.denominator * num2.denominator;
                    sum_numerator = num1.numerator * num2.denominator - num2.numerator * num1.denominator;
                    break;
                case '*':
                    sum_denominator = num1.denominator * num2.denominator;
                    sum_numerator = num1.numerator * num2.numerator;
                    break;
                case '/':
                    sum_denominator = num1.denominator * num2.numerator;
                    sum_numerator = num1.numerator * num2.denominator;
                    break;
                case '^':
                    sum_denominator = MyPow(num1.denominator, num2.numerator);
                    sum_numerator = MyPow(num1.numerator, num2.numerator);
                    break;

            }
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
        public int MyPow(int a, int b)
        {
            int res = 1;
            for (int i = 0; i < b; i++)
            {
                res *= a;
            }
            return res;
        }
        public bool Check(string user_res)
        {
            if (res == user_res)
            {
                return true;
            }
            return false;
        }
    }
}

