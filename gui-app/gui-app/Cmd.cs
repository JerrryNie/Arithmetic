using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace cal_cmd
{
    /*class Program
    {
        static void Main(string[] args)
        {
            Control control = new Control();
            control.ControlCore(args);
            //Solve solve = new Solve();
            //solve.CalCore("(1-2)/(1-2)");
            //System.Console.WriteLine(solve.GetValidate());
            //System.Console.WriteLine(solve.GetRes());
            //solve.CalCore("0+1-3");
            //System.Console.WriteLine(solve.GetValidate());
            //System.Console.WriteLine(solve.GetRes());
            //solve.CalCore("100^100");
            //System.Console.WriteLine(solve.GetValidate());
            //System.Console.WriteLine(solve.GetRes());
            //solve.CalCore("(1 * 3) ^ 2");
            //System.Console.WriteLine(solve.GetValidate());
            //System.Console.WriteLine(solve.GetRes());
            //System.Console.WriteLine(solve.GetRes());
            //System.Console.WriteLine(solve.Check("17/52"));
            //ProblemSet set = new ProblemSet();
            //set.Generate(1000);
        }
    }*/
    public class Control
    {
        private int num = 0;
        private int error_flag = 0;
        private int pow_type = 0;
        public int GetError() { return error_flag; }
        public void ControlCore(string[] args)
        {
            if (args.Length == 4 && args[0] == "-g")
            {
                if (!CheckArg(args))
                {
                    return;
                }
                FileStream output;
                StreamWriter write;
                try
                {
                    output = new FileStream(args[2], FileMode.Create);
                    write = new StreamWriter(output);
                    ProblemSet problem_set = new ProblemSet();
                    problem_set.SetPowType(pow_type);
                    problem_set.Generate(num);
                    foreach (Problem cur in problem_set.Get())
                    {
                        write.Write(cur.Get());
                        write.Write("\r\n");
                        write.Flush();
                    }
                    write.Close();
                    output.Close();
                }
                catch (IOException e)
                {
                    System.Console.WriteLine(e.ToString());
                    error_flag = 2;
                }

            }
            else if (args.Length == 3 && args[0] == "-s")
            {
                int right_cnt = 0;
                if (!CheckArg(args))
                {
                    return;
                }
                ProblemSet problem_set = new ProblemSet();
                problem_set.SetPowType(pow_type);
                problem_set.Generate(num);
                Solve solve = new Solve();
                foreach (Problem cur in problem_set.Get())
                {
                    System.Console.WriteLine(cur.Get());
                    string res = System.Console.ReadLine();
                    solve.CalCore(cur.Get());
                    System.Console.WriteLine("my answer :" + res);
                    if (solve.Check(res))
                    {
                        System.Console.WriteLine("正确");
                        right_cnt++;
                    }
                    else
                    {
                        System.Console.WriteLine("错误");
                        System.Console.WriteLine("正确答案是：" + solve.GetRes());

                    }
                }
                System.Console.WriteLine("您的成绩为:");
                System.Console.WriteLine("答对题目：" + right_cnt.ToString() + "道");
                System.Console.WriteLine("答错题目：" + (num - right_cnt).ToString() + "道");
            }
            else
            {
                error_flag = 4;
                System.Console.WriteLine("参数存在未知错误");
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
        public bool CheckArg(string[] args)
        {
            if (CheckNum(args[1]))
            {
                num = int.Parse(args[1]);
            }
            else
            {
                error_flag = 1;
                System.Console.WriteLine("Please input a positive integer");
                return false;
            }
            if (args.Length == 4 && CheckNum(args[3]))
            {
                pow_type = int.Parse(args[3]);
            }
            else if (args.Length == 3 && CheckNum(args[2]))
            {
                pow_type = int.Parse(args[2]);
            }
            else
            {
                error_flag = 3;
                System.Console.WriteLine("Pow type iserror");
                return false;
            }
            if (pow_type > 1)
            {
                error_flag = 3;
                System.Console.WriteLine("Pow type iserror");
                return false;
            }
            return true;
        }
    }
    public class Problem
    {
        private string expression;
        public string Get() { return expression; }
        public void Set(string content) { expression = content; }
        public Problem() { expression = ""; }
        public Problem(string res_exp) { expression = res_exp; }
    }
    public class ProblemSet
    {
        private List<Problem> problem_set;
        private class BracketPos
        {
            public int left = 0;
            public int right = 0;
            public bool l_legal = true;
            public bool r_legal = true;
        }
        private class ExpInf
        {
            public int cnt_num = 0;
            public int[] num_vis = new int[101];
        }
        private BracketPos[] bracket_pos;
        private int[] pow_pos = new int[5];
        static Dictionary<int, char> dic_op;
        private List<ExpInf> inf_set;
        private Random rd;
        private int pow_type;
        public ProblemSet()
        {
            problem_set = new List<Problem>();
            bracket_pos = new BracketPos[10];
            pow_pos = new int[5];
            dic_op = new Dictionary<int, char>();
            inf_set = new List<ExpInf>();
            rd = new Random();
            pow_type = 0;

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
        public void SetPowType(int p_pow_type)
        {
            pow_type = p_pow_type;
        }
        public void Generate(int n)
        {
            int cnt_problem = 0;
            while (cnt_problem < n)
            {
                cnt_problem += GenerateSingle();
            }
        }
        public List<Problem> Get() { return problem_set; }
        public int GenerateSingle()
        {
            int fraction = rd.Next(0, 2);//1表示有分数 0表示没有分数
            int last_num = 0;
            int last_type = 0;
            Solve cur_solve = new Solve();
            ExpInf cur_inf = new ExpInf();
            int cnt_num = rd.Next(2, 5);
            cur_inf.cnt_num = cnt_num;
            int cnt_bracket;
            if (cnt_num > 2)
            {
                cnt_bracket = rd.Next(1, Math.Min(3, cnt_num));
            }
            else
            {
                cnt_bracket = 0;
            }
            for (int i = 0; i < cnt_bracket; i++)
            {
                bracket_pos[i].left = rd.Next(1, cnt_num - 2);
                bracket_pos[i].right = rd.Next(bracket_pos[i].left + 1, cnt_num);
                bracket_pos[i].l_legal = true;
                bracket_pos[i].r_legal = true;
            }
            DealBracket(cnt_bracket);
            StringBuilder exp = new StringBuilder();
            List<int> op = new List<int>();
            for (int j = 0; j < cnt_bracket; j++)
            {
                if (bracket_pos[j].left == 0)
                {
                    exp.Append("(");
                }
            }
            int first_num;
            if (fraction == 0)
            {
                first_num = rd.Next(1, 21);
            }
            else
            {
                first_num = rd.Next(1, 11);
            }
            exp.Append(first_num.ToString());
            cur_inf.num_vis[first_num]++;
            for (int i = 1; i < cnt_num; i++)
            {
                int op_num;
                if (op.Count == 0)
                {
                    op_num = rd.Next(1, 5);
                }
                else
                {
                    if (op[op.Count - 1] > 2)
                    {
                        op_num = rd.Next(1, 3);
                    }
                    else
                    {
                        op_num = rd.Next(1, 6);
                    }
                }
                /*if (op.Length != 0 && op[op.Length - 1] == '^')
                {
                    while (op_num == 5)
                    {
                        op_num = rd.Next(1, 6);
                    }
                }*/
                if (op_num == 5)
                {
                    if (exp[exp.Length - 1] <= '9' && exp[exp.Length - 1] >= '0')
                    {
                        exp = exp.Remove(exp.Length - 1, 1);
                        if (exp[exp.Length - 1] > '9' && exp[exp.Length - 1] < '0')
                        {
                            exp.Append('2');
                        }
                    }
                }
                exp.Append(' ');
                if (op_num == 5)
                {
                    if (pow_type == 0)
                    {
                        exp.Append("**");
                    }
                    else
                    {
                        exp.Append("^");
                    }
                    op.Add(5);
                }
                else
                {
                    exp.Append(dic_op[op_num]);
                    op.Add(op_num);
                }
                exp.Append(' ');
                for (int j = 0; j < cnt_bracket; j++)
                {
                    if (op[op.Count - 1] == '^' && bracket_pos[j].left == i)
                    {
                        bracket_pos[j].l_legal = false;
                        bracket_pos[j].r_legal = false;
                    }
                    if (bracket_pos[j].l_legal && bracket_pos[j].left == i)
                    {
                        exp.Append("(");
                    }
                }
                int cur_num = 0;
                switch (op_num)
                {
                    case 5: cur_num = rd.Next(2, 4); break;
                    case 4: cur_num = rd.Next(1, 11); break;
                    case 3: cur_num = rd.Next(1, 11); break;
                    default: cur_num = fraction == 1 ? rd.Next(1, 11) : rd.Next(1, 101); break;
                }
                if (op_num == 4 || op_num == 5)
                {
                    cur_inf.num_vis[cur_num]++;
                    exp.Append(cur_num.ToString());
                }
                else
                {
                    int type = rd.Next(1, 7);
                    if (type < 3 && fraction == 1)
                    {
                        int de = rd.Next(2, 11);
                        int ne = rd.Next(1, de);
                        exp.Append(ne.ToString());
                        exp.Append('/');
                        exp.Append(de.ToString());
                    }
                    else
                    {
                        cur_inf.num_vis[cur_num]++;
                        exp.Append(cur_num.ToString());
                    }
                }
                for (int j = 0; j < cnt_bracket; j++)
                {
                    if (bracket_pos[j].r_legal && bracket_pos[j].right == i)
                    {
                        exp.Append(")");
                    }
                }
            }
            System.Console.WriteLine(exp.ToString());
            cur_solve.CalCore(exp.ToString());
            System.Console.WriteLine(cur_solve.GetRes());
            if (CheckDup(cur_inf) || !cur_solve.GetValidate())
            {
                return 0;
            }
            else
            {
                Problem new_proble = new Problem(exp.ToString());
                problem_set.Add(new_proble);
                inf_set.Add(cur_inf);
                return 1;
            }
        }
        private bool CheckDup(ExpInf cur_inf)
        {
            foreach (ExpInf inf in inf_set)
            {
                bool flag = true;
                if (inf.cnt_num != cur_inf.cnt_num)
                {
                    continue;
                }
                for (int i = 1; i < 101; i++)
                {
                    if (cur_inf.num_vis[i] != inf.num_vis[i])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    return true;
                }
            }
            return false;
        }
        public void DealBracket(int cnt_bracket)
        {
            for (int i = 0; i < cnt_bracket; i++)
            {
                for (int j = i + 1; j < cnt_bracket; j++)
                {
                    if (bracket_pos[i].left == bracket_pos[j].left &&
                        bracket_pos[i].right == bracket_pos[j].right)
                    {
                        bracket_pos[j].l_legal = false;
                        bracket_pos[j].r_legal = false;
                    }
                }
            }
            for (int i = 0; i < cnt_bracket; i++)
            {
                for (int j = 0; j < cnt_bracket; j++)
                {
                    if (bracket_pos[i].left == bracket_pos[j].right)
                    {
                        bracket_pos[i].l_legal = false;
                        bracket_pos[i].r_legal = false;
                        bracket_pos[j].l_legal = false;
                        bracket_pos[j].r_legal = false;
                    }
                }
            }
        }
    }
    public class Solve
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
        private bool validate;
        static Dictionary<char, int> dic_pri;
        public Solve()
        {
            postfix_exp = new Queue<UniType>();
            dic_pri = new Dictionary<char, int>();
            exp = new char[100];
            length = 0;
            res = "";
            validate = true;

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
        public bool GetValidate() { return validate; }
        public void CalCore(string tosolve)
        {
            validate = true;
            PreTreat(tosolve);
            InfixToPostfix();
            CalPost();
            Reset();
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
            try
            {
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
                        if (postfix_exp.Peek().op == '^' && Math.Abs(num1.numerator) > 6)
                        {
                            validate = false;
                        }
                        st_cal.Push(Cal(num1, num2, postfix_exp.Peek().op));
                    }
                    postfix_exp.Dequeue();
                }
                if (st_cal.Peek().denominator == 0)
                {
                    validate = false;
                }
                if (Math.Abs(st_cal.Peek().denominator) == 1)
                {
                    res = (st_cal.Peek().numerator * st_cal.Peek().denominator).ToString();
                }
                else
                {
                    if (st_cal.Peek().denominator < 0)
                    {
                        st_cal.Peek().numerator *= -1;
                        st_cal.Peek().denominator *= -1;
                    }
                    res = st_cal.Peek().numerator.ToString() + "/" + st_cal.Peek().denominator.ToString();
                }
                st_cal.Pop();
            }
            catch
            {
                validate = false;
            }
        }
        public UniType Cal(UniType num1, UniType num2, char op)
        {
            int sum_numerator = 1;
            int sum_denominator = 1;
            switch (op)
            {
                case '+':
                    sum_denominator = checked(num1.denominator * num2.denominator);
                    sum_numerator = checked(num1.numerator * num2.denominator + num2.numerator * num1.denominator);
                    break;
                case '-':
                    sum_denominator = checked(num1.denominator * num2.denominator);
                    sum_numerator = checked(num1.numerator * num2.denominator - num2.numerator * num1.denominator);
                    break;
                case '*':
                    sum_denominator = checked(num1.denominator * num2.denominator);
                    sum_numerator = checked(num1.numerator * num2.numerator);
                    break;
                case '/':
                    sum_denominator = checked(num1.denominator * num2.numerator);
                    sum_numerator = checked(num1.numerator * num2.denominator);
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
                res = checked(res * a);
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
        public void Reset()
        {
            for (int i = 0; i < exp.Length; i++)
            {
                exp[i] = '\0';
            }
            while (postfix_exp.Count != 0)
            {
                postfix_exp.Dequeue();
            }
        }
    }
}